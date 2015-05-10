using ListaDeLeitura.ViewModel.Message;
using ListaDeLeitura.ViewModel.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace ListaDeLeitura.ViewModel
{
    public class ViewModelLocator
    {
        private static HomePageViewModel main;
        static ViewModelLocator()
        {
            RegisterNavigationService();
        }

        public HomePageViewModel Main
        {
            get
            {
                if (main == null)
                {
                    main = new HomePageViewModel();
                }
                return main;
            }
        }

        private static void RegisterNavigationService()
        {
            Messenger.Instance.Subscribe<NavigateMessage>(NavigationMessageService.NavigateMessage);
        }
    }
}
