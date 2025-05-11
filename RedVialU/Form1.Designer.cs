namespace RedVialU
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelMapa = new Panel();
            btnSimularFlujo = new Button();
            btnMayorCongestion = new Button();
            cbOrigen = new ComboBox();
            cbDestino = new ComboBox();
            btnCalcularTiempo = new Button();
            btnBuscarRuta = new Button();
            btnSimularRutaVehicular = new Button();
            SuspendLayout();
            // 
            // panelMapa
            // 
            panelMapa.Location = new Point(21, 12);
            panelMapa.Name = "panelMapa";
            panelMapa.Size = new Size(600, 600);
            panelMapa.TabIndex = 0;
            panelMapa.Paint += panelMapa_Paint;
            // 
            // btnSimularFlujo
            // 
            btnSimularFlujo.Location = new Point(643, 12);
            btnSimularFlujo.Name = "btnSimularFlujo";
            btnSimularFlujo.Size = new Size(112, 45);
            btnSimularFlujo.TabIndex = 1;
            btnSimularFlujo.Text = "Simular Flujo";
            btnSimularFlujo.UseVisualStyleBackColor = true;
            btnSimularFlujo.Click += btnSimularFlujo_Click;
            // 
            // btnMayorCongestion
            // 
            btnMayorCongestion.Location = new Point(643, 72);
            btnMayorCongestion.Name = "btnMayorCongestion";
            btnMayorCongestion.Size = new Size(112, 42);
            btnMayorCongestion.TabIndex = 2;
            btnMayorCongestion.Text = "Interseccion mas Congestionada";
            btnMayorCongestion.UseVisualStyleBackColor = true;
            btnMayorCongestion.Click += btnMayorCongestion_Click;
            // 
            // cbOrigen
            // 
            cbOrigen.FormattingEnabled = true;
            cbOrigen.Items.AddRange(new object[] { "", "Norte", "Sur", "Este", "Oeste" });
            cbOrigen.Location = new Point(643, 172);
            cbOrigen.Name = "cbOrigen";
            cbOrigen.Size = new Size(82, 23);
            cbOrigen.TabIndex = 3;
            // 
            // cbDestino
            // 
            cbDestino.FormattingEnabled = true;
            cbDestino.Items.AddRange(new object[] { "", "Norte", "Sur", "Este", "Oeste" });
            cbDestino.Location = new Point(731, 172);
            cbDestino.Name = "cbDestino";
            cbDestino.Size = new Size(82, 23);
            cbDestino.TabIndex = 4;
            // 
            // btnCalcularTiempo
            // 
            btnCalcularTiempo.Location = new Point(643, 208);
            btnCalcularTiempo.Name = "btnCalcularTiempo";
            btnCalcularTiempo.Size = new Size(82, 46);
            btnCalcularTiempo.TabIndex = 5;
            btnCalcularTiempo.Text = "Calcular Tiempo";
            btnCalcularTiempo.UseVisualStyleBackColor = true;
            btnCalcularTiempo.Click += btnCalcularTiempo_Click;
            // 
            // btnBuscarRuta
            // 
            btnBuscarRuta.Location = new Point(731, 208);
            btnBuscarRuta.Name = "btnBuscarRuta";
            btnBuscarRuta.Size = new Size(96, 46);
            btnBuscarRuta.TabIndex = 6;
            btnBuscarRuta.Text = "BuscarRutaSimple";
            btnBuscarRuta.UseVisualStyleBackColor = true;
            btnBuscarRuta.Click += btnBuscarRuta_Click;
            // 
            // btnSimularRutaVehicular
            // 
            btnSimularRutaVehicular.Location = new Point(646, 264);
            btnSimularRutaVehicular.Name = "btnSimularRutaVehicular";
            btnSimularRutaVehicular.Size = new Size(202, 38);
            btnSimularRutaVehicular.TabIndex = 7;
            btnSimularRutaVehicular.Text = "Simular Ruta Vehicular";
            btnSimularRutaVehicular.UseVisualStyleBackColor = true;
            btnSimularRutaVehicular.Click += btnSimularRutaVehicular_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1005, 725);
            Controls.Add(btnSimularRutaVehicular);
            Controls.Add(btnBuscarRuta);
            Controls.Add(btnCalcularTiempo);
            Controls.Add(cbDestino);
            Controls.Add(cbOrigen);
            Controls.Add(btnMayorCongestion);
            Controls.Add(btnSimularFlujo);
            Controls.Add(panelMapa);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private Panel panelMapa;
        private Button btnSimularFlujo;
        private Button btnMayorCongestion;
        private ComboBox cbOrigen;
        private ComboBox cbDestino;
        private Button btnCalcularTiempo;
        private Button btnBuscarRuta;
        private Button btnSimularRutaVehicular;
    }
}
