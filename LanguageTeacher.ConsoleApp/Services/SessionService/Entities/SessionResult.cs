using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguageTeacher.ConsoleApp.Interfaces;
using LanguageTeacher.DataAccess.Data.Entities;
using Microsoft.VisualBasic;

namespace LanguageTeacher.ConsoleApp.Services.SessionService.Entities
{
    public class SessionResult
    {
        public int CorrectCount { get; }
        public int TotalCount { get; }
        public float Percent { get; }
        public VerbalEntry[] FailedEntries { get; }
        public char CharGrade { get; }

        public SessionResult(int correctCount, int totalCount, VerbalEntry[] failedEntries)
        {
            CorrectCount = correctCount;
            TotalCount = totalCount;
            Percent = (float) CorrectCount / TotalCount * 100;

            FailedEntries = failedEntries;

            if (Percent >= 90)
                CharGrade = 'A';
            else if (Percent >= 80)
                CharGrade = 'B';
            else if (Percent >= 70)
                CharGrade = 'C';
            else if (Percent >= 60)
                CharGrade = 'D';
            else
                CharGrade = 'F';
        }

        public override string ToString()
        {
            return $"{CorrectCount}/{TotalCount} - {CharGrade} ({Percent}%)";
        }
    }
}
