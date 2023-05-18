using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jumbula.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class correctingstudentcolumnnames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastName1",
                table: "Students",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "Gender1",
                table: "Students",
                newName: "Gender");

            migrationBuilder.RenameColumn(
                name: "FirstName1",
                table: "Students",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "DateOfBirth1",
                table: "Students",
                newName: "DateOfBirth");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Students",
                newName: "LastName1");

            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "Students",
                newName: "Gender1");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Students",
                newName: "FirstName1");

            migrationBuilder.RenameColumn(
                name: "DateOfBirth",
                table: "Students",
                newName: "DateOfBirth1");
        }
    }
}
