using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RebelRegistration.Services;

namespace RebelRegistration.Controllers
{
    [Route("api/[controller]")]
    public class RebelRegisterController: ControllerBase
    {
        private readonly IRebelRegisterService _rebelRegisterService;

        public RebelRegisterController(IRebelRegisterService rebelRegisterService)
        {
            _rebelRegisterService = rebelRegisterService;
        }

        [HttpPost]
        [Route("setrebels")]
        public async Task<ActionResult> Post([FromBody] List<RebelRequest> body)
        {
            await _rebelRegisterService.ProcessRebels(body);
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var list = await _rebelRegisterService.GetPlanets();
            return Ok(list);
        }
    }
}
