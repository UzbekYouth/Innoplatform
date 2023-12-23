using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Innoplatform.Data.Migrations
{
    /// <inheritdoc />
    public partial class AboutUsAssetMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AbouteUsId",
                table: "AboutUsAssets");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "AbouteUsId",
                table: "AboutUsAssets",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
