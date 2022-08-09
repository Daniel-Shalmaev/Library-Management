using System;

namespace Models
{
    abstract public class AbstractItem
    {
        public AbstractItem()
        {

        }
        public long ISBN { get; set; }
        public string ItemName { get; set; }
        public int Edition { get; set; }
        public long CopyNumber { get; set; }
        public string Subject { get; set; }
        public DateTime Date { get; set; }
        public Category CategoryProp { get; set; }
        public enum Category
        {
            Action,
            Adventure,
            Biography,
            Comic,
            Crime,
            Novel,
            Fairytale,
            Fantazy,
            Fiction,
            History,
            Horror,
            Humor,
            Mistery,
            Romance,
            Satire,
        }
    }
}
