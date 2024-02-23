using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Mission06_Yoon.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoryTable",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Category = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryTable", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "MoviesAdded",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Year = table.Column<int>(type: "INTEGER", nullable: false),
                    Director = table.Column<string>(type: "TEXT", nullable: false),
                    Rating = table.Column<string>(type: "TEXT", nullable: false),
                    Edited = table.Column<bool>(type: "INTEGER", nullable: false),
                    Lent_To = table.Column<string>(type: "TEXT", nullable: true),
                    CopiedToPlex = table.Column<bool>(type: "INTEGER", nullable: false),
                    Notes = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoviesAdded", x => x.MovieId);
                    table.ForeignKey(
                        name: "FK_MoviesAdded_CategoryTable_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "CategoryTable",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CategoryTable",
                columns: new[] { "CategoryId", "Category" },
                values: new object[,]
                {
                    { 1, "Miscellaneous" },
                    { 2, "Drama" },
                    { 3, "Magic" },
                    { 4, "Television" },
                    { 5, "Horror/Suspense" },
                    { 6, "Comedy" },
                    { 7, "Family" },
                    { 8, "Action/Adventure" },
                    { 9, "VHS" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MoviesAdded_CategoryId",
                table: "MoviesAdded",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MoviesAdded");

            migrationBuilder.DropTable(
                name: "CategoryTable");
        }
    }
}
