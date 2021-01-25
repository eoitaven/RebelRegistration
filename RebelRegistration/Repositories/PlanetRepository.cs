using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RebelRegistration.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RebelRegistration.Repositories
{
    public class PlanetRepository : IPlanetRepository
    {
        public readonly UniverseContext _context;
        public readonly ILogger<IPlanetRepository> _logger;

        public PlanetRepository(UniverseContext context, ILogger<IPlanetRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<List<Planet>> GetPlanetsAsync()
        {
            try
            {
                var list = await _context.Planets.ToListAsync();
                return list;

            } catch (Exception ex) {

                _logger.LogError(ex, "Error access database, table Planet");
           }
            return new List<Planet>();
        }
    }
}
