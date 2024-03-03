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
using System.Data.SQLite;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ADPSemesterProject
{
    public partial class OOPAdmin : Form
    {
        public string username = "";
        public int accessLevel = 2;
        public string password = "";
        public Form parent;

        public SQLiteConnection conn = new SQLiteConnection("Data Source=semester.db;");

        //true is users, false is menu.
        bool currentView = true;

        public OOPAdmin(string username, int accessLevel, string password, Form parent)
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
            DataTable dt = new DataTable();
            switch (collectionName)
            {
                case "menuCollection":
                    using (SQLiteCommand cmd = new SQLiteCommand(conn))
                    {
                        cmd.CommandText = "select * from menu";
                        conn.Open();
                        SQLiteDataAdapter ad = new SQLiteDataAdapter(cmd);
                        ad.Fill(dt);
                        ad.Dispose();
                    }
                    conn.Close();
                    dataGridView1.DataSource = dt;
                    break;
                case "ordersCollection":
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
                case "tablesCollection":
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

        private void OOPAdmin_FormClosed(object sender, FormClosedEventArgs e)
        {
            parent.Show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            int id = -1;
            if (!int.TryParse(txtBID.Text, out id))
            {
                DisplayError("invalidID", txtBID.Text);
                return;
            }
            if (currentView)
            {
                //for Users
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    cmd.CommandText = $"delete from staff where id = {id}";
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
                DisplayContent("staffCollection");
            }
            else
            {
                //for Menu
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    cmd.CommandText = $"delete from menu where id = {id}";
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
                DisplayContent("menuCollection");
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
                        using (var cmd = new SQLiteCommand(conn))
                        {
                            cmd.CommandText = $"insert into staff (Name, Password, Role, AccessLevel) Values ('{txtBUsersName.Text}', '{txtBUsersPassword.Text}', '{txtBUsersRole.Text}', {tryParseAccess});";
                            conn.Open();
                            cmd.ExecuteNonQuery();
                        }
                        conn.Close();
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
                using (var cmd = new SQLiteCommand(conn))
                {
                    cmd.CommandText = $"insert into menu (Name, Cost, Discount, Category, Description) Values ('{txtBMenuName.Text}', {tryParseCost}, {tryParseDiscount}, '{txtBMenuCategory.Text}', '{txtBMenuDescription.Text}');";
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
                DisplayContent("menuCollection");
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
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    cmd.CommandText = $"update staff set Name = '{txtBUsersName.Text}', Password = '{txtBUsersPassword.Text}', Role = '{txtBUsersRole.Text}', AccessLevel = {tryParseAccessLevel} where id = {id};";
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
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
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    cmd.CommandText = $"update menu set Name = '{txtBMenuName.Text}', Cost = {tryParseCost}, Discount = {tryParseDiscount}, Category = '{txtBMenuCategory.Text}', Description = '{txtBMenuDescription.Text}' where id = {id};";
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
                DisplayContent("menuCollection");
            }
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

        private void btnMenuRead_Click(object sender, EventArgs e)
        {
            DisplayContent("menuCollection");
            currentView = false;
            lCurrentViewSelected.Text = "Menu is currently selected";
        }

        private void btnUsersRead_Click(object sender, EventArgs e)
        {
            DisplayContent("staffCollection");
            currentView = true;
            lCurrentViewSelected.Text = "Users is currently selected";
        }
    }
}
