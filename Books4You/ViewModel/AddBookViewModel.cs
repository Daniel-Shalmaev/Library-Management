using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Models;
using System;
using System.Windows;
using static Models.AbstractItem;

namespace Books4You.ViewModel
{
    public class AddBookViewModel : ViewModelBase
    {
        public AddBookViewModel(ItemCollection itemCollection)
        {
            ItemCollection = itemCollection;
            ResetCommand = new RelayCommand(ResetFunc);
            AddBookCommand = new RelayCommand(AddBookFunc);
            AddComingSoonBookCommand = new RelayCommand(AddBookComingSoonFunc);
        }

        public ItemCollection ItemCollection { get; set; }

        public RelayCommand ResetCommand { get; set; }
        public RelayCommand AddBookCommand { get; set; }
        public RelayCommand AddComingSoonBookCommand { get; set; }

        private long isbn;
        private int edition;
        private string name;
        private string genre;
        private long copyNumer;
        private string subject;
        private string category;
        private DateTime publishDate;

        public long ISBN { get => isbn; set => Set(ref isbn, value); }
        public string Name { get => name; set => Set(ref name, value); }
        public string Genre { get => genre; set => Set(ref genre, value); }
        public int Edition { get => edition; set => Set(ref edition, value); }
        public string Subject { get => subject; set => Set(ref subject, value); }
        public long CopyNumer { get => copyNumer; set => Set(ref copyNumer, value); }
        public string CategoryP { get => category; set => Set(ref category, value); }
        public DateTime PublishDate { get => publishDate; set => Set(ref publishDate, value); }



        private void AddBookFunc()
        {
            if (Validation())
                MessageBox.Show("Please insert all details");
            else
            {
                ItemCollection.LibraryList.Add(new Book(Genre)
                {
                    ISBN = ISBN,
                    ItemName = Name,
                    Subject = Subject,
                    Date = PublishDate,
                    CopyNumber = copyNumer,
                    CategoryProp = (Category)Enum.Parse(typeof(Category), CategoryP)
                });
                ResetFunc();
            }
        }

        private void AddBookComingSoonFunc()
        {
            if (Validation())
                MessageBox.Show("Please insert all details");
            else
            {
                ItemCollection.ComingSoonList.Add(new Book(Genre)
                {
                    ISBN = ISBN,
                    ItemName = Name,
                    Subject = Subject,
                    Date = PublishDate,
                    CopyNumber = copyNumer,
                    CategoryProp = (Category)Enum.Parse(typeof(Category), CategoryP)
                });
                ResetFunc();
            }
        }
        private void ResetFunc()
        {
            Name = default;
            ISBN = default;
            Genre = default;
            Subject = default;
            Edition = default;
            CopyNumer = default;
            PublishDate = DateTime.MinValue;
        }

        private bool Validation()
        {
            if (ISBN == default || Name == null || Genre == null || Edition == default ||
                Subject == null || CopyNumer == default || CategoryP == null || PublishDate == default) return true;
            else return false;
        } 
    }
}
