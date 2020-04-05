namespace Fitness2You.Services.Data.TrainerServices
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Fitness2You.Web.ViewModels.Trainer;

    public interface ITrainersServices
    {
        Task<IList<EmployeeInputViewModel>> GetEmployees();
    }
}
