using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace İntProg_Vize.Migrations
{
    /// <inheritdoc />
    public partial class NewsTypesAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Haberler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NewsName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NewsDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NewsPlace = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NewsCountry = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Haberler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NewsTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsTypes", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Haberler");

            migrationBuilder.DropTable(
                name: "NewsTypes");
        }
    }
}
