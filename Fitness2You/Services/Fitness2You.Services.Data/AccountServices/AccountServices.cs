namespace Fitness2You.Services.Data.AccountServices
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Fitness2You.Data.Common.Repositories;
    using Fitness2You.Data.Models;
    using Fitness2You.Services.Mapping;
    using Fitness2You.Web.ViewModels.Account;
    using Microsoft.EntityFrameworkCore;

    public class AccountServices : IAccountServices
    {
        private readonly IRepository<UserClass> userClassRepository;
        private readonly IRepository<UserSubscription> userSubscriptionRepository;

        public AccountServices(
            IRepository<UserClass> userClassRepository,
            IRepository<UserSubscription> userSubscriptionRepository)
        {
            this.userClassRepository = userClassRepository;
            this.userSubscriptionRepository = userSubscriptionRepository;
        }

        public async Task<IList<UserClassInputViewModel>> GetUserClasses()
        {
            var info = await this.userClassRepository.All().To<UserClassInputViewModel>().ToListAsync();

            return info;
        }

        public async Task<IList<UserSubscriptionInputViewModel>> GetUserSubscriptions()
        {
            var info = await this.userSubscriptionRepository.All().To<UserSubscriptionInputViewModel>().ToListAsync();

            return info;
        }
    }
}
