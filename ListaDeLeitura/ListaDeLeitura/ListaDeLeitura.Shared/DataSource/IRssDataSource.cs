using ListaDeLeitura.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ListaDeLeitura.DataSource
{
    public interface IRssDataSource
    {
        Task<IList<RssArticle>> GetArticles();
    }
}
