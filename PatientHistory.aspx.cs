using HealthCentre;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Healthcare_Alex_Fedor
{
    public partial class PatientHistory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) {
            string pin = Session["pin"].ToString();
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

            }
        }
    }
}