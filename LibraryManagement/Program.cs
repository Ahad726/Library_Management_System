using System;
using System.Linq;

namespace LibraryManagement
{
    class Program
    {


        static void Main(string[] args)
        {
            LibraryContext context = new LibraryContext();




        again:

            Console.Clear();
            Console.WriteLine("\t==============================================================");
            Console.WriteLine("\tWelcome to Library Management System.");

            Console.WriteLine("\n\n\tTo entry student information enter: 1");
            Console.WriteLine("\tTo entry book information enter: 2");
            Console.WriteLine("\tTo issue a book, enter: 3");
            Console.WriteLine("\tTo return a book enter: 4");
            Console.WriteLine("\tTo check fine, enter: 5 ");
            Console.WriteLine("\tTo receive fine, enter: 6");
            Console.WriteLine("\t==============================================================");



            Console.Write("\n\tPlease enter your choice:");
            var choice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\t==================================================================");



            switch (choice)
            {


                case 1:
                    EnterStudent(context);
                    break;

                case 2:
                    EnterBook(context);
                    break;

                case 3:
                    IssueBook(context);
                    break;

                case 4:
                    ReturnBooksAndCalCulateFine(context);
                    break;

                case 5:
                    ShowFine(context);
                    break;

                case 6:
                    ReceiveStudentFine(context);
                    break;

                default:
                    Console.WriteLine("You have choosed Invalid Options.Try Again :");
                    Console.Beep(600, 1000);
                    break;
            }


            goto again;


        }


        //Enter Student Information
        public static void EnterStudent(LibraryContext context)
        {
            try
            {



                //Get data from user
                Console.WriteLine("\t================================================================");
                Console.WriteLine("\t===============Enter Sudent Information=================");
                Console.Write("Please Enter Student Id: ");
                var studentId = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("\t=========================");
                Console.Write("\tPlease Enter Student Name: ");
                var studentName = Console.ReadLine();

                //Update data into database


                context.Students.Add(new Student
                {
                    StudentId = studentId,
                    Name = studentName,
                    Fine = 0


                });

                context.Students.OrderBy(st => st.StudentId);

                context.SaveChanges();



            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                Console.WriteLine("Please input the right data. ");
                Console.Beep(600, 1500);
            }

        }


        //Enter Book Information
        public static void EnterBook(LibraryContext context)
        {

            try
            {


                Console.WriteLine("\t============================================================");
                Console.WriteLine("\t==============please Enter Book Information==================");
                Console.Write("Please Enter Book Id: ");
                var bookId = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("\t=================");
                Console.Write("Please Enter Book Title: ");
                var bookTitle = Console.ReadLine();

                Console.WriteLine("\t=================");
                Console.Write("Please Enter Book Author: ");
                var bookAuthor = Console.ReadLine();

                Console.WriteLine("\t=================");
                Console.Write("Please Enter Book Edition: ");
                var bookEdition = Console.ReadLine();

                Console.WriteLine("\t=================");
                Console.Write("Please Enter Book Barcode: ");
                var bookBarcode = Console.ReadLine();

                Console.WriteLine("\t=================");
                Console.Write("Please Enter Book Copy Count: ");
                var bookCopyCount = Convert.ToInt32(Console.ReadLine());

                context.Books.Add(new Book
                {
                    BookId = bookId,
                    Title = bookTitle,
                    Author = bookAuthor,
                    Edition = bookEdition,
                    Barcode = bookBarcode,
                    CopyCount = bookCopyCount
                });

                context.SaveChanges();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                Console.WriteLine("Please input the right data. ");
                Console.Beep(600, 1500);
            }

        }


        // Issue Book Method
        public static void IssueBook(LibraryContext context)
        {

            try
            {


                Console.WriteLine("\t=======================================================");
                Console.WriteLine("\t======Welcome To Book Issue Process=======");


                Console.Write("\tplease Enter A Valid Student Id: ");
                var studentId = Convert.ToInt32(Console.ReadLine());



                Console.WriteLine("\t====================");
                Console.Write("\tPlease Enter A Valid Book BarCode : ");
                var barcode = Console.ReadLine();


                var validStudent = context.Students.Where(std => std.StudentId == studentId).FirstOrDefault();

                var ValidBook = context.Books.Where(bk => bk.Barcode == barcode).FirstOrDefault();


               

                if (validStudent.Fine != 0)  // If a student already fined . He cannot issue another book.
                {
                    Console.WriteLine($"\n\tStudent Id {studentId} is already Fined. Pay the fine first before issuing another book");
                    Console.Beep(600, 1500);
                    Console.ReadLine();
                }

                else
                {

                    

                    if (validStudent != null && ValidBook != null)  //check student and book are valid 
                    {
                        int validCopy = ValidBook.CopyCount;

                        

                        if (validCopy > 0)  //check if the book copy is available
                        {

                            Console.WriteLine("\t==============");
                            Console.Write($"\n\t{barcode} Barcode  Book Is Issued. Entry The Issue Date : (MM/DD/YY)  ");

                            var bookissuedate = Convert.ToDateTime(Console.ReadLine());


                            context.IssuedBookDetails.Add(new BookIssue
                            {
                                StudentId = studentId,
                                BookBarcode = barcode,
                                BookIssueDate = bookissuedate

                            });
                            context.SaveChanges();

                            validCopy = validCopy - 1;
                            ValidBook.CopyCount = validCopy;
                            context.SaveChanges();

                        }
                        else
                        {
                            Console.WriteLine("\n\tThis Book Is Not Available Right Now");
                            Console.Beep(600, 1500);
                        }



                    }
                    else
                    {
                        Console.WriteLine("\n\tStudent Id Or Book BarCode Is Not Valid");
                        Console.Beep(600, 1500);
                    }

                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                Console.WriteLine("Please input the right data. ");
                Console.Beep(600, 1500);
            }

        }


        // Return book Method
        public static void ReturnBooksAndCalCulateFine(LibraryContext context)
        {
            try
            {


                Console.WriteLine("\t============================================================");
                Console.WriteLine("\t======Welcome to Book Returning process=======");
                Console.Write("\n\tPlease Enter Student Id: ");
                var studentId = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("\t===========");
                Console.Write("\n\tPlease Enter Book Barcode: ");
                var barcode = Console.ReadLine();


                Console.WriteLine("\t=========||||===========");
                Console.WriteLine($"\tThank you for returning book of barcode : {barcode}");
                Console.Write("\n\tEnter Book Returning Date : (MM/DD/YY)");

                var bookReturnDate = Convert.ToDateTime(Console.ReadLine());

                context.ReturnBookDetails.Add(new ReturnBook
                {
                    StudentId = studentId,
                    BookBarcode = barcode,
                    BookReturnDate = bookReturnDate

                });

                context.SaveChanges();

                //Book Count Increase By 1

                var returnBook = context.Books.Where(b => b.Barcode == barcode).FirstOrDefault();
                var returnBookCrntCount = returnBook.CopyCount;
                returnBookCrntCount = returnBookCrntCount + 1;

                returnBook.CopyCount = returnBookCrntCount;
                context.SaveChanges();


                // Calculate Fine

                DateTime bookIssueDate = context.IssuedBookDetails.Where(isbd => isbd.StudentId == studentId).Select(isbd => isbd.BookIssueDate).FirstOrDefault();

                DateTime returnBookDate = context.ReturnBookDetails.Where(rtbd => rtbd.StudentId == studentId).Select(rtbd => rtbd.BookReturnDate).FirstOrDefault();



                var delayDays = (returnBookDate - bookIssueDate).Days - 8;

                int delay = 0;

                if (delayDays > 0)
                {
                    delay = delayDays;
                }

                int fine = 0;

                if (delay > 0)
                {
                    fine = delay * 10;

                }


                var stdnt = context.Students.Where(st => st.StudentId == studentId).FirstOrDefault();
                stdnt.Fine = fine;
                context.SaveChanges();


                context.CheckFines.Add(new CheckFine
                {
                    StudentId = studentId,
                    BookIssueDate = bookIssueDate,
                    BookReturnDate = returnBookDate,
                    DelayDays = delay,
                    FineAmount = fine
                });

                context.SaveChanges();


                // Here I did this code for deleting the student entity in folowing two tables (if fine = 0) so that if he again issue a book ,
                //then the system will again calculate the fine.


                if (fine == 0)
                {
                    var issueBookTableEntity = context.IssuedBookDetails.Where(Ibd => Ibd.StudentId == studentId).FirstOrDefault();

                    context.IssuedBookDetails.Remove(issueBookTableEntity);
                    context.SaveChanges();

                    var returnBookTableEntity = context.ReturnBookDetails.Where(rbd => rbd.StudentId == studentId).FirstOrDefault();

                    context.ReturnBookDetails.Remove(returnBookTableEntity);
                    context.SaveChanges();
                }


               /* // If a student haved issued more than one book and returning a single book than show him following message.
                

                var issuedBook = context.IssuedBookDetails.Where(ib => ib.StudentId == studentId).FirstOrDefault();

                if (issuedBook != null)
                {
                    Console.WriteLine("\n\t You have issued more than 1 book. Return that before delay count");
                    Console.Beep(600, 1500);
                    Console.ReadLine();
                }*/



            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                Console.WriteLine("Please input the right data. ");
                Console.Beep(600, 1500);
            }

        }




        // Show Fine

        public static void ShowFine(LibraryContext context)
        {
            try
            {


                Console.WriteLine("\t=====================================================");
                Console.WriteLine("\t======Welcome To Fine Checking Process========");
                Console.Write("\n\tPlease Enter Student Id : ");
                var studentId = Convert.ToInt32(Console.ReadLine());


                int stdFineAmount = context.Students.Where(st => st.StudentId == studentId).Select(st => st.Fine).FirstOrDefault();

                Console.WriteLine($"\n\tDear Student With Student Id  {studentId} , you have been fined with {stdFineAmount} Taka");
                Console.Beep(400, 1000);
                Console.ReadLine();


            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                Console.WriteLine("Please input the right data. ");
                Console.Beep(600, 1500);
            }


        }


        // Receive Fine Method
        public static void ReceiveStudentFine(LibraryContext context)
        {
            try
            {

                Console.WriteLine("\t======================================================================");
                Console.WriteLine("\t============Welcome to Fine Receiving Section===========");
                Console.Write("\n\tEnter Student Id: ");
                var studentId = Convert.ToInt32(Console.ReadLine());

                // int studentFineAmount = context.CheckFines.Where(cf => cf.StudentId == studentId).Select(cf => cf.FineAmount).FirstOrDefault();

                int studentFineAmount = context.Students.Where(st => st.StudentId == studentId).Select(st => st.Fine).FirstOrDefault();
                Console.WriteLine($"\tStudent Id {studentId} Has Been Fined With {studentFineAmount} Taka ");


                Console.WriteLine("\t===============");
                Console.Write("\n\tEnter Fine Amount: ");
                var fineAmount = Convert.ToInt32(Console.ReadLine());

                // Fine reduce 

                var remainingAmount = studentFineAmount - fineAmount;


                var stdnt = context.Students.Where(st => st.StudentId == studentId).FirstOrDefault();

                stdnt.Fine = remainingAmount;
                context.SaveChanges();


                context.ReceiveFines.Add(new ReceiveFine
                {
                    StudentId = studentId,
                    ReceivedAmount = fineAmount,
                    RemainingFine = remainingAmount
                });

                context.SaveChanges();



                // Here I did this code for deleting the student entity in folowing two tables (if fine = 0) so that if he again issue a book ,
                //then the system will again calculate the fine.

                var stdntFine = context.Students.Where(st => st.StudentId == studentId).Select(st => st.Fine).FirstOrDefault();

                if (stdntFine == 0)
                {
                    var issueBookTableEntity = context.IssuedBookDetails.Where(Ibd => Ibd.StudentId == studentId).FirstOrDefault();

                    context.IssuedBookDetails.Remove(issueBookTableEntity);
                    context.SaveChanges();

                    var returnBookTableEntity = context.ReturnBookDetails.Where(rbd => rbd.StudentId == studentId).FirstOrDefault();

                    context.ReturnBookDetails.Remove(returnBookTableEntity);
                    context.SaveChanges();

                }




            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                Console.WriteLine("Please input the right data. ");
                Console.Beep(600, 1500);
            }

        }




    }
}
