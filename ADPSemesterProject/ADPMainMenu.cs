using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace ADPSemesterProject
{
    public partial class ADPMainMenu : Form
    {

        public string username = "";
        public int accessLevel = 2;
        public string password = "";
        public Form parent;
        //MongoDB connection
        public static MongoClient dbClient = new MongoClient("mongodb://127.0.0.1:27017");
        public static IMongoDatabase db = dbClient.GetDatabase("semester");
        static IMongoCollection<Staff> staffCollection = db.GetCollection<Staff>("staff");

        //These classes are my collection definitions
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
                case "staffCollection":
                    List<Staff> staffList = staffCollection.AsQueryable().ToList();
                    dataGridView1.DataSource = staffList;
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
            ADPManagement ADPManagement = new ADPManagement(username, accessLevel, password, this);
            this.Hide();
            ADPManagement.Show();
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            ADPStaff ADPStaff = new ADPStaff(username, accessLevel, password, this);
            this.Hide();
            ADPStaff.Show();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            AccessLevelStartup(accessLevel);
        }
    }
}
