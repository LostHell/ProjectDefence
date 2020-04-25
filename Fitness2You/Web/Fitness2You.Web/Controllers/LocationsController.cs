namespace Fitness2You.Web.Controllers
{
    using System.Threading.Tasks;

    using Fitness2You.Services.Data.LocationServices;
    using Fitness2You.Web.ViewModels.Locations;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class LocationsController : Controller
    {
        private readonly ILocationsService locationsService;

        public LocationsController(ILocationsService locationsService)
        {
            this.locationsService = locationsService;
        }

        public async Task<IActionResult> OurLocation()
        {
            var location = await this.locationsService.GetLocation();
            return this.View(location);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> OurLocation(LocationInputViewModel location)
        {
            if (!this.ModelState.IsValid)
            {
                this.ModelState.AddModelError(string.Empty, "Please, write valid coordinate");
                return this.NotFound();
            }

            await this.locationsService.UpdateLocation(location);
            return this.RedirectToAction("OurLocation");
        }
    }
}
