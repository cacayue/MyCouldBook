using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyCouldBook.Migrations
{
    public partial class AddGenerateookEntity_Migration4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookListAndBooks",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    BookListId = table.Column<long>(nullable: false),
                    BookId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookListAndBooks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookListAndBooks_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookListAndBooks_BookLists_BookListId",
                        column: x => x.BookListId,
                        principalTable: "BookLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookListAndBooks_BookId",
                table: "BookListAndBooks",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookListAndBooks_BookListId",
                table: "BookListAndBooks",
                column: "BookListId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookListAndBooks");
        }
    }
}
