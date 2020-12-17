using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace rotating.Migrations.Upload
{
    public partial class UploadMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "uploads",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    filename = table.Column<string>(nullable: false),
                    initial_date = table.Column<DateTime>(nullable: false),
                    last_one = table.Column<int>(nullable: false),
                    last_two = table.Column<int>(nullable: false),
                    last_three = table.Column<int>(nullable: false),
                    created_at = table.Column<DateTime>(nullable: false),
                    updated_at = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_uploads", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "uploads");
        }
    }
}
