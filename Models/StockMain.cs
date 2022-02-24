using System;
using System.Collections.Generic;

namespace loanbook.Models
{
    public partial class StockMain
    {
        public StockMain()
        {
            Items = new HashSet<Item>();
        }

        public int GrpId { get; set; }
        public string? Itemgroup { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}
