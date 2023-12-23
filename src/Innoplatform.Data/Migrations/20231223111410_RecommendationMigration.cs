using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Innoplatform.Data.Migrations
{
    /// <inheritdoc />
    public partial class RecommendationMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RecomedationAreaId",
                table: "Recommendations");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "RecomedationAreaId",
                table: "Recommendations",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
