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
using System.Data.SQLite;
using System.Xml.Linq;
using System.Data.Common;

namespace ADPSemesterProject
{
    public partial class OOPMainMenu : Form
    {

        public string username = "";
        public int accessLevel = 2;
        public string password = "";
        public Form parent;

        public SQLiteConnection conn = new SQLiteConnection("Data Source=semester.db;");

        //These classes are my collection definitions
        public OOPMainMenu(string username, int accessLevel, string password, Form parent)
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
            DataTable dt = new DataTable();
            switch (collectionName)
            {
                case "staffCollection":
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
                case "filteredSCUserOnly":
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
                    break;
                default:
                    MessageBox.Show("No known collection called " + collectionName);
                    break;
            }

        }

        private void OOPMainMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            parent.Show();
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            OOPAdmin OOPAdmin = new OOPAdmin(username, accessLevel, password, this);
            this.Hide();
            OOPAdmin.Show();
        }

        private void btnManagement_Click(object sender, EventArgs e)
        {
            OOPManagement OOPManagement = new OOPManagement(username, accessLevel, password, this);
            this.Hide();
            OOPManagement.Show();
        }
        private void btnStaff_Click(object sender, EventArgs e)
        {
            OOPStaff OOPStaff = new OOPStaff(username, accessLevel, password, this);
            this.Hide();
            OOPStaff.Show();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            AccessLevelStartup(accessLevel);
        }

        
    }
}
