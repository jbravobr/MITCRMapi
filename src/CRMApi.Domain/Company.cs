using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRMApi.Domain
{
    public class Company : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public virtual Address Address { get; set; }

        public int? AddressId { get; set; }

        [Required]
        [MaxLength(13)]
        public string DocumentNumber { get; set; }

        public virtual List<Product> Products { get; set; }
    }
}