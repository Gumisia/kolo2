using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Team
    {
        public int TeamId { get; set; }
        public int OrganizationId { get; set; }
        public string TeamName { get; set; }
        public string TeamDescription { get; set; }

        public virtual ICollection<Membership> Memberships { get; set; }
        public virtual ICollection<File> Files { get; set; }

        [ForeignKey("OrganizationId")]
        public virtual Organization Organization { get; set; }

    }
}
