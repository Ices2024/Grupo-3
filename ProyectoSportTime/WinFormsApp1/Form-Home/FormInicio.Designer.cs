namespace WinForm.Form_Home
{
    partial class FormInicio
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
            label2 = new Label();
            buttonTurno = new Button();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.BackColor = Color.Aqua;
            label1.Font = new Font("MS PGothic", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(0, -1);
            label1.Name = "label1";
            label1.Size = new Size(800, 49);
            label1.TabIndex = 0;
            label1.Text = "SportTime";
            label1.TextAlign = ContentAlignment.BottomLeft;
            // 
            // label2
            // 
            label2.Location = new Point(0, 418);
            label2.Name = "label2";
            label2.Size = new Size(100, 23);
            label2.TabIndex = 0;
            label2.Click += label2_Click;
            // 
            // buttonTurno
            // 
            buttonTurno.BackColor = Color.FromArgb(21, 109, 99);
            buttonTurno.FlatStyle = FlatStyle.Popup;
            buttonTurno.Font = new Font("Segoe UI", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonTurno.Location = new Point(34, 68);
            buttonTurno.Name = "buttonTurno";
            buttonTurno.Size = new Size(689, 58);
            buttonTurno.TabIndex = 11;
            buttonTurno.Text = "Turnos";
            buttonTurno.UseVisualStyleBackColor = false;
            buttonTurno.Click += buttonTurno_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(21, 109, 99);
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Segoe UI", 26.25F, FontStyle.Bold);
            button1.Location = new Point(34, 132);
            button1.Name = "button1";
            button1.Size = new Size(689, 58);
            button1.TabIndex = 12;
            button1.Text = "Canchas";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(21, 109, 99);
            button2.FlatStyle = FlatStyle.Popup;
            button2.Font = new Font("Segoe UI", 26.25F, FontStyle.Bold);
            button2.Location = new Point(34, 196);
            button2.Name = "button2";
            button2.Size = new Size(689, 58);
            button2.TabIndex = 13;
            button2.Text = "Clientes";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(21, 109, 99);
            button3.FlatStyle = FlatStyle.Popup;
            button3.Font = new Font("Segoe UI", 26.25F, FontStyle.Bold);
            button3.Location = new Point(34, 260);
            button3.Name = "button3";
            button3.Size = new Size(689, 58);
            button3.TabIndex = 14;
            button3.Text = "Productos";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // FormInicio
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 204, 181);
            ClientSize = new Size(800, 329);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(buttonTurno);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormInicio";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Label label2;
        private Button buttonTurno;
        private Button button1;
        private Button button2;
        private Button button3;
    }
}