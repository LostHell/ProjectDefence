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

        public async Task<IList<SubscriptionsInputViewModel>> GetAll()
        {
            var allSubscriptions = await this.subscriptionRepository.All().To<SubscriptionsInputViewModel>().ToListAsync();

            return allSubscriptions;
        }
    }
}
