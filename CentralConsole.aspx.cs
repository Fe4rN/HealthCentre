using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace HealthCentre {
    public partial class CentralConsole : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            //if (Session["role"] != "Doctor") {
            //    Response.Redirect("index.aspx");
            //}
        }

        protected void searchButton_Click(object sender, EventArgs e) {
            string pin = searchPatient.Text.Trim();

            if(Regex.IsMatch(pin, "(^\\d{8}[A-Za-z]$)|(^[XYZ]\\d{7}[A-Za-z]$)\r\n")) {
                string DBpath = Server.MapPath("~/data.db");
                SQLiteConnection conn = new SQLiteConnection("Data Source=" + DBpath + ";Version=3;");
                conn.Open();

                string query = "SELECT * FROM USERS WHERE pin = '" + pin + "';";
                SQLiteCommand comm = new SQLiteCommand(query, conn);

                SQLiteDataReader reader = comm.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);

                conn.Close();

                if (dt.Rows.Count == 1) {
                    DataRow row = dt.Rows[0];

                    Dictionary<string, object> columnValues = new Dictionary<string, object>();
                    foreach (DataColumn column in dt.Columns) {
                        columnValues[column.ColumnName] = row[column.ColumnName];
                    }

                    User queriedUser = new User(
                        Convert.ToInt32(columnValues["id"]),
                        columnValues["pin"].ToString(),
                        columnValues["password"].ToString(),
                        columnValues["email"].ToString(),
                        columnValues["role"].ToString(),
                        columnValues["first_name"].ToString(),
                        columnValues["last_name"].ToString(),
                        columnValues["dob"].ToString(),
                        columnValues["address"].ToString(),
                        Convert.ToInt32(columnValues["phone"]),
                        columnValues["created_at"].ToString(),
                        columnValues["updated_at"].ToString()
                    );

                    pinEdit.Text = queriedUser.Pin;
                    emailEdit.Text = queriedUser.Email;
                    firstEdit.Text = queriedUser.First_Name;
                    lastEdit.Text = queriedUser.Last_Name;
                    dateEdit.Text = queriedUser.Dob;
                    addressEdit.Text = queriedUser.Address;
                    phoneEdit.Text = queriedUser.Phone.ToString();

                }

            }
        }

        protected void deleteButton_Click(object sender, EventArgs e) {
            string pin = searchPatient.Text.Trim();

            if (Regex.IsMatch(pin, "(^\\d{8}[A-Za-z]$)|(^[XYZ]\\d{7}[A-Za-z]$)\r\n")) {
                string DBpath = Server.MapPath("~/data.db");
                SQLiteConnection conn = new SQLiteConnection("Data Source=" + DBpath + ";Version=3;");
                conn.Open();

                string query = "DELETE * FROM USERS WHERE pin = '" + pin + "';";
                SQLiteCommand comm = new SQLiteCommand(query, conn);

                SQLiteDataAdapter da = new SQLiteDataAdapter();
                da.DeleteCommand = comm;
                da.DeleteCommand.ExecuteNonQuery();

                conn.Close();
            }
        }

        protected void saveButton_Click(object sender, EventArgs e) {
            User updatedUser = new User();
            bool isValid = true;

            if (Regex.IsMatch(pinEdit.Text, @"(^\d{8}[A-Za-z]$)|(^[XYZ]\d{7}[A-Za-z]$)")) {
                updatedUser.Pin = pinEdit.Text;
            }
            else {
                isValid = false;
                errorLabel.Text = "Invalid PIN format.";
            }

            if (Regex.IsMatch(emailEdit.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$")) {
                updatedUser.Email = emailEdit.Text;
            }
            else {
                isValid = false;
                errorLabel.Text += "<br />Invalid Email format.";
            }

            if (Regex.IsMatch(firstEdit.Text, @"^[A-Za-z\s]+$")) {
                updatedUser.First_Name = firstEdit.Text;
            }
            else {
                isValid = false;
                errorLabel.Text += "<br />Invalid First Name format.";
            }

            if (Regex.IsMatch(lastEdit.Text, @"^[A-Za-z\s]+$")) {
                updatedUser.Last_Name = lastEdit.Text;
            }
            else {
                isValid = false;
                errorLabel.Text += "<br />Invalid Last Name format.";
            }

            if (Regex.IsMatch(dateEdit.Text, @"^\d{2}/\d{2}/\d{4}$")) {
                updatedUser.Dob = dateEdit.Text;
            }
            else {
                isValid = false;
                errorLabel.Text += "<br />Invalid Date of Birth format.";
            }

            if (Regex.IsMatch(addressEdit.Text, @"^[\w\s,.-]+$")) {
                updatedUser.Address = addressEdit.Text;
            }
            else {
                isValid = false;
                errorLabel.Text += "<br />Invalid Address format.";
            }

            if (Regex.IsMatch(phoneEdit.Text, @"^\d{9}$")) {
                updatedUser.Phone = Convert.ToInt32(phoneEdit.Text);
            }
            else {
                isValid = false;
                errorLabel.Text += "<br />Invalid Phone format.";
            }

            if (isValid) {
                string DBpath = Server.MapPath("~/data.db");
                SQLiteConnection conn = new SQLiteConnection("Data Source=" + DBpath + ";Version=3;");
                conn.Open();

                string query = "UPDATE USERS SET " +
                    "pin = '" + updatedUser.Pin + "', " +
                    "email = '" + updatedUser.Email + "', " +
                    "first_name = '" + updatedUser.First_Name + "', " +
                    "last_name = '" + updatedUser.Last_Name + "', " +
                    "dob = '" + updatedUser.Dob + "', " +
                    "address = '" + updatedUser.Address + "', " +
                    "phone = " + updatedUser.Phone + ", " +
                    "updated_at = '" + DateTime.Now.ToString("dd-MM-yyyy") + "' " +
                    "WHERE pin = '" + updatedUser.Pin + "';";

                SQLiteCommand comm = new SQLiteCommand(query, conn);

                SQLiteDataAdapter da = new SQLiteDataAdapter();
                da.DeleteCommand = comm;
                da.DeleteCommand.ExecuteNonQuery();

                conn.Close();
            }
        }

    }
}