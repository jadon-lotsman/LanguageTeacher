using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguageTeacher.ConsoleApp.Services.SessionService;
using LanguageTeacher.ConsoleApp.Services.SessionService.Entities;

namespace LanguageTeacher.ConsoleApp.Interfaces
{
    public interface IStudySessionService
    {
        void OpenSession(ISessionStrategy strategy);
        SessionResult CloseSession();
        void SendAnswer(string answer);
    }
}
