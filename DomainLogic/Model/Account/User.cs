using System.Collections.Generic;

namespace DomainLogic.Model
{
    public class User
    {
        public int UserId { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string Email { get; set; }

        public Subscription Subscription { get; set; }
    }
}
