using RebelRegistration.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RebelRegistration.Repositories
{
    public interface IPlanetRepository
    {
        Task<List<Planet>> GetPlanetsAsync();
    }
}