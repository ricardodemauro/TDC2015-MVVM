using ListaDeLeituraApresentacao.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Windows.ApplicationModel;

namespace ListaDeLeituraApresentacao.ViewModel
{
    public abstract class ViewModelBase : ModelBase
    {
        private static bool? _isInDesignMode;

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
