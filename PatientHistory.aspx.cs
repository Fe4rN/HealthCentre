using HealthCentre;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Healthcare_Alex_Fedor {
    public partial class PatientHistory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                if (Session["role"] == null) {
                    Response.Redirect("login.aspx");
                    return;
                }

                string currentRole = Session["role"].ToString();

                if (currentRole != "Patient" && currentRole != "Doctor") {
                    Response.Redirect("index.aspx");
                }

                int user_id = Convert.ToInt32(Session["id"]);

                string DBpath = Server.MapPath("~/data.db");
                SQLiteConnection conn = new SQLiteConnection("Data Source=" + DBpath + ";Version=3;");
                conn.Open();

                string query = "SELECT * FROM USERS WHERE id = " + user_id + ";";
                SQLiteCommand comm = new SQLiteCommand(query, conn);

                SQLiteDataReader reader = comm.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);



                if (dt.Rows.Count == 1) {
                    DataRow row = dt.Rows[0];

                    Dictionary<string, object> columnValues = new Dictionary<string, object>();
                    foreach (DataColumn column in dt.Columns) {
                        columnValues[column.ColumnName] = row[column.ColumnName];
                    }

                    User currentUser = new User(
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

                    lblName.Text = "" + currentUser.First_Name + " " + currentUser.Last_Name;
                    lblDOB.Text = currentUser.Dob;
                    lblAddress.Text = currentUser.Address;
                    lblPhone.Text = currentUser.Phone.ToString();

                    string appointmentQuery = "SELECT * FROM RECORDS WHERE patient_id = '" + currentUser.Id + "';";
                    SQLiteCommand appointmentComm = new SQLiteCommand(appointmentQuery, conn);

                    SQLiteDataReader appointmentReader = appointmentComm.ExecuteReader();
                    DataTable appointmentTable = new DataTable();
                    appointmentTable.Load(appointmentReader);

                    Dictionary<int, Record> records = new Dictionary<int, Record>();
                    for (int i = 0; i < appointmentTable.Rows.Count; i++) {
                        Record appointment = new Record(
                            Convert.ToInt32(appointmentTable.Rows[i]["id"]),
                            Convert.ToInt32(appointmentTable.Rows[i]["patient_id"]),
                            Convert.ToInt32(appointmentTable.Rows[i]["doctor_id"]),
                            appointmentTable.Rows[i]["appointment_date"].ToString(),
                            appointmentTable.Rows[i]["diagnosis"].ToString(),
                            appointmentTable.Rows[i]["treatment"].ToString(),
                            appointmentTable.Rows[i]["notes"].ToString()
                            );
                        records[i] = appointment;
                    }

                    ViewState["Records"] = records;

                    for (int i = 0; i < records.Count; i++) {
                        ListItem item = new ListItem
                        {
                            Text = "Appointment at: " + records[i].AppointmentDate + ".",
                            Value = records[i].Id.ToString()
                        };
                        recordList.Items.Add(item);
                    }
                }
            }
            
        }

        protected void recordList_SelectedIndexChanged(object sender, EventArgs e) {
            if (ViewState["Records"] is Dictionary<int, Record> records) {
                int selectedId = Convert.ToInt32(recordList.SelectedIndex);
                Record selectedRecord = records[selectedId];
                int doctor_id = Convert.ToInt32(selectedRecord.DoctorId);
                ViewState["record"] = selectedRecord;

                string DBpath = Server.MapPath("~/data.db");
                SQLiteConnection conn = new SQLiteConnection("Data Source=" + DBpath + ";Version=3;");
                conn.Open();

                string query = "SELECT * FROM USERS WHERE id = " + doctor_id + ";";
                SQLiteCommand comm = new SQLiteCommand(query, conn);

                SQLiteDataReader reader = comm.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);

                conn.Close();

                if (dt.Rows.Count == 1) {
                    String doctor_first_name = dt.Rows[0]["first_name"].ToString();
                    String doctor_last_name = dt.Rows[0]["last_name"].ToString();

                    appDoc.Text = "Dr. " + doctor_first_name + " " + doctor_last_name;
                }

                appDate.Text = selectedRecord.AppointmentDate.ToString();
                appDiagnosis.Text = selectedRecord.Diagnosis.ToString();
                appTreatment.Text = selectedRecord.Treatment.ToString();
                appNotes.Text = selectedRecord.Notes.ToString();
            }
        }
    }
}