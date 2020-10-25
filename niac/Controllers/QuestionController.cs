using Microsoft.AspNetCore.Mvc;
using niac.ViewModel;
using System.Net.Http;

namespace niac.Controllers
{
    public class QuestionController : Controller
    {
        private readonly IHttpClientFactory _HttpClientFactory;

        public QuestionController(IHttpClientFactory httpClientFactory)
        {
            _HttpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {

            QuestionViewModel model = new QuestionViewModel();

            var client = _HttpClientFactory.CreateClient("NiacClient");

            var response = client.GetAsync("members_json.ashx?m=GetAllCurrentMembers").Result;

            if (response.IsSuccessStatusCode)
            {
                using (HttpContent content = response.Content)
                {
                    var result = content.ReadAsStringAsync();

                    //RootMemberObject r = JsonConvert.DeserializeObject<RootMemberObject>(result.Result);

                    //model.MemberList = new List<Member>();

                    //MemberCostsDataSet ds = new MemberCostsDataSet();

                    //foreach (var memb in r.AllMembersList.Member)
                    //{
                    //    Member member = new Member();

                    //    member.PersonId = memb.PersonId;
                    //    member.AffiliationId = memb.AffiliationId;
                    //    member.MemberName = memb.MemberName;
                    //    member.MemberLastName = memb.MemberLastName;
                    //    member.MemberFirstName = memb.MemberFirstName;
                    //    member.MemberFullDisplayName = memb.MemberFullDisplayName;
                    //    member.MemberSortName = memb.MemberSortName;
                    //    member.MemberTitle = memb.MemberTitle;
                    //    member.PartyName = memb.PartyName;
                    //    member.PartyOrganisationId = memb.PartyOrganisationId;
                    //    member.ConstituencyName = memb.ConstituencyName;
                    //    member.ConstituencyId = memb.ConstituencyId;
                    //    member.MemberImgUrl = memb.MemberImgUrl;
                    //    member.MemberPrefix = memb.MemberPrefix;

                    //    foreach (var costs in ds.TwentyNineTeenTwentyTwentyMemberCosts.Where(i => i.PersonId == memb.PersonId))
                    //    {
                    //        member.NineteenTwentyExpenses = costs.ExpensesTotal;
                    //    }

                    //    foreach (var costs in ds.TwentyEightTeenTwentyNineTeenMemberCosts.Where(i => i.PersonId == memb.PersonId))
                    //    {
                    //        member.EighteenNineteenSalary = costs.Salary;
                    //        member.EighteenNineteenExpenses = costs.ExpensesTotal;
                    //    }

                    //    member.TotalSalaryExpensesCosts = member.NineteenTwentyExpenses + member.EighteenNineteenSalary + member.EighteenNineteenExpenses;

                    //    model.MemberList.Add(member);
                    //}
                }
            }

            return View(model);
        }
    }
}
