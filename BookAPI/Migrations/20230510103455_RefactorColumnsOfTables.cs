using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookAPI.Migrations
{
    /// <inheritdoc />
    public partial class RefactorColumnsOfTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FirsName",
                table: "Reviewers",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "FirsName",
                table: "Authors",
                newName: "FirstName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Reviewers",
                newName: "FirsName");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Authors",
                newName: "FirsName");
        }
    }
}
