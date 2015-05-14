using ListaDeLeituraApresentacao.DataSource;
using ListaDeLeituraApresentacao.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using ListaDeLeituraApresentacao.ViewModel.Command;

namespace ListaDeLeituraApresentacao.ViewModel
{
    public class HomePageViewModel : ViewModelBase
    {
        public RelayCommand RefreshCommand { get; set; }

        public ObservableCollection<RssArticle> Items { get; set; }

        private bool isRefreshing;
        public bool IsRefreshing
        {
            get { return isRefreshing; }
            set
            {
                if (SetProperty(ref isRefreshing, value))
                {
                    this.RefreshCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public HomePageViewModel()
        {
            this.Items = new ObservableCollection<RssArticle>();
            this.RefreshCommand = new RelayCommand(RefreshCommandAction, CanRefreshCommandAction);

            this.LoadRss();
        }

        public void RefreshCommandAction(object parameter)
        {
            this.LoadRss();
        }

        public bool CanRefreshCommandAction(object parameter)
        {
            
            return !IsRefreshing;
        }

        private async Task LoadRss()
        {
            this.IsRefreshing = true;
            this.Items.Clear();

            try
            {
                var articlesCollection = await RssDataSource.GetArticles();
                foreach (var article in articlesCollection)
                {
                    this.Items.Add(article);
                }
            }
            finally
            {
                this.IsRefreshing = false;
            }
        }
    }
}
