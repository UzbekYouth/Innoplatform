using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Innoplatform.Data.Migrations
{
    /// <inheritdoc />
    public partial class ProjectInvestmentMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IvestmentAreaId",
                table: "ProjectInvestments");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "IvestmentAreaId",
                table: "ProjectInvestments",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
