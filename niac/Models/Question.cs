using System;
using System.Collections.Generic;

namespace niac.Models
{
    public class Question
    {
        public string DocumentId { get; set; }
        public string Reference { get; set; }
        public DateTime TabledDate { get; set; }
        public string QuestionText { get; set; }
        public string DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string QOralAnswerRequested { get; set; }
        public string TablerPersonId { get; set; }
        public string MinisterPersonId { get; set; }
        public string QuestionDetails { get; set; }
    }

    public class QuestionsList
    {
        public List<Question> Question { get; set; }
    }

    public class RootQuestionObject
    {
        public QuestionsList QuestionsList { get; set; }
    }
}
