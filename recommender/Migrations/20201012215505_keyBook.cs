using Microsoft.EntityFrameworkCore.Migrations;

namespace recommender.Migrations
{
    public partial class keyBook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "Books",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Books",
                table: "Books",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Books",
                table: "Books");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "Books",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("Sqlite:Autoincrement", true);
        }
    }
}
