namespace Fitness2You.Services.Data.AccountServices
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Fitness2You.Data.Common.Repositories;
    using Fitness2You.Data.Models;
    using Fitness2You.Services.Mapping;
    using Fitness2You.Web.ViewModels.Subscription;
    using Microsoft.EntityFrameworkCore;

    public class AccountServices : IAccountServices
    {
        private readonly IRepository<Subscription> repositorySubscription;

        public AccountServices(IRepository<Subscription> repositorySubscription)
        {
            this.repositorySubscription = repositorySubscription;
        }

        public async Task<IList<SubscriptionsViewModel>> GetSubscriptions()
        {
            var allSubscriptions = await this.repositorySubscription.All().To<SubscriptionsViewModel>().ToListAsync();

            return allSubscriptions;
        }
    }
}
