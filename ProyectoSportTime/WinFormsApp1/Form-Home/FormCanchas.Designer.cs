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
            textCodigoDepo = new TextBox();
            buttonGuardar = new Button();
            buttonModificar = new Button();
            buttonEliminar = new Button();
            label1 = new Label();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // textCodigoDepo
            // 
            textCodigoDepo.Location = new Point(12, 49);
            textCodigoDepo.Name = "textCodigoDepo";
            textCodigoDepo.Size = new Size(100, 23);
            textCodigoDepo.TabIndex = 0;
            // 
            // buttonGuardar
            // 
            buttonGuardar.Location = new Point(12, 105);
            buttonGuardar.Name = "buttonGuardar";
            buttonGuardar.Size = new Size(75, 23);
            buttonGuardar.TabIndex = 1;
            buttonGuardar.Text = "Guardar";
            buttonGuardar.UseVisualStyleBackColor = true;
            // 
            // buttonModificar
            // 
            buttonModificar.Location = new Point(12, 134);
            buttonModificar.Name = "buttonModificar";
            buttonModificar.Size = new Size(75, 23);
            buttonModificar.TabIndex = 2;
            buttonModificar.Text = "Modificar";
            buttonModificar.UseVisualStyleBackColor = true;
            // 
            // buttonEliminar
            // 
            buttonEliminar.Location = new Point(12, 163);
            buttonEliminar.Name = "buttonEliminar";
            buttonEliminar.Size = new Size(75, 23);
            buttonEliminar.TabIndex = 3;
            buttonEliminar.Text = "Eliminar";
            buttonEliminar.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 31);
            label1.Name = "label1";
            label1.Size = new Size(49, 15);
            label1.TabIndex = 4;
            label1.Text = "Deporte";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(155, 31);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(271, 155);
            dataGridView1.TabIndex = 5;
            // 
            // FormCanchas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(646, 323);
            Controls.Add(dataGridView1);
            Controls.Add(label1);
            Controls.Add(buttonEliminar);
            Controls.Add(buttonModificar);
            Controls.Add(buttonGuardar);
            Controls.Add(textCodigoDepo);
            Name = "FormCanchas";
            Text = "FormCanchas";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textCodigoDepo;
        private Button buttonGuardar;
        private Button buttonModificar;
        private Button buttonEliminar;
        private Label label1;
        private DataGridView dataGridView1;
    }
}