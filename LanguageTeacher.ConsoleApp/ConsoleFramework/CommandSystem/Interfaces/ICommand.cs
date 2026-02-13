using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageTeacher.ConsoleApp.ConsoleFramework.CommandSystem.Interfaces
{
    public interface ICommand
    {
        void Execute(string[] args);
    }
}
