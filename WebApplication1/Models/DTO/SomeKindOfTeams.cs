using System.Collections.Generic;

namespace WebApplication1.Models.DTO
{
    public class SomeKindOfTeams
    {

        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public string TeamDescription { get; set; }

        public IEnumerable<SomeKindOfOrganization> Organizations { get; set; }
        public IEnumerable<SomeKindOfMembers> Members { get; set; }



    }
}
