using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguageTeacher.ConsoleApp.Interfaces;

namespace LanguageTeacher.ConsoleApp.ConsoleFramework.CommandSystem.Commands
{
    public class AddEntryTranscriptionCommand : CommandBase
    {
        protected override int ExpectedArgsCount => 2;
        protected override bool HasLimitlessArgs => false;

        private readonly IVocabularService _service;


        public AddEntryTranscriptionCommand(IVocabularService service)
        {
            _service = service;
        }


        protected override void ExecuteInternal(string[] args)
        {
            var entry = new VerbalEntryBuilder()
                .SetForeign(args[0])
                .SetTranscription(args[1])
                .Build();

            _service.Patch(entry);
        }
    }
}
