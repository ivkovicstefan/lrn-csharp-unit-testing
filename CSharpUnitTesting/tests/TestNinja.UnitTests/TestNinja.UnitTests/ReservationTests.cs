using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestClass]
    public class ReservationTests
    {
        [TestMethod]
        public void CanBeCancelledBy_UserIsAdmin_ReturnsTrue()
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
    }
}