using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguageTeacher.ConsoleApp.Services.StudyService;
using LanguageTeacher.ConsoleApp.Services.StudyService.Entities;

namespace LanguageTeacher.ConsoleApp.Interfaces
{
    public interface ILearningService
    {
        void StartSession();
        SessionResult StopSession();
        void GetAnswer(string answer);
    }
}
