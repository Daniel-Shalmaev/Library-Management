using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Models;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;

namespace Books4You.ViewModel
{
    public class LibraryViewModel : ViewModelBase
    {
        public LibraryViewModel(ItemCollection itemCollection)
        {
            ItemCollection = itemCollection;
            ISBNCheckCommand = new RelayCommand(ISBNCheckFunc);
            ShowAllCommand = new RelayCommand(() => filter.Filter = ShowAllFunc);
            filter = CollectionViewSource.GetDefaultView(ItemCollection.LibraryList);
            ShowBookCommand = new RelayCommand(() => filter.Filter = FilterBookFunc);
            ShowJournalCommand = new RelayCommand(() => filter.Filter = FilterJournalFunc);
            CategoryFilterCommand = new RelayCommand(() => filter.Filter = FilterCategoryFunc);
        }

        ICollectionView filter;

        public long ISBN { get; set; }

        private AbstractItem.Category category;

        public RelayCommand BuyCommand { get; set; }
        public RelayCommand ShowAllCommand { get; set; }
        public RelayCommand ShowBookCommand { get; set; }
        public ItemCollection ItemCollection { get; set; }
        public RelayCommand ShowJournalCommand { get; set; }
        public RelayCommand CategoryFilterCommand { get; set; }
        public RelayCommand ISBNCheckCommand { get; set; }

        public AbstractItem.Category CategoryP { get => category; set => Set(ref category, value); }

        private bool FilterBookFunc(object o) => o is Book;
        private bool ShowAllFunc(object o) => o is AbstractItem;
        private bool FilterJournalFunc(object o) => o is Journal;
        private bool FilterCategoryFunc(object o) => (o as AbstractItem).CategoryProp == CategoryP;

        private void ISBNCheckFunc()
        {
            if (ItemCollection[ISBN] != null) MessageBox.Show("ISBN is in library");
            else MessageBox.Show("ISBN is not in library yet"); 
        }
    }
}
