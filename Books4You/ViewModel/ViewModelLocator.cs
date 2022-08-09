using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using Models;

namespace Books4You.ViewModel
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<ItemCollection>();
            SimpleIoc.Default.Register<LibraryViewModel>();
            SimpleIoc.Default.Register<AddBookViewModel>();
            SimpleIoc.Default.Register<AddJournalViewModel>();
            SimpleIoc.Default.Register<ComingSoonViewModel>();
            SimpleIoc.Default.Register<LoginRegisterViewModel>();
        }

        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();
        public LibraryViewModel Library => ServiceLocator.Current.GetInstance<LibraryViewModel>();
        public AddBookViewModel AddBook => ServiceLocator.Current.GetInstance<AddBookViewModel>();
        public AddJournalViewModel AddJournal => ServiceLocator.Current.GetInstance<AddJournalViewModel>();
        public LoginRegisterViewModel Login => ServiceLocator.Current.GetInstance<LoginRegisterViewModel>();
        public ComingSoonViewModel ComingSoonBooks => ServiceLocator.Current.GetInstance<ComingSoonViewModel>();
    }
}