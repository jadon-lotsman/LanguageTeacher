using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguageTeacher.ConsoleApp.Interfaces;
using LanguageTeacher.ConsoleApp.Services.SessionService.Strategies;

namespace LanguageTeacher.ConsoleApp.ConsoleFramework.CommandSystem.Commands.SessionCommands
{
    public class OpenSessionCommand : CommandBase
    {
        protected override int ExpectedArgsCount => 1;
        protected override bool HasLimitlessArgs => false;

        private readonly IStudySessionService _service;


        public OpenSessionCommand(IStudySessionService service)
        {
            _service = service;
        }


        protected override void ExecuteInternal(string[] args)
        {
            ISessionStrategy? strategy = null;

            if (args[0] == "rand")
                strategy = new RandomSessionStrategy();

            if (strategy == null)
                throw new ArgumentException($"Session strategy '{args[0]}' is not exist.");

            _service.OpenSession(strategy);
        }
    }
}
