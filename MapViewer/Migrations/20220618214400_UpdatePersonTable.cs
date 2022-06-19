using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MapViewer.Migrations
{
    public partial class UpdatePersonTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "Persons");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Persons",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
