using System;
using System.Collections.Generic;

namespace Demo
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; } // Username
        public string Password { get; set; }
        public string FullName { get; set; }

        public Employee(int id, string name, string password, string fullName)
        {
            Id = id;
            Name = name;
            Password = password;
            FullName = fullName;
        }
    }

    public class LoginService
    {
        private List<Employee> employeeList;

        public LoginService()
        {
            employeeList = new List<Employee>();
            for (int i = 1; i <= 10; i++)
            {
                employeeList.Add(new Employee(
                    id: i,
                    name: $"{i}",
                    password: $"{i}",
                    fullName: $"Employee {i}"
                ));
            }
        }

        public Employee Login(string username, string password)
        {
            foreach (var emp in employeeList)
            {
                if (emp.Name == username && emp.Password == password)
                {
                    return emp;
                }
            }
            return null;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            LoginService loginService = new LoginService();

            Console.Write("Enter username: ");
            string username = Console.ReadLine();

            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            Employee emp = loginService.Login(username, password);

            if (emp != null)
            {
                Console.WriteLine($"Welcome {emp.FullName}!");
            }
            else
            {
                Console.WriteLine("Invalid credentials!");
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
