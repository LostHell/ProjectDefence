namespace Fitness2You.Web.ViewModels.Home
{
    using System.Collections.Generic;

    public class HomeViewModel
    {
        public IEnumerable<BenefitsViewModel> Benefits { get; set; }

        public NewsletterInputViewModel Newsletters { get; set; }
    }
}
