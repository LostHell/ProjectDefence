namespace Fitness2You.Services.Data.LocationServices
{
    using System.Threading.Tasks;
    using Fitness2You.Data.Common.Repositories;
    using Fitness2You.Data.Models;
    using Fitness2You.Services.Mapping;
    using Fitness2You.Web.ViewModels.Locations;
    using Microsoft.EntityFrameworkCore;

    public class LocationsService : ILocationsService
    {
        private readonly IRepository<Location> repositoryLocation;

        public LocationsService(IRepository<Location> repositoryLocation)
        {
            this.repositoryLocation = repositoryLocation;
        }

        public async Task<LocationInputViewModel> AddLocation()
        {
            var location = new Location
            {
                Latitude = "52.4183",
                Longitude = "13.3137",
            };

            await this.repositoryLocation.AddAsync(location);
            await this.repositoryLocation.SaveChangesAsync();

            return await this.repositoryLocation.All().To<LocationInputViewModel>().FirstOrDefaultAsync();
        }

        public async Task<LocationInputViewModel> GetLocation()
        {
            var currentLocation =
                await this.repositoryLocation.All().To<LocationInputViewModel>().FirstOrDefaultAsync();

            if (currentLocation == null)
            {
                currentLocation = await this.AddLocation();
            }

            return currentLocation;
        }

        public async Task UpdateLocation(LocationInputViewModel location)
        {
            var updateLocation = await this.repositoryLocation.All().FirstOrDefaultAsync(x => x.Id == location.Id);

            if (updateLocation != null)
            {
                this.repositoryLocation.Delete(updateLocation);

                updateLocation = new Location
                {
                    Id = location.Id,
                    Latitude = location.Latitude,
                    Longitude = location.Longitude,
                };

                await this.repositoryLocation.AddAsync(updateLocation);
                await this.repositoryLocation.SaveChangesAsync();
            }
        }
    }
}