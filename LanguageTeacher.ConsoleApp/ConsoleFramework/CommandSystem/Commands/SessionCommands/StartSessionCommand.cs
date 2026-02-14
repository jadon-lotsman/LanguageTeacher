using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguageTeacher.ConsoleApp.Interfaces;

namespace LanguageTeacher.ConsoleApp.ConsoleFramework.CommandSystem.Commands.SessionCommands
{
    public class StartSessionCommand : CommandBase
    {
        protected override int ExpectedArgsCount => 0;
        protected override bool HasLimitlessArgs => false;

        private readonly ILearningService _service;


        public StartSessionCommand(ILearningService service)
        {
            _service = service;
        }


        protected override void ExecuteInternal(string[] args)
        {
            _service.StartSession();
        }
    }
}
