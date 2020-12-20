using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace rotating.Migrations.Vibration
{
    public partial class VibrationMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "vibrations",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tag_no = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    area_id = table.Column<int>(type: "int", nullable: false),
                    upload_id = table.Column<int>(type: "int", nullable: false),
                    last_date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dvr_ob = table.Column<float>(type: "real", nullable: false),
                    dvr_obv = table.Column<float>(type: "real", nullable: false),
                    dvr_obh = table.Column<float>(type: "real", nullable: false),
                    dvr_ib = table.Column<float>(type: "real", nullable: false),
                    dvr_ibv = table.Column<float>(type: "real", nullable: false),
                    dvr_ibh = table.Column<float>(type: "real", nullable: false),
                    dvr_a = table.Column<float>(type: "real", nullable: false),
                    dvn_ob = table.Column<float>(type: "real", nullable: false),
                    dvn_obv = table.Column<float>(type: "real", nullable: false),
                    dvn_obh = table.Column<float>(type: "real", nullable: false),
                    dvn_ib = table.Column<float>(type: "real", nullable: false),
                    dvn_ibv = table.Column<float>(type: "real", nullable: false),
                    dvn_ibh = table.Column<float>(type: "real", nullable: false),
                    dvn_a = table.Column<float>(type: "real", nullable: false),
                    dvr_max = table.Column<float>(type: "real", nullable: false),
                    dvn_max = table.Column<float>(type: "real", nullable: false),
                    actual_vib = table.Column<float>(type: "real", nullable: false),
                    max_level = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    position = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    vib_status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    acc_status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    indikasi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    remark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    saran = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vibrations", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "vibrations");
        }
    }
}
