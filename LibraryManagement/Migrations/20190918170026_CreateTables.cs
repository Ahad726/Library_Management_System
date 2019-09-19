using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryManagement.Migrations
{
    public partial class CreateTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Author = table.Column<string>(nullable: true),
                    Edition = table.Column<string>(nullable: true),
                    Barcode = table.Column<string>(nullable: true),
                    CopyCount = table.Column<int>(nullable: false)
                });

            migrationBuilder.CreateTable(
                name: "CheckFines",
                columns: table => new
                {
                    SerialNo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StudentId = table.Column<int>(nullable: false),
                    BookIssueDate = table.Column<DateTime>(nullable: false),
                    BookReturnDate = table.Column<DateTime>(nullable: false),
                    BookKeepingDays = table.Column<int>(nullable: false),
                    FineAmount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckFines", x => x.SerialNo);
                });

            migrationBuilder.CreateTable(
                name: "IssuedBookDetails",
                columns: table => new
                {
                    SerialNo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StudentId = table.Column<int>(nullable: false),
                    BookBarcode = table.Column<string>(nullable: true),
                    BookIssueDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssuedBookDetails", x => x.SerialNo);
                });

            migrationBuilder.CreateTable(
                name: "ReceiveFines",
                columns: table => new
                {
                    SerialNo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StudentId = table.Column<int>(nullable: false),
                    ReceivedAmount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceiveFines", x => x.SerialNo);
                });

            migrationBuilder.CreateTable(
                name: "ReturnBookDetails",
                columns: table => new
                {
                    SerialNo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StudentId = table.Column<int>(nullable: false),
                    BookBarcode = table.Column<string>(nullable: true),
                    BookReturnDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReturnBookDetails", x => x.SerialNo);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "CheckFines");

            migrationBuilder.DropTable(
                name: "IssuedBookDetails");

            migrationBuilder.DropTable(
                name: "ReceiveFines");

            migrationBuilder.DropTable(
                name: "ReturnBookDetails");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
