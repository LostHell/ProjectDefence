namespace Fitness2You.Services.Data.Tests
{
    using Fitness2You.Web.ViewModels.Users;
    using Xunit;

    public class LoginInputModelTests
    {
        [Fact]
        public void LoginUsernameFormShouldBeValid()
        {
            // Arrange
            var validation = new LoginInputViewModel()
            {
                Username = "admin",
            };

            // Act
            var isValid = validation.Username.Length >= 5;

            // Assert
            Assert.True(isValid);
        }

        [Fact]
        public void LoginPasswordFormShouldBeValid()
        {
            // Arrange
            var validation = new LoginInputViewModel()
            {
                Password = "admina",
            };

            // Act
            var isValid = validation.Password.Length >= 6;

            // Assert
            Assert.True(isValid);
        }

        [Fact]
        public void LoginUsernameFormShouldBeINValid()
        {
            // Arrange
            var validation = new LoginInputViewModel()
            {
                Username = "adm",
            };

            // Act
            var isValid = validation.Username.Length >= 5;

            // Assert
            Assert.False(isValid);
        }

        [Fact]
        public void LoginPasswordFormShouldBeINValid()
        {
            // Arrange
            var validation = new LoginInputViewModel()
            {
                Password = "adm",
            };

            // Act
            var isValid = validation.Password.Length >= 6;

            // Assert
            Assert.False(isValid);
        }
    }
}
