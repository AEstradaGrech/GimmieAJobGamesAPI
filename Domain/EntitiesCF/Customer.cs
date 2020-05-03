using System;
namespace Domain.EntitiesCF
{
    public class Customer : Entity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public AccountType AccountType { get; set; }
    }
}
