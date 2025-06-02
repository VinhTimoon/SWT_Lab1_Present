using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    public class Employee
    {
        private int id;
        private string name;
        private string gmail;
        private string password;
        private string fullName;

        public Employee(int id, string name, string gmail, string password, string fullName)
        {
            this.id = id;
            this.name = name;
            this.gmail = gmail;
            this.password = password;
            this.fullName = fullName;
        }

        // Properties
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Gmail
        {
            get { return gmail; }
            set { gmail = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }
    }
}
