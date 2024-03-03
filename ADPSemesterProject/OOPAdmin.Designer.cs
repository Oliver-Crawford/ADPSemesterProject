namespace ADPSemesterProject
{
    partial class OOPAdmin
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
            btnDelete = new Button();
            btnUpdate = new Button();
            label1 = new Label();
            btnCreate = new Button();
            lCurrentViewSelected = new Label();
            txtBID = new TextBox();
            lID = new Label();
            txtBMenuDescription = new TextBox();
            label11 = new Label();
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
            txtBUsersAccessLevel = new TextBox();
            lUsersAccessLevel = new Label();
            txtBUsersRole = new TextBox();
            lUsersRole = new Label();
            txtBUsersPassword = new TextBox();
            lUsersPassword = new Label();
            txtBUsersName = new TextBox();
            lUsersName = new Label();
            btnUsersRead = new Button();
            lUsers = new Label();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(350, 288);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 65;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(350, 259);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(75, 23);
            btnUpdate.TabIndex = 64;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(326, 241);
            label1.Name = "label1";
            label1.Size = new Size(34, 15);
            label1.TabIndex = 63;
            label1.Text = "By ID";
            // 
            // btnCreate
            // 
            btnCreate.Location = new Point(350, 215);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(75, 23);
            btnCreate.TabIndex = 62;
            btnCreate.Text = "Create";
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Click += btnCreate_Click;
            // 
            // lCurrentViewSelected
            // 
            lCurrentViewSelected.AutoSize = true;
            lCurrentViewSelected.Location = new Point(326, 197);
            lCurrentViewSelected.Name = "lCurrentViewSelected";
            lCurrentViewSelected.Size = new Size(142, 15);
            lCurrentViewSelected.TabIndex = 61;
            lCurrentViewSelected.Text = "Users is currently selected";
            // 
            // txtBID
            // 
            txtBID.Location = new Point(350, 169);
            txtBID.Name = "txtBID";
            txtBID.Size = new Size(100, 23);
            txtBID.TabIndex = 60;
            // 
            // lID
            // 
            lID.AutoSize = true;
            lID.Location = new Point(326, 174);
            lID.Name = "lID";
            lID.Size = new Size(18, 15);
            lID.TabIndex = 59;
            lID.Text = "ID";
            // 
            // txtBMenuDescription
            // 
            txtBMenuDescription.Location = new Point(688, 316);
            txtBMenuDescription.Name = "txtBMenuDescription";
            txtBMenuDescription.Size = new Size(100, 23);
            txtBMenuDescription.TabIndex = 58;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(609, 316);
            label11.Name = "label11";
            label11.Size = new Size(67, 15);
            label11.TabIndex = 57;
            label11.Text = "Description";
            // 
            // txtBMenuCategory
            // 
            txtBMenuCategory.Location = new Point(688, 287);
            txtBMenuCategory.Name = "txtBMenuCategory";
            txtBMenuCategory.Size = new Size(100, 23);
            txtBMenuCategory.TabIndex = 56;
            // 
            // lMenuDescription
            // 
            lMenuDescription.AutoSize = true;
            lMenuDescription.Location = new Point(609, 290);
            lMenuDescription.Name = "lMenuDescription";
            lMenuDescription.Size = new Size(55, 15);
            lMenuDescription.TabIndex = 55;
            lMenuDescription.Text = "Category";
            // 
            // txtBMenuDiscount
            // 
            txtBMenuDiscount.Location = new Point(688, 258);
            txtBMenuDiscount.Name = "txtBMenuDiscount";
            txtBMenuDiscount.Size = new Size(100, 23);
            txtBMenuDiscount.TabIndex = 54;
            // 
            // lMenuDiscount
            // 
            lMenuDiscount.AutoSize = true;
            lMenuDiscount.Location = new Point(609, 261);
            lMenuDiscount.Name = "lMenuDiscount";
            lMenuDiscount.Size = new Size(54, 15);
            lMenuDiscount.TabIndex = 53;
            lMenuDiscount.Text = "Discount";
            // 
            // txtBMenuCost
            // 
            txtBMenuCost.Location = new Point(688, 229);
            txtBMenuCost.Name = "txtBMenuCost";
            txtBMenuCost.Size = new Size(100, 23);
            txtBMenuCost.TabIndex = 52;
            // 
            // lMenuCost
            // 
            lMenuCost.AutoSize = true;
            lMenuCost.Location = new Point(609, 232);
            lMenuCost.Name = "lMenuCost";
            lMenuCost.Size = new Size(31, 15);
            lMenuCost.TabIndex = 51;
            lMenuCost.Text = "Cost";
            // 
            // txtBMenuName
            // 
            txtBMenuName.Location = new Point(688, 200);
            txtBMenuName.Name = "txtBMenuName";
            txtBMenuName.Size = new Size(100, 23);
            txtBMenuName.TabIndex = 50;
            // 
            // lMenuName
            // 
            lMenuName.AutoSize = true;
            lMenuName.Location = new Point(609, 203);
            lMenuName.Name = "lMenuName";
            lMenuName.Size = new Size(39, 15);
            lMenuName.TabIndex = 49;
            lMenuName.Text = "Name";
            // 
            // btnMenuRead
            // 
            btnMenuRead.Location = new Point(688, 171);
            btnMenuRead.Name = "btnMenuRead";
            btnMenuRead.Size = new Size(75, 23);
            btnMenuRead.TabIndex = 48;
            btnMenuRead.Text = "Read";
            btnMenuRead.UseVisualStyleBackColor = true;
            // 
            // lMenu
            // 
            lMenu.AutoSize = true;
            lMenu.Location = new Point(609, 175);
            lMenu.Name = "lMenu";
            lMenu.Size = new Size(38, 15);
            lMenu.TabIndex = 47;
            lMenu.Text = "Menu";
            // 
            // txtBUsersAccessLevel
            // 
            txtBUsersAccessLevel.Location = new Point(91, 284);
            txtBUsersAccessLevel.Name = "txtBUsersAccessLevel";
            txtBUsersAccessLevel.Size = new Size(100, 23);
            txtBUsersAccessLevel.TabIndex = 46;
            // 
            // lUsersAccessLevel
            // 
            lUsersAccessLevel.AutoSize = true;
            lUsersAccessLevel.Location = new Point(12, 287);
            lUsersAccessLevel.Name = "lUsersAccessLevel";
            lUsersAccessLevel.Size = new Size(73, 15);
            lUsersAccessLevel.TabIndex = 45;
            lUsersAccessLevel.Text = "Access Level";
            // 
            // txtBUsersRole
            // 
            txtBUsersRole.Location = new Point(91, 255);
            txtBUsersRole.Name = "txtBUsersRole";
            txtBUsersRole.Size = new Size(100, 23);
            txtBUsersRole.TabIndex = 44;
            // 
            // lUsersRole
            // 
            lUsersRole.AutoSize = true;
            lUsersRole.Location = new Point(12, 258);
            lUsersRole.Name = "lUsersRole";
            lUsersRole.Size = new Size(30, 15);
            lUsersRole.TabIndex = 43;
            lUsersRole.Text = "Role";
            // 
            // txtBUsersPassword
            // 
            txtBUsersPassword.Location = new Point(91, 226);
            txtBUsersPassword.Name = "txtBUsersPassword";
            txtBUsersPassword.Size = new Size(100, 23);
            txtBUsersPassword.TabIndex = 42;
            // 
            // lUsersPassword
            // 
            lUsersPassword.AutoSize = true;
            lUsersPassword.Location = new Point(12, 229);
            lUsersPassword.Name = "lUsersPassword";
            lUsersPassword.Size = new Size(57, 15);
            lUsersPassword.TabIndex = 41;
            lUsersPassword.Text = "Password";
            // 
            // txtBUsersName
            // 
            txtBUsersName.Location = new Point(91, 197);
            txtBUsersName.Name = "txtBUsersName";
            txtBUsersName.Size = new Size(100, 23);
            txtBUsersName.TabIndex = 40;
            // 
            // lUsersName
            // 
            lUsersName.AutoSize = true;
            lUsersName.Location = new Point(12, 200);
            lUsersName.Name = "lUsersName";
            lUsersName.Size = new Size(39, 15);
            lUsersName.TabIndex = 39;
            lUsersName.Text = "Name";
            // 
            // btnUsersRead
            // 
            btnUsersRead.Location = new Point(91, 168);
            btnUsersRead.Name = "btnUsersRead";
            btnUsersRead.Size = new Size(75, 23);
            btnUsersRead.TabIndex = 38;
            btnUsersRead.Text = "Read";
            btnUsersRead.UseVisualStyleBackColor = true;
            // 
            // lUsers
            // 
            lUsers.AutoSize = true;
            lUsers.Location = new Point(12, 172);
            lUsers.Name = "lUsers";
            lUsers.Size = new Size(35, 15);
            lUsers.TabIndex = 37;
            lUsers.Text = "Users";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(776, 150);
            dataGridView1.TabIndex = 36;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // OOPAdmin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(label1);
            Controls.Add(btnCreate);
            Controls.Add(lCurrentViewSelected);
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
            Name = "OOPAdmin";
            Text = "OOPAdmin";
            FormClosed += OOPAdmin_FormClosed;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnDelete;
        private Button btnUpdate;
        private Label label1;
        private Button btnCreate;
        private Label lCurrentViewSelected;
        private TextBox txtBID;
        private Label lID;
        private TextBox txtBMenuDescription;
        private Label label11;
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
        private TextBox txtBUsersAccessLevel;
        private Label lUsersAccessLevel;
        private TextBox txtBUsersRole;
        private Label lUsersRole;
        private TextBox txtBUsersPassword;
        private Label lUsersPassword;
        private TextBox txtBUsersName;
        private Label lUsersName;
        private Button btnUsersRead;
        private Label lUsers;
        private DataGridView dataGridView1;
    }
}