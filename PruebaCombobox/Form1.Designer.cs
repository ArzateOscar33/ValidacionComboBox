namespace PruebaCombobox
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxPuertosExist = new System.Windows.Forms.ComboBox();
            this.comboBoxPuertosValidados = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Puertos Sin Validar";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(177, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Puertos Validados";
            // 
            // comboBoxPuertosExist
            // 
            this.comboBoxPuertosExist.FormattingEnabled = true;
            this.comboBoxPuertosExist.Location = new System.Drawing.Point(12, 72);
            this.comboBoxPuertosExist.Name = "comboBoxPuertosExist";
            this.comboBoxPuertosExist.Size = new System.Drawing.Size(121, 21);
            this.comboBoxPuertosExist.TabIndex = 2;
            // 
            // comboBoxPuertosValidados
            // 
            this.comboBoxPuertosValidados.FormattingEnabled = true;
            this.comboBoxPuertosValidados.Location = new System.Drawing.Point(152, 72);
            this.comboBoxPuertosValidados.Name = "comboBoxPuertosValidados";
            this.comboBoxPuertosValidados.Size = new System.Drawing.Size(121, 21);
            this.comboBoxPuertosValidados.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(285, 233);
            this.Controls.Add(this.comboBoxPuertosValidados);
            this.Controls.Add(this.comboBoxPuertosExist);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxPuertosExist;
        private System.Windows.Forms.ComboBox comboBoxPuertosValidados;
    }
}

