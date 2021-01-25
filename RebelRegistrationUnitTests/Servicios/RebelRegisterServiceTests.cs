using Microsoft.Extensions.Logging;
using Moq;
using RebelRegistration.Controllers;
using RebelRegistration.Models;
using RebelRegistration.Repositories;
using RebelRegistration.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace RebelRegistrationUnitTests.Servicios
{
    public class RebelRegisterServiceTests
    {
        public Mock<IPlanetRepository> _planetRepositoryMock;
        public Mock<IPlanetLogRepository> _planetLogRepositoryMock;
        public Mock<ILogger<RebelRegisterService>> _loggerMock;
        public RebelRegisterService service;

        public RebelRegisterServiceTests()
        {
            _planetRepositoryMock = new Mock<IPlanetRepository>();
            _planetLogRepositoryMock = new Mock<IPlanetLogRepository>();
            _loggerMock = new Mock<ILogger<RebelRegisterService>>();

        }

        [Fact]
        public async Task Should_Insert_Rebel_Register()
        {
            _planetRepositoryMock.Setup(t => t.GetPlanetsAsync()).ReturnsAsync(GetPlanetMock());
            _planetLogRepositoryMock.Setup(s => s.SetPlanetLog(It.IsAny<List<PlanetLog>>())).Returns(Task.CompletedTask);
            service = new RebelRegisterService(_planetRepositoryMock.Object, _planetLogRepositoryMock.Object, _loggerMock.Object);
            await service.ProcessRebels(GetRebelRequest());
            _planetLogRepositoryMock.Verify(t => t.SetPlanetLog(It.IsAny<List<PlanetLog>>()), Times.Once);
        }

        [Fact]
        public async Task Should_not_Insert_Rebel_Register()
        {
            _planetRepositoryMock.Setup(t => t.GetPlanetsAsync()).ReturnsAsync(GetPlanetMock());
            _planetLogRepositoryMock.Setup(s => s.SetPlanetLog(It.IsAny<List<PlanetLog>>())).Returns(Task.CompletedTask);
            service = new RebelRegisterService(_planetRepositoryMock.Object, _planetLogRepositoryMock.Object, _loggerMock.Object);
            await service.ProcessRebels(GetNotRebelRequest());
            _planetLogRepositoryMock.Verify(t => t.SetPlanetLog(It.IsAny<List<PlanetLog>>()), Times.Never);
        }

        private List<Planet> GetPlanetMock(){
            var list = new List<Planet>();
            list.Add(new Planet { PlanetId = 1, Name = "nametest1" });
            list.Add(new Planet { PlanetId = 2, Name = "nametest2" });
            return list;
        }

        private List<RebelRequest> GetRebelRequest()
        {
            var list = new List<RebelRequest>();
            list.Add(new RebelRequest { NameOfPlanet = "nametest1", NameOfRebel = "rebeltest1" });
            return list;
        }

        private List<RebelRequest> GetNotRebelRequest()
        {
            var list = new List<RebelRequest>();
            list.Add(new RebelRequest { NameOfPlanet = "nametest3", NameOfRebel = "rebeltest1" });
            return list;
        }
    }
}
