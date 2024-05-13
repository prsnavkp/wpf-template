using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.WPF.Commands
{
    public class AsyncCommand : AsyncCommandBase
    {
        private readonly Func<object, Task> _execute;

        public AsyncCommand(Func<object, Task> execute)
        {
            _execute = execute;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            await _execute(parameter);
        }
    }
}