using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement
{

    public class CheckFine
    {
        public int SerialNo { get; set; }
        public int StudentId { get; set; }
        public DateTime BookIssueDate { get; set; }
        public DateTime BookReturnDate { get; set; }
        public int DelayDays { get; set; }

        public int FineAmount { get; set; }


    }



}
