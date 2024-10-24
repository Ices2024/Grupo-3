namespace WinForm.FormAdmin
{
    partial class InicoSesion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InicoSesion));
            label1 = new Label();
            label2 = new Label();
            textBoxEmail = new TextBox();
            label3 = new Label();
            textBoxPassword = new TextBox();
            buttonInSc = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Font = new Font("MS PGothic", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(14, 40);
            label1.Name = "label1";
            label1.Size = new Size(437, 123);
            label1.TabIndex = 0;
            label1.Text = "Bienvenidos a SportTime";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.Font = new Font("MS PGothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(30, 176);
            label2.Name = "label2";
            label2.Size = new Size(99, 29);
            label2.TabIndex = 1;
            label2.Text = "Email";
            // 
            // textBoxEmail
            // 
            textBoxEmail.Location = new Point(30, 209);
            textBoxEmail.Margin = new Padding(3, 4, 3, 4);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(307, 27);
            textBoxEmail.TabIndex = 2;
            // 
            // label3
            // 
            label3.Font = new Font("MS PGothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(30, 293);
            label3.Name = "label3";
            label3.Size = new Size(99, 29);
            label3.TabIndex = 3;
            label3.Text = "Contraseña";
            // 
            // textBoxPassword
            // 
            textBoxPassword.Location = new Point(30, 341);
            textBoxPassword.Margin = new Padding(3, 4, 3, 4);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(307, 27);
            textBoxPassword.TabIndex = 4;
            // 
            // buttonInSc
            // 
            buttonInSc.Font = new Font("MS PGothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonInSc.Location = new Point(55, 473);
            buttonInSc.Margin = new Padding(3, 4, 3, 4);
            buttonInSc.Name = "buttonInSc";
            buttonInSc.Size = new Size(251, 47);
            buttonInSc.TabIndex = 5;
            buttonInSc.Text = "Iniciar Sesion";
            buttonInSc.UseVisualStyleBackColor = true;
            buttonInSc.Click += buttonInSc_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(457, 0);
            pictureBox1.Margin = new Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(457, 604);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // InicoSesion
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(pictureBox1);
            Controls.Add(buttonInSc);
            Controls.Add(textBoxPassword);
            Controls.Add(label3);
            Controls.Add(textBoxEmail);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "InicoSesion";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox textBoxEmail;
        private Label label3;
        private TextBox textBoxPassword;
        private Button buttonInSc;
        private PictureBox pictureBox1;
    }
}