using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRMApi.Domain
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

        public virtual List<StockProduct> StockProducts { get; set; }
    }
}