using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SoftTradeTEST.Commands
{
    internal class RelayCommand : ICommand
    {
        private ICommand? editManagerWindowCommand;
        private Func<object, bool> canShowWindow;

        public event EventHandler? CanExecuteChanged;

        private Action<object> _Excute {  get; set; }  
        private Predicate<object> _CanExcute {  get; set; }

        public RelayCommand(Action<object> Excute, Predicate<object> CanExcute) 
        {
            _Excute = Excute;
            _CanExcute = CanExcute;
        }

        public RelayCommand(ICommand? editManagerWindowCommand, Func<object, bool> canShowWindow)
        {
            this.editManagerWindowCommand = editManagerWindowCommand;
            this.canShowWindow = canShowWindow;
        }

        public bool CanExecute(object? parameter)
        {
            return _CanExcute(parameter);
        }

        public void Execute(object? parameter)
        {
            _Excute(parameter);
        }
    }
}
