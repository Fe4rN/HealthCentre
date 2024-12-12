using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Text;

namespace HealthCentre {
    public partial class Login : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void LoginButton_Click(object sender, EventArgs e) {
            string pin = userInput.Text.Trim();
            string password = passInput.Text.Trim();

            using (MD5 md5Hash = MD5.Create()) {
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                password = BitConverter.ToString(data).Replace("-", string.Empty);
            }

            string DBpath = Server.MapPath("~/data.db");
            SQLiteConnection conn = new SQLiteConnection("Data Source=" + DBpath + ";Version=3;");
            conn.Open();

            string query = "SELECT * FROM USERS WHERE pin = '" + pin + "' AND password = '" + password + "';";
            SQLiteCommand comm = new SQLiteCommand(query, conn);

            SQLiteDataReader reader = comm.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);

            conn.Close();

            if (dt.Rows.Count == 1) {
                String role = dt.Rows[0]["role"].ToString();
                int id = Convert.ToInt32(dt.Rows[0]["id"]);
                Session["pin"] = pin;
                Session["role"] = role;
                Session["id"] = id;
                switch (role) {
                    case "Patient":
                        Response.Redirect("PatientHistory.aspx");
                        break;

                    case "Doctor":
                        Response.Redirect("CentralConsole.aspx");
                        break;

                    default:
                        //TO DO---
                        break;
                }
            }
            else {
                error.Style["visibility"] = "visible";
            }
        }
    }
}