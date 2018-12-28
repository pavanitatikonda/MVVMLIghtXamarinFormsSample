using MVVMLightFormsSample.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MVVMLightFormsSample.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TodoAppPage : ContentPage
	{
        TodoItemViewModel _viewModel;
        public TodoAppPage ()
		{
			InitializeComponent ();
            _viewModel = App.Locator.TodoItem as TodoItemViewModel;
            BindingContext = _viewModel;
        }
	}
}