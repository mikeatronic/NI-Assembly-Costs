using System.Collections.Generic;

namespace niac.Models
{
    public class MemberContacts
    {

        public string AddressId { get; set; }
        public string PersonId { get; set; }
        public string AddressType { get; set; }
        public string RoomNumber { get; set; }
        public string Address1 { get; set; }
        public string Townland { get; set; }
        public string Ward { get; set; }
        public string TownCity { get; set; }
        public string Postcode { get; set; }
        public string TelephoneNumber { get; set; }
        public string EmaiAddress { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }

    public class AllMembersContactsList
    {
        public List<MemberContacts> Member { get; set; }
    }

    public class RootMemberContactsObject
    {
        public AllMembersContactsList AllMembersContactsList { get; set; }
    }
}
