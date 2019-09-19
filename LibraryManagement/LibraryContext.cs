using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement
{
    public class LibraryContext : DbContext
    {
        private const string _connectionString = "Server = DESKTOP-P8II8OC; Database=LibraryManagement;User Id = talha; Password=1618017";





        public DbSet<Student> Students { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<BookIssue> IssuedBookDetails { get; set; }

        public DbSet<ReturnBook> ReturnBookDetails { get; set; }

        public DbSet<CheckFine> CheckFines { get; set; }

        public DbSet<ReceiveFine> ReceiveFines { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }

            base.OnConfiguring(optionsBuilder);

        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<BookIssue>()
                .HasKey(bi => bi.SerialNo);
            builder.Entity<CheckFine>()
                .HasKey(cf => cf.SerialNo);

            builder.Entity<ReceiveFine>()
                .HasKey(rf => rf.SerialNo);

            builder.Entity<ReturnBook>()
                .HasKey(rb => rb.SerialNo);


            base.OnModelCreating(builder);
        }
    }
}
