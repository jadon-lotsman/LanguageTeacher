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
        const int column_width = 12, n_width = (column_width*3) + 5;

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
            Console.Write(new string('\u2550', n_width));
            Console.WriteLine('\u2555');
        }

        public static void WriteTableBody(VerbalPair pair)
        {
            Console.Write($"\u2502 {pair.Foreign.Capitalize(),-column_width} \u2502 ");

            string joined = string.Join(", ", pair.Translations);

            Console.Write($"{joined.Capitalize(), -column_width*2} \u2502\n");
        }

        public static void WriteTableFooter()
        {
            Console.Write('\u2558');
            Console.Write(new string('\u2550', n_width));
            Console.WriteLine('\u255B');
        }
    }
}
