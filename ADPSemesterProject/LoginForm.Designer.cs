namespace ADPSemesterProject
{
    partial class LoginForm
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
            lName = new Label();
            txtBName = new TextBox();
            btnLogin = new Button();
            txtBPassword = new TextBox();
            lPassword = new Label();
            SuspendLayout();
            // 
            // lName
            // 
            lName.AutoSize = true;
            lName.Location = new Point(167, 166);
            lName.Name = "lName";
            lName.Size = new Size(39, 15);
            lName.TabIndex = 0;
            lName.Text = "Name";
            // 
            // txtBName
            // 
            txtBName.Location = new Point(234, 163);
            txtBName.Name = "txtBName";
            txtBName.Size = new Size(100, 23);
            txtBName.TabIndex = 1;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(403, 192);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(75, 23);
            btnLogin.TabIndex = 2;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // txtBPassword
            // 
            txtBPassword.Location = new Point(234, 192);
            txtBPassword.Name = "txtBPassword";
            txtBPassword.Size = new Size(100, 23);
            txtBPassword.TabIndex = 4;
            // 
            // lPassword
            // 
            lPassword.AutoSize = true;
            lPassword.Location = new Point(167, 195);
            lPassword.Name = "lPassword";
            lPassword.Size = new Size(57, 15);
            lPassword.TabIndex = 3;
            lPassword.Text = "Password";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtBPassword);
            Controls.Add(lPassword);
            Controls.Add(btnLogin);
            Controls.Add(txtBName);
            Controls.Add(lName);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lName;
        private TextBox txtBName;
        private Button btnLogin;
        private TextBox txtBPassword;
        private Label lPassword;
    }
}
