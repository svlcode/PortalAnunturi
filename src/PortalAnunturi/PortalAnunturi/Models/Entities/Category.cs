using System;
using System.Collections.Generic;

namespace PortalAnunturi.Models.Entities
{
    public partial class Category
    {
        public Category()
        {
            Anouncement = new HashSet<Anouncement>();
        }

        public int IdCategory { get; set; }
        public string Name { get; set; }

        public ICollection<Anouncement> Anouncement { get; set; }
    }
}
