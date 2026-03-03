using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguageTeacher.ConsoleApp.Services.SessionService.Entities;
using LanguageTeacher.DataAccess.Data.Entities;

namespace LanguageTeacher.ConsoleApp.Interfaces
{
    public interface ISessionStrategy
    {
        List<Question> SelectQuestions(ICollection<VerbalEntry> entries);
    }
}
