using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.Windows.Forms;
namespace ADPSemesterProject
{
    public partial class LoginForm : Form
    {
        public static MongoClient dbClient = new MongoClient("mongodb://127.0.0.1:27017");
        public static IMongoDatabase db = dbClient.GetDatabase("semester");
        static IMongoCollection<Staff> staffCollection = db.GetCollection<Staff>("staff");
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


        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var builder = Builders<Staff>.Filter;
            var filter = builder.Eq("Name", txtBName.Text) & builder.Eq("Password", txtBPassword.Text);
            List<Staff> staffList = staffCollection.Find(filter).ToList();
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
    }
}
