using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace ListaDeLeitura.ViewModel.Message.Handler
{
    public static class NavigateMessageHandler
    {
        public static void NavigateMessage(NavigateMessage message)
        {
            var rootFrame = ((Frame)Window.Current.Content);

            if (message.NavigateBack)
            {
                if (rootFrame.CanGoBack)
                {
                    rootFrame.GoBack();
                }
            }
            else
            {
                var sourcePageType = Type.GetType(string.Format("AdventureWorksCatalog.View.{0}", message.PageName));
                rootFrame.Navigate(sourcePageType, message.Parameter);
            }
        }
    }
}
