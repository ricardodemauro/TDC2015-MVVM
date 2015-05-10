using ListaDeLeitura.DataSource;
using ListaDeLeitura.Model;
using ListaDeLeitura.ViewModel.Command;
using ListaDeLeitura.ViewModel.Message;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace ListaDeLeitura.ViewModel
{
    public class HomePageViewModel : ViewModelBase
    {
        public RelayCommand NavigateToArticleCommand { get; set; }
        public RelayCommand RefreshCommand { get; set; }

        public ObservableCollection<RssArticle> Items { get; set; }

        private RssArticle _selectedArticle;
        public RssArticle SelectedArticle
        {
            get
            {
#if DEBUG
                if (IsInDesignModeStatic)
                {
                    return Items[0];
                }
#endif
                return _selectedArticle;

            }
            set { SetProperty(ref _selectedArticle, value); }
        }

        private bool _refreshing;
        public bool Refreshing
        {
            get { return _refreshing; }
            set { SetProperty(ref _refreshing, value); this.RefreshCommand.RaiseCanExecuteChanged(); }
        }

        public HomePageViewModel()
        {
            this.Items = new ObservableCollection<RssArticle>();

            this.NavigateToArticleCommand = new RelayCommand(OnNavigateToArticleCommand, CanExecuteNavigateToArticleCommand);
            this.RefreshCommand = new RelayCommand(OnRefreshCommand, CanExecuteRefreshCommand);

            Refresh();
        }

        private bool CanExecuteNavigateToArticleCommand(object parameter)
        {
            return SelectedArticle != null;
        }

        private void OnNavigateToArticleCommand(object parameter)
        {
            PublishMessage(new NavigateMessage("ArticlePage", parameter));
        }

        private bool CanExecuteRefreshCommand(object parameter)
        {
            return !Refreshing;
        }

        private void OnRefreshCommand(object parameter)
        {
            Refresh();
        }

        public async Task Refresh()
        {
            this.Refreshing = true;

            this.Items.Clear();

            try
            {
                IList<RssArticle> list = await DataSource.RssDataSource.Instance.GetArticles();
                foreach (var item in list)
                {
                    Items.Add(item);
                }
            }
            catch (Exception)
            {
                //throw;
                //Logar erro
            }

            this.Refreshing = false;
        }
    }
}
