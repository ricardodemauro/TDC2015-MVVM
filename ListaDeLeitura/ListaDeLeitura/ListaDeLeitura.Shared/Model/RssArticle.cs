using System;
using System.Collections.Generic;
using System.Text;

namespace ListaDeLeitura.Model
{
    public class RssArticle : ModelBase
    {
        private Uri link;
        public Uri Link
        {
            get { return link; }
            set { SetProperty(ref link, value); }
        }

        private string summary;
        public string Summary
        {
            get { return summary; }
            set { SetProperty(ref summary, value); }
        }

        private string title;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        private DateTime pubDate;
        public DateTime PubDate
        {
            get { return pubDate; }
            set { SetProperty(ref pubDate, value); }
        }

        private string thumbnail;
        public string Thumbnail
        {
            get { return thumbnail; }
            set { SetProperty(ref thumbnail, value); }
        }
    }
}
