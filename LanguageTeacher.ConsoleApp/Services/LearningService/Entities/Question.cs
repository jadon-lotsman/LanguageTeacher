using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguageTeacher.DataAccess.Data.Entities;

namespace LanguageTeacher.ConsoleApp.Services.StudyService.Entities
{
    public class Question
    {
        public int EntryId { get; }
        public bool IsForwardQuestion { get; }
        public string QuestionValue { get; }
        public string UserValue { get; set; }


        public Question(VerbalEntry source, bool isForwardQuestion)
        {
            IsForwardQuestion = isForwardQuestion;
            EntryId = source.Id;
            QuestionValue = IsForwardQuestion ? source.Foreign : source.Translations[0];
            UserValue = "?";
        }
    }
}
