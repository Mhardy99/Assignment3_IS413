using Microsoft.EntityFrameworkCore.Migrations;

namespace Assignment3_IS413.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "movieResponses",
                columns: table => new
                {
                    MovieID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Category = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    YearReleased = table.Column<int>(nullable: false),
                    DirectorName = table.Column<string>(nullable: false),
                    MovieRating = table.Column<string>(nullable: false),
                    IsEdited = table.Column<bool>(nullable: false),
                    IsLentTo = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(maxLength: 25, nullable: true)
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
