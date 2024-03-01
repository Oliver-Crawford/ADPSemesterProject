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

namespace ADPSemesterProject
{
    public partial class ADPStaff : Form
    {
        public string username = "";
        public int accessLevel = 2;
        public string password = "";
        public Form parent;
        public static MongoClient dbClient = new MongoClient("mongodb://127.0.0.1:27017");
        public static IMongoDatabase db = dbClient.GetDatabase("semester");
        static IMongoCollection<Menu> menuCollection = db.GetCollection<Menu>("menu");
        static IMongoCollection<Orders> ordersCollection = db.GetCollection<Orders>("orders");
        static IMongoCollection<Staff> staffCollection = db.GetCollection<Staff>("staff");
        static IMongoCollection<Tables> tablesCollection = db.GetCollection<Tables>("tables");
        static IMongoCollection<ItemsOrdered> itemsOrderedCollection = db.GetCollection<ItemsOrdered>("itemsordered");

        string currentView = "tables";
        class Menu
        {
            [BsonId]
            public ObjectId ID { get; set; }
            [BsonElement("Name")]
            public string Name { get; set; }
            [BsonElement("Cost")]
            public double Cost { get; set; }
            [BsonElement("Discount")]
            public double Discount { get; set; }
            [BsonElement("Category")]
            public string Category { get; set; }
            [BsonElement("Description")]
            public string Description { get; set; }
        }
        class Orders
        {
            [BsonId]
            public ObjectId ID { get; set; }
            [BsonElement("ItemsOrdered")]
            public double TotalCost { get; set; }
        }
        class Staff
        {
            [BsonId]
            public ObjectId ID { get; set; }
            [BsonElement("Name")]
            public string Name { get; set; }
            [BsonElement("Password")]
            public string Password { get; set; }
            [BsonElement("Role")]
            public string Role { get; set; }
            [BsonElement("AccessLevel")]
            public int AccessLevel { get; set; }

        }
        class Tables
        {
            [BsonId]
            public ObjectId ID { get; set; }
            [BsonElement("TableStatus")]
            public string TableStatus { get; set; }
            [BsonElement("OrderStatus")]
            public string OrderStatus { get; set; }
            [ForeignKey("OrdersForeignKey")]
            public ObjectId OrdersForeignKey { get; set; }

        }
        class ItemsOrdered
        {
            [BsonId]
            public ObjectId ID { get; set; }
            [BsonElement("Name")]
            public string Name { get; set; }
            [BsonElement("Discounted")]
            public bool Discounted { get; set; }
            [BsonElement("Cost")]
            public double Cost { get; set; }
            [ForeignKey("OrdersForeignKey")]
            public ObjectId OrdersForeignKey { get; set; }
        }

        public ADPStaff(string username, int accessLevel, string password, Form parent)
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
            switch (collectionName)
            {
                case "menuCollection":
                    List<Menu> menuList = menuCollection.AsQueryable().ToList();
                    dataGridView1.DataSource = menuList;
                    break;
                case "ordersCollection":
                    List<Orders> ordersList = ordersCollection.AsQueryable().ToList();
                    dataGridView1.DataSource = ordersList;
                    btnCreate.Enabled = true;
                    btnUpdate.Enabled = false;
                    btnDelete.Enabled = true;
                    btnReadOrderItems.Enabled = true;
                    btnOrderItemsCreate.Enabled = false;
                    btnOrderItemsDelete.Enabled = false;
                    chkBDiscounted.Enabled = false;
                    break;
                case "staffCollection":
                    List<Staff> staffList = staffCollection.AsQueryable().ToList();
                    dataGridView1.DataSource = staffList;
                    break;
                case "tablesCollection":
                    List<Tables> tablesList = tablesCollection.AsQueryable().ToList();
                    dataGridView1.DataSource = tablesList;
                    btnCreate.Enabled = false;
                    btnUpdate.Enabled = true;
                    btnDelete.Enabled = false;
                    btnReadOrderItems.Enabled = false;
                    btnOrderItemsCreate.Enabled = false;
                    btnOrderItemsDelete.Enabled = false;
                    chkBDiscounted.Enabled = false;
                    break;
                case "filteredUsersProjectionManagement":
                    List<Staff> filteredUPM = staffCollection.Find("{}").Project<Staff>("{_id: 1, Name: 1, Role: 1}").ToList();
                    dataGridView1.DataSource = filteredUPM;
                    btnCreate.Enabled = false;
                    btnUpdate.Enabled = true;
                    btnDelete.Enabled = false;
                    btnReadOrderItems.Enabled = false;
                    btnOrderItemsCreate.Enabled = false;
                    btnOrderItemsDelete.Enabled = false;
                    chkBDiscounted.Enabled = false;
                    break;
                case "itemsOrderedCollection":
                    ObjectId itemsOrderedId;
                    if (!ObjectId.TryParse(txtBID.Text, out itemsOrderedId))
                    {
                        DisplayError("invalidID", txtBID.Text);
                        break;
                    }
                    var itemsOrderedBuilder = Builders<ItemsOrdered>.Filter;
                    var itemsOrderedFilter = itemsOrderedBuilder.Eq("OrdersForeignKey", itemsOrderedId);
                    List<ItemsOrdered> filteredOrders = itemsOrderedCollection.Find(itemsOrderedFilter).ToList();
                    dataGridView1.DataSource = filteredOrders;
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
        private void ADPStaff_FormClosed(object sender, FormClosedEventArgs e)
        {
            parent.Show();
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

        private void btnTableRead_Click(object sender, EventArgs e)
        {
            DisplayContent("tablesCollection");
            currentView = "tables";
            lCurrentViewSelected.Text = "Tables is currently selected";
        }

        private void btnOrdersRead_Click(object sender, EventArgs e)
        {
            DisplayContent("ordersCollection");
            currentView = "order";
            lCurrentViewSelected.Text = "Orders is currently selected";
        }

        private void btnReadOrderItems_Click(object sender, EventArgs e)
        {
            currentView = "itemsordered";
            lCurrentViewSelected.Text = "Order Items is currently selected";
            DisplayContent("itemsOrderedCollection");
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

        private void btnCreate_Click(object sender, EventArgs e)
        {
            switch (currentView)
            {
                case "order":
                    Orders newOrder = new Orders() { TotalCost = 0.0 };
                    ordersCollection.InsertOne(newOrder);
                    DisplayContent("ordersCollection");
                    break;

                default:
                    DisplayErrorUnknownSelectionHandler(e);
                    break;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            switch (currentView)
            {
                case "order":
                    ObjectId orderId;
                    if (!ObjectId.TryParse(txtBID.Text, out orderId))
                    {
                        DisplayError("invalidID", txtBID.Text);
                        break;
                    }
                    //make sure the order you're deleting exists
                    var filterOrder = Builders<Orders>.Filter.Eq("ID", orderId);
                    List<Orders> ordersList = ordersCollection.Find(filterOrder).ToList();
                    if (ordersList.Count == 0)
                    {
                        DisplayError("invalidID", txtBID.Text);
                        break;
                    }
                    //delete all the items ordered relating to this order
                    var filterGetItemsOrdered = Builders<ItemsOrdered>.Filter.Eq("OrdersForeignKey", orderId);
                    List<ItemsOrdered> itemsOrderedList = itemsOrderedCollection.Find(filterGetItemsOrdered).ToList();
                    foreach (ItemsOrdered item in itemsOrderedList)
                    {
                        var filterDeleteItem = Builders<ItemsOrdered>.Filter.Eq("ID", item.ID);
                        itemsOrderedCollection.DeleteOne(filterDeleteItem);
                    }
                    //delete the order
                    ordersCollection.DeleteOne(filterOrder);
                    DisplayContent("ordersCollection");
                    break;
                default:
                    DisplayErrorUnknownSelectionHandler(e);
                    break;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            switch (currentView)
            {
                case "tables":
                    ObjectId id;
                    if (!ObjectId.TryParse(txtBID.Text, out id))
                    {
                        DisplayError("invalidID", txtBID.Text);
                        break;
                    }
                    var filterTables = Builders<Tables>.Filter.Eq("ID", id);
                    var updateTables = Builders<Tables>.Update.Set("TableStatus", txtBTableStatus.Text).Set("OrderStatus", txtBTableOrderStatus.Text);
                    ObjectId foreignKey;
                    if (!ObjectId.TryParse(txtBTableOrderId.Text, out foreignKey))
                    {
                        updateTables.Set("OrdersForeignKey", foreignKey);
                    }
                    tablesCollection.UpdateOne(filterTables, updateTables);
                    DisplayContent("tablesCollection");
                    break;

                default:
                    DisplayErrorUnknownSelectionHandler(e);
                    break;
            }
        }

        private void btnOrderItemsCreate_Click(object sender, EventArgs e)
        {
            //get the menu info, doing this first so if it doesn't exist then it won't insert bad data into the DB
            var builderGetMenuInfo = Builders<Menu>.Filter;
            var filterGetMenuInfo = builderGetMenuInfo.Eq("Name", txtBOrderItemsName.Text);
            List<Menu> filteredMenuInfoList = menuCollection.Find(filterGetMenuInfo).Project<Menu>("{_id: -1, Cost: 1, Discount: 1}").ToList();
            if (filteredMenuInfoList.Count == 0)
            {
                DisplayError("badItemName", txtBOrderItemsName.Text);
                return;
            }
            //check and make sure related ID exists
            ObjectId foreignKey;
            if (!ObjectId.TryParse(txtBID.Text, out foreignKey))
            {
                DisplayError("invalidID", txtBID.Text);
            }
            ItemsOrdered newItemsOrdered = new ItemsOrdered() { Name = txtBOrderItemsName.Text, Discounted = chkBDiscounted.Checked, OrdersForeignKey = foreignKey };
            //grab the order info before inserting, to account for the order not existing anymore for some reason
            var builderGetOrderInfo = Builders<Orders>.Filter;
            var filterGetOrderInfo = builderGetOrderInfo.Eq("ID", newItemsOrdered.OrdersForeignKey);
            List<Orders> filteredOrderInfo = ordersCollection.Find(filterGetOrderInfo).ToList();
            if (filteredOrderInfo.Count == 0)
            {
                DisplayError("missingOrder", txtBID.Text);
                return;
            }
            //calculate the amount to be added to the total
            double toAdd = filteredMenuInfoList[0].Cost;
            double discountAmount = 0.0;
            if (newItemsOrdered.Discounted)
            {
                discountAmount = filteredMenuInfoList[0].Discount;
            }
            toAdd = Double.Round(toAdd - (toAdd * discountAmount), 2);
            double total = filteredOrderInfo[0].TotalCost + toAdd;
            newItemsOrdered.Cost = toAdd;
            //after the cost is added to the itemorder insert it and update the order
            itemsOrderedCollection.InsertOne(newItemsOrdered);
            var filterUpdateTotalCost = Builders<Orders>.Filter.Eq("ID", ObjectId.Parse(txtBID.Text));
            var updateUpdateTotalCost = Builders<Orders>.Update.Set("TotalCost", total);
            ordersCollection.UpdateOne(filterUpdateTotalCost, updateUpdateTotalCost);
            DisplayContent("ordersCollection");
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
            if(filteredOrders.Count == 0)
            {
                DisplayError("invalidID", txtBID.Text);
                return;
            }
            var orderItemsFilter = Builders<ItemsOrdered>.Filter.Eq("OrdersForeignKey", orderId);
            List<ItemsOrdered> filteredItemsOrdered = itemsOrderedCollection.Find(orderItemsFilter).ToList();
            string receipt = "ORDER: ";
            receipt += filteredOrders[0].ID + "\n";
            foreach(var item in filteredItemsOrdered)
            {
                receipt += $"{item.Name}: {item.Cost}$\n";
            }
            receipt += "Total: " + filteredOrders[0].TotalCost + "$";
            MessageBox.Show(receipt);
        }
    }
}
