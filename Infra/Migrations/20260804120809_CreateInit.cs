using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class CreateInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Providers_Categories_CategoryId1",
                table: "Providers");

            migrationBuilder.DropIndex(
                name: "IX_Providers_CategoryId1",
                table: "Providers");

            migrationBuilder.DropColumn(
                name: "CategoryId1",
                table: "Providers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId1",
                table: "Providers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Providers_CategoryId1",
                table: "Providers",
                column: "CategoryId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Providers_Categories_CategoryId1",
                table: "Providers",
                column: "CategoryId1",
                principalTable: "Categories",
                principalColumn: "Id");
        }
    }
}
