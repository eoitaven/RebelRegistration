using System.ComponentModel.DataAnnotations.Schema;

namespace RebelRegistration.Models
{
    [Table("planetlog", Schema = "public")]
    public class PlanetLog
    {
        [Column("planetlogid")]
        public long PlanetLogId { get; set; }
        [Column("log")]
        public string Log { get; set; }
        [Column("planetid")]
        public long PlanetId { get; set; }
        public Planet Planet { get; set; }

    }
}
