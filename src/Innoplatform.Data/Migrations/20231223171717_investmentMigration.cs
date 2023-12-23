using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Innoplatform.Data.Migrations
{
    /// <inheritdoc />
    public partial class investmentMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationProjectInvestments_Investments_InvestmentId",
                table: "OrganizationProjectInvestments");

            migrationBuilder.DropIndex(
                name: "IX_OrganizationProjectInvestments_InvestmentId",
                table: "OrganizationProjectInvestments");

            migrationBuilder.DropColumn(
                name: "InvestmentId",
                table: "OrganizationProjectInvestments");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationProjectInvestments_InvestmentAreaId",
                table: "OrganizationProjectInvestments",
                column: "InvestmentAreaId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationProjectInvestments_InvestmentAreas_InvestmentAr~",
                table: "OrganizationProjectInvestments",
                column: "InvestmentAreaId",
                principalTable: "InvestmentAreas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationProjectInvestments_InvestmentAreas_InvestmentAr~",
                table: "OrganizationProjectInvestments");

            migrationBuilder.DropIndex(
                name: "IX_OrganizationProjectInvestments_InvestmentAreaId",
                table: "OrganizationProjectInvestments");

            migrationBuilder.AddColumn<long>(
                name: "InvestmentId",
                table: "OrganizationProjectInvestments",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationProjectInvestments_InvestmentId",
                table: "OrganizationProjectInvestments",
                column: "InvestmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationProjectInvestments_Investments_InvestmentId",
                table: "OrganizationProjectInvestments",
                column: "InvestmentId",
                principalTable: "Investments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
