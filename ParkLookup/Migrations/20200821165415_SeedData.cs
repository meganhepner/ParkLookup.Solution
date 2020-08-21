using Microsoft.EntityFrameworkCore.Migrations;

namespace ParkLookup.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "NationalParks",
                columns: new[] { "NationalParkId", "NationalParkCamping", "NationalParkFishing", "NationalParkHighlight", "NationalParkHiking", "NationalParkName", "NationalParkState" },
                values: new object[,]
                {
                    { 1, true, true, "largest mountain in AK", true, "Denali", "Alaska" },
                    { 2, true, true, "lodges, big trees", true, "Olympic", "Washington" },
                    { 3, true, false, "lake", false, "Crater Lake", "Oregon" },
                    { 4, true, false, "volcano", true, "Mt St Helens", "Washington" },
                    { 5, true, false, "geothermal", true, "Yellowstone National Park", "Idaho" }
                });

            migrationBuilder.InsertData(
                table: "StateParks",
                columns: new[] { "StateParkId", "StateParkCamping", "StateParkFishing", "StateParkHighlight", "StateParkHiking", "StateParkName", "StateParkState" },
                values: new object[,]
                {
                    { 1, true, true, "grizzly bears", true, "Chugach", "Alaska" },
                    { 2, true, false, "waterfalls", true, "Silver Falls", "Oregon" },
                    { 3, true, true, "geothermal", false, "Harriman", "Idaho" },
                    { 4, true, true, "military bunker", false, "Fort Flagler", "Washington" },
                    { 5, true, false, "climbing", true, "Smith Rock", "Oregon" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "NationalParks",
                keyColumn: "NationalParkId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "NationalParks",
                keyColumn: "NationalParkId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "NationalParks",
                keyColumn: "NationalParkId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "NationalParks",
                keyColumn: "NationalParkId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "NationalParks",
                keyColumn: "NationalParkId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "StateParks",
                keyColumn: "StateParkId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "StateParks",
                keyColumn: "StateParkId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "StateParks",
                keyColumn: "StateParkId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "StateParks",
                keyColumn: "StateParkId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "StateParks",
                keyColumn: "StateParkId",
                keyValue: 5);
        }
    }
}
