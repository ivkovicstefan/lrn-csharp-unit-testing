using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestClass]
    public class ReservationTests
    {
        [TestMethod]
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
            Assert.IsTrue(result);
        }

        [TestMethod]
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
            Assert.IsTrue(result);
        }

        [TestMethod]
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
            Assert.IsFalse(result);
        }
    }
}