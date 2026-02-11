using System;
using System.Text.RegularExpressions;
using System.Windows.Input;
using LanguageTeacher.ConsoleApp.Framework.CommandSystem;
using LanguageTeacher.DataAccess.Data.Entities;

namespace LanguageTeacher.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var vocabService = new VocabularService();
            var cmdFactory = new CommandFactory();

            while (true)
            {
                Console.Clear();

                ConsoleASCII.WriteVocabularTable(vocabService.GetAll());
                Console.Write("> ");

                string? userRequest = Console.ReadLine();

                var cmd = cmdFactory.CreateCommand(userRequest);
                cmd.Execute(vocabService);
            }
        }
    }
}
