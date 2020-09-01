using Microsoft.EntityFrameworkCore.Migrations;

namespace recommender.Migrations.BookRated
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    book_id = table.Column<int>(nullable: false),
                    isbn = table.Column<int>(nullable: false),
                    authors = table.Column<string>(nullable: true),
                    year = table.Column<double>(nullable: false),
                    original_title = table.Column<string>(nullable: true),
                    title = table.Column<string>(nullable: true),
                    language_code = table.Column<string>(nullable: true),
                    average_rating = table.Column<double>(nullable: false),
                    ratings_count = table.Column<double>(nullable: false),
                    image_url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Book");
        }
    }
}
