using Books4You.Views;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Models;
using System.Windows;

namespace Books4You.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            ExitCommand = new RelayCommand(ExitFunc);
            LogoutCommand = new RelayCommand(LogoutFunc);
            LibraryCommand = new RelayCommand(LibraryViewFunc);
            AddBookCommand = new RelayCommand(AddBookViewFunc);
            AddJournalCommand = new RelayCommand(AddJournalViewFunc);
            AddComingSoonCommand = new RelayCommand(ComingSoonViewFunc);
        }
        public RelayCommand ExitCommand { get; set; }
        public RelayCommand LogoutCommand { get; set; }
        public RelayCommand LibraryCommand { get; set; }
        public RelayCommand AddBookCommand { get; set; }
        public RelayCommand AddJournalCommand { get; set; }
        public RelayCommand BrowseJournalCommand { get; set; }
        public RelayCommand AddComingSoonCommand { get; set; }

        public Visibility IsManager => UserLogin.IsManager ? Visibility.Visible : Visibility.Collapsed;
        public Visibility IsCustomer => UserLogin.IsManager ? Visibility.Collapsed : Visibility.Visible;

        private void LibraryViewFunc()
        {
            LibraryView libraryView = new LibraryView();
            Window main = new Window { Width = 1250, Height = 750 };
            main.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            main.DataContext = libraryView.DataContext;
            main.Content = libraryView.Content;
            main.Show();
        }

        private void ExitFunc() => Application.Current.Shutdown();

        private void AddBookViewFunc()
        {
            var addBook = new AddBookView();
            Window main = new Window { Width = 600, Height = 700 };
            main.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            main.DataContext = addBook.DataContext;
            main.Content = addBook.Content;
            main.Show();
        }
        private void AddJournalViewFunc()
        {
            var JournalView = new AddJournal();
            Window main = new Window { Width = 600, Height = 700 };
            main.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            main.DataContext = JournalView.DataContext;
            main.Content = JournalView.Content;
            main.Show();
        }

        private void ComingSoonViewFunc()
        {
            ComingSoonView coomingSoonBooksView = new ComingSoonView();
            Window main = new Window { Width = 1250, Height = 750 };
            main.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            main.DataContext = coomingSoonBooksView.DataContext;
            main.Content = coomingSoonBooksView.Content;
            main.Show();
        }

        private void LogoutFunc() => Application.Current.Windows[1].Close();
    }
}