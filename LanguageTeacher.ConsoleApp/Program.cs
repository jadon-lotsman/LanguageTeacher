using System;
using System.Text.RegularExpressions;
using System.Windows.Input;
using LanguageTeacher.ConsoleApp.ConsoleFramework;
using LanguageTeacher.ConsoleApp.ConsoleFramework.CommandSystem;
using LanguageTeacher.DataAccess.Data.Entities;

namespace LanguageTeacher.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var vocabService = new VocabularService();
            var cmdExecutor = new CommandExecutor(vocabService);

            while (true)
            {
                Console.Clear();

                ConsoleASCII.WriteVocabularTable(vocabService.GetAll());
                Console.Write("> ");

                string? userRequest = Console.ReadLine();

                try
                {
                    cmdExecutor.ExecuteUserCommand(userRequest);
                }
                catch (Exception ex)
                {
                    ConsoleASCII.WriteError(ex.Message);
                    Console.ReadLine();
                }
            }
        }
    }
}
