using System;
using System.Collections.Generic;

namespace loanbook.Models
{
    public partial class Taxis
    {
        public int TxnId { get; set; }
        public string ProductName { get; set; } = null!;
        public int Quantity { get; set; }
        public int Price { get; set; }
        public int? CustomerId { get; set; }

        public virtual Customer? Customer { get; set; }
    }
}
