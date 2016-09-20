using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRMApi.Domain
{
    public class Customer : BaseEntity
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        [Required]
        [MaxLength(80)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(80)]
        public string LastName { get; set; }

        [Required]
        public virtual Adress Adress { get; set; }

        public int AdressId { get; set; }

        [Required]
        public bool Status { get; set; }

        public decimal LastOrderAmout { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}