using System;
using System.Collections.Generic;
using System.Text;

namespace ListaDeLeituraApresentacao.ViewModel
{
    public class ViewModelLocator
    {
        public HomePageViewModel HomePageVM
        {
            get
            {
                return new HomePageViewModel();
            }
        }
    }
}
