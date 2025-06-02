using NUnit.Framework;
using System.Collections;

namespace Demo.Tests
{
    public class LoginTests
    {
        private ArrayList employeeList;

        [SetUp]
        public void Setup()
        {
            employeeList = new ArrayList();
            for (int i = 1; i <= 10; i++)
            {
                employeeList.Add(new Employee(
                    id: i,
                    name: i.ToString(),
                    gmail: $"{i}@gmail.com",
                    password: i.ToString(),
                    fullName: $"Employee {i}"
                ));
            }
        }

        private Employee TestLogin(string username, string password)
        {
            foreach (Employee emp in employeeList)
            {
                if (emp.Name == username && emp.Password == password)
                {
                    return emp;
                }
            }
            return null;
        }

        [Test]
        public void Login_CorrectCredentials_ReturnsEmployee()
        {
            var result = TestLogin("5", "5");
            Assert.That(result, Is.Not.Null);
            Assert.That(result.FullName, Is.EqualTo("Employee 5"));
        }

        [Test]
        public void Login_WrongPassword_ReturnsNull()
        {
            var result = TestLogin("3", "1");
            Assert.That(result, Is.Null);
        }

        [Test]
        public void Login_EmptyPassword_ReturnsNull()
        {
            var result = TestLogin("2", "");
            Assert.That(result, Is.Null);
        }

    }
}
