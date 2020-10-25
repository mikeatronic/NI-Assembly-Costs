using System;
namespace niac.Models.Answers
{
    public class Question
    {
        public string DocumentId { get; set; }
        public string DocumentType { get; set; }
        public string Reference { get; set; }
        public string TablerName { get; set; }
        public string TablerTitle { get; set; }
        public string TablerAffiliationId { get; set; }
        public string TablerPersonId { get; set; }
        public DateTime TabledDate { get; set; }
        public DateTime AnsweredOnDate { get; set; }
        public string QuestionText { get; set; }
        public DateTime AnswerByDate { get; set; }
        public string PriorityRequest { get; set; }
        public string MinisterTitle { get; set; }
        public string MinisterAffiliationId { get; set; }
        public string MinisterPersonId { get; set; }
        public string Department { get; set; }
        public string AnswerPlainText { get; set; }
        public string DepartmentID { get; set; }
        public string AnswerOpenXml { get; set; }
        public string AnswerHtml { get; set; }
    }

    public class QuestionsList
    {
        public Question Question { get; set; }
    }

    public class AnswerRoot
    {
        public QuestionsList QuestionsList { get; set; }
    }
}
