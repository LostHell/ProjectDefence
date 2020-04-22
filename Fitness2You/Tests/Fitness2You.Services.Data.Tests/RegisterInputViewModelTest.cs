namespace Fitness2You.Services.Data.Tests
{
    using System.Text.RegularExpressions;

    using Fitness2You.Web.ViewModels.User;
    using Xunit;

    public class RegisterInputViewModelTest
    {
        [Theory]
        [InlineData("admin")]
        [InlineData("administrator")]
        [InlineData("wowbeat")]
        [InlineData("losthell")]
        [InlineData("zodiaka")]
        public void ValidUsername(string username)
        {
            // Activate
            var validationUser = new RegisterInputViewModel();

            // Act
            var result = validationUser.Username = username;

            // Assert
            Assert.True(result.Length >= 5 && result.Length <= 30);
        }

        [Theory]
        [InlineData("admi")]
        [InlineData("wow")]
        [InlineData("lo")]
        [InlineData(" ")]
        [InlineData("administratoradministratoradministrator")]
        public void InvalidUsername(string username)
        {
            // Activate
            var validationUser = new RegisterInputViewModel();

            // Act
            var result = validationUser.Username = username;

            // Assert
            Assert.False(result.Length >= 5 && result.Length <= 30);
        }

        [Theory]
        [InlineData("admin@admin.com")]
        [InlineData("localhost@admin.com")]
        [InlineData("wowbeat@gmail.com")]
        [InlineData("niki@gmail.com")]
        [InlineData("peter@yahoo.com")]
        public void ValidEmail(string email)
        {
            var patternEmail = @"^[A-z0-9\.]{3,30}\@[A-z]{3,11}\.[A-z]{2,7}$";
            Regex regex = new Regex(patternEmail);
            bool isValid = regex.IsMatch(email);

            // Assert
            Assert.True(isValid);
        }

        [Theory]
        [InlineData("admin.com")]
        [InlineData("localhost.admin.com")]
        [InlineData("@gmail.com")]
        [InlineData("niki@gmail.")]
        [InlineData("peter@yahoo")]
        public void InvalidEmail(string email)
        {
            // Act
            var patternEmail = @"^[A-z0-9\.]{3,30}\@[A-z]{3,11}\.[A-z]{2,7}$";
            Regex regex = new Regex(patternEmail);
            bool isValid = regex.IsMatch(email);

            // Assert
            Assert.False(isValid);
        }

        [Theory]
        [InlineData("0891234567")]
        [InlineData("0881234567")]
        [InlineData("0871234567")]
        public void ValidPhone(string phone)
        {
            // Act
            var patternPhone = @"^[0]{1}[8]{1}[7-9]{1}[0-9]{7}$";
            Regex regex = new Regex(patternPhone);
            bool isValid = regex.IsMatch(phone);

            // Assert
            Assert.True(isValid);
        }

        [Theory]
        [InlineData("")]
        [InlineData("087123")]
        [InlineData("0123456789")]
        [InlineData("08912345671")]
        [InlineData("088 1234 567")]
        public void InvalidPhone(string phone)
        {
            // Act
            var patternPhone = @"^[0]{1}[8]{1}[7-9]{1}[0-9]{7}$";
            Regex regex = new Regex(patternPhone);
            bool isValid = regex.IsMatch(phone);

            // Assert
            Assert.False(isValid);
        }

        [Theory]
        [InlineData("password")]
        [InlineData("newpassword")]
        [InlineData("password123")]
        [InlineData("myNewPassword")]
        [InlineData("myNewPassword!")]
        public void ValidPassword(string password)
        {
            // Activate
            var validationPassword = new RegisterInputViewModel();

            // Act
            var result = validationPassword.Password = password;

            // Assert
            Assert.True(result.Length >= 6 && result.Length <= 30);
        }

        [Theory]
        [InlineData(" ")]
        [InlineData("my!")]
        [InlineData("new")]
        [InlineData("pas3")]
        [InlineData("myNed")]
        public void InvalidPassword(string password)
        {
            // Activate
            var validationPassword = new RegisterInputViewModel();

            // Act
            var result = validationPassword.Password = password;

            // Assert
            Assert.False(result.Length >= 6 && result.Length <= 30);
        }
    }
}
