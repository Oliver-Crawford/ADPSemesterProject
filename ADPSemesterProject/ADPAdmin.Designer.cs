namespace ADPSemesterProject
{
    partial class ADPAdmin
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
            dataGridView1 = new DataGridView();
            lUsers = new Label();
            btnUsersRead = new Button();
            lUsersName = new Label();
            txtBUsersName = new TextBox();
            txtBUsersPassword = new TextBox();
            lUsersPassword = new Label();
            txtBUsersRole = new TextBox();
            lUsersRole = new Label();
            txtBUsersAccessLevel = new TextBox();
            lUsersAccessLevel = new Label();
            txtBMenuCategory = new TextBox();
            lMenuDescription = new Label();
            txtBMenuDiscount = new TextBox();
            lMenuDiscount = new Label();
            txtBMenuCost = new TextBox();
            lMenuCost = new Label();
            txtBMenuName = new TextBox();
            lMenuName = new Label();
            btnMenuRead = new Button();
            lMenu = new Label();
            txtBMenuDescription = new TextBox();
            label11 = new Label();
            txtBID = new TextBox();
            lID = new Label();
            btnCreateUser = new Button();
            btnCreateMenu = new Button();
            lCurrentViewSelected = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(776, 150);
            dataGridView1.TabIndex = 4;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // lUsers
            // 
            lUsers.AutoSize = true;
            lUsers.Location = new Point(12, 172);
            lUsers.Name = "lUsers";
            lUsers.Size = new Size(35, 15);
            lUsers.TabIndex = 5;
            lUsers.Text = "Users";
            // 
            // btnUsersRead
            // 
            btnUsersRead.Location = new Point(91, 168);
            btnUsersRead.Name = "btnUsersRead";
            btnUsersRead.Size = new Size(75, 23);
            btnUsersRead.TabIndex = 6;
            btnUsersRead.Text = "Read";
            btnUsersRead.UseVisualStyleBackColor = true;
            btnUsersRead.Click += btnUsersRead_Click;
            // 
            // lUsersName
            // 
            lUsersName.AutoSize = true;
            lUsersName.Location = new Point(12, 200);
            lUsersName.Name = "lUsersName";
            lUsersName.Size = new Size(39, 15);
            lUsersName.TabIndex = 7;
            lUsersName.Text = "Name";
            // 
            // txtBUsersName
            // 
            txtBUsersName.Location = new Point(91, 197);
            txtBUsersName.Name = "txtBUsersName";
            txtBUsersName.Size = new Size(100, 23);
            txtBUsersName.TabIndex = 8;
            // 
            // txtBUsersPassword
            // 
            txtBUsersPassword.Location = new Point(91, 226);
            txtBUsersPassword.Name = "txtBUsersPassword";
            txtBUsersPassword.Size = new Size(100, 23);
            txtBUsersPassword.TabIndex = 10;
            // 
            // lUsersPassword
            // 
            lUsersPassword.AutoSize = true;
            lUsersPassword.Location = new Point(12, 229);
            lUsersPassword.Name = "lUsersPassword";
            lUsersPassword.Size = new Size(57, 15);
            lUsersPassword.TabIndex = 9;
            lUsersPassword.Text = "Password";
            // 
            // txtBUsersRole
            // 
            txtBUsersRole.Location = new Point(91, 255);
            txtBUsersRole.Name = "txtBUsersRole";
            txtBUsersRole.Size = new Size(100, 23);
            txtBUsersRole.TabIndex = 12;
            // 
            // lUsersRole
            // 
            lUsersRole.AutoSize = true;
            lUsersRole.Location = new Point(12, 258);
            lUsersRole.Name = "lUsersRole";
            lUsersRole.Size = new Size(30, 15);
            lUsersRole.TabIndex = 11;
            lUsersRole.Text = "Role";
            // 
            // txtBUsersAccessLevel
            // 
            txtBUsersAccessLevel.Location = new Point(91, 284);
            txtBUsersAccessLevel.Name = "txtBUsersAccessLevel";
            txtBUsersAccessLevel.Size = new Size(100, 23);
            txtBUsersAccessLevel.TabIndex = 14;
            // 
            // lUsersAccessLevel
            // 
            lUsersAccessLevel.AutoSize = true;
            lUsersAccessLevel.Location = new Point(12, 287);
            lUsersAccessLevel.Name = "lUsersAccessLevel";
            lUsersAccessLevel.Size = new Size(73, 15);
            lUsersAccessLevel.TabIndex = 13;
            lUsersAccessLevel.Text = "Access Level";
            // 
            // txtBMenuCategory
            // 
            txtBMenuCategory.Location = new Point(688, 287);
            txtBMenuCategory.Name = "txtBMenuCategory";
            txtBMenuCategory.Size = new Size(100, 23);
            txtBMenuCategory.TabIndex = 24;
            // 
            // lMenuDescription
            // 
            lMenuDescription.AutoSize = true;
            lMenuDescription.Location = new Point(609, 290);
            lMenuDescription.Name = "lMenuDescription";
            lMenuDescription.Size = new Size(55, 15);
            lMenuDescription.TabIndex = 23;
            lMenuDescription.Text = "Category";
            // 
            // txtBMenuDiscount
            // 
            txtBMenuDiscount.Location = new Point(688, 258);
            txtBMenuDiscount.Name = "txtBMenuDiscount";
            txtBMenuDiscount.Size = new Size(100, 23);
            txtBMenuDiscount.TabIndex = 22;
            // 
            // lMenuDiscount
            // 
            lMenuDiscount.AutoSize = true;
            lMenuDiscount.Location = new Point(609, 261);
            lMenuDiscount.Name = "lMenuDiscount";
            lMenuDiscount.Size = new Size(54, 15);
            lMenuDiscount.TabIndex = 21;
            lMenuDiscount.Text = "Discount";
            // 
            // txtBMenuCost
            // 
            txtBMenuCost.Location = new Point(688, 229);
            txtBMenuCost.Name = "txtBMenuCost";
            txtBMenuCost.Size = new Size(100, 23);
            txtBMenuCost.TabIndex = 20;
            // 
            // lMenuCost
            // 
            lMenuCost.AutoSize = true;
            lMenuCost.Location = new Point(609, 232);
            lMenuCost.Name = "lMenuCost";
            lMenuCost.Size = new Size(31, 15);
            lMenuCost.TabIndex = 19;
            lMenuCost.Text = "Cost";
            // 
            // txtBMenuName
            // 
            txtBMenuName.Location = new Point(688, 200);
            txtBMenuName.Name = "txtBMenuName";
            txtBMenuName.Size = new Size(100, 23);
            txtBMenuName.TabIndex = 18;
            // 
            // lMenuName
            // 
            lMenuName.AutoSize = true;
            lMenuName.Location = new Point(609, 203);
            lMenuName.Name = "lMenuName";
            lMenuName.Size = new Size(39, 15);
            lMenuName.TabIndex = 17;
            lMenuName.Text = "Name";
            // 
            // btnMenuRead
            // 
            btnMenuRead.Location = new Point(688, 171);
            btnMenuRead.Name = "btnMenuRead";
            btnMenuRead.Size = new Size(75, 23);
            btnMenuRead.TabIndex = 16;
            btnMenuRead.Text = "Read";
            btnMenuRead.UseVisualStyleBackColor = true;
            btnMenuRead.Click += btnMenuRead_Click;
            // 
            // lMenu
            // 
            lMenu.AutoSize = true;
            lMenu.Location = new Point(609, 175);
            lMenu.Name = "lMenu";
            lMenu.Size = new Size(38, 15);
            lMenu.TabIndex = 15;
            lMenu.Text = "Menu";
            // 
            // txtBMenuDescription
            // 
            txtBMenuDescription.Location = new Point(688, 316);
            txtBMenuDescription.Name = "txtBMenuDescription";
            txtBMenuDescription.Size = new Size(100, 23);
            txtBMenuDescription.TabIndex = 26;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(609, 316);
            label11.Name = "label11";
            label11.Size = new Size(67, 15);
            label11.TabIndex = 25;
            label11.Text = "Description";
            // 
            // txtBID
            // 
            txtBID.Location = new Point(350, 169);
            txtBID.Name = "txtBID";
            txtBID.Size = new Size(100, 23);
            txtBID.TabIndex = 28;
            // 
            // lID
            // 
            lID.AutoSize = true;
            lID.Location = new Point(326, 174);
            lID.Name = "lID";
            lID.Size = new Size(18, 15);
            lID.TabIndex = 27;
            lID.Text = "ID";
            // 
            // btnCreateUser
            // 
            btnCreateUser.Location = new Point(12, 316);
            btnCreateUser.Name = "btnCreateUser";
            btnCreateUser.Size = new Size(75, 23);
            btnCreateUser.TabIndex = 29;
            btnCreateUser.Text = "Create User";
            btnCreateUser.UseVisualStyleBackColor = true;
            btnCreateUser.Click += btnCreateUser_Click;
            // 
            // btnCreateMenu
            // 
            btnCreateMenu.Location = new Point(609, 345);
            btnCreateMenu.Name = "btnCreateMenu";
            btnCreateMenu.Size = new Size(89, 23);
            btnCreateMenu.TabIndex = 30;
            btnCreateMenu.Text = "Create Menu";
            btnCreateMenu.UseVisualStyleBackColor = true;
            btnCreateMenu.Click += btnCreateMenu_Click;
            // 
            // lCurrentViewSelected
            // 
            lCurrentViewSelected.AutoSize = true;
            lCurrentViewSelected.Location = new Point(326, 197);
            lCurrentViewSelected.Name = "lCurrentViewSelected";
            lCurrentViewSelected.Size = new Size(142, 15);
            lCurrentViewSelected.TabIndex = 31;
            lCurrentViewSelected.Text = "Users is currently selected";
            // 
            // ADPAdmin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lCurrentViewSelected);
            Controls.Add(btnCreateMenu);
            Controls.Add(btnCreateUser);
            Controls.Add(txtBID);
            Controls.Add(lID);
            Controls.Add(txtBMenuDescription);
            Controls.Add(label11);
            Controls.Add(txtBMenuCategory);
            Controls.Add(lMenuDescription);
            Controls.Add(txtBMenuDiscount);
            Controls.Add(lMenuDiscount);
            Controls.Add(txtBMenuCost);
            Controls.Add(lMenuCost);
            Controls.Add(txtBMenuName);
            Controls.Add(lMenuName);
            Controls.Add(btnMenuRead);
            Controls.Add(lMenu);
            Controls.Add(txtBUsersAccessLevel);
            Controls.Add(lUsersAccessLevel);
            Controls.Add(txtBUsersRole);
            Controls.Add(lUsersRole);
            Controls.Add(txtBUsersPassword);
            Controls.Add(lUsersPassword);
            Controls.Add(txtBUsersName);
            Controls.Add(lUsersName);
            Controls.Add(btnUsersRead);
            Controls.Add(lUsers);
            Controls.Add(dataGridView1);
            Name = "ADPAdmin";
            Text = "ADPAdmin";
            FormClosed += ADPAdmin_FormClosed;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Label lUsers;
        private Button btnUsersRead;
        private Label lUsersName;
        private TextBox txtBUsersName;
        private TextBox txtBUsersPassword;
        private Label lUsersPassword;
        private TextBox txtBUsersRole;
        private Label lUsersRole;
        private TextBox txtBUsersAccessLevel;
        private Label lUsersAccessLevel;
        private TextBox txtBMenuCategory;
        private Label lMenuDescription;
        private TextBox txtBMenuDiscount;
        private Label lMenuDiscount;
        private TextBox txtBMenuCost;
        private Label lMenuCost;
        private TextBox txtBMenuName;
        private Label lMenuName;
        private Button btnMenuRead;
        private Label lMenu;
        private TextBox txtBMenuDescription;
        private Label label11;
        private TextBox txtBID;
        private Label lID;
        private Button btnCreateUser;
        private Button btnCreateMenu;
        private Label lCurrentViewSelected;
    }
}