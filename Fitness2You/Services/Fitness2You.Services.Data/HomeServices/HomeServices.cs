namespace Fitness2You.Services.Data.HomeServices
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Fitness2You.Data.Common.Repositories;
    using Fitness2You.Data.Models;
    using Fitness2You.Services.Mapping;
    using Fitness2You.Web.ViewModels.Home;
    using Microsoft.EntityFrameworkCore;

    public class HomeServices : IHomeServices
    {
        private readonly IRepository<Newsletter> repositoryNewsletter;
        private readonly IRepository<Benefit> repositoryBenefit;

        public HomeServices(
            IRepository<Newsletter> repositoryNewsletter,
            IRepository<Benefit> repositoryBenefit)
        {
            this.repositoryNewsletter = repositoryNewsletter;
            this.repositoryBenefit = repositoryBenefit;
        }

        public async Task<IList<BenefitsViewModel>> GetAllBenefits()
        {
            var allBenefits = await this.repositoryBenefit.All().To<BenefitsViewModel>().ToListAsync();

            return allBenefits;
        }

        public async Task SendNewsLetter(NewsletterInputViewModel newsletter)
        {
            var findNewsletter = await this.repositoryNewsletter.All().FirstOrDefaultAsync(x => x.Email == newsletter.Email && x.Fullname == newsletter.Fullname);

            if (findNewsletter == null)
            {
                findNewsletter = new Newsletter()
                {
                    Fullname = newsletter.Fullname,
                    Email = newsletter.Email,
                    SendOn = DateTime.UtcNow,
                };
            }

            await this.repositoryNewsletter.AddAsync(findNewsletter);
            await this.repositoryNewsletter.SaveChangesAsync();
        }
    }
}
