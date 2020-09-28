using Microsoft.EntityFrameworkCore.Migrations;

namespace recommender.Migrations
{
    public partial class existingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    book_id = table.Column<int>(nullable: false),
                    isbn = table.Column<int>(nullable: false),
                    authors = table.Column<string>(nullable: true),
                    year = table.Column<double>(nullable: false),
                    original_title = table.Column<string>(nullable: true),
                    title = table.Column<string>(nullable: true),
                    language_code = table.Column<string>(nullable: true),
                    average_rating = table.Column<double>(nullable: false),
                    ratings_count = table.Column<double>(nullable: false),
                    image_url = table.Column<string>(nullable: true),
                    rating = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    book_id = table.Column<int>(nullable: false),
                    user_id = table.Column<int>(nullable: false),
                    rating_ = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Ratings");
        }
    }
}
