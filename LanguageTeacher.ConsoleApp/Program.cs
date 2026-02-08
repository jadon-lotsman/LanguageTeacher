using System;
using LanguageTeacher.DataAccess;
using LanguageTeacher.DataAccess.Data;
using LanguageTeacher.DataAccess.Data.Entities;
using LanguageTeacher.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace LanguageTeacher.ConsoleApp
{
    public static class StringExtension
    {
        public static string Capitalize(this string str)
        {
            char[] letters = str.ToLower().ToCharArray();
            letters[0] = char.ToUpper(letters[0]);

            return new string(letters);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<VocabularAppContext>();
            var options = optionsBuilder.UseSqlite("Data Source=vocabularapp.db").Options;

            VerbalPairRepository repository = new VerbalPairRepository(new VocabularAppContext(options));

            while (true)
            {
                Console.Clear();

                ConsoleUI.PrintVocabularTable(repository.GetAll());

                Console.WriteLine("\nВведите слово или напишите 'exam'");
                string foreign = Console.ReadLine();

                Console.WriteLine("Введите перевод:");
                string translate = Console.ReadLine();

                repository.Add(new VerbalPair() { Id=0, Foreign=foreign, Translate=translate, Knowledge=0});
            }
        }
    }
}
