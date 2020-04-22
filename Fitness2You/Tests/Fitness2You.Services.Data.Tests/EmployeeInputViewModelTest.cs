namespace Fitness2You.Services.Data.Tests
{
    using System.Text.RegularExpressions;

    using Fitness2You.Web.ViewModels.Trainer;
    using Xunit;

    public class EmployeeInputViewModelTest
    {
        [Theory]
        [InlineData("Maria Georgieva")]
        [InlineData("Eva Georgieva")]
        [InlineData("Eva Mendes")]
        [InlineData("Iva Petrov")]
        public void ValidFullname(string fullname)
        {
            var patternFullname = @"^[A-z]{3,}\ [A-z]{4,}$";
            Regex regex = new Regex(patternFullname);
            bool result = regex.IsMatch(fullname);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void ValidTitle()
        {
            var title = new EmployeeInputViewModel();
            title.Title = "Professnional trainer";
            var currentTitle = title.Title;
            Assert.Equal("Professnional trainer", currentTitle);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(9999)]
        [InlineData(10000)]
        public void ValidSalary(decimal salary)
        {
            var emplSalary = new EmployeeInputViewModel();
            emplSalary.Salary = salary;

            var result = emplSalary.Salary;

            Assert.True(result >= 0m && result <= 10000m);
        }
    }
}
