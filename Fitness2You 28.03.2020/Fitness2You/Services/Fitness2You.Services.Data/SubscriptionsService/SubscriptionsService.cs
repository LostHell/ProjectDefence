namespace Fitness2You.Services.Data.SubscriptionsService
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Fitness2You.Data.Common.Repositories;
    using Fitness2You.Data.Models;
    using Fitness2You.Web.ViewModels.Subscriptions;

    public class SubscriptionsService : ISubscriptionsService
    {
        private readonly IRepository<Subscription> entityRepository;

        public SubscriptionsService(IRepository<Subscription> entityRepository)
        {
            this.entityRepository = entityRepository;
        }

        public async Task AddSubscription(InputSubscriptionsViewModel input)
        {
            var newSubscription = new Subscription
            {
                Name = input.Name,
                Description = input.Description,
                Price = input.Price,
                Discount = input.Discount,
                ImageUrl = input.ImagePath,
                CreatedOn = DateTime.UtcNow,
                IsActive = true,
            };

            await this.entityRepository.AddAsync(newSubscription);
            await this.entityRepository.SaveChangesAsync();
        }

        public bool ExistName(string name)
        {
            return this.entityRepository.All().Any(x => x.Name == name);
        }
    }
}
