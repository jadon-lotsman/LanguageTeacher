using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageTeacher.DataAccess.Data.Entities
{
    public class VerbalPair
    {
        public int Id { get; set; }
        public string Foreign { get; set; }
        public string Translate { get; set; }
        public int? Knowledge { get; set; }
    }
}
