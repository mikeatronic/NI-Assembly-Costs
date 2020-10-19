namespace niac.Models
{
    public class MemberCosts
    {
        public int PersonId { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        //  public int TotalFamilyMembersEmployed { get; set; }
        // public string TotalFamilyMembersEmployedDesc { get; set; }
        public decimal Salary { get; set; }
        public decimal ExpensesTotal { get; set; }
    }
}
