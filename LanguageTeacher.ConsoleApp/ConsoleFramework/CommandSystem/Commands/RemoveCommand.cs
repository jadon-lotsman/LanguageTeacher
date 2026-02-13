using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageTeacher.ConsoleApp.ConsoleFramework.CommandSystem.Commands
{
    public class RemoveCommand : CommandBase
    {
        protected override int ExpectedArgsCount => 1;
        protected override bool HasLimitlessArgs => false;

        private readonly VocabularService _service;


        public RemoveCommand(VocabularService service)
        {
            _service = service;
        }


        protected override void ExecuteInternal(string[] args)
        {
            var entry = new VerbalEntryBuilder()
                .SetForeign(args[0])
                .Build();

            _service.Remove(entry);
        }
    }
}
