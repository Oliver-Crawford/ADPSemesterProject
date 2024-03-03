namespace ADPSemesterProject
{
    partial class OOPStaff
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
            btnPrintBill = new Button();
            txtBTableOrderId = new TextBox();
            label9 = new Label();
            txtBTableOrderStatus = new TextBox();
            label8 = new Label();
            txtBTableStatus = new TextBox();
            label7 = new Label();
            btnTableRead = new Button();
            label6 = new Label();
            label5 = new Label();
            btnReadOrderItems = new Button();
            chkBDiscounted = new CheckBox();
            label4 = new Label();
            btnOrderItemsDelete = new Button();
            btnOrderItemsCreate = new Button();
            txtBOrderItemsName = new TextBox();
            label3 = new Label();
            btnOrdersRead = new Button();
            label2 = new Label();
            btnDelete = new Button();
            btnCreate = new Button();
            btnUpdate = new Button();
            label1 = new Label();
            lCurrentViewSelected = new Label();
            txtBID = new TextBox();
            lID = new Label();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // btnPrintBill
            // 
            btnPrintBill.Location = new Point(375, 321);
            btnPrintBill.Name = "btnPrintBill";
            btnPrintBill.Size = new Size(75, 23);
            btnPrintBill.TabIndex = 146;
            btnPrintBill.Text = "Print Bill";
            btnPrintBill.UseVisualStyleBackColor = true;
            // 
            // txtBTableOrderId
            // 
            txtBTableOrderId.Location = new Point(688, 260);
            txtBTableOrderId.Name = "txtBTableOrderId";
            txtBTableOrderId.Size = new Size(100, 23);
            txtBTableOrderId.TabIndex = 145;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(609, 263);
            label9.Name = "label9";
            label9.Size = new Size(51, 15);
            label9.TabIndex = 144;
            label9.Text = "Order ID";
            // 
            // txtBTableOrderStatus
            // 
            txtBTableOrderStatus.Location = new Point(688, 231);
            txtBTableOrderStatus.Name = "txtBTableOrderStatus";
            txtBTableOrderStatus.Size = new Size(100, 23);
            txtBTableOrderStatus.TabIndex = 143;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(609, 234);
            label8.Name = "label8";
            label8.Size = new Size(72, 15);
            label8.TabIndex = 142;
            label8.Text = "Order Status";
            // 
            // txtBTableStatus
            // 
            txtBTableStatus.Location = new Point(688, 202);
            txtBTableStatus.Name = "txtBTableStatus";
            txtBTableStatus.Size = new Size(100, 23);
            txtBTableStatus.TabIndex = 141;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(609, 205);
            label7.Name = "label7";
            label7.Size = new Size(69, 15);
            label7.TabIndex = 140;
            label7.Text = "Table Status";
            // 
            // btnTableRead
            // 
            btnTableRead.Location = new Point(688, 173);
            btnTableRead.Name = "btnTableRead";
            btnTableRead.Size = new Size(75, 23);
            btnTableRead.TabIndex = 139;
            btnTableRead.Text = "Read";
            btnTableRead.UseVisualStyleBackColor = true;
            btnTableRead.Click += btnTableRead_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(609, 177);
            label6.Name = "label6";
            label6.Size = new Size(39, 15);
            label6.TabIndex = 138;
            label6.Text = "Tables";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(13, 202);
            label5.Name = "label5";
            label5.Size = new Size(94, 15);
            label5.TabIndex = 137;
            label5.Text = "View items by ID";
            // 
            // btnReadOrderItems
            // 
            btnReadOrderItems.Location = new Point(108, 197);
            btnReadOrderItems.Name = "btnReadOrderItems";
            btnReadOrderItems.Size = new Size(75, 23);
            btnReadOrderItems.TabIndex = 136;
            btnReadOrderItems.Text = "Read";
            btnReadOrderItems.UseVisualStyleBackColor = true;
            btnReadOrderItems.Click += btnReadOrderItems_Click;
            // 
            // chkBDiscounted
            // 
            chkBDiscounted.AutoSize = true;
            chkBDiscounted.Location = new Point(108, 255);
            chkBDiscounted.Name = "chkBDiscounted";
            chkBDiscounted.Size = new Size(86, 19);
            chkBDiscounted.TabIndex = 135;
            chkBDiscounted.Text = "Discounted";
            chkBDiscounted.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(29, 238);
            label4.Name = "label4";
            label4.Size = new Size(36, 15);
            label4.TabIndex = 134;
            label4.Text = "Items";
            // 
            // btnOrderItemsDelete
            // 
            btnOrderItemsDelete.Location = new Point(108, 309);
            btnOrderItemsDelete.Name = "btnOrderItemsDelete";
            btnOrderItemsDelete.Size = new Size(75, 23);
            btnOrderItemsDelete.TabIndex = 133;
            btnOrderItemsDelete.Text = "Delete";
            btnOrderItemsDelete.UseVisualStyleBackColor = true;
            // 
            // btnOrderItemsCreate
            // 
            btnOrderItemsCreate.Location = new Point(108, 280);
            btnOrderItemsCreate.Name = "btnOrderItemsCreate";
            btnOrderItemsCreate.Size = new Size(75, 23);
            btnOrderItemsCreate.TabIndex = 132;
            btnOrderItemsCreate.Text = "Create";
            btnOrderItemsCreate.UseVisualStyleBackColor = true;
            // 
            // txtBOrderItemsName
            // 
            txtBOrderItemsName.Location = new Point(108, 226);
            txtBOrderItemsName.Name = "txtBOrderItemsName";
            txtBOrderItemsName.Size = new Size(100, 23);
            txtBOrderItemsName.TabIndex = 131;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(25, 226);
            label3.Name = "label3";
            label3.Size = new Size(52, 15);
            label3.TabIndex = 130;
            label3.Text = "To Order";
            // 
            // btnOrdersRead
            // 
            btnOrdersRead.Location = new Point(108, 168);
            btnOrdersRead.Name = "btnOrdersRead";
            btnOrdersRead.Size = new Size(75, 23);
            btnOrdersRead.TabIndex = 129;
            btnOrdersRead.Text = "Read";
            btnOrdersRead.UseVisualStyleBackColor = true;
            btnOrdersRead.Click += btnOrdersRead_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(29, 172);
            label2.Name = "label2";
            label2.Size = new Size(42, 15);
            label2.TabIndex = 128;
            label2.Text = "Orders";
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(375, 292);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 127;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnCreate
            // 
            btnCreate.Location = new Point(375, 214);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(75, 23);
            btnCreate.TabIndex = 126;
            btnCreate.Text = "Create";
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Click += btnCreate_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(375, 263);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(75, 23);
            btnUpdate.TabIndex = 125;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(351, 240);
            label1.Name = "label1";
            label1.Size = new Size(34, 15);
            label1.TabIndex = 124;
            label1.Text = "By ID";
            // 
            // lCurrentViewSelected
            // 
            lCurrentViewSelected.AutoSize = true;
            lCurrentViewSelected.Location = new Point(351, 196);
            lCurrentViewSelected.Name = "lCurrentViewSelected";
            lCurrentViewSelected.Size = new Size(146, 15);
            lCurrentViewSelected.TabIndex = 123;
            lCurrentViewSelected.Text = "Tables is currently selected";
            // 
            // txtBID
            // 
            txtBID.Location = new Point(375, 168);
            txtBID.Name = "txtBID";
            txtBID.Size = new Size(100, 23);
            txtBID.TabIndex = 122;
            // 
            // lID
            // 
            lID.AutoSize = true;
            lID.Location = new Point(351, 173);
            lID.Name = "lID";
            lID.Size = new Size(18, 15);
            lID.TabIndex = 121;
            lID.Text = "ID";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(776, 150);
            dataGridView1.TabIndex = 120;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // OOPStaff
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnPrintBill);
            Controls.Add(txtBTableOrderId);
            Controls.Add(label9);
            Controls.Add(txtBTableOrderStatus);
            Controls.Add(label8);
            Controls.Add(txtBTableStatus);
            Controls.Add(label7);
            Controls.Add(btnTableRead);
            Controls.Add(label6);
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
            Controls.Add(dataGridView1);
            Name = "OOPStaff";
            Text = "OOPStaff";
            FormClosed += OOPStaff_FormClosed;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnPrintBill;
        private TextBox txtBTableOrderId;
        private Label label9;
        private TextBox txtBTableOrderStatus;
        private Label label8;
        private TextBox txtBTableStatus;
        private Label label7;
        private Button btnTableRead;
        private Label label6;
        private Label label5;
        private Button btnReadOrderItems;
        private CheckBox chkBDiscounted;
        private Label label4;
        private Button btnOrderItemsDelete;
        private Button btnOrderItemsCreate;
        private TextBox txtBOrderItemsName;
        private Label label3;
        private Button btnOrdersRead;
        private Label label2;
        private Button btnDelete;
        private Button btnCreate;
        private Button btnUpdate;
        private Label label1;
        private Label lCurrentViewSelected;
        private TextBox txtBID;
        private Label lID;
        private DataGridView dataGridView1;
    }
}