namespace Fitness2You.Services.Data.AccountServices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Fitness2You.Data.Common.Repositories;
    using Fitness2You.Data.Models;
    using Fitness2You.Services.Mapping;
    using Fitness2You.Web.ViewModels.Class;
    using Fitness2You.Web.ViewModels.Subscription;
    using Fitness2You.Web.ViewModels.Trainer;
    using Fitness2You.Web.ViewModels.User;
    using Microsoft.EntityFrameworkCore;

    public class AdminServices : IAdminServices
    {
        private readonly IRepository<Subscription> repositorySubscription;
        private readonly IRepository<Class> repositoryClass;
        private readonly IRepository<ApplicationUser> repositoryUser;
        private readonly IRepository<Trainer> repositoryTrainer;

        public AdminServices(
            IRepository<Subscription> repositorySubscription,
            IRepository<Class> repositoryClass,
            IRepository<ApplicationUser> repositoryUser,
            IRepository<Trainer> repositoryTrainer)
        {
            this.repositorySubscription = repositorySubscription;
            this.repositoryClass = repositoryClass;
            this.repositoryUser = repositoryUser;
            this.repositoryTrainer = repositoryTrainer;
        }

        public async Task<IList<ClassesViewModel>> GetClasses()
        {
            var allClasses = await this.repositoryClass.All().To<ClassesViewModel>().ToListAsync();

            return allClasses;
        }

        public async Task<IList<AllUserViewModel>> GetAllUsers()
        {
            var allUsers = await this.repositoryUser.All().To<AllUserViewModel>().ToListAsync();

            return allUsers;
        }

        public async Task<IList<EmployeeViewModel>> GetEmployees()
        {
            var allTrainers = await this.repositoryTrainer.All().To<EmployeeViewModel>().ToListAsync();

            return allTrainers;
        }

        // Subscriptions Services //
        public async Task<IList<SubscriptionsInputViewModel>> GetSubscriptions()
        {
            var allSubscriptions = await this.repositorySubscription.All().To<SubscriptionsInputViewModel>().ToListAsync();

            return allSubscriptions;
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
            else
            {
                newSubscription.Discount = subscriptions.Discount;
            }

            await this.repositorySubscription.AddAsync(newSubscription);
            await this.repositorySubscription.SaveChangesAsync();
        }

        public async Task EditAsync(SubscriptionsInputViewModel subscriptions)
        {
            var subs = this.repositorySubscription.All().FirstOrDefault(x => x.Id == subscriptions.Id);

            if (subs != null)
            {
                this.repositorySubscription.Delete(subs);

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

                await this.repositorySubscription.AddAsync(subs);
            }

            await this.repositorySubscription.SaveChangesAsync();
        }

        public async Task DeleteAsync(SubscriptionsInputViewModel subscriptions)
        {
            var subs = this.repositorySubscription.All().FirstOrDefault(x => x.Id == subscriptions.Id);

            if (subs != null)
            {
                this.repositorySubscription.Delete(subs);
            }

            await this.repositorySubscription.SaveChangesAsync();
        }

        public async Task<SubscriptionsInputViewModel> GetIdAsync(int? id)
        {
            var subscription = await this.repositorySubscription.All().To<SubscriptionsInputViewModel>().FirstOrDefaultAsync(x => x.Id == id);

            return subscription;
        }

        // Finish Subscription Services
    }
}
