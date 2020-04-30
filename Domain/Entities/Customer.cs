﻿using System;
using System.Collections.Generic;

namespace GimmieAJobGamesAPI.Context
{
    public partial class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public int Age { get; set; }
        public int CountryZone { get; set; }
        public int CustomerAccountTypeId { get; set; }

        public virtual CustomerAccountType CustomerAccountType { get; set; }
    }
}