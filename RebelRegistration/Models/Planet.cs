using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RebelRegistration.Models
{
    [Table("planet", Schema = "public")]
    public class Planet
    {
        [Key]
        [Column("planetid")]
        public long PlanetId { get; set; }
        [Column("name")]
        public string Name { get; set; }

        public List<PlanetLog> logs { get; set; }
    }
}
