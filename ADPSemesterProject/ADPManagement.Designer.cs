namespace ADPSemesterProject
{
    partial class ADPManagement
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
            btnUpdate = new Button();
            label1 = new Label();
            lCurrentViewSelected = new Label();
            txtBID = new TextBox();
            lID = new Label();
            txtBUsersRole = new TextBox();
            lUsersRole = new Label();
            btnUsersRead = new Button();
            lUsers = new Label();
            dataGridView1 = new DataGridView();
            btnCreate = new Button();
            btnDelete = new Button();
            label2 = new Label();
            btnOrdersRead = new Button();
            label3 = new Label();
            txtBOrderItemsName = new TextBox();
            btnOrderItemsDelete = new Button();
            btnOrderItemsCreate = new Button();
            label4 = new Label();
            chkBDiscounted = new CheckBox();
            btnReadOrderItems = new Button();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(375, 263);
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
            label1.Location = new Point(351, 240);
            label1.Name = "label1";
            label1.Size = new Size(34, 15);
            label1.TabIndex = 63;
            label1.Text = "By ID";
            // 
            // lCurrentViewSelected
            // 
            lCurrentViewSelected.AutoSize = true;
            lCurrentViewSelected.Location = new Point(351, 196);
            lCurrentViewSelected.Name = "lCurrentViewSelected";
            lCurrentViewSelected.Size = new Size(142, 15);
            lCurrentViewSelected.TabIndex = 61;
            lCurrentViewSelected.Text = "Users is currently selected";
            // 
            // txtBID
            // 
            txtBID.Location = new Point(375, 168);
            txtBID.Name = "txtBID";
            txtBID.Size = new Size(100, 23);
            txtBID.TabIndex = 60;
            // 
            // lID
            // 
            lID.AutoSize = true;
            lID.Location = new Point(351, 173);
            lID.Name = "lID";
            lID.Size = new Size(18, 15);
            lID.TabIndex = 59;
            lID.Text = "ID";
            // 
            // txtBUsersRole
            // 
            txtBUsersRole.Location = new Point(91, 197);
            txtBUsersRole.Name = "txtBUsersRole";
            txtBUsersRole.Size = new Size(100, 23);
            txtBUsersRole.TabIndex = 44;
            // 
            // lUsersRole
            // 
            lUsersRole.AutoSize = true;
            lUsersRole.Location = new Point(12, 200);
            lUsersRole.Name = "lUsersRole";
            lUsersRole.Size = new Size(30, 15);
            lUsersRole.TabIndex = 43;
            lUsersRole.Text = "Role";
            // 
            // btnUsersRead
            // 
            btnUsersRead.Location = new Point(91, 168);
            btnUsersRead.Name = "btnUsersRead";
            btnUsersRead.Size = new Size(75, 23);
            btnUsersRead.TabIndex = 38;
            btnUsersRead.Text = "Read";
            btnUsersRead.UseVisualStyleBackColor = true;
            btnUsersRead.Click += btnUsersRead_Click;
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
            // btnCreate
            // 
            btnCreate.Location = new Point(375, 214);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(75, 23);
            btnCreate.TabIndex = 65;
            btnCreate.Text = "Create";
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Click += btnCreate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(375, 292);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 66;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 252);
            label2.Name = "label2";
            label2.Size = new Size(42, 15);
            label2.TabIndex = 67;
            label2.Text = "Orders";
            // 
            // btnOrdersRead
            // 
            btnOrdersRead.Location = new Point(91, 248);
            btnOrdersRead.Name = "btnOrdersRead";
            btnOrdersRead.Size = new Size(75, 23);
            btnOrdersRead.TabIndex = 68;
            btnOrdersRead.Text = "Read";
            btnOrdersRead.UseVisualStyleBackColor = true;
            btnOrdersRead.Click += btnOrdersRead_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(8, 306);
            label3.Name = "label3";
            label3.Size = new Size(52, 15);
            label3.TabIndex = 71;
            label3.Text = "To Order";
            // 
            // txtBOrderItemsName
            // 
            txtBOrderItemsName.Location = new Point(91, 306);
            txtBOrderItemsName.Name = "txtBOrderItemsName";
            txtBOrderItemsName.Size = new Size(100, 23);
            txtBOrderItemsName.TabIndex = 72;
            // 
            // btnOrderItemsDelete
            // 
            btnOrderItemsDelete.Location = new Point(91, 389);
            btnOrderItemsDelete.Name = "btnOrderItemsDelete";
            btnOrderItemsDelete.Size = new Size(75, 23);
            btnOrderItemsDelete.TabIndex = 74;
            btnOrderItemsDelete.Text = "Delete";
            btnOrderItemsDelete.UseVisualStyleBackColor = true;
            btnOrderItemsDelete.Click += btnOrderItemsDelete_Click;
            // 
            // btnOrderItemsCreate
            // 
            btnOrderItemsCreate.Location = new Point(91, 360);
            btnOrderItemsCreate.Name = "btnOrderItemsCreate";
            btnOrderItemsCreate.Size = new Size(75, 23);
            btnOrderItemsCreate.TabIndex = 73;
            btnOrderItemsCreate.Text = "Create";
            btnOrderItemsCreate.UseVisualStyleBackColor = true;
            btnOrderItemsCreate.Click += btnOrderItemsCreate_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 318);
            label4.Name = "label4";
            label4.Size = new Size(36, 15);
            label4.TabIndex = 75;
            label4.Text = "Items";
            // 
            // chkBDiscounted
            // 
            chkBDiscounted.AutoSize = true;
            chkBDiscounted.Location = new Point(91, 335);
            chkBDiscounted.Name = "chkBDiscounted";
            chkBDiscounted.Size = new Size(86, 19);
            chkBDiscounted.TabIndex = 77;
            chkBDiscounted.Text = "Discounted";
            chkBDiscounted.UseVisualStyleBackColor = true;
            // 
            // btnReadOrderItems
            // 
            btnReadOrderItems.Location = new Point(91, 277);
            btnReadOrderItems.Name = "btnReadOrderItems";
            btnReadOrderItems.Size = new Size(75, 23);
            btnReadOrderItems.TabIndex = 78;
            btnReadOrderItems.Text = "Read";
            btnReadOrderItems.UseVisualStyleBackColor = true;
            btnReadOrderItems.Click += btnReadOrderItems_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(-4, 282);
            label5.Name = "label5";
            label5.Size = new Size(94, 15);
            label5.TabIndex = 80;
            label5.Text = "View items by ID";
            // 
            // ADPManagement
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label5);
            Controls.Add(btnReadOrderItems);
            Controls.Add(chkBDiscounted);
            Controls.Add(label4);
            Controls.Add(btnOrderItemsDelete);
            Controls.Add(btnOrderItemsCreate);
            Controls.Add(txtBOrderItemsName);
            Controls.Add(label3);
            Controls.Add(btnOrdersRead);
            Controls.Add(label2);
            Controls.Add(btnDelete);
            Controls.Add(btnCreate);
            Controls.Add(btnUpdate);
            Controls.Add(label1);
            Controls.Add(lCurrentViewSelected);
            Controls.Add(txtBID);
            Controls.Add(lID);
            Controls.Add(txtBUsersRole);
            Controls.Add(lUsersRole);
            Controls.Add(btnUsersRead);
            Controls.Add(lUsers);
            Controls.Add(dataGridView1);
            Name = "ADPManagement";
            Text = "ADPManagement";
            FormClosed += ADPManagement_FormClosed;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnUpdate;
        private Label label1;
        private Label lCurrentViewSelected;
        private TextBox txtBID;
        private Label lID;
        private TextBox txtBUsersRole;
        private Label lUsersRole;
        private Button btnUsersRead;
        private Label lUsers;
        private DataGridView dataGridView1;
        private Button btnCreate;
        private Button btnDelete;
        private Label label2;
        private Button btnOrdersRead;
        private Label label3;
        private TextBox txtBOrderItemsName;
        private Button btnOrderItemsDelete;
        private Button btnOrderItemsCreate;
        private Label label4;
        private CheckBox chkBDiscounted;
        private Button btnReadOrderItems;
        private Label label5;
    }
}