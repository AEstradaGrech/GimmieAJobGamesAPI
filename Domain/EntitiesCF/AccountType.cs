using System;
namespace Domain.EntitiesCF
{
    public class AccountType : Entity
    {
        public AccountTypes Type { get; set; }
        public string Description { get; set; }
    }
}
