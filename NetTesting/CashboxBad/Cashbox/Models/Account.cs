using System.Collections.Generic;

namespace Cashbox.Models
{
    public class Account
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public decimal Balance { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
