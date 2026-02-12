using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageTeacher.ConsoleApp.ConsoleFramework.CommandSystem.Commands
{
    public class AddTranscriptionCommand : ICommand
    {
        private IVerbalEntryBuilder entryBuilder;

        public AddTranscriptionCommand(string foreign, string transcription)
        {
            entryBuilder = new VerbalEntryBuilder()
                .SetForeign(foreign)
                .SetTranscription(transcription);
        }


        public void Execute(VocabularService service)
        {
            var entry = entryBuilder.Build();

            service.Patch(entry);
        }
    }
}
