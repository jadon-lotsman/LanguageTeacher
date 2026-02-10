using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguageTeacher.ConsoleApp.ConsoleFramework.CommandSystem;
using LanguageTeacher.DataAccess.Data.Entities;
using LanguageTeacher.DataAccess.Interfaces;

namespace LanguageTeacher.ConsoleApp.Framework.CommandSystem
{
    public class CommandParser
    {
        public ICommand Parse(string? request)
        {
            if (string.IsNullOrEmpty(request))
                throw new ArgumentException("Command request is empty", nameof(request));

            string[] parts = request.SplitIgnored(' ', '"');

            string commandName = parts[0].ToLower();

            return commandName switch
            {
                "add" => ParseAddCommand(parts),
                "remove" => ParseRemoveCommand(parts),
                _ => throw new ArgumentException("Unknown command", commandName)
            };
        }

        private ICommand ParseAddCommand(string[] parts)
        {
            if (parts.Length < 3)
                throw new ArgumentException("Add command has no arguments");

            return new VocabularAddCommand(parts[1], parts[2]);
        }

        private ICommand ParseRemoveCommand(string[] parts)
        {
            if (parts.Length < 2)
                throw new ArgumentException("Remove command has no arguments");

            int id = int.Parse(parts[1]);

            return new VocabularRemoveCommand(id);
        }
    }
}
