using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRMApi.Domain
{
    public class Order : BaseEntity
    {
        public Order()
        {
            Products = new HashSet<Product>();
        }

        [Required]
        public virtual Customer Customer { get; set; }

        public int CustomerId { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public decimal Discount { get; set; }

        [Required]
        public EnumPaymentType PaymentType { get; set; }

        [Required]
        public virtual ICollection<Product> Products { get; set; }
    }
}