using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguageTeacher.ConsoleApp.ConsoleFramework.CommandSystem;
using LanguageTeacher.ConsoleApp.ConsoleFramework.CommandSystem.Commands;
using LanguageTeacher.DataAccess.Data.Entities;
using LanguageTeacher.DataAccess.Interfaces;

namespace LanguageTeacher.ConsoleApp.Framework.CommandSystem
{
    public class CommandFactory
    {
        public ICommand CreateCommand(string? request)
        {
            if (string.IsNullOrEmpty(request))
                throw new ArgumentException("Command request is empty", nameof(request));

            string[] parts = request.SplitIgnored(' ', '"');

            string commandName = parts[0].ToLower();

            return commandName switch
            {
                "add" => CreateAddCommand(parts),
                "remove" => ParseRemoveCommand(parts),
                _ => throw new ArgumentException("Unknown command", commandName)
            };
        }

        private ICommand CreateAddCommand(string[] parts)
        {
            if (parts.Length < 3)
                throw new ArgumentException("Add command has no arguments");

            string foreign = parts[1];
            List<string> translations = new List<string>();

            for (int i = 2; i < parts.Length; i++)
            {
                translations.Add(parts[i]);
            }

            return new AddCommand(foreign, translations.ToArray());
        }

        private ICommand ParseRemoveCommand(string[] parts)
        {
            if (parts.Length < 2)
                throw new ArgumentException("Remove command has no arguments");

            int id = int.Parse(parts[1]);

            return new RemoveCommand(id);
        }
    }
}
