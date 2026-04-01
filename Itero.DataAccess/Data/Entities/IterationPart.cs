using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itero.DataAccess.Data.Entities
{
    public class IterationPart
    {
        public int Id { get; set; } 
        public bool IsForwardQuestion { get; set; }
        public string Value { get; set; }
        public string? UserValue { get; set; }


        public int IterationId { get; set; }
        public Iteration Iteration { get; set; }


        public int BasedEntryId { get; set; }
        public VocabularyEntry BasedEntry { get; set; }


        public IterationPart() { }

        public IterationPart(VocabularyEntry source, bool isForwardQuestion)
        {
            IsForwardQuestion = isForwardQuestion;

            Value = IsForwardQuestion ? source.Foreign : source.Translations[0];
            BasedEntry = source;
        }
    }
}
