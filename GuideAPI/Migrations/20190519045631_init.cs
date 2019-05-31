using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GuideAPI.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StyleSheet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StyleSheet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ColorPalette",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 10, nullable: true),
                    Description = table.Column<string>(maxLength: 15, nullable: true),
                    Color = table.Column<string>(nullable: true),
                    StyleSheetId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColorPalette", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ColorPalette_StyleSheet_StyleSheetId",
                        column: x => x.StyleSheetId,
                        principalTable: "StyleSheet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Typepography",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Typeface = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: true),
                    StyleSheetId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Typepography", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Typepography_StyleSheet_StyleSheetId",
                        column: x => x.StyleSheetId,
                        principalTable: "StyleSheet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ColorPalette_StyleSheetId",
                table: "ColorPalette",
                column: "StyleSheetId");

            migrationBuilder.CreateIndex(
                name: "IX_Typepography_StyleSheetId",
                table: "Typepography",
                column: "StyleSheetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ColorPalette");

            migrationBuilder.DropTable(
                name: "Typepography");

            migrationBuilder.DropTable(
                name: "StyleSheet");
        }
    }
}
