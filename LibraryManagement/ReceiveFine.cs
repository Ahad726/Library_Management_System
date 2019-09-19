using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement
{
    public class ReceiveFine
    {
        public int SerialNo { get; set; }
        public int StudentId { get; set; }
        public int ReceivedAmount { get; set; }

        public int RemainingFine { get; set; }

    }
}
