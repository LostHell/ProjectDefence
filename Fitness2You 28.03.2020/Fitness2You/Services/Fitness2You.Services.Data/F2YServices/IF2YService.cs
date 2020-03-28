namespace Fitness2You.Services.Data.F2YServices
{
    using System.Collections.Generic;

    using Fitness2You.Web.ViewModels.F2Y;

    public interface IF2YService
    {
        IEnumerable<UsersViewModel> All();
    }
}
