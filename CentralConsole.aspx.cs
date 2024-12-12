using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using Microsoft.Ajax.Utilities;
using System.Security.Cryptography;
using System.Text;

namespace HealthCentre {
    public partial class CentralConsole : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            string currentRole = Session["role"].ToString();
            if (currentRole != "Doctor") {
                Response.Redirect("index.aspx");
            }
        }

        protected void searchButton_Click(object sender, EventArgs e) {
            string pin = searchPatient.Text.Trim();

            if(Regex.IsMatch(pin, @"(^(\d{8})([A-Z])$)|(^[XYZ]\d{7,8}[A-Z]$)")) {
                string DBpath = Server.MapPath("~/data.db");
                SQLiteConnection conn = new SQLiteConnection("Data Source=" + DBpath + ";Version=3;");
                conn.Open();

                string query = "SELECT * FROM USERS WHERE pin = '" + pin + "';";
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

                    ViewState["queriedUser"] = queriedUser;

                    pinEdit.Text = queriedUser.Pin;
                    emailEdit.Text = queriedUser.Email;
                    firstEdit.Text = queriedUser.First_Name;
                    lastEdit.Text = queriedUser.Last_Name;
                    dateEdit.Text = queriedUser.Dob;
                    addressEdit.Text = queriedUser.Address;
                    phoneEdit.Text = queriedUser.Phone.ToString();

                    string appointmentQuery = "SELECT * FROM RECORDS WHERE patient_id = '" + queriedUser.Id + "';";
                    SQLiteCommand appointmentComm = new SQLiteCommand(appointmentQuery, conn);

                    SQLiteDataReader appointmentReader = appointmentComm.ExecuteReader();
                    DataTable appointmentTable = new DataTable();
                    appointmentTable.Load(appointmentReader);

                    Dictionary<int,Record> records = new Dictionary<int,Record>();
                    for(int i=0; i < appointmentTable.Rows.Count; i++) {
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

                    for(int i = 0; i < records.Count; i++) {
                        ListItem item = new ListItem
                        {
                            Text = "Appointment at: " + records[i].AppointmentDate + ".",
                            Value = records[i].Id.ToString()
                        };
                        appointmentBox.Items.Add(item);
                    }

                } else {
                    errorLabel.Text = "Patient not found";
                }



                conn.Close();
            }
        }

        protected void deleteButton_Click(object sender, EventArgs e) {
            string pin = searchPatient.Text.Trim();

            if (Regex.IsMatch(pin, @"(^(\d{8})([A-Z])$)|(^[XYZ]\d{7,8}[A-Z]$)")) {
                string DBpath = Server.MapPath("~/data.db");
                SQLiteConnection conn = new SQLiteConnection("Data Source=" + DBpath + ";Version=3;");
                conn.Open();

                string query = "DELETE FROM USERS WHERE pin = '" + pin + "';";
                SQLiteCommand comm = new SQLiteCommand(query, conn);

                SQLiteDataAdapter da = new SQLiteDataAdapter();
                da.DeleteCommand = comm;
                da.DeleteCommand.ExecuteNonQuery();

                conn.Close();

                pinEdit.Text = "";
                emailEdit.Text = "";
                firstEdit.Text = "";
                lastEdit.Text = "";
                dateEdit.Text = "";
                addressEdit.Text = "";
                phoneEdit.Text = "";
                errorLabel.Text = "PATIENT DELETED SUCCESFULLY";
            }


        }

        protected void saveButton_Click(object sender, EventArgs e) {
            User updatedUser = new User();
            bool isValid = true;
            errorLabel.Text = "";

            if (Regex.IsMatch(pinEdit.Text, @"(^(\d{8})([A-Z])$)|(^[XYZ]\d{7,8}[A-Z]$)")) {
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

        protected void createButton_Click(object sender, EventArgs e) {
            User newUser = new User();
            bool isValid = true;
            createErrorLabel.Text = "";

            if (Regex.IsMatch(createPin.Text, @"(^(\d{8})([A-Z])$)|(^[XYZ]\d{7,8}[A-Z]$)")) {
                newUser.Pin = createPin.Text;
            }
            else {
                isValid = false;
                createErrorLabel.Text = "Invalid PIN format.";
            }

            String password = createPassword.Text;

            using (MD5 md5Hash = MD5.Create()) {
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                password = BitConverter.ToString(data).Replace("-", string.Empty);
            }
            newUser.Password = password;

            if (Regex.IsMatch(createEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$")) {
                newUser.Email = createEmail.Text;
            }
            else {
                isValid = false;
                createErrorLabel.Text += "<br />Invalid Email format.";
            }

            if (Regex.IsMatch(createFirst.Text, @"^[A-Za-z\s]+$")) {
                newUser.First_Name = createFirst.Text;
            }
            else {
                isValid = false;
                createErrorLabel.Text += "<br />Invalid First Name format.";
            }

            if (Regex.IsMatch(createLast.Text, @"^[A-Za-z\s]+$")) {
                newUser.Last_Name = createLast.Text;
            }
            else {
                isValid = false;
                createErrorLabel.Text += "<br />Invalid Last Name format.";
            }

            if (Regex.IsMatch(createDate.Text, @"^\d{2}/\d{2}/\d{4}$")) {
                newUser.Dob = createDate.Text;
            }
            else {
                isValid = false;
                createErrorLabel.Text += "<br />Invalid Date of Birth format.";
            }

            if (Regex.IsMatch(createAddress.Text, @"^[\w\s,.-]+$")) {
                newUser.Address = createAddress.Text;
            }
            else {
                isValid = false;
                createErrorLabel.Text += "<br />Invalid Address format.";
            }

            if (Regex.IsMatch(createPhone.Text, @"^\d{9}$")) {
                newUser.Phone = Convert.ToInt32(createPhone.Text);
            }
            else {
                isValid = false;
                createErrorLabel.Text += "<br />Invalid Phone format.";
            }

            if (isValid) {
                string DBpath = Server.MapPath("~/data.db");
                SQLiteConnection conn = new SQLiteConnection("Data Source=" + DBpath + ";Version=3;");
                conn.Open();

                string query = "INSERT INTO USERS (pin, password, email, role, first_name, last_name, dob, address, phone, created_at, updated_at) VALUES (" +
                    "'" + newUser.Pin + "', " +
                    "'" + newUser.Password + "', " +
                    "'" + newUser.Email + "', " +
                    "'Patient', " +
                    "'" + newUser.First_Name + "', " +
                    "'" + newUser.Last_Name + "', " +
                    "'" + newUser.Dob + "', " +
                    "'" + newUser.Address + "', " +
                    newUser.Phone + ", " +
                    "'" + DateTime.Now.ToString("dd-MM-yyyy") + "', " +
                    "'" + DateTime.Now.ToString("dd-MM-yyyy") + "'" +
                    ");";


                SQLiteCommand comm = new SQLiteCommand(query, conn);

                SQLiteDataAdapter da = new SQLiteDataAdapter();
                da.InsertCommand = comm;
                da.InsertCommand.ExecuteNonQuery();

                conn.Close();
            }
        }

        protected void appointmentBox_SelectedIndexChanged(object sender, EventArgs e) {
            if (ViewState["Records"] is Dictionary<int, Record> records) {
                int selectedId = Convert.ToInt32(appointmentBox.SelectedIndex);
                Record selectedRecord = records[selectedId];
                ViewState["record"] = selectedRecord;


                editAppDate.Text = selectedRecord.AppointmentDate.ToString();
                editDiagnosis.Text = selectedRecord.Diagnosis.ToString();
                editTreatment.Text = selectedRecord.Treatment.ToString();
                editNotes.Text = selectedRecord.Notes.ToString();
            }
        }

        protected void saveAppInfo_Click(object sender, EventArgs e) {
            Record currentRecord = (Record)ViewState["record"];
            Record updatedAppointment = new Record();
            bool isValid = true;
            errorAppLabel.Text = "";

            updatedAppointment.Id = currentRecord.Id;
            updatedAppointment.PatientId = currentRecord.PatientId;
            updatedAppointment.DoctorId = currentRecord.DoctorId;

            if (Regex.IsMatch(editAppDate.Text, @"^\d{2}/\d{2}/\d{4}$")) {
                updatedAppointment.AppointmentDate = editAppDate.Text;
            }
            else {
                isValid = false;
                errorAppLabel.Text = "Invalid Appointment Date format.";
            }

            if (Regex.IsMatch(editDiagnosis.Text, @"^[A-Za-z]+$")) {
                updatedAppointment.Diagnosis = editDiagnosis.Text;
            }
            else {
                isValid = false;
                errorAppLabel.Text = "Invalid Diagnosis format.";
            }

            if (Regex.IsMatch(editTreatment.Text, @"^[a-zA-Z0-9]+$")) {
                updatedAppointment.Treatment = editTreatment.Text;
            }
            else {
                isValid = false;
                errorAppLabel.Text = "Invalid Treatment format.";
            }

            if (Regex.IsMatch(editNotes.Text, @"^[a-zA-Z0-9]+$")) {
                updatedAppointment.Notes = editNotes.Text;
            }
            else {
                isValid = false;
                errorAppLabel.Text = "Invalid note format.";
            }

            if (isValid) {
                string DBpath = Server.MapPath("~/data.db");
                SQLiteConnection conn = new SQLiteConnection("Data Source=" + DBpath + ";Version=3;");
                conn.Open();

                string query = "UPDATE RECORDS SET " +
                    "patient_id = " + updatedAppointment.PatientId + ", " +
                    "doctor_id = " + updatedAppointment.DoctorId + ", " +
                    "appointment_date = '" + updatedAppointment.AppointmentDate + "', " +
                    "diagnosis = '" + updatedAppointment.Diagnosis + "', " +
                    "treatment = '" + updatedAppointment.Treatment + "', " +
                    "notes = '" + updatedAppointment.Notes + "' " +
                    "WHERE id = " + updatedAppointment.Id + ";";

                SQLiteCommand comm = new SQLiteCommand(query, conn);

                SQLiteDataAdapter da = new SQLiteDataAdapter();
                da.DeleteCommand = comm;
                da.DeleteCommand.ExecuteNonQuery();

                conn.Close();
            }
        }

        protected void deleteApp_Click(object sender, EventArgs e) {
            Record currentRecord = (Record)ViewState["record"];

            string DBpath = Server.MapPath("~/data.db");
            SQLiteConnection conn = new SQLiteConnection("Data Source=" + DBpath + ";Version=3;");
            conn.Open();

            string query = "DELETE FROM RECORDS WHERE id = " + currentRecord.Id + ";";
            SQLiteCommand comm = new SQLiteCommand(query, conn);

            SQLiteDataAdapter da = new SQLiteDataAdapter();
            da.DeleteCommand = comm;
            da.DeleteCommand.ExecuteNonQuery();

            conn.Close();
        }

        protected void createAppointment_Click(object sender, EventArgs e) {
            int doctor_id = Convert.ToInt32(Session["id"]);
            User patient = (User)ViewState["queriedUser"];
            int patient_id = patient.Id;
            Record newRecord = new Record();
            bool isValid = true;
            createAppErrorLabel.Text = "";

            newRecord.PatientId = patient_id;
            newRecord.DoctorId = doctor_id;

            if (Regex.IsMatch(createAppDate.Text, @"^\d{2}/\d{2}/\d{4}$")) {
                newRecord.AppointmentDate = createAppDate.Text;
            }
            else {
                isValid = false;
                createAppErrorLabel.Text = "Invalid Appointment Date format.";
            }

            if (Regex.IsMatch(createDiagnosis.Text, @"^[A-Za-z]+$")) {
                newRecord.Diagnosis = createDiagnosis.Text;
            }
            else {
                isValid = false;
                createAppErrorLabel.Text = "Invalid Diagnosis format.";
            }

            if (Regex.IsMatch(createTreatment.Text, @"^[a-zA-Z0-9]+$")) {
                newRecord.Treatment = createTreatment.Text;
            }
            else {
                isValid = false;
                createAppErrorLabel.Text = "Invalid Treatment format.";
            }

            if (Regex.IsMatch(createNotes.Text, @"^[a-zA-Z0-9]+$")) {
                newRecord.Notes = createNotes.Text;
            }
            else {
                isValid = false;
                createAppErrorLabel.Text = "Invalid note format.";
            }


            if (isValid) {
                string DBpath = Server.MapPath("~/data.db");
                SQLiteConnection conn = new SQLiteConnection("Data Source=" + DBpath + ";Version=3;");
                conn.Open();

                string query = "INSERT INTO RECORDS (patient_id, doctor_id, appointment_date, diagnosis, treatment, notes) VALUES (" +
                    "" + newRecord.PatientId + ", " +
                    "" + newRecord.DoctorId + ", " +
                    "'" + newRecord.AppointmentDate + "', " +
                    "'" + newRecord.Diagnosis + "', " +
                    "'" + newRecord.Treatment + "', " +
                    "'" + newRecord.Notes + "');";


                SQLiteCommand comm = new SQLiteCommand(query, conn);

                SQLiteDataAdapter da = new SQLiteDataAdapter();
                da.InsertCommand = comm;
                da.InsertCommand.ExecuteNonQuery();

                conn.Close();
            }

        }
    }
}