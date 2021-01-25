using System.Diagnostics.CodeAnalysis;

namespace RebelRegistration.Settings
{
    [ExcludeFromCodeCoverage]
    public class PlanetDatabaseSettings
    {
        public string ConnectionString { get; set; } = "";
    }
}
