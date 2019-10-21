using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EndPoint.Migrations
{
    public partial class ThemeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ThemeID",
                table: "Posts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ThemeModel",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThemeModel", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_ThemeID",
                table: "Posts",
                column: "ThemeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_ThemeModel_ThemeID",
                table: "Posts",
                column: "ThemeID",
                principalTable: "ThemeModel",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_ThemeModel_ThemeID",
                table: "Posts");

            migrationBuilder.DropTable(
                name: "ThemeModel");

            migrationBuilder.DropIndex(
                name: "IX_Posts_ThemeID",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "ThemeID",
                table: "Posts");
        }
    }
}
