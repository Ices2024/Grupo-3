namespace WinForm.Form_Home
{
    partial class FormCanchas
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
            comboBoxDeporte = new ComboBox();
            txtTipo = new TextBox();
            label1 = new Label();
            label2 = new Label();
            buttonGuardar = new Button();
            buttonModificar = new Button();
            buttonEliminar = new Button();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // comboBoxDeporte
            // 
            comboBoxDeporte.FormattingEnabled = true;
            comboBoxDeporte.Location = new Point(12, 41);
            comboBoxDeporte.Name = "comboBoxDeporte";
            comboBoxDeporte.Size = new Size(121, 23);
            comboBoxDeporte.TabIndex = 0;
            // 
            // txtTipo
            // 
            txtTipo.Location = new Point(12, 112);
            txtTipo.Name = "txtTipo";
            txtTipo.Size = new Size(121, 23);
            txtTipo.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 23);
            label1.Name = "label1";
            label1.Size = new Size(63, 15);
            label1.TabIndex = 2;
            label1.Text = "Deporte ID";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 94);
            label2.Name = "label2";
            label2.Size = new Size(30, 15);
            label2.TabIndex = 3;
            label2.Text = "Tipo";
            // 
            // buttonGuardar
            // 
            buttonGuardar.Location = new Point(12, 162);
            buttonGuardar.Name = "buttonGuardar";
            buttonGuardar.Size = new Size(75, 23);
            buttonGuardar.TabIndex = 4;
            buttonGuardar.Text = "Guardar";
            buttonGuardar.UseVisualStyleBackColor = true;
            buttonGuardar.Click += buttonGuardar_Click;
            // 
            // buttonModificar
            // 
            buttonModificar.Location = new Point(163, 162);
            buttonModificar.Name = "buttonModificar";
            buttonModificar.Size = new Size(75, 23);
            buttonModificar.TabIndex = 5;
            buttonModificar.Text = "Modificar";
            buttonModificar.UseVisualStyleBackColor = true;
            buttonModificar.Click += buttonModificar_Click;
            // 
            // buttonEliminar
            // 
            buttonEliminar.Location = new Point(328, 162);
            buttonEliminar.Name = "buttonEliminar";
            buttonEliminar.Size = new Size(75, 23);
            buttonEliminar.TabIndex = 6;
            buttonEliminar.Text = "Eliminar";
            buttonEliminar.UseVisualStyleBackColor = true;
            buttonEliminar.Click += buttonEliminar_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(163, 6);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(240, 150);
            dataGridView1.TabIndex = 7;
            // 
            // FormCanchas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridView1);
            Controls.Add(buttonEliminar);
            Controls.Add(buttonModificar);
            Controls.Add(buttonGuardar);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtTipo);
            Controls.Add(comboBoxDeporte);
            Name = "FormCanchas";
            Text = "FormCanchas";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBoxDeporte;
        private TextBox txtTipo;
        private Label label1;
        private Label label2;
        private Button buttonGuardar;
        private Button buttonModificar;
        private Button buttonEliminar;
        private DataGridView dataGridView1;
    }
}