using GalaSoft.MvvmLight.Command;
using Models;
using System.ComponentModel;
using System.Windows.Data;

namespace Books4You.ViewModel
{
    public class ComingSoonViewModel
    {
        public ComingSoonViewModel(ItemCollection itemCollection)
        {
            ItemCollection = itemCollection;
            ShowAllCommand = new RelayCommand(() => filter.Filter = ShowAllFunc);
            ShowBookCommand = new RelayCommand(() => filter.Filter = FilterBookFunc);
            filter = CollectionViewSource.GetDefaultView(ItemCollection.ComingSoonList);
            ShowJournalCommand = new RelayCommand(() => filter.Filter = FilterJournalFunc);
        }

        ICollectionView filter;

        public RelayCommand ShowAllCommand { get; set; }
        public RelayCommand ShowBookCommand { get; set; }
        public ItemCollection ItemCollection { get; set; }
        public RelayCommand ShowJournalCommand { get; set; }

        private bool FilterBookFunc(object o) => o is Book;
        private bool ShowAllFunc(object o) => o is AbstractItem;
        private bool FilterJournalFunc(object o) => o is Journal;
    }
}
