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
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tag_no = table.Column<string>(nullable: false),
                    user_id = table.Column<int>(nullable: false),
                    area_id = table.Column<int>(nullable: false),
                    upload_id = table.Column<int>(nullable: false),
                    last_date = table.Column<string>(nullable: true),
                    dvr_ob = table.Column<float>(nullable: false),
                    dvr_obv = table.Column<float>(nullable: false),
                    dvr_obh = table.Column<float>(nullable: false),
                    dvr_ib = table.Column<float>(nullable: false),
                    dvr_ibv = table.Column<float>(nullable: false),
                    dvr_ibh = table.Column<float>(nullable: false),
                    dvr_a = table.Column<float>(nullable: false),
                    dvn_ob = table.Column<float>(nullable: false),
                    dvn_obv = table.Column<float>(nullable: false),
                    dvn_obh = table.Column<float>(nullable: false),
                    dvn_ib = table.Column<float>(nullable: false),
                    dvn_ibv = table.Column<float>(nullable: false),
                    dvn_ibh = table.Column<float>(nullable: false),
                    dvn_a = table.Column<float>(nullable: false),
                    dvr_max = table.Column<float>(nullable: false),
                    dvn_max = table.Column<float>(nullable: false),
                    actual_vib = table.Column<float>(nullable: false),
                    max_level = table.Column<string>(nullable: true),
                    position = table.Column<string>(nullable: true),
                    type = table.Column<string>(nullable: true),
                    vib_status = table.Column<string>(nullable: true),
                    acc_status = table.Column<string>(nullable: true),
                    status = table.Column<string>(nullable: true),
                    indikasi = table.Column<string>(nullable: true),
                    remark = table.Column<string>(nullable: true),
                    saran = table.Column<string>(nullable: true),
                    created_at = table.Column<DateTime>(nullable: false),
                    updated_at = table.Column<DateTime>(nullable: false)
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
