using RebelRegistration.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RebelRegistration.Repositories
{
    public class PlanetLogRepository : IPlanetLogRepository
    {
        public readonly UniverseContext _context;

        public PlanetLogRepository(UniverseContext context)
        {
            _context = context;
        }

        public Task SetPlanetLog(List<PlanetLog> rebels)
        {
            _context.PlanetLogs.AddRange(rebels);
            _context.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
