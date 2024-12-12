using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthCentre {
    public class User {
        private int id;
        private string pin;
        private string password;
        private string email;
        private string role;
        private string first_name;
        private string last_name;
        private string dob;
        private string address;
        private int phone;
        private string created_at;
        private string updated_at;

        public int Id {
            get { return id; }
            set { id = value; }
        }

        public string Pin {
            get { return pin; }
            set { pin = value; }
        }

        public string Password {
            get { return password; }
            set { password = value; }
        }

        public string Email {
            get { return email; }
            set { email = value; }
        }

        public string Role {
            get { return role; }
            set { role = value; }
        }

        public string First_Name {
            get { return first_name; }
            set { first_name = value; }
        }

        public string Last_Name {
            get { return last_name; }
            set { last_name = value; }
        }

        public string Dob {
            get { return dob; }
            set { dob = value; }
        }

        public string Address {
            get { return address; }
            set { address = value; }
        }

        public int Phone {
            get { return phone; }
            set { phone = value; }
        }

        public string Created_at {
            get { return created_at; }
            set { created_at = value; }
        }
        public string Updated_at {
            get { return updated_at; }
            set { updated_at = value; }
        }

        public User(int ID, string PIN, string PASSWORD, string EMAIL, string ROLE, string FIRST_NAME,
            string LAST_NAME, string DOB, string ADDRESS, int PHONE, string CREATED_AT, string UPDATED_AT) {
            this.Id = ID;
            this.Pin = PIN;
            this.Password = PASSWORD;
            this.Email = EMAIL;
            this.Role = ROLE;
            this.First_Name = FIRST_NAME;
            this.Last_Name = LAST_NAME;
            this.Dob = DOB;
            this.Address = ADDRESS;
            this.Phone = PHONE;
            this.Created_at = CREATED_AT;
            this.Updated_at = UPDATED_AT;
        }

        public User() { }

    }
}