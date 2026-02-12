using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageTeacher.ConsoleApp.ConsoleFramework.CommandSystem.Commands
{
    public class AddCommand : ICommand
    {
        private IVerbalEntryBuilder entryBuilder;

        public AddCommand(string foreign, string[] translates)
        {
            entryBuilder = new VerbalEntryBuilder()
                .SetForeign(foreign)
                .AddTranslation(translates);
        }


        public void Execute(VocabularService service)
        {
            var entry = entryBuilder.Build();

            service.Add(entry);
        }
    }
}
