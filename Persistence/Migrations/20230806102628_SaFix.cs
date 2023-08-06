using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SaFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ef95714c-0958-4770-99e6-91bf2f2aad68",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "3d5c6747-d498-4664-8030-25f02d3a6364", "SA@BLOGGIE.PL", "SA", "AQAAAAIAAYagAAAAEFEk4iDyjqecJKBx5TVO4FdWKTfO9DgCD6Qc3IeE6P5H/tLOBU26c+D3C0+fAFMYEA==", "35d6dd7f-bebc-4385-aea4-4abaa5a7f681", "sa" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ef95714c-0958-4770-99e6-91bf2f2aad68",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "15e7445b-511e-43e2-921a-891ae60918f4", null, null, "AQAAAAIAAYagAAAAELp3Okhaj49A4UV1Y5v+TXYd/7Xw3wGRu8xI3/2lEKiGUHYgrJZJpoy3Z6BxDjebYA==", "d2f90287-c3a8-4fca-b354-0c1d326b258f", "sa@bloggie.pl" });
        }
    }
}
