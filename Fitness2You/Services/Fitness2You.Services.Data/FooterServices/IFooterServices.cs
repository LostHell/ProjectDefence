namespace Fitness2You.Services.Data.FooterServices
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Fitness2You.Web.ViewModels.Footer;

    public interface IFooterServices
    {
        Task<IList<ContactsViewModelsInFooter>> GetContacts();

        Task<IList<ClassesViewModelInFooter>> GetClasses();
    }
}
