using System;
using System.Collections.Generic;

namespace PortalAnunturi.Models.Entities
{
    public partial class User
    {
        public User()
        {
            Anunt = new HashSet<Anunt>();
        }

        public int IdUser { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<Anunt> Anunt { get; set; }
    }
}
