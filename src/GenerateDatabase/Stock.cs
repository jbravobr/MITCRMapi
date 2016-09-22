using System.Collections.Generic;

namespace GenerateDatabase
{
    public class Stock : BaseEntity
    {
        public string Name { get; set; }

        public bool Status { get; set; }

        public List<StockProduct> StockProducts { get; set; }
    }
}