using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using MVVMLightFormsSample.Services;
using MVVMLightFormsSample.ViewModel;
using MVVMLightFormsSample.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MVVMLightFormsSample
{
    public partial class App : Application
    {
        private static ViewModelLocator _locator;
        NavigationService navigationService;
        public App()
        {
            InitializeComponent();

            if (navigationService == null)
            {
                navigationService = new NavigationService();
            }

            navigationService.Configure(ViewModelLocator.TodoItemPageKey, typeof(TodoAppPage));
            navigationService.Configure(ViewModelLocator.Navigation1PageKey, typeof(Navigation1Page));

            if (!SimpleIoc.Default.IsRegistered<INavigationService>())
            {
                SimpleIoc.Default.Register<INavigationService>(() => navigationService);
            }

            var _firstPage = new NavigationPage(new TodoAppPage());
            navigationService.Initialize(_firstPage);

            MainPage = _firstPage;
        }

        public static ViewModelLocator Locator
        {
            get
            {
                return _locator ?? (_locator = new ViewModelLocator());
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            if (navigationService == null)
            {
                navigationService = new NavigationService();
            }
            navigationService.Configure(ViewModelLocator.TodoItemPageKey, typeof(TodoAppPage));
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }


    //public class NavigationService : INavigationService
    //{
    //    public string CurrentPageKey => throw new System.NotImplementedException();

    //    public void GoBack()
    //    {
    //        throw new System.NotImplementedException();
    //    }

    //    public void NavigateTo(string pageKey)
    //    {
    //        throw new System.NotImplementedException();
    //    }

    //    public void NavigateTo(string pageKey, object parameter)
    //    {
    //        throw new System.NotImplementedException();
    //    }
    //}
}
