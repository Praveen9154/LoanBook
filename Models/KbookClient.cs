using System;
using System.Collections.Generic;

namespace loanbook.Models
{
    public partial class KbookClient
    {
        public KbookClient()
        {
            Customers = new HashSet<Customer>();
        }

        public int KbookClientId { get; set; }
        public string Name { get; set; } = null!;
        public int Phoneno { get; set; }
        public string? Status { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }
}
