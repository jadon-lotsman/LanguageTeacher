using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguageTeacher.ConsoleApp;
using LanguageTeacher.DataAccess.Data.Entities;

namespace LanguageTeacher.ConsoleApp
{
    static class ConsoleUI
    {
        const int foreigWidth = 12,
                translWidth = 28,
                totalWidth = foreigWidth + translWidth + 5;

        public static void PrintVocabularTable(ICollection<VerbalPair> pairs)
        {
            WriteTableHeader();

            foreach (var pair in pairs)
                WriteTableBody(pair);

            WriteTableFooter();
        }

        public static void WriteTableHeader()
        {
            Console.Write('\u2552');

            for (int i = 0; i < totalWidth; i++)
                Console.Write('\u2550');

            Console.WriteLine('\u2555');
        }

        public static void WriteTableBody(VerbalPair pair)
        {
            Console.Write($"\u2502 {pair.Foreign.Capitalize(),-foreigWidth} \u2502 ");

            string translateLine = "";
            //for (int i = 0; i < pair.Translates.Count; i++)
            //{
            //    translateLine += pair.Translates[i];
            //    if (i < pair.Translates.Count - 1)
            //        translateLine += ", ";
            //}

            translateLine += pair.Translate;

            Console.Write($"{translateLine.Capitalize(),-translWidth} \u2502\n");
        }

        public static void WriteTableFooter()
        {
            Console.Write('\u2558');

            for (int i = 0; i < totalWidth; i++)
                Console.Write('\u2550');

            Console.WriteLine('\u255B');
        }
    }
}
