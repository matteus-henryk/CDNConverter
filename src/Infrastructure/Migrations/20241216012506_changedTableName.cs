using Microsoft.EntityFrameworkCore.Migrations;

namespace CDNConverter.Migrations
{
    public partial class changedTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TransformedLogPath",
                table: "ConvertedLogs",
                newName: "ConvertedLogPath");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ConvertedLogPath",
                table: "ConvertedLogs",
                newName: "TransformedLogPath");
        }
    }
}
