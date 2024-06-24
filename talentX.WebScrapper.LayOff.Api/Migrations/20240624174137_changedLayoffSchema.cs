using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace talentX.WebScrapper.LayOff.Api.Migrations
{
    public partial class changedLayoffSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "layoff");

            migrationBuilder.RenameTable(
                name: "ScrapOutputDatas",
                newName: "ScrapOutputDatas",
                newSchema: "layoff");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "ScrapOutputDatas",
                schema: "layoff",
                newName: "ScrapOutputDatas");
        }
    }
}
