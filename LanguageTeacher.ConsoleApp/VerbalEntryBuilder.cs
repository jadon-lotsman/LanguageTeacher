using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguageTeacher.DataAccess.Data.Entities;

namespace LanguageTeacher.ConsoleApp
{
    public interface IVerbalEntryBuilder
    {
        IVerbalEntryBuilder SetForeign(string arg);
        IVerbalEntryBuilder SetTranscription(string arg);
        IVerbalEntryBuilder AddTranslation(params string[] arg);
        IVerbalEntryBuilder AddExample(params string[] arg);

        VerbalEntry Build();
    }

    public class VerbalEntryBuilder : IVerbalEntryBuilder
    {
        private readonly VerbalEntry _entry = new VerbalEntry();

        public IVerbalEntryBuilder SetForeign(string foreign)
        {
            _entry.Foreign = foreign;
            return this;
        }

        public IVerbalEntryBuilder SetTranscription(string transcription) 
        {
            _entry.Transcription = transcription;
            return this;
        }

        public IVerbalEntryBuilder AddTranslation(params string[] translation) 
        { 
            _entry.Translations.AddRange(translation);
            return this; 
        }

        public IVerbalEntryBuilder AddExample(params string[] example) 
        { 
            _entry.Examples.AddRange(example); 
            return this; 
        }

        public VerbalEntry Build()
        {
            return _entry;
        }
    }
}
