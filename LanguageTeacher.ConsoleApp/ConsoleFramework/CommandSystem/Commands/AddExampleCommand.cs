using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageTeacher.ConsoleApp.ConsoleFramework.CommandSystem.Commands
{
    public class AddExampleCommand : CommandBase
    {
        protected override int ExpectedArgsCount => 2;
        protected override bool HasLimitlessArgs => true;

        private readonly VocabularService _service;


        public AddExampleCommand(VocabularService service)
        {
            _service = service;
        }


        protected override void ExecuteInternal(string[] args)
        {
            var builder = new VerbalEntryBuilder()
                .SetForeign(args[0]);

            for (int i = 1; i < args.Length; i++)
            {
                builder.AddExample(args[i]);
            }

            var entry = builder.Build();

            _service.Patch(entry);
        }
    }
}
