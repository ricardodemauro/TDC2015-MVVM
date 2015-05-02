using ListaDeLeitura.Model;
using ListaDeLeitura.ViewModel.Command;
using ListaDeLeitura.ViewModel.Message;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace ListaDeLeitura.ViewModel
{
    public class ViewModelBase : ModelBase
    {
        public ICommand NavigateBackCommand { get; private set; }

        public ViewModelBase()
        {
            Subscribe();
            NavigateBackCommand = new RelayCommand(OnNavigateBackCommand);
        }

        private void OnNavigateBackCommand(object obj)
        {
            PublishMessage(NavigateMessage.Back);
        }

        public Messenger Messenger
        {
            get { return Messenger.Instance; }
        }

        protected virtual void Subscribe()
        {
        }

        protected void PublishMessage<TMessage>(TMessage message)
        {
            Messenger.Publish<TMessage>(message);
        }
    }
}
