using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InterviewTask.Migrations
{
    public partial class AddedNamesOfTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AreaName",
                table: "Item",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EntityTypeName",
                table: "Item",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RegionName",
                table: "Item",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VillageName",
                table: "Item",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WillayaName",
                table: "Item",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AreaName",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "EntityTypeName",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "RegionName",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "VillageName",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "WillayaName",
                table: "Item");
        }
    }
}
