using System.ComponentModel.DataAnnotations;

namespace GenerateDatabase
{
    public class StockProduct
    {
        public virtual Product Product { get; set; }

        public int ProductId { get; set; }

        public virtual Stock Stock { get; set; }

        public int StockId { get; set; }

        public int Amount { get; set; }
    }
}