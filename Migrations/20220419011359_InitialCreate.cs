using Microsoft.EntityFrameworkCore.Migrations;

namespace BooksTracker.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Type);
                });

            migrationBuilder.CreateTable(
                name: "CategoryType",
                columns: table => new
                {
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    CategoryTypeCode = table.Column<string>(type: "TEXT", nullable: true),
                    CategoryType = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryType", x => x.Name);
                    table.ForeignKey(
                        name: "FK_CategoryType_Category_CategoryType",
                        column: x => x.CategoryType,
                        principalTable: "Category",
                        principalColumn: "Type",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    ISBN = table.Column<string>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Author = table.Column<string>(type: "TEXT", nullable: false),
                    CategoryTypeName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.ISBN);
                    table.ForeignKey(
                        name: "FK_Book_CategoryType_CategoryTypeName",
                        column: x => x.CategoryTypeName,
                        principalTable: "CategoryType",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_CategoryTypeName",
                table: "Book",
                column: "CategoryTypeName");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryType_CategoryType",
                table: "CategoryType",
                column: "CategoryType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "CategoryType");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
