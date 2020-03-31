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
        private readonly IRepository<Subscription> subscriptionRepository;

        public SubscriptionsServices(IRepository<Subscription> subscriptionRepository)
        {
            this.subscriptionRepository = subscriptionRepository;
        }

        public async Task AddNewSubscriptionAsync(SubscriptionsInputViewModel subscriptions)
        {
            var newSubscription = new Subscription()
            {
                Name = subscriptions.Name,
                ImageUrl = subscriptions.ImageUrl,
                Price = subscriptions.Price,
                CreatedOn = DateTime.UtcNow,
                IsActive = subscriptions.IsActive,
            };

            if (subscriptions.Discount == null)
            {
                newSubscription.Discount = 0;
            }

            await this.subscriptionRepository.AddAsync(newSubscription);
            await this.subscriptionRepository.SaveChangesAsync();
        }

        public async Task<SubscriptionsInputViewModel> GetIdAsync(int? id)
        {
            var subscription = await this.subscriptionRepository.All().To<SubscriptionsInputViewModel>().FirstOrDefaultAsync(x => x.Id == id);

            return subscription;
        }

        public async Task<IList<SubscriptionsInputViewModel>> GetAll()
        {
            var allSubscriptions = await this.subscriptionRepository.All().To<SubscriptionsInputViewModel>().ToListAsync();

            return allSubscriptions;
        }

        public async Task EditAsync(SubscriptionsInputViewModel subscriptions)
        {
            var subs = this.subscriptionRepository.All().FirstOrDefault(x => x.Id == subscriptions.Id);

            if (subs != null)
            {
                this.subscriptionRepository.Delete(subs);

                subs = new Subscription
                {
                    Id = subscriptions.Id,
                    Name = subscriptions.Name,
                    ImageUrl = subscriptions.ImageUrl,
                    Price = subscriptions.Price,
                    CreatedOn = DateTime.UtcNow,
                    IsActive = subscriptions.IsActive,
                };

                if (subscriptions.Discount == null)
                {
                    subs.Discount = 0;
                }
                else
                {
                    subs.Discount = subscriptions.Discount;
                }

                await this.subscriptionRepository.AddAsync(subs);
            }

            await this.subscriptionRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(SubscriptionsInputViewModel subscriptions)
        {
            var subs = this.subscriptionRepository.All().FirstOrDefault(x => x.Id == subscriptions.Id);

            if (subs != null)
            {
                this.subscriptionRepository.Delete(subs);
            }

            await this.subscriptionRepository.SaveChangesAsync();
        }
    }
}
