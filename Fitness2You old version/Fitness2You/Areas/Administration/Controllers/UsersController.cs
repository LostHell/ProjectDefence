using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fitness2You.Areas.Administration.Controllers
{
    [Area("Administration")]
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}
