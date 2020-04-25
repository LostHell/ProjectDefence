namespace Fitness2You.Services.Data.HomeServices
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Fitness2You.Web.ViewModels.Home;

    public interface IHomeServices
    {
        Task SendNewsLetter(NewsletterInputViewModel newsletter);

        Task<IList<BenefitsViewModel>> GetAllBenefits();
    }
}
