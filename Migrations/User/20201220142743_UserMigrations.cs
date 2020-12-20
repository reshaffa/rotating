using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace rotating.Migrations.User
{
    public partial class UserMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nip = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "created_at", "email", "name", "nip", "password", "phone", "role", "status", "updated_at" },
                values: new object[] { 1, new DateTime(2020, 12, 20, 0, 0, 0, 0, DateTimeKind.Local), "yulianti@pertamina.com", "Yulianti Eka Prista", 194020001, "tyyyAbbeaMS4FBHCdvUaAC5a6THCA1zAf6rC/jghXtw=", "08821389745", "engineer", 1, new DateTime(2020, 12, 20, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "created_at", "email", "name", "nip", "password", "phone", "role", "status", "updated_at" },
                values: new object[] { 2, new DateTime(2020, 12, 20, 0, 0, 0, 0, DateTimeKind.Local), "pratama@pertamina.com", "Pratama Edi Saputra", 194020002, "tyyyAbbeaMS4FBHCdvUaAC5a6THCA1zAf6rC/jghXtw=", "087985298445", "engineer", 1, new DateTime(2020, 12, 20, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "created_at", "email", "name", "nip", "password", "phone", "role", "status", "updated_at" },
                values: new object[] { 3, new DateTime(2020, 12, 20, 0, 0, 0, 0, DateTimeKind.Local), "safril@pertamina.com", "Safril Sidik", 194020003, "tyyyAbbeaMS4FBHCdvUaAC5a6THCA1zAf6rC/jghXtw=", "088213669701", "admin", 1, new DateTime(2020, 12, 20, 0, 0, 0, 0, DateTimeKind.Local) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
