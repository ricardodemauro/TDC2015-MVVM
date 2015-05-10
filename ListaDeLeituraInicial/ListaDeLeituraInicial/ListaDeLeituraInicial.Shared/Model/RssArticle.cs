using System;
using System.Collections.Generic;
using System.Text;

namespace ListaDeLeituraInicial.Model
{
    public class RssArticle
    {
        public string Titulo { get; set; }

        public DateTime DataPublicacao { get; set; }

        public string Descricao { get; set; }

        public Uri Link { get; set; }

        public string Thumbnail { get; set; }
    }
}
