using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryManagement
{
    public class BookIssue
    {
        public int SerialNo { get; set; }
        public int StudentId { get; set; }

       // public Student Student { get; set; }

        public string BookBarcode { get; set; }

        public DateTime BookIssueDate { get; set; }



        // The following method has been moved to program.cs
    /*
        public void IssueBook(int studentId, string barcode)
        {
            LibraryContext context = new LibraryContext();

            var validStudent = context.Students.Where(std => std.StudentId == studentId).FirstOrDefault();

            var ValidBook = context.Books.Where(bk => bk.Barcode == barcode).FirstOrDefault();



            if (validStudent != null && ValidBook != null)
            {


                Console.WriteLine($"{0} Barcode  Book Is Isued. Entry The Issue Date : ", barcode);

                var bookissuedate = Convert.ToDateTime(Console.ReadLine());


                context.IssuedBookDetails.Add(new BookIssue
                {
                    StudentId = studentId,
                    BookBarcode = barcode,
                    BookIssueDate = bookissuedate

                });

            }
            else
            {
                Console.WriteLine("Student Id Or Book BarCode Is Not Valid");
            }

        }
        */

    }
}
