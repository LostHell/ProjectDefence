namespace Fitness2You.Web.Controllers
{
    using System.Threading.Tasks;

    using Fitness2You.Services.Data.TrainerServices;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class TrainersController : Controller
    {
        private readonly ITrainersServices trainersServices;

        public TrainersController(ITrainersServices trainersServices)
        {
            this.trainersServices = trainersServices;
        }

        public async Task<IActionResult> OurTrainers()
        {
            var allTrainers = await this.trainersServices.GetEmployees();
            return this.View(allTrainers);
        }
    }
}
