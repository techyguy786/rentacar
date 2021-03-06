using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using vega.Core.Models;
using vega.Core;

namespace vega.Persistence
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly VegaDbContext context;

        public VehicleRepository(VegaDbContext context)
        {
            this.context = context;
        }
        public async Task<Vehicle> GetVehicle(int id, bool includeRelated = true)
        {
            if (!includeRelated)
                return await context.Vehicles.FindAsync(id);

            return await context.Vehicles
                .Include(v => v.VehicleFeatures)
                    .ThenInclude(vf => vf.Feature)
                .Include(v => v.Model)
                    .ThenInclude(m => m.Make)
                .SingleOrDefaultAsync(v => v.VehicleId == id);
        }

        public void Add(Vehicle vehicle)
        {
            context.Vehicles.Add(vehicle);
        }

        public void Delete(Vehicle vehicle)
        {
            context.Remove(vehicle);
        }
    }
}