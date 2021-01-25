using System.Collections.Generic;
using System.Threading.Tasks;
using RebelRegistration.Controllers;

namespace RebelRegistration.Services
{
    public interface IRebelRegisterService
    {
        Task ProcessRebels(List<RebelRequest> rebels);

        Task<string> GetPlanets();
    }
}
