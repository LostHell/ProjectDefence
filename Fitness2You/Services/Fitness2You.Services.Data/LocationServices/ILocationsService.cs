namespace Fitness2You.Services.Data.LocationServices
{
    using System.Threading.Tasks;

    using Fitness2You.Web.ViewModels.Locations;

    public interface ILocationsService
    {
        Task<LocationInputViewModel> GetLocation();

        Task UpdateLocation(LocationInputViewModel location);
    }
}
