﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRMApi.Domain
{
    public class Order : BaseEntity
    {
        public virtual Customer Customer { get; set; }

        public int CustomerId { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public decimal Discount { get; set; }

        [Required]
        public EnumPaymentType PaymentType { get; set; }

        public virtual List<Product> Products { get; set; }
    }
}