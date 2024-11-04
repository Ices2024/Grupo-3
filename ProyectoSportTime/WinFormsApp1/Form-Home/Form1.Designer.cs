namespace WinForm.Form_Home
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
            label1 = new Label();
            label2 = new Label();
            buttonTurno = new Button();
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
            buttonTurno.Font = new Font("Segoe UI", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonTurno.Location = new Point(34, 68);
            buttonTurno.Name = "buttonTurno";
            buttonTurno.Size = new Size(689, 58);
            buttonTurno.TabIndex = 11;
            buttonTurno.Text = "Turnos";
            buttonTurno.UseVisualStyleBackColor = false;
            buttonTurno.Click += buttonTurno_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonTurno);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Label label2;
        private Button buttonTurno;
    }
}