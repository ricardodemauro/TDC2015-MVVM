﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace ListaDeLeitura.ViewModel.Command
{
    public class RelayCommand : ICommand
    {
        public Action<object> ExecuteAction { get; set; }

        public Func<object, bool> CanExecuteFunction { get; set; }

        public RelayCommand(Action<object> executeAction, Func<object, bool> canExecuteFunction = null)
        {
            if (canExecuteFunction == null)
                canExecuteFunction = (o) => true;
            if (executeAction == null)
                throw new ArgumentNullException("executeAction");

            ExecuteAction = executeAction;
            CanExecuteFunction = canExecuteFunction;
        }

        public void RaiseCanExecuteChanged()
        {
            var handler = CanExecuteChanged;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        #region ICommand implementation
        public bool CanExecute(object parameter)
        {
            return CanExecuteFunction(parameter);
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            ExecuteAction(parameter);
        }
        #endregion
    }
}
