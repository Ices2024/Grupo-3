namespace WinForm.Form_Home
{
    partial class TurnoForm
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
            dataGridViewTurnos = new DataGridView();
            comboBoxCancha = new ComboBox();
            comboBoxConsumicion = new ComboBox();
            numericUpDownCantidad = new NumericUpDown();
            dateTimePicker1 = new DateTimePicker();
            dateTimePicker2 = new DateTimePicker();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            buttonGuardar = new Button();
            buttonModificar = new Button();
            buttonEliminar = new Button();
            buttonLimpiar = new Button();
            buttonVolver = new Button();
            comboBoxCliente = new ComboBox();
            label6 = new Label();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTurnos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownCantidad).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewTurnos
            // 
            dataGridViewTurnos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewTurnos.Location = new Point(41, 98);
            dataGridViewTurnos.Name = "dataGridViewTurnos";
            dataGridViewTurnos.Size = new Size(653, 210);
            dataGridViewTurnos.TabIndex = 0;
            // 
            // comboBoxCancha
            // 
            comboBoxCancha.FormattingEnabled = true;
            comboBoxCancha.Items.AddRange(new object[] { "1 - futbol", "2 - futbol", "3 - basquet", "4 - basquet", "5 -  voley" });
            comboBoxCancha.Location = new Point(157, 348);
            comboBoxCancha.Name = "comboBoxCancha";
            comboBoxCancha.Size = new Size(121, 23);
            comboBoxCancha.TabIndex = 1;
            // 
            // comboBoxConsumicion
            // 
            comboBoxConsumicion.FormattingEnabled = true;
            comboBoxConsumicion.Items.AddRange(new object[] { "1 - Coca Cola 500ml", "2 - Seven Up 500ml", "3 - Cerveza 1 litro", "4 - Agua Saborizada 500ml" });
            comboBoxConsumicion.Location = new Point(305, 347);
            comboBoxConsumicion.Name = "comboBoxConsumicion";
            comboBoxConsumicion.Size = new Size(121, 23);
            comboBoxConsumicion.TabIndex = 2;
            // 
            // numericUpDownCantidad
            // 
            numericUpDownCantidad.Location = new Point(433, 348);
            numericUpDownCantidad.Name = "numericUpDownCantidad";
            numericUpDownCantidad.Size = new Size(30, 23);
            numericUpDownCantidad.TabIndex = 3;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CustomFormat = "HH:mm";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.Location = new Point(521, 348);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.ShowUpDown = true;
            dateTimePicker1.Size = new Size(98, 23);
            dateTimePicker1.TabIndex = 4;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.CustomFormat = "HH:mm";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.Location = new Point(625, 348);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.ShowUpDown = true;
            dateTimePicker2.Size = new Size(93, 23);
            dateTimePicker2.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(160, 333);
            label1.Name = "label1";
            label1.Size = new Size(47, 15);
            label1.TabIndex = 6;
            label1.Text = "Cancha";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(308, 333);
            label2.Name = "label2";
            label2.Size = new Size(78, 15);
            label2.TabIndex = 7;
            label2.Text = "Consumicion";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(524, 333);
            label3.Name = "label3";
            label3.Size = new Size(36, 15);
            label3.TabIndex = 8;
            label3.Text = "Inicio";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(628, 333);
            label4.Name = "label4";
            label4.Size = new Size(23, 15);
            label4.TabIndex = 9;
            label4.Text = "Fin";
            // 
            // buttonGuardar
            // 
            buttonGuardar.BackColor = Color.FromArgb(21, 109, 99);
            buttonGuardar.ForeColor = Color.Black;
            buttonGuardar.Location = new Point(35, 391);
            buttonGuardar.Margin = new Padding(0);
            buttonGuardar.Name = "buttonGuardar";
            buttonGuardar.Size = new Size(75, 23);
            buttonGuardar.TabIndex = 10;
            buttonGuardar.Text = "Guardar";
            buttonGuardar.UseVisualStyleBackColor = false;
            buttonGuardar.Click += buttonGuardar_Click;
            // 
            // buttonModificar
            // 
            buttonModificar.BackColor = Color.FromArgb(21, 109, 99);
            buttonModificar.Location = new Point(113, 391);
            buttonModificar.Name = "buttonModificar";
            buttonModificar.Size = new Size(75, 23);
            buttonModificar.TabIndex = 11;
            buttonModificar.Text = "Modificar";
            buttonModificar.UseVisualStyleBackColor = false;
            buttonModificar.Click += buttonModificar_Click;
            // 
            // buttonEliminar
            // 
            buttonEliminar.BackColor = Color.FromArgb(21, 109, 99);
            buttonEliminar.Location = new Point(194, 391);
            buttonEliminar.Name = "buttonEliminar";
            buttonEliminar.Size = new Size(75, 23);
            buttonEliminar.TabIndex = 12;
            buttonEliminar.Text = "Eliminar";
            buttonEliminar.UseVisualStyleBackColor = false;
            buttonEliminar.Click += buttonEliminar_Click;
            // 
            // buttonLimpiar
            // 
            buttonLimpiar.BackColor = Color.FromArgb(21, 109, 99);
            buttonLimpiar.Location = new Point(509, 389);
            buttonLimpiar.Name = "buttonLimpiar";
            buttonLimpiar.Size = new Size(75, 23);
            buttonLimpiar.TabIndex = 13;
            buttonLimpiar.Text = "Limpiar";
            buttonLimpiar.UseVisualStyleBackColor = false;
            buttonLimpiar.Click += buttonLimpiar_Click;
            // 
            // buttonVolver
            // 
            buttonVolver.BackColor = Color.FromArgb(21, 109, 99);
            buttonVolver.Location = new Point(590, 389);
            buttonVolver.Name = "buttonVolver";
            buttonVolver.Size = new Size(75, 23);
            buttonVolver.TabIndex = 14;
            buttonVolver.Text = "Volver";
            buttonVolver.UseVisualStyleBackColor = false;
            buttonVolver.Click += buttonVolver_Click;
            // 
            // comboBoxCliente
            // 
            comboBoxCliente.FormattingEnabled = true;
            comboBoxCliente.Items.AddRange(new object[] { "1 ", "2", "3" });
            comboBoxCliente.Location = new Point(12, 348);
            comboBoxCliente.Name = "comboBoxCliente";
            comboBoxCliente.Size = new Size(110, 23);
            comboBoxCliente.TabIndex = 17;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(15, 333);
            label6.Name = "label6";
            label6.Size = new Size(44, 15);
            label6.TabIndex = 18;
            label6.Text = "Cliente";
            // 
            // label5
            // 
            label5.BackColor = Color.FromArgb(21, 109, 99);
            label5.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(41, 9);
            label5.Name = "label5";
            label5.Size = new Size(653, 75);
            label5.TabIndex = 19;
            label5.Text = "Turnos";
            label5.TextAlign = ContentAlignment.TopCenter;
            // 
            // TurnoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 204, 181);
            ClientSize = new Size(756, 450);
            Controls.Add(label5);
            Controls.Add(label6);
            Controls.Add(comboBoxCliente);
            Controls.Add(buttonVolver);
            Controls.Add(buttonLimpiar);
            Controls.Add(buttonEliminar);
            Controls.Add(buttonModificar);
            Controls.Add(buttonGuardar);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dateTimePicker2);
            Controls.Add(dateTimePicker1);
            Controls.Add(numericUpDownCantidad);
            Controls.Add(comboBoxConsumicion);
            Controls.Add(comboBoxCancha);
            Controls.Add(dataGridViewTurnos);
            Cursor = Cursors.Default;
            Name = "TurnoForm";
            Padding = new Padding(3);
            Text = "TurnoForm";
            TransparencyKey = Color.Black;
            ((System.ComponentModel.ISupportInitialize)dataGridViewTurnos).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownCantidad).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewTurnos;
        private ComboBox comboBoxCancha;
        private ComboBox comboBoxConsumicion;
        private NumericUpDown numericUpDownCantidad;
        private DateTimePicker dateTimePicker1;
        private DateTimePicker dateTimePicker2;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button buttonGuardar;
        private Button buttonModificar;
        private Button buttonEliminar;
        private Button buttonLimpiar;
        private Button buttonVolver;
        private ComboBox comboBoxCliente;
        private Label label6;
        private Label label5;
    }
}