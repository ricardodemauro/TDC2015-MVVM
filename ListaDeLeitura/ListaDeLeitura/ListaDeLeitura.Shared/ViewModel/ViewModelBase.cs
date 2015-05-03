using ListaDeLeitura.Model;
using ListaDeLeitura.ViewModel.Command;
using ListaDeLeitura.ViewModel.Message;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Windows.Input;
using Windows.ApplicationModel;

namespace ListaDeLeitura.ViewModel
{
    public class ViewModelBase : ModelBase
    {
        private static bool? _isInDesignMode;

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

        [SuppressMessage("Microsoft.Security", "CA2122:DoNotIndirectlyExposeMethodsWithLinkDemands",
             Justification = "The security risk here is neglectible.")]
        public static bool IsInDesignModeStatic
        {
            get
            {
                if (!_isInDesignMode.HasValue)
                {
#if SILVERLIGHT 
                     _isInDesignMode = DesignerProperties.IsInDesignTool; 
#else
#if NETFX_CORE
                    _isInDesignMode = DesignMode.DesignModeEnabled;
#else
#if XAMARIN 
                     // TODO XAMARIN Is there such a thing as design mode? How to detect it? 
                     _isInDesignMode = false; 
#else 
                     var prop = DesignerProperties.IsInDesignModeProperty; 
                     _isInDesignMode 
                         = (bool)DependencyPropertyDescriptor 
                                         .FromProperty(prop, typeof(FrameworkElement)) 
                                         .Metadata.DefaultValue; 
#endif
#endif
#endif
                }


                return _isInDesignMode.Value;
            }
        }

    }
}
