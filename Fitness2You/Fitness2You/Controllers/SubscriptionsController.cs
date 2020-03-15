using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Fitness2You.Controllers
{
    public class SubscriptionsController : Controller
    {
        public IActionResult Subscription()
        {
            return View();
        }
    }
}