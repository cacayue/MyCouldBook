using Microsoft.EntityFrameworkCore.Migrations;

namespace MyCouldBook.Migrations
{
    public partial class AddGenerateookEntity_Migration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookAndBookTags",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<long>(nullable: false),
                    TagId = table.Column<long>(nullable: false),
                    BookTagId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookAndBookTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookAndBookTags_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookAndBookTags_BookTags_BookTagId",
                        column: x => x.BookTagId,
                        principalTable: "BookTags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookAndBookTags_BookId",
                table: "BookAndBookTags",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookAndBookTags_BookTagId",
                table: "BookAndBookTags",
                column: "BookTagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookAndBookTags");
        }
    }
}
