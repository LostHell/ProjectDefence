namespace Fitness2You.Services.Data.SubscriptionsServices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Fitness2You.Data.Common.Repositories;
    using Fitness2You.Data.Models;
    using Fitness2You.Services.Mapping;
    using Fitness2You.Web.ViewModels.Subscription;
    using Microsoft.EntityFrameworkCore;

    public class SubscriptionsServices : ISubscriptionsServices
    {
        private readonly IRepository<ApplicationUser> userRepository;
        private readonly IRepository<Subscription> subscriptionRepository;
        private readonly IRepository<UserSubscription> userSubscriptionRepository;

        public SubscriptionsServices(
            IRepository<ApplicationUser> userRepository,
            IRepository<Subscription> subscriptionRepository,
            IRepository<UserSubscription> userSubscriptionRepository)
        {
            this.userRepository = userRepository;
            this.subscriptionRepository = subscriptionRepository;
            this.userSubscriptionRepository = userSubscriptionRepository;
        }

        public async Task AddUserToSubscription(int id, string username)
        {
            var user = this.userRepository.All().FirstOrDefault(x => x.UserName == username);

            var userToSubscription = new UserSubscription()
            {
                SubscriptionId = id,
                UserId = user.Id,
                TakeOn = DateTime.UtcNow,
            };

            await this.userSubscriptionRepository.AddAsync(userToSubscription);
            await this.userSubscriptionRepository.SaveChangesAsync();
        }

        public async Task<IList<SubscriptionsInputViewModel>> GetAll()
        {
            var allSubscriptions = await this.subscriptionRepository.All().To<SubscriptionsInputViewModel>().ToListAsync();

            return allSubscriptions;
        }
    }
}
