using System;
using System.Text.RegularExpressions;
using LanguageTeacher.DataAccess.Repositories;

namespace LanguageTeacher.ConsoleApp
{

    public static class StringExtension
    {
        public static string Capitalize(this string str)
        {
            char[] letters = str.ToLower().ToCharArray();
            letters[0] = char.ToUpper(letters[0]);

            return string.Join("", letters);
        }

        public static string RemoveMultispaces(this string str)
        {
            str = str.Trim();
            str = Regex.Replace(str, @"\s+", " ");

            return new string(str);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var vocabService = new VocabularService(new PairsRepository());

            while (true)
            {
                Console.Clear();

                ConsoleUI.PrintVocabularTable(vocabService.GetAll());

                Console.WriteLine("\nДобавьте новое слово или перевод");
                string foreign = Console.ReadLine();

                Console.WriteLine("Введите перевод:");
                string translate = Console.ReadLine();

                vocabService.Add(foreign, translate);
            }
        }
    }
}
