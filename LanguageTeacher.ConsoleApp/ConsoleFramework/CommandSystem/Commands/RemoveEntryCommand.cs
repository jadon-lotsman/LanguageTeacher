using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguageTeacher.ConsoleApp.Interfaces;

namespace LanguageTeacher.ConsoleApp.ConsoleFramework.CommandSystem.Commands
{
    public class RemoveEntryCommand : CommandBase
    {
        protected override int ExpectedArgsCount => 1;
        protected override bool HasLimitlessArgs => false;

        private readonly IVocabularService _service;


        public RemoveEntryCommand(IVocabularService service)
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
