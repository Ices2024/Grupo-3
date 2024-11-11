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
            label5 = new Label();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // txtTipo
            // 
            txtTipo.Location = new Point(12, 105);
            txtTipo.Name = "txtTipo";
            txtTipo.Size = new Size(100, 23);
            txtTipo.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 87);
            label1.Name = "label1";
            label1.Size = new Size(30, 15);
            label1.TabIndex = 1;
            label1.Text = "Tipo";
            // 
            // buttonGuardar
            // 
            buttonGuardar.BackColor = Color.FromArgb(21, 109, 99);
            buttonGuardar.FlatStyle = FlatStyle.Popup;
            buttonGuardar.Location = new Point(12, 255);
            buttonGuardar.Name = "buttonGuardar";
            buttonGuardar.Size = new Size(75, 23);
            buttonGuardar.TabIndex = 2;
            buttonGuardar.Text = "Guardar";
            buttonGuardar.UseVisualStyleBackColor = false;
            buttonGuardar.Click += buttonGuardar_Click;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(12, 161);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(170, 23);
            txtDescripcion.TabIndex = 3;
            // 
            // txtProveedor
            // 
            txtProveedor.Location = new Point(12, 215);
            txtProveedor.Name = "txtProveedor";
            txtProveedor.Size = new Size(100, 23);
            txtProveedor.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 143);
            label2.Name = "label2";
            label2.Size = new Size(69, 15);
            label2.TabIndex = 5;
            label2.Text = "Descripcion";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 197);
            label3.Name = "label3";
            label3.Size = new Size(61, 15);
            label3.TabIndex = 6;
            label3.Text = "Proveedor";
            // 
            // buttonModificar
            // 
            buttonModificar.BackColor = Color.FromArgb(21, 109, 99);
            buttonModificar.FlatStyle = FlatStyle.Popup;
            buttonModificar.Location = new Point(202, 255);
            buttonModificar.Name = "buttonModificar";
            buttonModificar.Size = new Size(75, 23);
            buttonModificar.TabIndex = 7;
            buttonModificar.Text = "Modificar";
            buttonModificar.UseVisualStyleBackColor = false;
            buttonModificar.Click += buttonModificar_Click;
            // 
            // buttonEliminar
            // 
            buttonEliminar.BackColor = Color.FromArgb(21, 109, 99);
            buttonEliminar.FlatStyle = FlatStyle.Popup;
            buttonEliminar.Location = new Point(539, 255);
            buttonEliminar.Name = "buttonEliminar";
            buttonEliminar.Size = new Size(75, 23);
            buttonEliminar.TabIndex = 8;
            buttonEliminar.Text = "Eliminar";
            buttonEliminar.UseVisualStyleBackColor = false;
            buttonEliminar.Click += buttonEliminar_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(202, 99);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(412, 150);
            dataGridView1.TabIndex = 9;
            // 
            // label5
            // 
            label5.BackColor = Color.FromArgb(21, 109, 99);
            label5.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(2, -1);
            label5.Name = "label5";
            label5.Size = new Size(657, 44);
            label5.TabIndex = 20;
            label5.Text = "Productos";
            label5.TextAlign = ContentAlignment.BottomLeft;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(21, 109, 99);
            button1.FlatStyle = FlatStyle.Popup;
            button1.Location = new Point(584, 301);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 21;
            button1.Text = "Volver";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // FormProductos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 204, 181);
            ClientSize = new Size(661, 336);
            Controls.Add(button1);
            Controls.Add(label5);
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
        private Label label5;
        private Button button1;
    }
}