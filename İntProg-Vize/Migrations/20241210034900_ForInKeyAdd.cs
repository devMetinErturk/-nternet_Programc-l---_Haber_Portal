using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace İntProg_Vize.Migrations
{
    /// <inheritdoc />
    public partial class ForInKeyAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NewsTypeId",
                table: "Haberler",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Haberler_NewsTypeId",
                table: "Haberler",
                column: "NewsTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Haberler_NewsTypes_NewsTypeId",
                table: "Haberler",
                column: "NewsTypeId",
                principalTable: "NewsTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Haberler_NewsTypes_NewsTypeId",
                table: "Haberler");

            migrationBuilder.DropIndex(
                name: "IX_Haberler_NewsTypeId",
                table: "Haberler");

            migrationBuilder.DropColumn(
                name: "NewsTypeId",
                table: "Haberler");
        }
    }
}
