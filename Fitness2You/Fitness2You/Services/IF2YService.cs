using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Fitness2You.Services
{
    public interface IF2YService
    {
        IEnumerable<IdentityUser> All();
    }
}
