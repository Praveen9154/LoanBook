using System;
using System.Collections.Generic;

namespace loanbook.Models
{
    public partial class Item
    {
        public int ItemId { get; set; }
        public string? ItemName { get; set; }
        public int? GrpId { get; set; }

        public virtual StockMain? Grp { get; set; }
    }
}
