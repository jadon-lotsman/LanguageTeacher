using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguageTeacher.ConsoleApp.ConsoleFramework.CommandSystem.Commands;
using LanguageTeacher.ConsoleApp.ConsoleFramework.CommandSystem.Interfaces;
using LanguageTeacher.DataAccess.Data.Entities;
using LanguageTeacher.DataAccess.Interfaces;

namespace LanguageTeacher.ConsoleApp.ConsoleFramework.CommandSystem
{
    public class CommandFactory
    {
        public ICommand Create(string command, VocabularService service)
        {
            return command.ToLower() switch
            {
                "add" => new AddCommand(service),
                "example" =>  new AddExampleCommand(service),
                "pronun" => new AddTranscriptionCommand(service),
                "remove" => new RemoveCommand(service),
                _ => throw new ArgumentException($"Unknown command with name '{command}'")
            };
        }
    }
}
