using System;
using System.Windows.Input;

namespace miniSem.Base.Mvvm {
    public class BaseCommand: ICommand {
        public event EventHandler CanExecuteChanged;
        private readonly Action _action;
        private bool _canExecute;
        
        public void SetCanExecute(bool canExecute) {
            _canExecute = canExecute;
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        private BaseCommand(Action action, bool canExecute = true) {
            _action = action;
            _canExecute = canExecute;
        }
        
        /// <summary>
        /// 快速创建一个指令
        /// </summary>
        /// <param name="action">执行的任务</param>
        /// <param name="canExecute">是否可以执行</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static BaseCommand Create(Action action, bool canExecute = true) {
            if (action == null) {
                throw new ArgumentNullException(nameof(action));
            }
            return new BaseCommand(action, canExecute);
        }

        public bool CanExecute(object parameter) => _canExecute;
        public void Execute(object parameter) => _action?.Invoke(); 
    }
}