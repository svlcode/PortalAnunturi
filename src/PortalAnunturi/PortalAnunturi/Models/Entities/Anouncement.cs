using System;
using System.Collections.Generic;

namespace PortalAnunturi.Models.Entities
{
    public partial class Anouncement
    {
        public int IdAnouncement { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public int Category { get; set; }
        public int User { get; set; }

        public Category CategoryNavigation { get; set; }
        public User UserNavigation { get; set; }
    }
}
