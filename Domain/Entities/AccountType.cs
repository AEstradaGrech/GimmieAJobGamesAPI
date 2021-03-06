﻿using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class AccountType
    {
        public AccountType()
        {
            CustomerAccountType = new HashSet<CustomerAccountType>();
            GamePromotion = new HashSet<GamePromotion>();
        }

        public int Id { get; set; }
        public string AccountDesc { get; set; }
        public bool HasGift { get; set; }

        public virtual ICollection<CustomerAccountType> CustomerAccountType { get; set; }
        public virtual ICollection<GamePromotion> GamePromotion { get; set; }
    }
}
