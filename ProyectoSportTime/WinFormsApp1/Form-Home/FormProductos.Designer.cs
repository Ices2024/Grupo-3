namespace WinForm.Form_Home
{
    partial class FormProductos
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
            txtTipo = new TextBox();
            label1 = new Label();
            buttonGuardar = new Button();
            txtDescripcion = new TextBox();
            txtProveedor = new TextBox();
            label2 = new Label();
            label3 = new Label();
            buttonModificar = new Button();
            buttonEliminar = new Button();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // txtTipo
            // 
            txtTipo.Location = new Point(12, 31);
            txtTipo.Name = "txtTipo";
            txtTipo.Size = new Size(100, 23);
            txtTipo.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 13);
            label1.Name = "label1";
            label1.Size = new Size(30, 15);
            label1.TabIndex = 1;
            label1.Text = "Tipo";
            // 
            // buttonGuardar
            // 
            buttonGuardar.Location = new Point(12, 181);
            buttonGuardar.Name = "buttonGuardar";
            buttonGuardar.Size = new Size(75, 23);
            buttonGuardar.TabIndex = 2;
            buttonGuardar.Text = "Guardar";
            buttonGuardar.UseVisualStyleBackColor = true;
            buttonGuardar.Click += buttonGuardar_Click;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(12, 84);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(170, 23);
            txtDescripcion.TabIndex = 3;
            // 
            // txtProveedor
            // 
            txtProveedor.Location = new Point(12, 141);
            txtProveedor.Name = "txtProveedor";
            txtProveedor.Size = new Size(100, 23);
            txtProveedor.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 66);
            label2.Name = "label2";
            label2.Size = new Size(69, 15);
            label2.TabIndex = 5;
            label2.Text = "Descripcion";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 123);
            label3.Name = "label3";
            label3.Size = new Size(61, 15);
            label3.TabIndex = 6;
            label3.Text = "Proveedor";
            // 
            // buttonModificar
            // 
            buttonModificar.Location = new Point(202, 181);
            buttonModificar.Name = "buttonModificar";
            buttonModificar.Size = new Size(75, 23);
            buttonModificar.TabIndex = 7;
            buttonModificar.Text = "Modificar";
            buttonModificar.UseVisualStyleBackColor = true;
            buttonModificar.Click += buttonModificar_Click;
            // 
            // buttonEliminar
            // 
            buttonEliminar.Location = new Point(367, 181);
            buttonEliminar.Name = "buttonEliminar";
            buttonEliminar.Size = new Size(75, 23);
            buttonEliminar.TabIndex = 8;
            buttonEliminar.Text = "Eliminar";
            buttonEliminar.UseVisualStyleBackColor = true;
            buttonEliminar.Click += buttonEliminar_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(202, 14);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(240, 150);
            dataGridView1.TabIndex = 9;
            // 
            // FormProductos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(491, 290);
            Controls.Add(dataGridView1);
            Controls.Add(buttonEliminar);
            Controls.Add(buttonModificar);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtProveedor);
            Controls.Add(txtDescripcion);
            Controls.Add(buttonGuardar);
            Controls.Add(label1);
            Controls.Add(txtTipo);
            Name = "FormProductos";
            Text = "FormProductos";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtTipo;
        private Label label1;
        private Button buttonGuardar;
        private TextBox txtDescripcion;
        private TextBox txtProveedor;
        private Label label2;
        private Label label3;
        private Button buttonModificar;
        private Button buttonEliminar;
        private DataGridView dataGridView1;
    }
}