﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using niac.DataSets;
using niac.Models;
using niac.ViewModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;

namespace niac.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory _HttpClientFactory;

        public HomeController(IHttpClientFactory httpClientFactory)
        {
            _HttpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            MemberViewModel model = new MemberViewModel();

            var client = _HttpClientFactory.CreateClient("NiacClient");

            var response = client.GetAsync("members_json.ashx?m=GetAllCurrentMembers").Result;

            if (response.IsSuccessStatusCode)
            {
                using (HttpContent content = response.Content)
                {
                    var result = content.ReadAsStringAsync();

                    RootMemberObject r = JsonConvert.DeserializeObject<RootMemberObject>(result.Result);

                    model.MemberList = new List<Member>();

                    MemberCostsDataSet ds = new MemberCostsDataSet();

                    foreach (var memb in r.AllMembersList.Member)
                    {
                        Member member = new Member();

                        member.PersonId = memb.PersonId;
                        member.AffiliationId = memb.AffiliationId;
                        member.MemberName = memb.MemberName;
                        member.MemberLastName = memb.MemberLastName;
                        member.MemberFirstName = memb.MemberFirstName;
                        member.MemberFullDisplayName = memb.MemberFullDisplayName;
                        member.MemberSortName = memb.MemberSortName;
                        member.MemberTitle = memb.MemberTitle;
                        member.PartyName = memb.PartyName;
                        member.PartyOrganisationId = memb.PartyOrganisationId;
                        member.ConstituencyName = memb.ConstituencyName;
                        member.ConstituencyId = memb.ConstituencyId;
                        member.MemberImgUrl = memb.MemberImgUrl;
                        member.MemberPrefix = memb.MemberPrefix;

                        foreach (var costs in ds.TwentyNineTeenTwentyTwentyMemberCosts.Where(i => i.PersonId == memb.PersonId))
                        {
                            member.NineteenTwentyExpenses = costs.ExpensesTotal;
                        }

                        foreach (var costs in ds.TwentyEightTeenTwentyNineTeenMemberCosts.Where(i => i.PersonId == memb.PersonId))
                        {
                            member.EighteenNineteenSalary = costs.Salary;
                            member.EighteenNineteenExpenses = costs.ExpensesTotal;
                        }

                        member.TotalSalaryExpensesCosts = member.NineteenTwentyExpenses + member.EighteenNineteenSalary + member.EighteenNineteenExpenses;

                        model.MemberList.Add(member);
                    }
                }
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            Member model = new Member();

            var client = _HttpClientFactory.CreateClient("NiacClient");

            var response = client.GetAsync("members_json.ashx?m=GetAllCurrentMembers").Result;

            if (response.IsSuccessStatusCode)
            {
                using (HttpContent content = response.Content)
                {
                    var result = content.ReadAsStringAsync();

                    RootMemberObject r = JsonConvert.DeserializeObject<RootMemberObject>(result.Result);

                    foreach (var memb in r.AllMembersList.Member.Where(i => i.PersonId == id))
                    {
                        model.PersonId = memb.PersonId;
                        model.AffiliationId = memb.AffiliationId;
                        model.MemberName = memb.MemberName;
                        model.MemberLastName = memb.MemberLastName;
                        model.MemberFirstName = memb.MemberFirstName;
                        model.MemberFullDisplayName = memb.MemberFullDisplayName;
                        model.MemberSortName = memb.MemberSortName;
                        model.MemberTitle = memb.MemberTitle;
                        model.PartyName = memb.PartyName;
                        model.PartyOrganisationId = memb.PartyOrganisationId;
                        model.ConstituencyName = memb.ConstituencyName;
                        model.ConstituencyId = memb.ConstituencyId;
                        model.MemberImgUrl = memb.MemberImgUrl;
                        model.MemberPrefix = memb.MemberPrefix;
                    }
                }
            }

            var responseQuestions = client.GetAsync("questions_json.ashx?m=GetQuestionsByMember&personId=" + id).Result;

            if (responseQuestions.IsSuccessStatusCode)
            {
                using (HttpContent content = responseQuestions.Content)
                {
                    var result = content.ReadAsStringAsync();

                    RootQuestionObject r = JsonConvert.DeserializeObject<RootQuestionObject>(result.Result);

                    model.TotalQuestionsAsked = r.QuestionsList.Question.Count;

                    model.Question = new List<Question>();

                    foreach (var question in r.QuestionsList.Question)
                    {
                        Question newQuestion = new Question();

                        newQuestion.TabledDate = question.TabledDate;
                        newQuestion.QuestionDetails = question.QuestionDetails;
                        newQuestion.QuestionText = question.QuestionText;
                        newQuestion.QOralAnswerRequested = question.QOralAnswerRequested;
                        newQuestion.DepartmentName = question.DepartmentName;
                        newQuestion.DocumentId = question.DocumentId;

                        model.Question.Add(newQuestion);
                    }
                }
            }


            // Test

            GetAddress(model);

            return View(model);
        }

        private Member GetAddress(Member member)
        {
            var client = _HttpClientFactory.CreateClient("NiacClient");
            var response = client.GetAsync("members_json.ashx?m=GetMemberContactDetailsByPersonId&personId=" + member.PersonId).Result;

            if (response.IsSuccessStatusCode)
            {
                using (HttpContent content = response.Content)
                {
                    var result = content.ReadAsStringAsync();

                    // Get
                    RootMemberObject r = JsonConvert.DeserializeObject<RootMemberObject>(result.Result);

                    member.MemberContacts = new List<Member>();

                    foreach (var memb in r.AllMembersList.Member)
                    {
                        Member memberContacts = new Member();

                        memberContacts.Address1 = memb.Address1;
                        memberContacts.TownCity = memb.TownCity;
                        memberContacts.Postcode = memb.Postcode;
                        member.MemberContacts.Add(memberContacts);
                    }
                }
            }

            return member;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
