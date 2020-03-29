namespace Fitness2You.Services.Data.FooterServices
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Fitness2You.Data.Common.Repositories;
    using Fitness2You.Data.Models;
    using Fitness2You.Services.Mapping;
    using Fitness2You.Web.ViewModels.Footer;
    using Microsoft.EntityFrameworkCore;

    public class FooterServices : IFooterServices
    {
        private readonly IRepository<Contact> repositoryContact;
        private readonly IRepository<Class> repositoryClass;

        public FooterServices(
            IRepository<Contact> repositoryContact,
            IRepository<Class> repositoryClass)
        {
            this.repositoryContact = repositoryContact;
            this.repositoryClass = repositoryClass;
        }

        public async Task<IList<ContactsViewModelsInFooter>> GetContacts()
        {
            var contacs = await this.repositoryContact.All().To<ContactsViewModelsInFooter>().ToListAsync();

            return contacs;
        }

        public async Task<IList<ClassesViewModelInFooter>> GetClasses()
        {
            var classes = await this.repositoryClass.All().To<ClassesViewModelInFooter>().ToListAsync();

            return classes;
        }
    }
}
