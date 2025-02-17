﻿using CommandPattern.Commands;
using CommandPattern.Core.Contracts;
using System.Linq;

namespace CommandPattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private readonly ICommandFactory commandFactory;

        public CommandInterpreter()
        {
            this.commandFactory = new CommandFactory();
        }

        public string Read(string args)
        {
            string[] parts = args.Split();
            string commandType = parts[0];
            string[] commandArgs = parts.Skip(1).ToArray();

            ICommand command = this.commandFactory.CreateCommad(commandType);

            return command.Execute(commandArgs);
        }
    }
}
