using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement
{
    public class ReturnBook
    {
        public int SerialNo { get; set; }
        public int StudentId { get; set; }
        public string BookBarcode { get; set; }

        public DateTime BookReturnDate { get; set; }


        //the following method has been moved to program.cs

            /*
        public void ReturnBooks(int studentId, string barcode)
        {
            LibraryContext context = new LibraryContext();

            Console.WriteLine($"Thank you for returning book of barcode : {0}",barcode);
            Console.WriteLine("Enter Book Returning Date");

            var bookReturnDate = Convert.ToDateTime(Console.ReadLine());

            context.ReturnBookDetails.Add(new ReturnBook
            {
                StudentId = studentId,
                BookBarcode = barcode,
                BookReturnDate = bookReturnDate

            });

        }
        */

    }
}
