using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Models;
using System;
using System.Windows;
using static Models.AbstractItem;

namespace Books4You.ViewModel
{
    public class AddJournalViewModel : ViewModelBase
    {
        public AddJournalViewModel(ItemCollection itemCollection)
        {
            ItemCollection = itemCollection;
            ResetCommand = new RelayCommand(ResetFunc);
            AddJournalCommand = new RelayCommand(AddJournalFunc);
            AddComingSoonJournalCommand = new RelayCommand(AddJournalComingSoonFunc);
        }

        public RelayCommand ResetCommand { get; set; }
        public ItemCollection ItemCollection { get; set; }
        public RelayCommand AddJournalCommand { get; set; }
        public RelayCommand AddComingSoonJournalCommand { get; set; }

        private long isbn;
        private int edition;
        private string name;
        private string subject;
        private long copyNumber;
        private string category;
        private DateTime printDate;

        public long ISBN { get => isbn; set => Set(ref isbn, value); }
        public string Name { get => name; set => Set(ref name, value); }
        public int Edition { get => edition; set => Set(ref edition, value); }
        public string Subject { get => subject; set => Set(ref subject, value); }
        public string CategoryP { get => category; set => Set(ref category, value); }
        public long CopyNumer { get => copyNumber; set => Set(ref copyNumber, value); }
        public DateTime PrintDate { get => printDate; set => Set(ref printDate, value); }


        private void AddJournalFunc()
        {
            if (Validation())
                MessageBox.Show("Please insert all details");
            else
            {
                ItemCollection.LibraryList.Add(new Journal(PrintDate)
                {
                    ISBN = ISBN,
                    ItemName = Name,
                    Subject = Subject,
                    Edition = Edition,
                    CopyNumber = copyNumber,
                    CategoryProp = (Category)Enum.Parse(typeof(Category), CategoryP)
                });
                ResetFunc();
            }
        }

        private void AddJournalComingSoonFunc()
        {
            if (Validation())
                MessageBox.Show("Please insert all details");
            else
            {
                ItemCollection.ComingSoonList.Add(new Journal(PrintDate)
                {
                    ISBN = ISBN,
                    ItemName = Name,
                    Edition = Edition,
                    Subject = Subject,
                    CopyNumber = copyNumber,
                    CategoryProp = (Category)Enum.Parse(typeof(Category), CategoryP)
                });
                ResetFunc();
            }
        }

        private void ResetFunc()
        {
            Name = default;
            ISBN = default;
            Subject = default;
            Edition = default;
            CopyNumer = default;
            PrintDate = DateTime.MinValue;
        }

        private bool Validation()
        {
            if (ISBN == default || Name == null || Edition == default || Subject == null ||
                CopyNumer == default || CategoryP == null || PrintDate == default) return true;
            else return false;
        }
    }
}
