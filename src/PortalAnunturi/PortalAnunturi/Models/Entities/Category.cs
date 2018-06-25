using System;
using System.Collections.Generic;

namespace PortalAnunturi.Models.Entities
{
    public partial class Category
    {
        public Category()
        {
            Anunt = new HashSet<Anunt>();
        }

        public int IdCategory { get; set; }
        public string CategoryName { get; set; }

        public ICollection<Anunt> Anunt { get; set; }
    }
}
