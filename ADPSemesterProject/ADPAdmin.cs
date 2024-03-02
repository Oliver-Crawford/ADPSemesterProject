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
using System.Reflection.Metadata.Ecma335;

namespace ADPSemesterProject
{
    public partial class ADPAdmin : Form
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
        //true is users, false is menu.
        bool currentView = true;

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

        public ADPAdmin(string username, int accessLevel, string password, Form parent)
        {
            InitializeComponent();
            this.username = username;
            this.accessLevel = accessLevel;
            this.password = password;
            this.parent = parent;
            this.BackColor = parent.BackColor;
            DisplayContent("staffCollection");
        }

        //Displays table contents based on the given collection name
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
                    break;
                case "staffCollection":
                    List<Staff> staffList = staffCollection.AsQueryable().ToList();
                    dataGridView1.DataSource = staffList;
                    break;
                case "tablesCollection":
                    List<Tables> tablesList = tablesCollection.AsQueryable().ToList();
                    dataGridView1.DataSource = tablesList;
                    break;
                case "filteredSCUserOnly":
                    var builderC2 = Builders<Staff>.Filter;
                    var filterC2 = builderC2.Eq("Name", username) & builderC2.Eq("Password", password);
                    List<Staff> filteredUserOnlyList = staffCollection.Find(filterC2).ToList();
                    dataGridView1.DataSource = filteredUserOnlyList;

                    break;
                default:
                    MessageBox.Show("No known collection called " + collectionName);
                    break;
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

        private void ADPAdmin_FormClosed(object sender, FormClosedEventArgs e)
        {
            parent.Show();
        }

        private void btnUsersRead_Click(object sender, EventArgs e)
        {
            DisplayContent("staffCollection");
            currentView = true;
            lCurrentViewSelected.Text = "Users is currently selected";
        }

        private void btnMenuRead_Click(object sender, EventArgs e)
        {
            DisplayContent("menuCollection");
            currentView = false;
            lCurrentViewSelected.Text = "Menu is currently selected";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //This is to handle if the user clicks the column selecter, which doesn't have any use here.
            if (e.RowIndex == -1)
            {
                return;
            }
            if (currentView)
            {
                //Updates user info
                switch (e.ColumnIndex)
                {
                    case 0:
                        txtBID.Text = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                        break;
                    case 1:
                        txtBUsersName.Text = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                        break;
                    case 2:
                        txtBUsersPassword.Text = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                        break;
                    case 3:
                        txtBUsersRole.Text = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                        break;
                    case 4:
                        txtBUsersAccessLevel.Text = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                        break;
                    case -1:
                        txtBID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                        txtBUsersName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                        txtBUsersPassword.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                        txtBUsersRole.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                        txtBUsersAccessLevel.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                        break;
                    default:
                        break;
                }
            }
            else
            {
                //updates menu info
                switch (e.ColumnIndex)
                {
                    case 0:
                        txtBID.Text = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                        break;
                    case 1:
                        txtBMenuName.Text = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                        break;
                    case 2:
                        txtBMenuCost.Text = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                        break;
                    case 3:
                        txtBMenuDiscount.Text = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                        break;
                    case 4:
                        txtBMenuCategory.Text = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                        break;
                    case 5:
                        txtBMenuDescription.Text = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                        break;
                    case -1:
                        txtBID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                        txtBMenuName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                        txtBMenuCost.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                        txtBMenuDiscount.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                        txtBMenuCategory.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                        txtBMenuDescription.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                        break;
                    default:
                        break;
                }
            }

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (currentView)
            {
                //inserts new users record
                int tryParseAccess = -1;
                if (int.TryParse(txtBUsersAccessLevel.Text, out tryParseAccess))
                {
                    if (tryParseAccess > -1 && tryParseAccess < 3)
                    {
                        Staff newUser = new Staff() { Name = txtBUsersName.Text, Password = txtBUsersPassword.Text, Role = txtBUsersRole.Text, AccessLevel = tryParseAccess };
                        staffCollection.InsertOne(newUser);
                        DisplayContent("staffCollection");
                    }
                    else
                    {
                        DisplayError("accessLevelOutOfRangeError");
                    }

                }
                else
                {
                    DisplayError("accessLevelParseError");
                }
            }
            else
            {
                //inserts new menu record
                double tryParseCost = 0.0;
                double tryParseDiscount = 0.0;
                if (!double.TryParse(txtBMenuCost.Text, out tryParseCost))
                {
                    DisplayError("menuCostParseError");
                    return;
                }
                if (!double.TryParse(txtBMenuDiscount.Text, out tryParseDiscount))
                {
                    DisplayError("menuDiscountParseError");
                    return;
                }
                if (tryParseDiscount > 1)
                {
                    DisplayError("menuDiscountOutOfRangeError");
                    return;
                }
                Menu newMenu = new Menu() { Name = txtBMenuName.Text, Cost = tryParseCost, Discount = tryParseDiscount, Category = txtBMenuCategory.Text, Description = txtBMenuDescription.Text };
                menuCollection.InsertOne(newMenu);
                DisplayContent("menuCollection");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ObjectId id;
            if(!ObjectId.TryParse(txtBID.Text, out id))
            {
                DisplayError("invalidID", txtBID.Text);
                return;
            }
            if (currentView)
            {
                //for Users
                int tryParseAccessLevel = -1;
                if (!int.TryParse(txtBUsersAccessLevel.Text, out tryParseAccessLevel))
                {
                    DisplayError("accessLevelParseError");
                    return;
                }
                if (tryParseAccessLevel < 0 || tryParseAccessLevel > 2)
                {
                    DisplayError("accessLevelOutOfRangeError");
                    return;
                }
                var filter = Builders<Staff>.Filter.Eq("ID", id);
                var update = Builders<Staff>.Update.Set("Name", txtBUsersName.Text).Set("Password", txtBUsersPassword.Text).Set("Role", txtBUsersRole.Text).Set("AccessLevel", tryParseAccessLevel);
                staffCollection.UpdateOne(filter, update);
                DisplayContent("staffCollection");
            }
            else
            {
                //for Menu
                double tryParseCost = 0.0;
                double tryParseDiscount = 0.0;
                if (!double.TryParse(txtBMenuCost.Text, out tryParseCost))
                {
                    DisplayError("menuCostParseError");
                    return;
                }
                if (!double.TryParse(txtBMenuDiscount.Text, out tryParseDiscount))
                {
                    DisplayError("menuDiscountParseError");
                    return;
                }
                if (tryParseDiscount > 1)
                {
                    DisplayError("menuDiscountOutOfRangeError");
                    return;
                }
                var filter = Builders<Menu>.Filter.Eq("ID", id);
                var update = Builders<Menu>.Update.Set("Name", txtBMenuName.Text).Set("Cost", tryParseCost).Set("Discount", tryParseDiscount).Set("Category", txtBMenuCategory.Text).Set("Description", txtBMenuDescription.Text);
                menuCollection.UpdateOne(filter, update);
                DisplayContent("menuCollection");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            ObjectId id;
            if (!ObjectId.TryParse(txtBID.Text, out id))
            {
                DisplayError("invalidID", txtBID.Text);
                return;
            }
            if (currentView)
            {
                //for Users
                var filter = Builders<Staff>.Filter.Eq("ID", id);
                staffCollection.DeleteOne(filter);
                DisplayContent("staffCollection");
            }
            else
            {
                //for Menu
                var filter = Builders<Menu>.Filter.Eq("ID", id);
                menuCollection.DeleteOne(filter);
                DisplayContent("menuCollection");
            }
        }
    }
}
