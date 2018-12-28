using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using MVVMLightFormsSample.Model;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MVVMLightFormsSample.ViewModel
{
    public class TodoItemViewModel : ObservableObject
    {
        private readonly INavigationService _navigationService;
        private RelayCommand _addItem;

        private RelayCommand _navigateItem;

        public string NewItem
        {
            get;
            set;
        }
        public ObservableCollection<TodoItemModel> Items
        {
            get;
            set;
        }
        public ICommand NavigateCommand { get; set; }

        public TodoItemViewModel(INavigationService navigationService)
        {
            if (navigationService == null)
            {
                throw new ArgumentNullException("navigationService");
            }
            else
            {
                _navigationService = navigationService;
            }

            NewItem = "";
            Items = new ObservableCollection<TodoItemModel>() {
                new TodoItemModel(){
                    Name="Fix some bug",
                },

                new TodoItemModel(){
                    Name = "Deploy App"
                },

                new TodoItemModel(){
                    Name ="Make millions of dollars"
                }
            };
        }

        public RelayCommand AddItem
        {
            get
            {
                return _addItem ?? (_addItem = new RelayCommand(() => AddNewItem()));
            }
        }

        public RelayCommand Navigate1Data
        {
            get
            {
                return _navigateItem ?? (_navigateItem = new RelayCommand(() => NavigateToPage()));
            }
        }
        private void NavigateToPage()
        {
            _navigationService.NavigateTo(ViewModelLocator.Navigation1PageKey);
        }
        private void AddNewItem()
        {
            if (NewItem.Trim().Length > 0)
            {
                Items.Add(new TodoItemModel() { Name = NewItem });
                NewItem = "";
                RaisePropertyChanged("NewItem");
            }
        }
    }
}
