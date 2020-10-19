using System.Collections.Generic;

namespace niac.Models
{
    public class Organisation
    {
        public string OrganisationId { get; set; }
        public string OrganisationName { get; set; }
        public string OrganisationType { get; set; }
        public string OrganisationAbbreviation { get; set; }
    }

    public class OrganisationsList
    {
        public List<Organisation> Organisation { get; set; }
    }

    public class OrgList
    {
        public OrganisationsList OrganisationsList { get; set; }
    }
}
