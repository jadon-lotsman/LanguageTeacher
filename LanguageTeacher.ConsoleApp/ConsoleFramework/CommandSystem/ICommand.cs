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
}
