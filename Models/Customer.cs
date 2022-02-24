using System;
using System.Collections.Generic;

namespace loanbook.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Taxes = new HashSet<Taxis>();
        }

        public int CustomerId { get; set; }
        public string CusName { get; set; } = null!;
        public int Phoneno { get; set; }
        public string? Status { get; set; }
        public int Ordertotal { get; set; }
        public int ClientId { get; set; }

        public virtual KbookClient Client { get; set; } = null!;
        public virtual ICollection<Taxis> Taxes { get; set; }
    }
}
