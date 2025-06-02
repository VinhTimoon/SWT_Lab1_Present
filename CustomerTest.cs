using NUnit.Framework;
using Lab1_V2;

namespace Lab1_V2.Tests
{
    [TestFixture]
    public class CustomerTest
    {
        [SetUp]
        public void Setup()
        {
            // Code này sẽ chạy trước mỗi test case
            Customer customer = new Customer();
        }

        [Test]
        public void CheckAge_AgeIs18_ReturnsTrue()
        {
            // Arrange
            Customer customer = new Customer { Age = 18 };

            // Act
            bool result = customer.CheckAge();

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void CheckAge_AgeIs60_ReturnsTrue()
        {
            // Arrange
            Customer customer = new Customer { Age = 60 };

            // Act
            bool result = customer.CheckAge();

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void CheckAge_AgeIs419_ReturnsTrue()
        {
            // Arrange
            Customer customer = new Customer { Age = 19 };

            // Act
            bool result = customer.CheckAge();

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void CheckAge_AgeIs17_ReturnsFalse()
        {
            // Arrange
            Customer customer = new Customer { Age = 17 };

            // Act
            bool result = customer.CheckAge();

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void CheckAge_AgeIs61_ReturnsFalse()
        {
            // Arrange
            Customer customer = new Customer { Age = 61 };

            // Act
            bool result = customer.CheckAge();

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void SetAge_NegativeAge_ThrowsArgumentException()
        {
            // Arrange
            Customer customer = new Customer();

            // Act & Assert
            Assert.Throws<ArgumentException>(() =>
            {
                customer.Age = -5;
            });
        }

        [TearDown]
        public void Cleanup()
        {

        }
    }
}