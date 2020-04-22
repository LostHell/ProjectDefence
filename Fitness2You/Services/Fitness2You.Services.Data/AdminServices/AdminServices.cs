namespace Fitness2You.Services.Data.AdminServices
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
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    public class AdminServices : IAdminServices
    {
        private readonly IRepository<Subscription> repositorySubscription;
        private readonly IRepository<Class> repositoryClass;
        private readonly IRepository<IdentityUserRole<string>> repositoryUserRole;
        private readonly IRepository<ApplicationRole> repositoryRole;
        private readonly IRepository<ApplicationUser> repositoryUser;
        private readonly IRepository<Trainer> repositoryTrainer;

        public AdminServices(
            IRepository<Subscription> repositorySubscription,
            IRepository<Class> repositoryClass,
            IRepository<IdentityUserRole<string>> repositoryUserRole,
            IRepository<ApplicationRole> repositoryRole,
            IRepository<ApplicationUser> repositoryUser,
            IRepository<Trainer> repositoryTrainer)
        {
            this.repositorySubscription = repositorySubscription;
            this.repositoryClass = repositoryClass;
            this.repositoryUserRole = repositoryUserRole;
            this.repositoryRole = repositoryRole;
            this.repositoryUser = repositoryUser;
            this.repositoryTrainer = repositoryTrainer;
        }

        // Start Class Services
        public async Task<IList<ClassesInputViewModel>> GetClasses()
        {
            var allClasses = await this.repositoryClass.All().To<ClassesInputViewModel>().ToListAsync();

            return allClasses;
        }

        public async Task AddNewClassAsync(ClassesInputViewModel classes)
        {
            var newClass = new Class()
            {
                Name = classes.Name,
                ImageUrl = classes.ImageUrl,
                Price = classes.Price,
                CreatedOn = DateTime.UtcNow,
                IsActive = classes.IsActive,
            };

            if (classes.Discount == null)
            {
                newClass.Discount = 0;
            }
            else
            {
                newClass.Discount = classes.Discount;
            }

            await this.repositoryClass.AddAsync(newClass);
            await this.repositoryClass.SaveChangesAsync();
        }

        public async Task<ClassesInputViewModel> GetClassIdAsync(int? id)
        {
            var subscription = await this.repositoryClass.All().To<ClassesInputViewModel>().FirstOrDefaultAsync(x => x.Id == id);

            return subscription;
        }

        public async Task EditClassAsync(ClassesInputViewModel subscriptions)
        {
            var currentClass = this.repositoryClass.All().FirstOrDefault(x => x.Id == subscriptions.Id);

            if (currentClass != null)
            {
                this.repositoryClass.Delete(currentClass);

                currentClass = new Class
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
                    currentClass.Discount = 0;
                }
                else
                {
                    currentClass.Discount = subscriptions.Discount;
                }

                await this.repositoryClass.AddAsync(currentClass);
            }

            await this.repositoryClass.SaveChangesAsync();
        }

        public async Task DeleteClassAsync(ClassesInputViewModel classes)
        {
            var currentClass = this.repositoryClass.All().FirstOrDefault(x => x.Id == classes.Id);

            if (currentClass != null)
            {
                this.repositoryClass.Delete(currentClass);
            }

            await this.repositoryClass.SaveChangesAsync();
        }

        // Finish Class Services

        // Start User Service
        public async Task<IList<UserInputViewModel>> GetAllUsers()
        {
            var allUsers = await this.repositoryUser.All().To<UserInputViewModel>().ToListAsync();

            return allUsers;
        }

        public async Task<IList<UserRoleInputViewModel>> GetUserRole()
        {
            var userRole = await this.repositoryUserRole.All().To<UserRoleInputViewModel>().ToListAsync();

            return userRole;
        }

        public async Task<IList<RoleInputViewModel>> GetRole()
        {
            var role = await this.repositoryRole.All().To<RoleInputViewModel>().ToListAsync();

            return role;
        }

        public async Task ChangeRole(string username)
        {
            var userRepo = await this.repositoryUser.All().FirstOrDefaultAsync(x => x.UserName == username);
            var userRoleRepo = await this.repositoryUserRole.All().Where(x => x.UserId == userRepo.Id).FirstOrDefaultAsync();
            var roleRepo = await this.repositoryRole.All().ToListAsync();

            var userRole = roleRepo.Where(x => x.Name == "User").Select(x => x.Id).FirstOrDefault();
            var adminRole = roleRepo.Where(x => x.Name == "Admin").Select(x => x.Id).FirstOrDefault();

            if (userRoleRepo.RoleId == userRole)
            {
                this.repositoryUserRole.Delete(userRoleRepo);

                userRoleRepo = new IdentityUserRole<string>()
                {
                    UserId = userRepo.Id,
                    RoleId = adminRole,
                };
            }
            else if (userRoleRepo.RoleId == adminRole)
            {
                this.repositoryUserRole.Delete(userRoleRepo);

                userRoleRepo = new IdentityUserRole<string>()
                {
                    UserId = userRepo.Id,
                    RoleId = userRole,
                };
            }

            await this.repositoryUserRole.AddAsync(userRoleRepo);
            await this.repositoryUserRole.SaveChangesAsync();
        }

        public async Task<ApplicationUser> GetUser(string username)
        {
            var user = await this.repositoryUser.All().FirstOrDefaultAsync(x => x.UserName == username);

            return user;
        }

        // Finish User Service

        // Start Employee Service
        public async Task<IList<EmployeeInputViewModel>> GetEmployees()
        {
            var allTrainers = await this.repositoryTrainer.All().To<EmployeeInputViewModel>().ToListAsync();

            return allTrainers;
        }

        public async Task AddNewEmployeeAsync(EmployeeInputViewModel employee)
        {
            var newEmployee = new Trainer()
            {
                FullName = employee.Fullname,
                ImageUrl = employee.ImageUrl,
                Salary = employee.Salary,
                Title = employee.Title,
                CreatedOn = DateTime.UtcNow,
            };

            await this.repositoryTrainer.AddAsync(newEmployee);
            await this.repositoryTrainer.SaveChangesAsync();
        }

        public async Task<EmployeeInputViewModel> GetEmployeeIdAsync(string id)
        {
            var employee = await this.repositoryTrainer.All().To<EmployeeInputViewModel>().FirstOrDefaultAsync(x => x.Id == id);

            return employee;
        }

        public async Task EditEmployeeAsync(EmployeeInputViewModel employee)
        {
            var currentEmployee = this.repositoryTrainer.All().FirstOrDefault(x => x.Id == employee.Id);

            if (currentEmployee != null)
            {
                this.repositoryTrainer.Delete(currentEmployee);

                currentEmployee = new Trainer
                {
                    Id = employee.Id,
                    FullName = employee.Fullname,
                    ImageUrl = employee.ImageUrl,
                    Salary = employee.Salary,
                    Title = employee.Title,
                    CreatedOn = DateTime.UtcNow,
                };

                await this.repositoryTrainer.AddAsync(currentEmployee);
            }

            await this.repositoryTrainer.SaveChangesAsync();
        }

        public async Task DeleteEmployeeAsync(EmployeeInputViewModel employee)
        {
            var currentEmployee = this.repositoryTrainer.All().FirstOrDefault(x => x.Id == employee.Id);

            if (currentEmployee != null)
            {
                this.repositoryTrainer.Delete(currentEmployee);
            }

            await this.repositoryTrainer.SaveChangesAsync();
        }

        // Finish Employee Service

        // Start Subscriptions Services //
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

        public async Task EditSubscriptionAsync(SubscriptionsInputViewModel subscriptions)
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

        public async Task DeleteSubscriptionAsync(SubscriptionsInputViewModel subscriptions)
        {
            var subs = this.repositorySubscription.All().FirstOrDefault(x => x.Id == subscriptions.Id);

            if (subs != null)
            {
                this.repositorySubscription.Delete(subs);
            }

            await this.repositorySubscription.SaveChangesAsync();
        }

        public async Task<SubscriptionsInputViewModel> GetSubscriptionIdAsync(int? id)
        {
            var subscription = await this.repositorySubscription.All().To<SubscriptionsInputViewModel>().FirstOrDefaultAsync(x => x.Id == id);

            return subscription;
        }

        // Finish Subscription Services
    }
}
