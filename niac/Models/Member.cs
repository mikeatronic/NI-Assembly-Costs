using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace niac.Models
{
    public class Member
    {
        public int PersonId { get; set; }
        public string AffiliationId { get; set; }

        [DisplayName("Name")]
        public string MemberName { get; set; }
        public string MemberLastName { get; set; }
        public string MemberFirstName { get; set; }
        public string MemberFullDisplayName { get; set; }
        public string MemberSortName { get; set; }

        [DisplayName("Member title")]
        public string MemberTitle { get; set; }

        [DisplayName("Party")]
        public string PartyName { get; set; }


        public string PartyOrganisationId { get; set; }

        [DisplayName("Constituency")]
        public string ConstituencyName { get; set; }

        public string ConstituencyId { get; set; }
        public string MemberImgUrl { get; set; }
        public string MemberPrefix { get; set; }

        public string AddressId { get; set; }
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

        public decimal EighteenNineteenSalary { get; set; }
        public decimal EighteenNineteenExpenses { get; set; }
        public decimal NineteenTwentyExpenses { get; set; }
        public decimal TotalSalaryExpensesCosts { get; set; }
        public List<Member> MemberContacts { get; set; }

        public int TotalQuestionsAsked { get; set; }

        [JsonPropertyName("Question")]
        public List<Question> Question { get; set; }

    }

    public class AllMembersList
    {
        public List<Member> Member { get; set; }
    }

    public class RootMemberObject
    {
        public AllMembersList AllMembersList { get; set; }
    }
}
