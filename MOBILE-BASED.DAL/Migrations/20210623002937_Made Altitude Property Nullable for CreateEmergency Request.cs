using Microsoft.EntityFrameworkCore.Migrations;

namespace MOBILE_BASED.DAL.Migrations
{
    public partial class MadeAltitudePropertyNullableforCreateEmergencyRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Altitude",
                table: "EmergencyRequests",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Altitude",
                table: "EmergencyRequests",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);
        }
    }
}
