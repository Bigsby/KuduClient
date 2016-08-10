using System;
using System.Windows.Input;

namespace KuduClient
{
    public sealed class ActionCommand : ICommand
    {
        private readonly Action<object> _execute;
        public ActionCommand(Action<object> execute)
        {
            _execute = execute;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return null != _execute;
        }

        public void Execute(object parameter)
        {
            if (CanExecute(parameter))
                _execute(parameter);
        }
    }
}
