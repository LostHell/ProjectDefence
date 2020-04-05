namespace Fitness2You.Services.Data.TrainerServices
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Fitness2You.Data.Common.Repositories;
    using Fitness2You.Data.Models;
    using Fitness2You.Services.Mapping;
    using Fitness2You.Web.ViewModels.Trainer;
    using Microsoft.EntityFrameworkCore;

    public class TrainersServices : ITrainersServices
    {
        private readonly IRepository<Trainer> repositoryTrainer;

        public TrainersServices(IRepository<Trainer> repositoryTrainer)
        {
            this.repositoryTrainer = repositoryTrainer;
        }

        public async Task<IList<EmployeeInputViewModel>> GetEmployees()
        {
            var allTrainers = await this.repositoryTrainer.All().To<EmployeeInputViewModel>().ToListAsync();

            return allTrainers;
        }
    }
}
