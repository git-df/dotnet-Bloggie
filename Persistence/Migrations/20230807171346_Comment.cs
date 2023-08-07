using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Comment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "blogPostComments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BlogPostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_blogPostComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_blogPostComments_BlogPosts_BlogPostId",
                        column: x => x.BlogPostId,
                        principalTable: "BlogPosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ef95714c-0958-4770-99e6-91bf2f2aad68",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9da32f1d-bc05-4b63-9330-bf5440f70c38", "AQAAAAIAAYagAAAAEIx2ZfugbFHN280s2rK+hnn6JWeJSpbAjJFbd2LqXA8NG63dnAWGwapHVRScZmuxZQ==", "5f74d71a-3a13-4774-a116-4bf1a90f5268" });

            migrationBuilder.CreateIndex(
                name: "IX_blogPostComments_BlogPostId",
                table: "blogPostComments",
                column: "BlogPostId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "blogPostComments");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ef95714c-0958-4770-99e6-91bf2f2aad68",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "89b0c59a-7b5c-4a13-9ce4-54d6903d17cd", "AQAAAAIAAYagAAAAEKJzQUBB1pFbPRukN4nMl+xxkNwGvnF/j1Y74sXOE7Lba7VGNEBKHoSkXKVzel0b7A==", "211da57e-51ef-42eb-b412-6c58193a3b3d" });
        }
    }
}
