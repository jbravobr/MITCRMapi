using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRMApi.Domain
{
    public class Customer : BaseEntity
    {
        [Required]
        [MaxLength(80)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(80)]
        public string LastName { get; set; }

        public virtual Address Address { get; set; }

        public int? AddressId { get; set; }

        [Required]
        public bool Status { get; set; }

        public decimal LastOrderAmout { get; set; }

        public virtual List<Order> Orders { get; set; }
    }
}