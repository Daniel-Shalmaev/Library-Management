using System;

namespace Models
{
    public class Journal : AbstractItem
    {
        public Journal(DateTime printDate) => PrintDate = printDate;
        public DateTime PrintDate { get; set; }
    }
}
