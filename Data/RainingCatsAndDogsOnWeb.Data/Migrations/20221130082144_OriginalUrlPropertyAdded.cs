using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RainingCatsAndDogsOnWeb.Data.Migrations
{
    public partial class OriginalUrlPropertyAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OriginalUrl",
                table: "Ads",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OriginalUrl",
                table: "Ads");
        }
    }
}
