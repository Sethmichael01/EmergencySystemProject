using Microsoft.EntityFrameworkCore.Migrations;

namespace MOBILE_BASED.DAL.Migrations
{
    public partial class stafflocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "StaffAltitude",
                table: "EmergencyRequests",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "StaffLatitude",
                table: "EmergencyRequests",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "StaffLongitude",
                table: "EmergencyRequests",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StaffAltitude",
                table: "EmergencyRequests");

            migrationBuilder.DropColumn(
                name: "StaffLatitude",
                table: "EmergencyRequests");

            migrationBuilder.DropColumn(
                name: "StaffLongitude",
                table: "EmergencyRequests");
        }
    }
}
