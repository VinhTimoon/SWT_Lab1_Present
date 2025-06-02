using System;
using System.Collections;

namespace Demo
{
    internal class Program
    {
        static ArrayList employeeList = new ArrayList();
        static Employee currentUser = null;

        static void Main(string[] args)
        {
            for (int i = 1; i <= 10; i++)
            {
                Employee employee = new Employee(
                    id: i,
                    name: i.ToString(),
                    gmail: $"{i}@gmail.com",
                    password: i.ToString(),
                    fullName: $"Employee {i}"
                );
                employeeList.Add(employee);
            }

            while (true)
            {
                if (currentUser == null)
                {
                    Console.WriteLine("\n=== LOGIN MENU ===");
                    Console.WriteLine("1. Login");
                    Console.WriteLine("0. Exit");
                    Console.Write("Enter your choice: ");

                    int choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            Login();
                            break;
                        case 0:
                            Console.WriteLine("Goodbye!");
                            return;
                        default:
                            Console.WriteLine("Invalid choice!");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine($"\n=== MAIN MENU (Logged in as: {currentUser.FullName}) ===");
                    Console.WriteLine("1. Show All Employees");
                    Console.WriteLine("2. Create New Employee");
                    Console.WriteLine("3. Update Employee");
                    Console.WriteLine("4. Delete Employee");
                    Console.WriteLine("5. Search Employee by ID");
                    Console.WriteLine("6. Logout");
                    Console.WriteLine("0. Exit");
                    Console.Write("Enter your choice: ");

                    int choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            ShowAll();
                            break;
                        case 2:
                            Create();
                            break;
                        case 3:
                            Update();
                            break;
                        case 4:
                            Delete();
                            break;
                        case 5:
                            SearchById();
                            break;
                        case 6:
                            Logout();
                            break;
                        case 0:
                            Console.WriteLine("Goodbye!");
                            return;
                        default:
                            Console.WriteLine("Invalid choice!");
                            break;
                    }
                }
            }
        }

        static void Login()
        {
            Console.Write("Enter username: ");
            string username = Console.ReadLine();
            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            foreach (Employee emp in employeeList)
            {
                if (emp.Name == username && emp.Password == password)
                {
                    currentUser = emp;
                    Console.WriteLine($"Welcome {emp.FullName}!");
                    return;
                }
            }
            Console.WriteLine("Invalid credentials!");
        }

        static void Logout()
        {
            currentUser = null;
            Console.WriteLine("Logged out successfully!");
        }

        static void ShowAll()
        {
            if (employeeList.Count == 0)
            {
                Console.WriteLine("No employees found!");
                return;
            }

            foreach (Employee emp in employeeList)
            {
                Console.WriteLine($"ID: {emp.Id}");
                Console.WriteLine($"Username: {emp.Name}");
                Console.WriteLine($"Gmail: {emp.Gmail}");
                Console.WriteLine($"Full Name: {emp.FullName}");
                Console.WriteLine("------------------------");
            }
        }

        static void Create()
        {
            Console.Write("Enter ID: ");
            int id = Convert.ToInt32(Console.ReadLine());
            
            if (GetById(id) != null)
            {
                Console.WriteLine("Employee with this ID already exists!");
                return;
            }

            Console.Write("Enter Username: ");
            string username = Console.ReadLine();
            Console.Write("Enter Gmail: ");
            string gmail = Console.ReadLine();
            Console.Write("Enter Password: ");
            string password = Console.ReadLine();
            Console.Write("Enter Full Name: ");
            string fullName = Console.ReadLine();

            Employee newEmployee = new Employee(id, username, gmail, password, fullName);
            employeeList.Add(newEmployee);
            Console.WriteLine("Employee created successfully!");
        }

        static void Update()
        {
            Console.Write("Enter ID to update: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Employee emp = GetById(id);

            if (emp == null)
            {
                Console.WriteLine("Employee not found!");
                return;
            }

            Console.Write("Enter new Username (press Enter to skip): ");
            string username = Console.ReadLine();
            if (!string.IsNullOrEmpty(username)) emp.Name = username;

            Console.Write("Enter new Gmail (press Enter to skip): ");
            string gmail = Console.ReadLine();
            if (!string.IsNullOrEmpty(gmail)) emp.Gmail = gmail;

            Console.Write("Enter new Password (press Enter to skip): ");
            string password = Console.ReadLine();
            if (!string.IsNullOrEmpty(password)) emp.Password = password;

            Console.Write("Enter new Full Name (press Enter to skip): ");
            string fullName = Console.ReadLine();
            if (!string.IsNullOrEmpty(fullName)) emp.FullName = fullName;

            Console.WriteLine("Employee updated successfully!");
        }

        static void Delete()
        {
            Console.Write("Enter ID to delete: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Employee emp = GetById(id);

            if (emp == null)
            {
                Console.WriteLine("Employee not found!");
                return;
            }

            employeeList.Remove(emp);
            Console.WriteLine("Employee deleted successfully!");
        }

        static void SearchById()
        {
            Console.Write("Enter ID to search: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Employee emp = GetById(id);

            if (emp == null)
            {
                Console.WriteLine("Employee not found!");
                return;
            }

            Console.WriteLine($"ID: {emp.Id}");
            Console.WriteLine($"Username: {emp.Name}");
            Console.WriteLine($"Gmail: {emp.Gmail}");
            Console.WriteLine($"Full Name: {emp.FullName}");
        }

        static Employee GetById(int id)
        {
            foreach (Employee emp in employeeList)
            {
                if (emp.Id == id)
                {
                    return emp;
                }
            }
            return null;
        }
    }
}
