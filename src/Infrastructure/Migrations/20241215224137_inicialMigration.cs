using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CDNConverter.Migrations
{
    public partial class inicialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OriginalLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    OriginalLogPath = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OriginalLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConvertedLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    TransformedLogPath = table.Column<string>(nullable: false),
                    OriginalLogId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConvertedLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConvertedLogs_OriginalLogs_OriginalLogId",
                        column: x => x.OriginalLogId,
                        principalTable: "OriginalLogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConvertedLogs_OriginalLogId",
                table: "ConvertedLogs",
                column: "OriginalLogId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConvertedLogs");

            migrationBuilder.DropTable(
                name: "OriginalLogs");
        }
    }
}
