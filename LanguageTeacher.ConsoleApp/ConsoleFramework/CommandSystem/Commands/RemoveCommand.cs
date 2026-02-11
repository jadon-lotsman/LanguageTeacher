using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageTeacher.ConsoleApp.ConsoleFramework.CommandSystem.Commands
{
    public class RemoveCommand : ICommand
    {
        private int _id;

        public RemoveCommand(int id)
        {
            _id = id;
        }

        public void Execute(VocabularService service)
        {
            service.Remove(_id);
        }
    }
}
