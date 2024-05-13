using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.WPF.Commands
{
    public class AsyncCommandWithoutParameter : AsyncCommandBase
    {
        private readonly Func<Task> _execute;

        public AsyncCommandWithoutParameter(Func<Task> execute)
        {
            _execute = execute;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            await _execute();
        }
    }
}