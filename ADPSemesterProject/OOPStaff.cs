using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.SQLite;

namespace ADPSemesterProject
{
    public partial class OOPStaff : Form
    {
        public string username = "";
        public int accessLevel = 2;
        public string password = "";
        public Form parent;
        public SQLiteConnection conn = new SQLiteConnection("Data Source=semester.db;");
        string currentView = "tables";

        public OOPStaff(string username, int accessLevel, string password, Form parent)
        {
            InitializeComponent();
            this.username = username;
            this.accessLevel = accessLevel;
            this.password = password;
            this.parent = parent;
            this.BackColor = parent.BackColor;
            DisplayContent("tablesCollection");
        }
        public void DisplayContent(string collectionName)
        {
            DataTable dt = new DataTable();
            switch (collectionName)
            {
                case "menuCollection":

                    using (SQLiteCommand cmd = new SQLiteCommand(conn))
                    {
                        cmd.CommandText = "select * from orders";
                        conn.Open();
                        SQLiteDataAdapter ad = new SQLiteDataAdapter(cmd);
                        ad.Fill(dt);
                        ad.Dispose();
                    }
                    conn.Close();
                    dataGridView1.DataSource = dt;
                    break;
                case "ordersCollection":
                    currentView = "order";
                    lCurrentViewSelected.Text = "Orders is currently selected";
                    using (SQLiteCommand cmd = new SQLiteCommand(conn))
                    {
                        cmd.CommandText = "select * from orders";
                        conn.Open();
                        SQLiteDataAdapter ad = new SQLiteDataAdapter(cmd);
                        ad.Fill(dt);
                        ad.Dispose();
                    }
                    conn.Close();
                    dataGridView1.DataSource = dt;
                    btnCreate.Enabled = true;
                    btnUpdate.Enabled = false;
                    btnDelete.Enabled = true;
                    btnReadOrderItems.Enabled = true;
                    btnOrderItemsCreate.Enabled = false;
                    btnOrderItemsDelete.Enabled = false;
                    chkBDiscounted.Enabled = false;
                    break;
                case "staffCollection":
                    currentView = "user";
                    lCurrentViewSelected.Text = "Users is currently selected";
                    using (SQLiteCommand cmd = new SQLiteCommand(conn))
                    {
                        cmd.CommandText = "select * from staff";
                        conn.Open();
                        SQLiteDataAdapter ad = new SQLiteDataAdapter(cmd);
                        ad.Fill(dt);
                        ad.Dispose();
                    }
                    conn.Close();
                    dataGridView1.DataSource = dt;
                    break;
                case "tablesCollection":
                    currentView = "tables";
                    lCurrentViewSelected.Text = "Tables is currently selected";
                    using (SQLiteCommand cmd = new SQLiteCommand(conn))
                    {
                        cmd.CommandText = "select * from tables";
                        conn.Open();
                        SQLiteDataAdapter ad = new SQLiteDataAdapter(cmd);
                        ad.Fill(dt);
                        ad.Dispose();
                    }
                    conn.Close();
                    dataGridView1.DataSource = dt;
                    btnCreate.Enabled = true;
                    btnUpdate.Enabled = true;
                    btnDelete.Enabled = true;
                    btnReadOrderItems.Enabled = false;
                    btnOrderItemsCreate.Enabled = false;
                    btnOrderItemsDelete.Enabled = false;
                    chkBDiscounted.Enabled = false;
                    break;
                case "filteredUsersProjectionManagement":
                    currentView = "user";
                    lCurrentViewSelected.Text = "Users is currently selected";
                    using (SQLiteCommand cmd = new SQLiteCommand(conn))
                    {
                        cmd.CommandText = $"select * from staff where Name = '{username}' and Password = '{password}'";
                        conn.Open();
                        SQLiteDataAdapter ad = new SQLiteDataAdapter(cmd);
                        ad.Fill(dt);
                        ad.Dispose();
                    }
                    conn.Close();
                    dataGridView1.DataSource = dt;
                    btnCreate.Enabled = false;
                    btnUpdate.Enabled = true;
                    btnDelete.Enabled = false;
                    btnReadOrderItems.Enabled = false;
                    btnOrderItemsCreate.Enabled = false;
                    btnOrderItemsDelete.Enabled = false;
                    chkBDiscounted.Enabled = false;
                    break;
                case "itemsOrderedCollection":
                    currentView = "itemsordered";
                    lCurrentViewSelected.Text = "Order Items is currently selected";
                    int id;
                    if (!int.TryParse(txtBID.Text, out id))
                    {
                        DisplayError("invalidID", txtBID.Text);
                        DisplayContent("ordersCollection");
                        break;
                    }
                    using (SQLiteCommand cmd = new SQLiteCommand(conn))
                    {
                        cmd.CommandText = $"select * from itemsordered where ordersForeignKey = {id}";
                        conn.Open();
                        SQLiteDataAdapter ad = new SQLiteDataAdapter(cmd);
                        ad.Fill(dt);
                        ad.Dispose();
                    }
                    conn.Close();
                    dataGridView1.DataSource = dt;
                    btnCreate.Enabled = false;
                    btnUpdate.Enabled = false;
                    btnDelete.Enabled = false;
                    btnOrderItemsCreate.Enabled = true;
                    btnOrderItemsDelete.Enabled = true;
                    btnReadOrderItems.Enabled = true;
                    chkBDiscounted.Enabled = true;
                    break;
                default:
                    MessageBox.Show("No known collection called " + collectionName);
                    break;
            }

        }
        public void DisplayErrorUnknownSelectionHandler(EventArgs e)
        {
            if (e.ToString() == null)
            {
                DisplayError("unknownSelection", "null");

            }
            else
            {
                DisplayError("unknownSelection", e.ToString());
            }
        }
        public void DisplayError(string er, string passthrough = "")
        {
            switch (er)
            {
                case "accessLevelParseError":
                    MessageBox.Show("The Access Level needs to be a whole number!");
                    break;
                case "accessLevelOutOfRangeError":
                    MessageBox.Show("Access level must be 0, 1, or 2");
                    break;
                case "menuCostParseError":
                    MessageBox.Show("Menu Cost must be a number!");
                    break;
                case "menuDiscountParseError":
                    MessageBox.Show("Discount must be a number!");
                    break;
                case "menuDiscountOutOfRangeError":
                    MessageBox.Show("Discount can't be greater than 1!");
                    break;
                case "unknownSelection":
                    MessageBox.Show($"Unkown selection made: {passthrough}");
                    break;
                case "invalidID":
                    MessageBox.Show($"invalid ID: {passthrough}");
                    break;

                default:
                    MessageBox.Show($"Unknown error: {er}");
                    break;

            }
        }






        private void btnOrderItemsDelete_Click(object sender, EventArgs e)
        {
            //get the item that you want to delete
            ObjectId foreignKey;
            if (!ObjectId.TryParse(txtBID.Text, out foreignKey))
            {
                DisplayError("invalidID", txtBID.Text);
                return;
            }
            var filterGetItemOrdered = Builders<ItemsOrdered>.Filter.Eq("ID", foreignKey);
            List<ItemsOrdered> itemOrderedList = itemsOrderedCollection.Find(filterGetItemOrdered).ToList();
            if (itemOrderedList.Count == 0)
            {
                DisplayError("invalidID", txtBID.Text);
                return;
            }
            //get the orders collection based on the itemOrder foreign key, we need to make a new total cost
            var filterGetOrder = Builders<Orders>.Filter.Eq("ID", itemOrderedList[0].OrdersForeignKey);
            List<Orders> ordersList = ordersCollection.Find(filterGetOrder).ToList();
            if (ordersList.Count == 0)
            {
                DisplayError("orphanedItem", txtBID.Text);
                return;
            }
            //now that I have all the information i need, and errors probably won't happen due to user error, delete that item
            itemsOrderedCollection.DeleteOne(filterGetItemOrdered);

            double toSubtract = itemOrderedList[0].Cost;
            double newTotal = ordersList[0].TotalCost - toSubtract;
            //Update the orders collection using the new total cost
            var updateUpdateTotalCost = Builders<Orders>.Update.Set("TotalCost", newTotal);
            ordersCollection.UpdateOne(filterGetOrder, updateUpdateTotalCost);
            DisplayContent("ordersCollection");
        }

        private void btnPrintBill_Click(object sender, EventArgs e)
        {
            ObjectId orderId;
            if (!ObjectId.TryParse(txtBID.Text, out orderId))
            {
                DisplayError("invalidID", txtBID.Text);
                return;
            }
            var ordersFilter = Builders<Orders>.Filter.Eq("ID", orderId);
            List<Orders> filteredOrders = ordersCollection.Find(ordersFilter).ToList();
            if (filteredOrders.Count == 0)
            {
                DisplayError("invalidID", txtBID.Text);
                return;
            }
            var orderItemsFilter = Builders<ItemsOrdered>.Filter.Eq("OrdersForeignKey", orderId);
            List<ItemsOrdered> filteredItemsOrdered = itemsOrderedCollection.Find(orderItemsFilter).ToList();
            string receipt = "ORDER: ";
            receipt += filteredOrders[0].ID + "\n";
            foreach (var item in filteredItemsOrdered)
            {
                receipt += $"{item.Name}: {item.Cost}$\n";
            }
            receipt += "Total: " + filteredOrders[0].TotalCost + "$";
            MessageBox.Show(receipt);
        }

        private void OOPStaff_FormClosed(object sender, FormClosedEventArgs e)
        {
            parent.Show();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //This is to handle if the user clicks the column selecter, which doesn't have any use here.
            if (e.RowIndex == -1)
            {
                return;
            }
            switch (currentView)
            {
                case "order":
                    txtBID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                    txtBTableOrderId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                    break;
                case "itemsordered":
                    switch (e.ColumnIndex)
                    {
                        case 0:
                            txtBID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                            break;
                        case 1:
                            txtBOrderItemsName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                            break;
                        case 2:
                            chkBDiscounted.Checked = bool.Parse(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                            break;
                        case 3:
                            txtBID.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                            break;
                        case -1:
                            txtBID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                            txtBOrderItemsName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                            chkBDiscounted.Checked = bool.Parse(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                            break;
                    }
                    break;
                case "tables":
                    switch (e.ColumnIndex)
                    {
                        case 0:
                            txtBID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                            break;
                        case 1:
                            txtBTableStatus.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                            break;
                        case 2:
                            txtBTableOrderStatus.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                            break;
                        case 3:
                            txtBTableOrderId.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                            txtBID.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                            break;
                        case -1:
                            txtBID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                            txtBTableStatus.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                            txtBTableOrderStatus.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                            txtBTableOrderId.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
        }

        private void btnTableRead_Click(object sender, EventArgs e)
        {
            DisplayContent("tablesCollection");
        }

        private void btnOrdersRead_Click(object sender, EventArgs e)
        {
            DisplayContent("ordersCollection");
        }

        private void btnReadOrderItems_Click(object sender, EventArgs e)
        {
            DisplayContent("itemsOrderedCollection");
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            switch (currentView)
            {
                case "order":
                    using (var cmd = new SQLiteCommand(conn))
                    {
                        cmd.CommandText = $"insert into orders (ItemsOrdered) Values (0.0);";
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    conn.Close();
                    DisplayContent("ordersCollection");
                    break;
                case "tables":
                    int foreignKey;
                    if (!int.TryParse(txtBTableOrderId.Text, out foreignKey))
                    {
                        DisplayError("invalidID", txtBID.Text);
                        break;
                    }
                    using (var cmd = new SQLiteCommand(conn))
                    {
                        cmd.CommandText = $"insert into tables (TableStatus, OrderStatus, OrdersId) Values ('{txtBTableStatus.Text}', '{txtBTableOrderStatus.Text}', {foreignKey});";
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    conn.Close();
                    DisplayContent("tablesCollection");
                    break;
                default:
                    DisplayErrorUnknownSelectionHandler(e);
                    break;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id;
            if (!int.TryParse(txtBID.Text, out id))
            {
                DisplayError("invalidID", txtBID.Text);
                return;
            }
            switch (currentView)
            {
                case "order":
                    using (SQLiteCommand cmd = new SQLiteCommand(conn))
                    {
                        cmd.CommandText = $"delete from orders where _id = {id}";
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    conn.Close();
                    using (SQLiteCommand cmd = new SQLiteCommand(conn))
                    {
                        cmd.CommandText = $"delete from itemsordered where ordersForeignKey = {id}";
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    conn.Close();
                    DisplayContent("ordersCollection");
                    break;
                default:
                    DisplayErrorUnknownSelectionHandler(e);
                    break;

            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id;
            if (!int.TryParse(txtBID.Text, out id))
            {
                DisplayError("invalidID", txtBID.Text);
                return;
            }
            switch (currentView)
            {
                case "tables":
                    int foreignKey = -1;
                    int.TryParse(txtBTableOrderId.Text, out foreignKey);
                    using (SQLiteCommand cmd = new SQLiteCommand(conn))
                    {
                        cmd.CommandText = $"update tables set TableStatus = '{txtBTableStatus.Text}', OrderStatus = '{txtBTableOrderStatus.Text}', OrdersId = {foreignKey} where _id = {id};";
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    conn.Close();
                    DisplayContent("tablesCollection");
                    break;

                default:
                    DisplayErrorUnknownSelectionHandler(e);
                    break;
            }
        }

        private void btnOrderItemsCreate_Click(object sender, EventArgs e)
        {
            //make sure foreign key exists in orders table, get discount price from menu table, insert new items ordered, update orders total cost.
            DataTable dt = new DataTable();
            double orderTotalCost = 0.0;
            double discountAmount = 0.0;
            double itemCost = 0.0;
            double finalItemCost;
            int foreignKey;
            if (!int.TryParse(txtBID.Text, out foreignKey))
            {
                DisplayError("invalidID", txtBID.Text);
                return;
            }
            using (SQLiteCommand cmd = new SQLiteCommand(conn))
            {
                cmd.CommandText = $"select * from orders where _id = {foreignKey}";
                conn.Open();
                SQLiteDataAdapter ad = new SQLiteDataAdapter(cmd);
                ad.Fill(dt);
                ad.Dispose();
            }
            conn.Close();
            if (dt.Rows.Count == 0)
            {
                DisplayError("orphanedItem", txtBID.Text);
                return;
            }
            foreach (DataRow row in dt.Rows)
            {
                orderTotalCost = double.Parse(row.ItemArray[1].ToString());
            }
            dt.Clear();
            //get the discount amount and cost from menu
            using (SQLiteCommand cmd = new SQLiteCommand(conn))
            {
                cmd.CommandText = $"select * from menu where Name = '{txtBOrderItemsName.Text}'";
                conn.Open();
                SQLiteDataAdapter ad = new SQLiteDataAdapter(cmd);
                ad.Fill(dt);
                ad.Dispose();
            }
            conn.Close();
            if (dt.Rows.Count == 0)
            {
                DisplayError("badItemName", txtBOrderItemsName.Text);
                return;
            }
            foreach (DataRow row in dt.Rows)
            {
                itemCost = double.Parse(row.ItemArray[3].ToString());
                discountAmount = double.Parse(row.ItemArray[4].ToString());
            }
            dt.Clear();
            if (chkBDiscounted.Checked)
            {
                finalItemCost = double.Round(itemCost - (itemCost * discountAmount), 2);
            }
            else
            {
                finalItemCost = double.Round(itemCost, 2);
            }
            orderTotalCost += finalItemCost;
            //insert new itemsordered
            using (var cmd = new SQLiteCommand(conn))
            {
                cmd.CommandText = $"insert into itemsordered (Name, discounted, cost, ordersForeignKey) Values ('{txtBOrderItemsName.Text}', {chkBDiscounted.Checked}, {finalItemCost}, {foreignKey});";
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            conn.Close();
            //update orders
            using (SQLiteCommand cmd = new SQLiteCommand(conn))
            {
                cmd.CommandText = $"update orders set ItemsOrdered = {orderTotalCost} where _id = {foreignKey};";
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            conn.Close();
            DisplayContent("ordersCollection");
        }
    }
}

