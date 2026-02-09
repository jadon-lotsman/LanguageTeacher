using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageTeacher.DataAccess.Data.Entities
{
    public class VerbalPair
    {
        public int Id { get; set; }
        public string Foreign { get; set; }
        public List<string> Translations { get; set; } = new List<string>();
        public int? Knowledge { get; set; }
    }
}
