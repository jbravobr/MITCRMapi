using System.ComponentModel.DataAnnotations;

namespace CRMApi.Domain
{
    public class Adress : BaseEntity
    {
        [Required]
        public int Number { get; set; }

        [Required]
        [MaxLength(9)]
        public string ZipCode { get; set; }

        [Required]
        [MaxLength(150)]
        public string StreetName { get; set; }

        [Required]
        [MaxLength(120)]
        public string Burgh { get; set; }
    }
}