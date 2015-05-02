using System;
using System.Collections.Generic;
using System.Text;

namespace ListaDeLeitura.Model
{
    public class RssArticle : ModelBase
    {
        private Uri _link;
        public Uri Link
        {
            get { return _link; }
            set { SetProperty(ref _link, value); }
        }

        private string _summary;
        public string Summary
        {
            get { return _summary; }
            set { SetProperty(ref _summary, value); }
        }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
    }
}
