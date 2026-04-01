using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itero.BusinessLogic.DTOs
{
    public class VocabularCreateDTO
    {
        public string Foreign { get; set; }
        public string[] Translations { get; set; }
    }
}
