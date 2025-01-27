using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _03.CommandPattern.Contracts;

namespace _03.CommandPattern
{
    public class ModifyPrice
    {
        private readonly List<ICommand> commands;
        private ICommand command;

        public ModifyPrice()
        {
            this.commands = new List<ICommand>();
        }

        public void SetCommand(ICommand command) => this.command = command;

        public void Invoke()
        {
            this.commands.Add(command);
            this.command.ExecuteAction();
        }
    }
}
