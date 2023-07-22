using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Firma.Migrations
{
    /// <inheritdoc />
    public partial class allowNullLegalNature : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_company_legal_nature_legal_nature_id",
                table: "company");

            migrationBuilder.AlterColumn<int>(
                name: "legal_nature_id",
                table: "company",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "fk_company_legal_nature_legal_nature_id",
                table: "company",
                column: "legal_nature_id",
                principalTable: "legal_nature",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_company_legal_nature_legal_nature_id",
                table: "company");

            migrationBuilder.AlterColumn<int>(
                name: "legal_nature_id",
                table: "company",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "fk_company_legal_nature_legal_nature_id",
                table: "company",
                column: "legal_nature_id",
                principalTable: "legal_nature",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
