using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itero.BusinessLogic.DTOs
{
    public class VocabularUpdateDTO
    {
        public string? Foreign { get; set; }
        public string? Transcription { get; set; }
        public string[]? ExamplesAdd { get; set; }
        public string[]? ExamplesDelete { get; set; }
        public string[]? TranslationsAdd { get; set; }
        public string[]? TranslationsDelete { get; set; }
    }
}
