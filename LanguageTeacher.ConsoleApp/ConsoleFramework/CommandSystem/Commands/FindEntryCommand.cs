using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguageTeacher.ConsoleApp.Interfaces;

namespace LanguageTeacher.ConsoleApp.ConsoleFramework.CommandSystem.Commands
{
    public class FindEntryCommand : CommandBase
    {
        protected override int ExpectedArgsCount => 1;
        protected override bool HasLimitlessArgs => false;

        private readonly IVocabularService _service;


        public FindEntryCommand(IVocabularService service)
        {
            _service = service;
        }


        protected override void ExecuteInternal(string[] args)
        {
            var entry = _service.GetByKey(args[0]);

            if (entry == null)
                throw new ArgumentException($"Item with foreign '{args[0]}' not found.");

            ConsoleASCII.WriteTableHeader();
            ConsoleASCII.WriteTableBody(entry);
            ConsoleASCII.WriteTableFooter();

            Console.ReadLine();
        }
    }
}
