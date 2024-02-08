using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PruebaCombobox
{
    public partial class Form1 : Form
    {
        //public ValidacionCOM validacionCOM;
        public Form1()
        {
           
            InitializeComponent();

        }
        private void Form1_Shown(object sender, EventArgs e)
        {
         


            ValidacionCOM validacionCOM = new ValidacionCOM();

            validacionCOM.ValidarPuertosComParalelo();
            // validacion.ValidacionRed();
            // List<string> ipvalida = validacion.Red;
            List<string> puertosValidados = validacionCOM.ObtenerPuertosComValidados();

            // Agregar los puertos validados al ComboBox de puertos validados
            comboBoxPuertosValidados.Items.AddRange(puertosValidados.ToArray());

            comboBoxPuertosExist.DataSource=SerialPort.GetPortNames();  
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
       
    }
}
