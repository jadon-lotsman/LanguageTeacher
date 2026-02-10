using System;
using System.Text.RegularExpressions;
using System.Windows.Input;
using LanguageTeacher.ConsoleApp.ConsoleFramework.CommandSystem;
using LanguageTeacher.ConsoleApp.Framework.CommandSystem;
using LanguageTeacher.DataAccess.Repositories;

namespace LanguageTeacher.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var vocabService = new VocabularService(new VocabularRepository());
            var commandParser = new CommandParser();

            while (true)
            {
                Console.Clear();

                ConsoleASCII.WriteVocabularTable(vocabService.GetAll());
                Console.Write("> ");

                string? userRequest = Console.ReadLine();

                var command = commandParser.Parse(userRequest);
                command.Execute(vocabService);
            }
        }
    }
}
