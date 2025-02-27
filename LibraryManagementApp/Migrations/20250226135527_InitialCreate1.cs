using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LibraryManagementApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CopiesAvailable = table.Column<int>(type: "int", nullable: false),
                    BorrowCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "BorrowCount", "CopiesAvailable", "ISBN", "Title" },
                values: new object[,]
                {
                    { "1", "Ramesh Menon", 8, 25, "978-8129115356", "The Mahabharata" },
                    { "2", "Ramesh Menon", 10, 30, "978-0312428032", "The Ramayana: A Modern Retelling" },
                    { "3", "Ranjit Desai", 15, 20, "978-8172241215", "Shivaji: The Great Maratha" },
                    { "4", "Ranjit Desai", 12, 25, "978-8177667843", "Swami" },
                    { "5", "Ranjit Desai", 8, 45, "978-8177661018", "Radheya" },
                    { "6", " V. P. Kale", 55, 35, "978-8184981073", "Partner" },
                    { "7", " V. P. Kale", 16, 15, "978-8177665153", "Vapurza" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
