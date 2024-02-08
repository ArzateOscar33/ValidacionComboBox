using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PruebaCombobox
{
    public class ValidacionCOM
    {
        // Lista para almacenar los puertos COM validados
        private List<string> PuertosComValidados;

        // Objeto de bloqueo para evitar condiciones de carrera al modificar la lista desde múltiples hilos
        private object lockObject = new object();

        // Evento que se dispara cuando se reciben datos
        public event EventHandler<DataReceivedEventArgs> DataReceived;

        // Constructor de la clase
        public ValidacionCOM()
        {
            // Inicializa la lista de puertos COM validados
            PuertosComValidados = new List<string>();
        }

        // Método para validar los puertos COM de manera paralela
        public void ValidarPuertosComParalelo()
        {
            // Obtiene los nombres de los puertos COM disponibles
            string[] nombresPuertos = SerialPort.GetPortNames();

            // Utiliza Parallel.ForEach para recorrer los nombres de los puertos COM de manera paralela
            Parallel.ForEach(nombresPuertos, puerto =>
            {
                // Llama al método para validar un puerto COM específico
                ValidarPuertoCom(puerto);
            });
        }

        // Método privado para validar un puerto COM específico
        private async void ValidarPuertoCom(string portName)
        {
            // Crea una instancia de SerialPort para el puerto COM actual
            SerialPort serialPort = new SerialPort(portName);

            // Configura las propiedades del puerto serie
            serialPort.BaudRate = 115200;
            serialPort.DataBits = 8;
            serialPort.StopBits = StopBits.One;
            serialPort.Parity = Parity.None;

            try
            {
                // Abre el puerto COM
                serialPort.Open();

                // Envía la solicitud "REQ" al puerto COM
                serialPort.Write("REQ");

                // Espera la respuesta (ajustar según necesidades)
                Task.Delay(7000).Wait();

                // Lee la respuesta del puerto COM
                string respuesta = serialPort.ReadExisting();

                // Verifica si la línea es completa utilizando la función EsLineaCompleta
                if (EsLineaCompleta(respuesta))
                {
                    // Extrae lo que está dentro de los brackets y envía los datos al listener de eventos
                    Match data = Regex.Match(respuesta, @"(?:[^{}]+)", RegexOptions.None);
                    Data_Listener(data.Value);

                    // Agrega el puerto COM validado a la lista
                    lock (lockObject)
                    {
                        PuertosComValidados.Add(portName);
                    }
                }
            }
            catch (Exception ex)
            {
                // Captura y muestra cualquier excepción que pueda ocurrir durante la validación del puerto
                Console.WriteLine($"Error en el puerto {portName}: {ex.Message}");
            }
            finally
            {
                // Cierra el puerto COM en el bloque finally para asegurarse de que se cierre correctamente
                if (serialPort.IsOpen)
                {
                    serialPort.Close();
                }
            }
        }

        // Método privado que verifica si la línea es completa
        private bool EsLineaCompleta(string buffer)
        {
            // Verifica si la lectura es completa. Si contiene los brackets de inicio y final "{}", está completa.
            bool lineComplete = Regex.Match(buffer, @"{.*}", RegexOptions.None).Success;
            return lineComplete;
        }

        // Método privado que maneja los datos recibidos
        private void Data_Listener(string data)
        {
            // Verifica que el evento no sea null antes de invocarlo
            EventHandler<DataReceivedEventArgs> handler = DataReceived;
            if (handler != null)
            {
                // Invoca el evento y pasa los datos recibidos mediante un objeto DataReceivedEventArgs
                handler.Invoke(this, new DataReceivedEventArgs(data));
            }
        }

        // Método público que devuelve la lista de puertos COM validados
        public List<string> ObtenerPuertosComValidados()
        {
            return PuertosComValidados;
        }
    }

    // Clase que hereda de EventArgs y se utiliza para contener información adicional sobre el evento DataReceived
    public class DataReceivedEventArgs : EventArgs
    {
        // Propiedad para acceder a los datos recibidos desde el exterior de la clase
        public string ReceivedCommand { get; }

        // Constructor sin parámetros necesario para manejar el error
        public DataReceivedEventArgs()
        {
        }

        // Constructor que acepta los datos recibidos como parámetro
        public DataReceivedEventArgs(string receivedCommand)
        {
            // Asigna los datos recibidos a la propiedad ReceivedCommand
            ReceivedCommand = receivedCommand;
        }
    }
}
