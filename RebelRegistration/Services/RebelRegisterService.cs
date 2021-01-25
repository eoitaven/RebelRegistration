using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RebelRegistration.Controllers;
using RebelRegistration.Models;
using RebelRegistration.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RebelRegistration.Services
{
    public class RebelRegisterService : IRebelRegisterService
    {
        public readonly IPlanetRepository _planetRepository;
        public readonly IPlanetLogRepository _planetLogRepository;
        public readonly ILogger<RebelRegisterService> _logger;

        public RebelRegisterService(IPlanetRepository planetRepository, IPlanetLogRepository planetLogRepository,
             ILogger<RebelRegisterService> logger)
        {
            _planetRepository = planetRepository;
            _planetLogRepository = planetLogRepository;
            _logger = logger;
        }
        public async Task<string> GetPlanets()
        {
            var listofplants = await _planetRepository.GetPlanetsAsync();
            listofplants.Select(prop => prop.Name).ToList();
            return JsonConvert.SerializeObject(listofplants.Select(prop => prop.Name).ToList());
        }

        public async Task ProcessRebels(List<RebelRequest> rebels)
        {
            try
            {
                var listofplants = await _planetRepository.GetPlanetsAsync();
                var listofPlanetLog = new List<PlanetLog>();
                /*En este punto, se podrías lanzar threads para insertar en base de datos más rápido*/
                /*Este no es el bucle ideal, lo lanzaría en theads para procesar la lista más rápida*/
                foreach (var rebel in rebels)
                {
                    var planet = listofplants.Where(p => p.Name.Trim().ToLower() == rebel.NameOfPlanet.Trim().ToLower()).FirstOrDefault();
                    if (planet != null)
                    {
                        var planetLog = new PlanetLog
                        {
                            PlanetId = planet.PlanetId,
                            Log = $"Rebel {rebel.NameOfRebel} on planet {planet.Name.Trim()} at {DateTime.UtcNow.ToString("O")}"
                        };
                        listofPlanetLog.Add(planetLog);
                    }else
                    {
                        _logger.LogWarning($"{rebel.NameOfPlanet.Trim().ToLower()} not found");
                    }
                }

                if (listofPlanetLog.Count > 0)
                {
                    await _planetLogRepository.SetPlanetLog(listofPlanetLog);
                    _logger.LogInformation($"Inserting {listofPlanetLog.Count} rebels");
                }

            }catch(Exception ex)
            {
                _logger.LogError(ex, "Error saving rebels");
            }
        }
    }
}
