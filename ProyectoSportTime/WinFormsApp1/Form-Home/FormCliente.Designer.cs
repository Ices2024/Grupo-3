namespace WinForm.Form_Home
{
    partial class FormCliente
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
            label1 = new Label();
            textBoxNombre = new TextBox();
            label2 = new Label();
            textBoxTelefono = new TextBox();
            buttonGuardar = new Button();
            dataGridView1 = new DataGridView();
            buttonModificar = new Button();
            buttonEliminar = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 51);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 0;
            label1.Text = "Nombre";
            // 
            // textBoxNombre
            // 
            textBoxNombre.Location = new Point(26, 69);
            textBoxNombre.Name = "textBoxNombre";
            textBoxNombre.Size = new Size(100, 23);
            textBoxNombre.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(26, 119);
            label2.Name = "label2";
            label2.Size = new Size(52, 15);
            label2.TabIndex = 2;
            label2.Text = "Telefono";
            // 
            // textBoxTelefono
            // 
            textBoxTelefono.Location = new Point(26, 137);
            textBoxTelefono.Name = "textBoxTelefono";
            textBoxTelefono.Size = new Size(100, 23);
            textBoxTelefono.TabIndex = 3;
            // 
            // buttonGuardar
            // 
            buttonGuardar.Location = new Point(26, 189);
            buttonGuardar.Name = "buttonGuardar";
            buttonGuardar.Size = new Size(75, 23);
            buttonGuardar.TabIndex = 4;
            buttonGuardar.Text = "Guardar";
            buttonGuardar.UseVisualStyleBackColor = true;
            buttonGuardar.Click += buttonGuardar_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(173, 51);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(248, 161);
            dataGridView1.TabIndex = 5;
            // 
            // buttonModificar
            // 
            buttonModificar.Location = new Point(173, 218);
            buttonModificar.Name = "buttonModificar";
            buttonModificar.Size = new Size(75, 23);
            buttonModificar.TabIndex = 6;
            buttonModificar.Text = "Modificar";
            buttonModificar.UseVisualStyleBackColor = true;
            buttonModificar.Click += buttonModificar_Click;
            // 
            // buttonEliminar
            // 
            buttonEliminar.Location = new Point(346, 218);
            buttonEliminar.Name = "buttonEliminar";
            buttonEliminar.Size = new Size(75, 23);
            buttonEliminar.TabIndex = 7;
            buttonEliminar.Text = "Eliminar";
            buttonEliminar.UseVisualStyleBackColor = true;
            buttonEliminar.Click += buttonEliminar_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(486, 286);
            Controls.Add(buttonEliminar);
            Controls.Add(buttonModificar);
            Controls.Add(dataGridView1);
            Controls.Add(buttonGuardar);
            Controls.Add(textBoxTelefono);
            Controls.Add(label2);
            Controls.Add(textBoxNombre);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBoxNombre;
        private Label label2;
        private TextBox textBoxTelefono;
        private Button buttonGuardar;
        private DataGridView dataGridView1;
        private Button buttonModificar;
        private Button buttonEliminar;
    }
}