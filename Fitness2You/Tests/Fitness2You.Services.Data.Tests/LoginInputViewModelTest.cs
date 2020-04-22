namespace Fitness2You.Services.Data.Tests
{
    using Fitness2You.Web.ViewModels.User;
    using Xunit;

    public class LoginInputViewModelTest
    {
        [Fact]
        public void UsernameShouldBeBetween5And30SymbolsLong()
        {
            // Activate
            var validationUser = new LoginInputViewModel();

            // Act
            var username = validationUser.Username = "admin";

            // Assert
            Assert.True(username.Length >= 5 && username.Length <= 30);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("admi")]
        [InlineData("asdfghfdsadfgdsafgdsafgdssafgdssafsfdfdsasdfg")]
        public void InvalidUsername(string username)
        {
            // Arrange
            var invalidUser = new LoginInputViewModel();

            // Act
            var result = invalidUser.Username = username;

            // Assert
            Assert.False(result.Length >= 5 && result.Length <= 30);
        }

        [Fact]
        public void PasswordShouldBeBetween6And30CharactersLong()
        {
            // Activate
            var validationPassword = new LoginInputViewModel();

            // Act
            var password = validationPassword.Password = "Karadzhov...";

            // Assert
            Assert.True(password.Length >= 6 && password.Length <= 30);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("admi")]
        [InlineData("asdfghfdsadfgdsafgdsafgdssafgdssafsfdfdsasdfg")]
        public void InvalidPassword(string password)
        {
            // Arrange
            var invalidPassword = new LoginInputViewModel();

            // Act
            var result = invalidPassword.Password = password;

            // Assert
            Assert.False(result.Length >= 6 && result.Length <= 30);
        }
    }
}
