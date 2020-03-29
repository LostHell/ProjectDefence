namespace Fitness2You.Web.ViewModels.Footer
{
    using Fitness2You.Data.Models;
    using Fitness2You.Services.Mapping;

    public class ContactsViewModelsInFooter : IMapFrom<Contact>
    {
        public string Address { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }
    }
}
