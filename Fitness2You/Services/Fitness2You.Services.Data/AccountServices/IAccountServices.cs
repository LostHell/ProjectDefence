namespace Fitness2You.Services.Data.AccountServices
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Fitness2You.Web.ViewModels.Account;

    public interface IAccountServices
    {
        Task<IList<UserSubscriptionInputViewModel>> GetUserSubscriptions();

        Task<IList<UserClassInputViewModel>> GetUserClasses();
    }
}
