using System;
using System.Collections.Generic;

namespace PortalAnunturi.Models.Entities
{
    public partial class Anunt
    {
        public int IdAnunt { get; set; }
        public string Titlu { get; set; }
        public string Descriere { get; set; }
        public DateTime? DataCreare { get; set; }
        public DateTime? DataExpirare { get; set; }
        public int IdCategory { get; set; }
        public int IdUser { get; set; }

        public Category IdCategoryNavigation { get; set; }
        public User IdUserNavigation { get; set; }
    }
}
