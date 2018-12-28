//using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;

namespace MVVMLightFormsSample.ViewModel
{
    public class ViewModelLocator
    {
        public const string TodoItemPageKey = "TodoItemPage";
        public const string Navigation1PageKey = "Navigation1Page";
        public ViewModelLocator()
        {
            SimpleIoc.Default.Register<TodoItemViewModel>();
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
                                                         "CA1822:MarkMembersAsStatic",
                                                         Justification = "This non-static member is needed for data binding purposes.")]
        public TodoItemViewModel TodoItem
        {
            get
            {
                return SimpleIoc.Default.GetInstance<TodoItemViewModel>();
            }
        }

        public static void Cleanup()
        {
        }
    }
}
