using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GenerateDatabase
{
    public class Product : BaseEntity
    {
        public Product()
        {
            StockProducts = new HashSet<StockProduct>();
        }

        [Required]
        [MaxLength(80)]
        public string Name { get; set; }

        [Required]
        public bool Status { get; set; }

        [Required]
        public virtual Company Company { get; set; }

        public int CompanyId { get; set; }

        public virtual ICollection<StockProduct> StockProducts { get; set; }
    }
}