using System;
using System.Collections.Generic;
using System.Text;

namespace ListaDeLeitura.ViewModel
{
    public class ViewModelLocator
    {
        public HomePageViewModel Main
        {
            get
            {
                return new HomePageViewModel();
            }
        }
    }
}
