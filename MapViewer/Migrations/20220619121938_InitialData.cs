using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MapViewer.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Places",
                columns: new[] { "ID", "Latitude", "Longitude", "Text" },
                values: new object[,]
                {
                    { 1, 55.752307999999999, 37.610489000000001, "Библиотека имени Ленина" },
                    { 2, 55.75226, 37.608643999999998, "Александровский сад" },
                    { 3, 55.750509000000001, 37.609073000000002, "Боровицкая" },
                    { 4, 55.755451000000001, 37.619326999999998, "Казанский собор" },
                    { 5, 55.749679, 37.608711, "Дом Пашкова" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "ID",
                keyValue: 5);
        }
    }
}
