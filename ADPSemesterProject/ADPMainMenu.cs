using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using MongoDB.Driver.Core.Authentication;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADPSemesterProject
{
    public partial class ADPMainMenu : Form
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
        //These classes are my collection definitions
        class Menu
        {
            [BsonId]
            public BsonObjectId ID { get; set; }
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
            public BsonObjectId ID { get; set; }
            [BsonElement("ItemsOrdered")]
            public List<string> ItemsOrdered { get; set; }
            [BsonElement("TotalCost")]
            public double TotalCost { get; set; }
        }
        class Staff
        {
            [BsonId]
            public BsonObjectId ID { get; set; }
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
            public BsonObjectId ID { get; set; }
            [BsonElement("TableStatus")]
            public string TableStatus { get; set; }
            [BsonElement("OrderStatus")]
            public string OrderStatus { get; set; }
            [ForeignKey("OrderID")]
            public int OrderID { get; set; }

        }
        public ADPMainMenu(string username, int accessLevel, string password, Form parent)
        {
            InitializeComponent();
            this.username = username;
            this.accessLevel = accessLevel;
            this.password = password;
            this.parent = parent;
            AccessLevelStartup(accessLevel);
        }
        public void AccessLevelStartup(int accessLevel)
        {
            switch (accessLevel)
            {
                case 0:
                    btnAdmin.Enabled = true;
                    btnManagement.Enabled = true;
                    DisplayContent("staffCollection");
                    this.BackColor = Color.PaleVioletRed;
                    break;
                case 1:
                    btnManagement.Enabled = true;
                    DisplayContent("filteredSCUserOnly");
                    this.BackColor = Color.PaleTurquoise;
                    break;
                case 2:
                    DisplayContent("filteredSCUserOnly");
                    break;
                default:
                    MessageBox.Show($"Something has gone wrong! \n Access Level {accessLevel} should not exist.");
                    this.BackColor = Color.DarkGray;
                    break;
            }
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

        //this is to actually close the program when Form2 is closed, otherwise it will just keep running without any UI.
        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            parent.Show();
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            ADPAdmin ADPAdmin = new ADPAdmin(username, accessLevel, password, this);
            this.Hide();
            ADPAdmin.Show();
        }

        private void btnManagement_Click(object sender, EventArgs e)
        {

        }

        private void btnStaff_Click(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            AccessLevelStartup(accessLevel);
        }
    }
}
