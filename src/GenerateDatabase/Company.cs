using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GenerateDatabase
{
    public class Company : BaseEntity
    {
        public Company()
        {
            Products = new HashSet<Product>();
        }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public virtual Adress Adress { get; set; }

        public int AdressId { get; set; }

        [Required]
        [MaxLength(13)]
        public string DocumentNumber { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}