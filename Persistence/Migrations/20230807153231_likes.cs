using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class likes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogPostLike_BlogPosts_BlogPostId",
                table: "BlogPostLike");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BlogPostLike",
                table: "BlogPostLike");

            migrationBuilder.RenameTable(
                name: "BlogPostLike",
                newName: "BlogPostLikes");

            migrationBuilder.RenameIndex(
                name: "IX_BlogPostLike_BlogPostId",
                table: "BlogPostLikes",
                newName: "IX_BlogPostLikes_BlogPostId");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "BlogPostLikes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "BlogPostLikes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Updated",
                table: "BlogPostLikes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "BlogPostLikes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BlogPostLikes",
                table: "BlogPostLikes",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ef95714c-0958-4770-99e6-91bf2f2aad68",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "89b0c59a-7b5c-4a13-9ce4-54d6903d17cd", "AQAAAAIAAYagAAAAEKJzQUBB1pFbPRukN4nMl+xxkNwGvnF/j1Y74sXOE7Lba7VGNEBKHoSkXKVzel0b7A==", "211da57e-51ef-42eb-b412-6c58193a3b3d" });

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPostLikes_BlogPosts_BlogPostId",
                table: "BlogPostLikes",
                column: "BlogPostId",
                principalTable: "BlogPosts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogPostLikes_BlogPosts_BlogPostId",
                table: "BlogPostLikes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BlogPostLikes",
                table: "BlogPostLikes");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "BlogPostLikes");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "BlogPostLikes");

            migrationBuilder.DropColumn(
                name: "Updated",
                table: "BlogPostLikes");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "BlogPostLikes");

            migrationBuilder.RenameTable(
                name: "BlogPostLikes",
                newName: "BlogPostLike");

            migrationBuilder.RenameIndex(
                name: "IX_BlogPostLikes_BlogPostId",
                table: "BlogPostLike",
                newName: "IX_BlogPostLike_BlogPostId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BlogPostLike",
                table: "BlogPostLike",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ef95714c-0958-4770-99e6-91bf2f2aad68",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c41390de-f006-4f10-9541-328d3ab44896", "AQAAAAIAAYagAAAAEBoz34a95z77YjNiJOfDKeKypg+0vLix8LRAIMq7tERED/ZY/+PwbXfUXDn3vYiznQ==", "b02cc961-6005-45fa-a358-87638c83298f" });

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPostLike_BlogPosts_BlogPostId",
                table: "BlogPostLike",
                column: "BlogPostId",
                principalTable: "BlogPosts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
