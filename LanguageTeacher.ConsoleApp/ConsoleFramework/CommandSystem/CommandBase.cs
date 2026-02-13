using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguageTeacher.ConsoleApp.ConsoleFramework.CommandSystem.Interfaces;

namespace LanguageTeacher.ConsoleApp.ConsoleFramework.CommandSystem
{
    public abstract class CommandBase : ICommand
    {
        protected abstract int ExpectedArgsCount { get; }
        protected abstract bool HasLimitlessArgs { get; }
        protected abstract void ExecuteInternal(string[] args);


        public void Execute(string[] args)
        {
            bool IsValidLimitless = HasLimitlessArgs && args.Length >= ExpectedArgsCount;

            if (args.Length == ExpectedArgsCount || IsValidLimitless)
                ExecuteInternal(args);
            else
                throw new ArgumentException($"The command expects {ExpectedArgsCount} argument(s), but {args.Length} were provided.");
        }
    }
}
