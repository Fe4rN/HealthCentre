using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Healthcare_Alex_Fedor
{
    public partial class PatientHistory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                string DBpath = Server.MapPath("~/data.db");
                using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + DBpath + ";Version=3;"))
                {
                    conn.Open();
                    Response.Write("Connection Successful!");
                }
            }
            catch (Exception ex)
            {
                Response.Write("Database Connection Failed: " + ex.Message);
            }

            if (!IsPostBack)
            {
                int patientId = GetPatientIdFromQuery(); // Obtén el ID del paciente desde la URL u otro medio.
                if (patientId > 0)
                {
                    LoadPatientInfo(patientId);
                    LoadPatientRecords(patientId);
                }
            }
        }

        private int GetPatientIdFromQuery()
        {
            // Aquí suponemos que el ID del paciente viene como parámetro de querystring: ?patientId=1
            string patientIdStr = Request.QueryString["patientId"];
            int patientId;
            return int.TryParse(patientIdStr, out patientId) ? patientId : 0;
        }

        private void LoadPatientInfo(int patientId)
        {
            string DBpath = Server.MapPath("~/data.db");
            using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + DBpath + ";Version=3;"))
            {
                conn.Open();
                string query = "SELECT first_name, last_name, dob, address, phone FROM USERS WHERE id = @patientId";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@patientId", patientId);
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            lblName.Text = $"{reader["first_name"]} {reader["last_name"]}";
                            lblDOB.Text = reader["dob"].ToString();
                            lblAddress.Text = reader["address"].ToString();
                            lblPhone.Text = reader["phone"].ToString();
                        }
                    }
                }
            }
        }

        // ... (resto de tu código)

        private void LoadPatientRecords(int patientId)
        {
            string DBpath = Server.MapPath("~/data.db");
            using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + DBpath + ";Version=3;"))
            {
                try
                {
                    conn.Open();
                    Console.WriteLine("Conexión a la base de datos establecida."); 

                    string query = "SELECT appointment_date, diagnosis, treatment, notes FROM RECORDS WHERE patient_id = @patientId";
                    Console.WriteLine("Consulta SQL: " + query);

                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@patientId", patientId);
                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                gvRecords.DataSource = reader;
                                gvRecords.DataBind();
                            }
                            else
                            {
                                //lblMessage.Text = "No se encontraron registros para este paciente.";
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al cargar los registros: " + ex.Message);
                }
            }
        }
    }
}