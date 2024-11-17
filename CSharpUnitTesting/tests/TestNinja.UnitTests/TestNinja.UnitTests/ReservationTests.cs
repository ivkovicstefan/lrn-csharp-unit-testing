using NUnit.Framework;
using TestNinja.Fundamentals;
using Assert = NUnit.Framework.Assert;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class ReservationTests
    {
        [Test]
        public void CanBeCancelledBy_Admin_ReturnsTrue()
        {
            // Arrange
            var user = new User
            {
                IsAdmin = false,
            };

            var admin = new User
            {
                IsAdmin = true
            };

            var reservation = new Reservation
            {
                MadeBy = user
            };

            // Act
            var result = reservation.CanBeCancelledBy(admin);

            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void CanBeCancelledBy_SameUser_ReturnsTrue()
        {
            // Arrange
            var user = new User();
            var reservation = new Reservation
            {
                MadeBy = user
            };

            // Act
            var result = reservation.CanBeCancelledBy(user);

            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void CanBeCancelledBy_AnotherUser_ReturnsFalse()
        {
            // Arrange
            var user1 = new User();
            var reservation = new Reservation
            {
                MadeBy = user1
            };
            var user2 = new User();

            // Act
            var result = reservation.CanBeCancelledBy(user2);

            // Assert
            Assert.That(result, Is.False);
        }
    }
}