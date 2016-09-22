using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GenerateDatabase
{
    public class Product : BaseEntity
    {
        [Required]
        [MaxLength(80)]
        public string Name { get; set; }

        [Required]
        public bool Status { get; set; }

        public virtual Company Company { get; set; }

        public int CompanyId { get; set; }

        public List<StockProduct> StockProducts { get; set; }

        public int? OrderId { get; set; }

        public Order Order { get; set; }
    }
}