using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace rotating.Migrations.Area
{
    public partial class AreaMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "areas",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    area_type = table.Column<int>(nullable: false),
                    name = table.Column<string>(nullable: false),
                    created_at = table.Column<DateTime>(nullable: false),
                    updated_at = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_areas", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "areas",
                columns: new[] { "id", "area_type", "created_at", "name", "updated_at" },
                values: new object[,]
                {
                    { 1, 0, new DateTime(2020, 12, 17, 0, 0, 0, 0, DateTimeKind.Local), "FOC I", new DateTime(2020, 12, 17, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 32, 0, new DateTime(2020, 12, 17, 0, 0, 0, 0, DateTimeKind.Local), "PLBC FOC I", new DateTime(2020, 12, 17, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 31, 0, new DateTime(2020, 12, 17, 0, 0, 0, 0, DateTimeKind.Local), "PLBC UTL III", new DateTime(2020, 12, 17, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 30, 0, new DateTime(2020, 12, 17, 0, 0, 0, 0, DateTimeKind.Local), "SRU & IPAL", new DateTime(2020, 12, 17, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 29, 0, new DateTime(2020, 12, 17, 0, 0, 0, 0, DateTimeKind.Local), "RFCC LEU", new DateTime(2020, 12, 17, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 28, 0, new DateTime(2020, 12, 17, 0, 0, 0, 0, DateTimeKind.Local), "RFCC RCU", new DateTime(2020, 12, 17, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 27, 0, new DateTime(2020, 12, 17, 0, 0, 0, 0, DateTimeKind.Local), "RFCC UTL", new DateTime(2020, 12, 17, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 26, 0, new DateTime(2020, 12, 17, 0, 0, 0, 0, DateTimeKind.Local), "RFCC GTO", new DateTime(2020, 12, 17, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 25, 0, new DateTime(2020, 12, 17, 0, 0, 0, 0, DateTimeKind.Local), "OM", new DateTime(2020, 12, 17, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 24, 0, new DateTime(2020, 12, 17, 0, 0, 0, 0, DateTimeKind.Local), "UTL II", new DateTime(2020, 12, 17, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 23, 0, new DateTime(2020, 12, 17, 0, 0, 0, 0, DateTimeKind.Local), "OM LOC III", new DateTime(2020, 12, 17, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 22, 0, new DateTime(2020, 12, 17, 0, 0, 0, 0, DateTimeKind.Local), "FOC II B", new DateTime(2020, 12, 17, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 21, 0, new DateTime(2020, 12, 17, 0, 0, 0, 0, DateTimeKind.Local), "FOC II A", new DateTime(2020, 12, 17, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 20, 0, new DateTime(2020, 12, 17, 0, 0, 0, 0, DateTimeKind.Local), "AREA 05", new DateTime(2020, 12, 17, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 19, 0, new DateTime(2020, 12, 17, 0, 0, 0, 0, DateTimeKind.Local), "LOC II", new DateTime(2020, 12, 17, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 18, 0, new DateTime(2020, 12, 17, 0, 0, 0, 0, DateTimeKind.Local), "UTL III", new DateTime(2020, 12, 17, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 17, 0, new DateTime(2020, 12, 17, 0, 0, 0, 0, DateTimeKind.Local), "LOC III", new DateTime(2020, 12, 17, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 16, 0, new DateTime(2020, 12, 17, 0, 0, 0, 0, DateTimeKind.Local), "SRU", new DateTime(2020, 12, 17, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 2, 0, new DateTime(2020, 12, 17, 0, 0, 0, 0, DateTimeKind.Local), "LOC I", new DateTime(2020, 12, 17, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 3, 0, new DateTime(2020, 12, 17, 0, 0, 0, 0, DateTimeKind.Local), "OM 30", new DateTime(2020, 12, 17, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 4, 0, new DateTime(2020, 12, 17, 0, 0, 0, 0, DateTimeKind.Local), "OM KPC", new DateTime(2020, 12, 17, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 5, 0, new DateTime(2020, 12, 17, 0, 0, 0, 0, DateTimeKind.Local), "OM LOC II", new DateTime(2020, 12, 17, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 6, 0, new DateTime(2020, 12, 17, 0, 0, 0, 0, DateTimeKind.Local), "OM LOC I", new DateTime(2020, 12, 17, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 7, 0, new DateTime(2020, 12, 17, 0, 0, 0, 0, DateTimeKind.Local), "OM FOC I", new DateTime(2020, 12, 17, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 33, 0, new DateTime(2020, 12, 17, 0, 0, 0, 0, DateTimeKind.Local), "PLBC LN", new DateTime(2020, 12, 17, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 8, 0, new DateTime(2020, 12, 17, 0, 0, 0, 0, DateTimeKind.Local), "OM LPG", new DateTime(2020, 12, 17, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 10, 0, new DateTime(2020, 12, 17, 0, 0, 0, 0, DateTimeKind.Local), "OM DRUM PLAN", new DateTime(2020, 12, 17, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 11, 0, new DateTime(2020, 12, 17, 0, 0, 0, 0, DateTimeKind.Local), "UTL I", new DateTime(2020, 12, 17, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 12, 0, new DateTime(2020, 12, 17, 0, 0, 0, 0, DateTimeKind.Local), "OM DERMAGA", new DateTime(2020, 12, 17, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 13, 0, new DateTime(2020, 12, 17, 0, 0, 0, 0, DateTimeKind.Local), "OM UTL I", new DateTime(2020, 12, 17, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 14, 0, new DateTime(2020, 12, 17, 0, 0, 0, 0, DateTimeKind.Local), "OM TELUK PENYU", new DateTime(2020, 12, 17, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 15, 0, new DateTime(2020, 12, 17, 0, 0, 0, 0, DateTimeKind.Local), "KPC", new DateTime(2020, 12, 17, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 9, 0, new DateTime(2020, 12, 17, 0, 0, 0, 0, DateTimeKind.Local), "OM FOC II", new DateTime(2020, 12, 17, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 34, 0, new DateTime(2020, 12, 17, 0, 0, 0, 0, DateTimeKind.Local), "OM DERMAGA PLBC", new DateTime(2020, 12, 17, 0, 0, 0, 0, DateTimeKind.Local) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "areas");
        }
    }
}
