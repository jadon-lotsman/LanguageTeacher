using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LanguageTeacher.ConsoleApp.ConsoleFramework.CommandSystem
{
    public class CommandExecutor
    {
        private VocabularService _service;
        private CommandFactory _factory;

        public CommandExecutor(VocabularService service)
        {
            _service = service;
            _factory = new CommandFactory();
        }


        public void ExecuteUserCommand(string? request)
        {
            if (string.IsNullOrEmpty(request))
                throw new ArgumentException("User command request is empty.");

            string[] splittedRequest = request.SplitIgnored(' ', '"');

            string commandName = splittedRequest[0];
            string[] commandArgs = new string[splittedRequest.Length - 1];

            Array.Copy(splittedRequest, 1, commandArgs, 0, splittedRequest.Length-1);


            var сommand = _factory.Create(commandName, _service);


            сommand.Execute(commandArgs);
        }
    }
}
