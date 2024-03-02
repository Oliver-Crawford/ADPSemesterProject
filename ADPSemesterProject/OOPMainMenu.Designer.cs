namespace ADPSemesterProject
{
    partial class OOPMainMenu
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
            btnRefresh = new Button();
            btnStaff = new Button();
            btnManagement = new Button();
            dataGridView1 = new DataGridView();
            btnAdmin = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(12, 168);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(75, 23);
            btnRefresh.TabIndex = 11;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            // 
            // btnStaff
            // 
            btnStaff.Location = new Point(534, 255);
            btnStaff.Margin = new Padding(0);
            btnStaff.Name = "btnStaff";
            btnStaff.Size = new Size(267, 194);
            btnStaff.TabIndex = 10;
            btnStaff.Text = "Staff";
            btnStaff.UseVisualStyleBackColor = true;
            // 
            // btnManagement
            // 
            btnManagement.Enabled = false;
            btnManagement.Location = new Point(267, 255);
            btnManagement.Margin = new Padding(0);
            btnManagement.Name = "btnManagement";
            btnManagement.Size = new Size(267, 194);
            btnManagement.TabIndex = 9;
            btnManagement.Text = "Management";
            btnManagement.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(776, 150);
            dataGridView1.TabIndex = 8;
            // 
            // btnAdmin
            // 
            btnAdmin.Enabled = false;
            btnAdmin.Location = new Point(0, 255);
            btnAdmin.Margin = new Padding(0);
            btnAdmin.Name = "btnAdmin";
            btnAdmin.Size = new Size(267, 194);
            btnAdmin.TabIndex = 7;
            btnAdmin.Text = "Admin";
            btnAdmin.UseVisualStyleBackColor = true;
            // 
            // OOPMainMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnRefresh);
            Controls.Add(btnStaff);
            Controls.Add(btnManagement);
            Controls.Add(dataGridView1);
            Controls.Add(btnAdmin);
            Name = "OOPMainMenu";
            Text = "OOPMainMenu";
            FormClosed += OOPMainMenu_FormClosed;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnRefresh;
        private Button btnStaff;
        private Button btnManagement;
        private DataGridView dataGridView1;
        private Button btnAdmin;
    }
}