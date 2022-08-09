using System.Collections.ObjectModel;

namespace Models
{
    public class ItemCollection
    {
        public ItemCollection()
        {
            LibraryList = new ObservableCollection<AbstractItem>();
            ComingSoonList = new ObservableCollection<AbstractItem>();
            BagList = new ObservableCollection<AbstractItem>();
        }

        public ObservableCollection<AbstractItem> LibraryList { get; set; }
        public ObservableCollection<AbstractItem> ComingSoonList { get; set; }
        public ObservableCollection<AbstractItem> BagList { get; set; }

        private AbstractItem Get(long isbn)
        {
            foreach (AbstractItem item in LibraryList)
            {
                if (item.ISBN == isbn) return item;
            }
            return null;
        }

        public AbstractItem this[long isbn] => Get(isbn);
    }
}
