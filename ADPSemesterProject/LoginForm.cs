using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System.Data.SQLite;
namespace ADPSemesterProject
{
    public partial class LoginForm : Form
    {
        //MongoDB connection
        public static MongoClient dbClient = new MongoClient("mongodb://127.0.0.1:27017");
        public static IMongoDatabase db = dbClient.GetDatabase("semester");
        static IMongoCollection<MongoStaff> staffCollection = db.GetCollection<MongoStaff>("staff");

        //SQLite connection
        public SQLiteConnection conn = new SQLiteConnection("Data Source=semester.db;");
        class MongoStaff
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



        public LoginForm()
        {
            InitializeComponent();
            this.BackColor = Color.Coral;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (rBtnMongoDB.Checked)
            {
                var builder = Builders<MongoStaff>.Filter;
                var filter = builder.Eq("Name", txtBName.Text) & builder.Eq("Password", txtBPassword.Text);
                List<MongoStaff> staffList = staffCollection.Find(filter).ToList();
                if (staffList.Any())
                {
                    ADPMainMenu ADPForms = new ADPMainMenu(staffList[0].Name, staffList[0].AccessLevel, staffList[0].Password, this);
                    this.Hide();
                    ADPForms.Show();
                }
                else
                {
                    MessageBox.Show("Invalid username/password");
                }
            }
            else
            {
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    cmd.CommandText = $"select * from staff where Name = '{txtBName.Text}' AND Password = '{txtBPassword.Text}'";
                    bool success = false;
                    string name = "";
                    string password = "";
                    int accessLevel = -1;
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            name = reader[1].ToString();
                            password = reader[2].ToString();
                            accessLevel = int.Parse(reader[4].ToString());
                        }
                    }
                    conn.Close();
                    if (accessLevel != -1)
                    {
                        OOPMainMenu OOPMainMenu = new OOPMainMenu(name, accessLevel, password, this);
                        this.Hide();
                        OOPMainMenu.Show();
                    }
                    else
                    {
                        MessageBox.Show("Invalid username/password");
                    }
                }



            }



        }

        private void rBtnMongoDB_CheckedChanged(object sender, EventArgs e)
        {
            this.BackColor = Color.Coral;
        }

        private void rBtnSQLDB_CheckedChanged(object sender, EventArgs e)
        {
            this.BackColor = Color.Thistle;
        }
    }
}
