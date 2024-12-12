using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthCentre {
    [Serializable]
    public class Record {
        private int id;
        private int patient_id;
        private int doctor_id;
        private string appointment_date;
        private string diagnosis;
        private string treatment;
        private string notes;

        public Record(int ID, int PATIENT_ID, int DOCTOR_ID, string APPOINTMENT_DATE, string DIAGNOSIS, string TREATMENT, string NOTES) {
            Id = ID;
            PatientId = PATIENT_ID;
            DoctorId = DOCTOR_ID;
            AppointmentDate = APPOINTMENT_DATE;
            Diagnosis = DIAGNOSIS;
            Treatment = TREATMENT;
            Notes = NOTES;
        }

        public Record() { }


        public int Id {
            get { return id; }
            set { id = value; }
        }

        public int PatientId {
            get { return patient_id; }
            set { patient_id = value; }
        }

        public int DoctorId {
            get { return doctor_id; }
            set { doctor_id = value; }
        }

        public string AppointmentDate {
            get { return appointment_date; }
            set { appointment_date = value; }
        }

        public string Diagnosis {
            get { return diagnosis; }
            set { diagnosis = value; }
        }
        public string Treatment {
            get { return treatment; }
            set { treatment = value; }
        }

        public string Notes {
            get { return notes; }
            set { notes = value; }
        }
    }
}