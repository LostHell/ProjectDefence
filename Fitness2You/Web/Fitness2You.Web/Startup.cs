namespace Fitness2You.Web
{
    using System;
    using System.Reflection;

    using Fitness2You.Data;
    using Fitness2You.Data.Common;
    using Fitness2You.Data.Common.Repositories;
    using Fitness2You.Data.Models;
    using Fitness2You.Data.Repositories;
    using Fitness2You.Data.Seeding;
    using Fitness2You.Services.Data.AccountServices;
    using Fitness2You.Services.Data.AdminServices;
    using Fitness2You.Services.Data.ClassService;
    using Fitness2You.Services.Data.FooterServices;
    using Fitness2You.Services.Data.HomeServices;
    using Fitness2You.Services.Data.SubscriptionsServices;
    using Fitness2You.Services.Data.TrainerServices;
    using Fitness2You.Services.Data.UserServices;
    using Fitness2You.Services.Mapping;
    using Fitness2You.Services.Messaging;
    using Fitness2You.Web.ViewModels;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(this.configuration.GetConnectionString("DefaultConnection")));

            // Service for make Cache
            // services.AddDistributedSqlServerCache(options =>
            // {
            //    options.ConnectionString = this.configuration.GetConnectionString("DefaultConnection");
            //    options.SchemaName = "dbo";
            //    options.TableName = "CacheRecords";
            // });
            // services.AddSession(options =>
            // {
            //    options.IdleTimeout = TimeSpan.FromDays(2);
            //    options.Cookie.HttpOnly = true;
            //    options.Cookie.IsEssential = true;
            // });
            services.AddDefaultIdentity<ApplicationUser>(IdentityOptionsProvider.GetIdentityOptions)
                .AddRoles<ApplicationRole>().AddEntityFrameworkStores<ApplicationDbContext>();

            services.Configure<CookiePolicyOptions>(
                options =>
                    {
                        options.CheckConsentNeeded = context => true;
                        options.MinimumSameSitePolicy = SameSiteMode.None;
                        options.ConsentCookie.Name = "Fitness2YouCookie";
                        options.ConsentCookie.Expiration = TimeSpan.FromDays(2);
                    });

            // Change route Authorize attribute
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Users/Login";
                options.ExpireTimeSpan = TimeSpan.FromDays(2);
                options.Cookie.Name = "Fitness2You_Cookie";
                options.Cookie.SameSite = SameSiteMode.Strict;
            });

            // Service for LogOut User after change Role
            services.Configure<SecurityStampValidatorOptions>(options =>
            {
                // enables immediate logout, after updating the user's stat.
                options.ValidationInterval = TimeSpan.Zero;
            });

            services.AddControllersWithViews();
            services.AddRazorPages();

            services.AddSingleton(this.configuration);

            // Data repositories
            services.AddScoped(typeof(IDeletableEntityRepository<>), typeof(EfDeletableEntityRepository<>));
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped<IDbQueryRunner, DbQueryRunner>();

            // Application services
            services.AddTransient<IEmailSender, NullMessageSender>();
            services.AddTransient<IHomeServices, HomeServices>();
            services.AddTransient<IFooterServices, FooterServices>();
            services.AddTransient<IUsersService, UsersService>();
            services.AddTransient<ISubscriptionsServices, SubscriptionsServices>();
            services.AddTransient<IClassesServices, ClassesServices>();
            services.AddTransient<ITrainersServices, TrainersServices>();
            services.AddTransient<IAdminServices, AdminServices>();
            services.AddTransient<IAccountServices, AccountServices>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly);

            // Seed data on application startup
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                dbContext.Database.Migrate();

                // new ApplicationDbContextSeeder().SeedAsync(dbContext, serviceScope.ServiceProvider).GetAwaiter().GetResult();
                new AdminUserAndRoleSeeder(dbContext, serviceScope.ServiceProvider).SeedDataAsync().GetAwaiter().GetResult();
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(
                endpoints =>
                    {
                        endpoints.MapControllerRoute("areaRoute", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                        endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
                        endpoints.MapRazorPages();
                    });
        }
    }
}
