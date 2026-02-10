using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguageTeacher.DataAccess.Data.Entities;

namespace LanguageTeacher.ConsoleApp.ConsoleFramework.CommandSystem
{
    public interface ICommand
    {
        void Execute(VocabularService service);
    }

    public class VocabularAddCommand : ICommand
    {
        private string _foreign, _translate;

        public VocabularAddCommand(string foreign, string translate)
        {
            _foreign = foreign;
            _translate = translate;
        }

        public void Execute(VocabularService service)
        {
            service.Add(_foreign, _translate);
        }
    }

    public class VocabularRemoveCommand : ICommand
    {
        private int _id;

        public VocabularRemoveCommand(int id)
        {
            _id = id;
        }

        public void Execute(VocabularService service)
        {
            service.Remove(_id);
        }
    }
}
