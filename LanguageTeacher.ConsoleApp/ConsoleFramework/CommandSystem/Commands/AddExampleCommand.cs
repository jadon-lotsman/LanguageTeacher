using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageTeacher.ConsoleApp.ConsoleFramework.CommandSystem.Commands
{
    public class AddExampleCommand : ICommand
    {
        private IVerbalEntryBuilder entryBuilder;

        public AddExampleCommand(string foreign, string[] examples)
        {
            entryBuilder = new VerbalEntryBuilder()
                .SetForeign(foreign)
                .AddExample(examples);
        }


        public void Execute(VocabularService service)
        {
            var entry = entryBuilder.Build();

            service.Patch(entry);
        }
    }
}
