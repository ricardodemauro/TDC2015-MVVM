using System;
using System.Collections.Generic;
using System.Text;

namespace ListaDeLeitura.ViewModel.Message
{
    public class NavigateMessage
    {
        public bool NavigateBack { get; set; }
        public string PageName { get; set; }
        public object Parameter { get; set; }

        public NavigateMessage(string pageName, object parameter = null)
        {
            PageName = pageName;
            Parameter = parameter;
        }

        public static NavigateMessage Back
        {
            get
            {
                return new NavigateMessage(null)
                {
                    NavigateBack = true,
                };
            }
        }
    }
}
