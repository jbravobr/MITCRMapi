using System.Collections.Generic;

namespace CRMApi.Domain
{
    public class Stock : BaseEntity
    {
        public string Name { get; set; }

        public bool Status { get; set; }

        public virtual ICollection<StockProduct> StockProducts { get; set; }
    }
}