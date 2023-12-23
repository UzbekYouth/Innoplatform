using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Innoplatform.Data.Migrations
{
    /// <inheritdoc />
    public partial class SaltMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Hash",
                table: "Users",
                newName: "Salt");

            migrationBuilder.RenameColumn(
                name: "Hash",
                table: "Organizations",
                newName: "Salt");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Salt",
                table: "Users",
                newName: "Hash");

            migrationBuilder.RenameColumn(
                name: "Salt",
                table: "Organizations",
                newName: "Hash");
        }
    }
}
