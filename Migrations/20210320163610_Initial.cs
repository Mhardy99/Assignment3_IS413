using Microsoft.EntityFrameworkCore.Migrations;

namespace Assignment3_IS413.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "movieResponses",
                columns: table => new
                {
                    MovieID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Category = table.Column<string>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    YearReleased = table.Column<int>(type: "INTEGER", nullable: false),
                    DirectorName = table.Column<string>(type: "TEXT", nullable: false),
                    MovieRating = table.Column<string>(type: "TEXT", nullable: false),
                    IsEdited = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsLentTo = table.Column<string>(type: "TEXT", nullable: true),
                    Notes = table.Column<string>(type: "TEXT", maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movieResponses", x => x.MovieID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "movieResponses");
        }
    }
}
