using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class CustomerAccountType
    {
        public CustomerAccountType()
        {
            Customer = new HashSet<Customer>();
        }

        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int AccountTypeId { get; set; }

        public virtual AccountType AccountType { get; set; }
        public virtual ICollection<Customer> Customer { get; set; }
    }
}
