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
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nip = table.Column<int>(nullable: false),
                    name = table.Column<string>(nullable: false),
                    email = table.Column<string>(nullable: false),
                    phone = table.Column<string>(nullable: false),
                    password = table.Column<string>(nullable: false),
                    status = table.Column<int>(nullable: false),
                    role = table.Column<string>(nullable: false),
                    created_at = table.Column<DateTime>(nullable: false),
                    updated_at = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "created_at", "email", "name", "nip", "password", "phone", "role", "status", "updated_at" },
                values: new object[] { 1, new DateTime(2020, 12, 17, 0, 0, 0, 0, DateTimeKind.Local), "yulianti@pertamina.com", "Yulianti Eka Prista", 194020001, "7cUDtt084TSg1vUyltg+xJHXaa+ZQvxJgGKMIZ7cvaA=", "08821389745", "engineer", 1, new DateTime(2020, 12, 17, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "created_at", "email", "name", "nip", "password", "phone", "role", "status", "updated_at" },
                values: new object[] { 2, new DateTime(2020, 12, 17, 0, 0, 0, 0, DateTimeKind.Local), "pratama@pertamina.com", "Pratama Edi Saputra", 194020002, "7cUDtt084TSg1vUyltg+xJHXaa+ZQvxJgGKMIZ7cvaA=", "087985298445", "engineer", 1, new DateTime(2020, 12, 17, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "created_at", "email", "name", "nip", "password", "phone", "role", "status", "updated_at" },
                values: new object[] { 3, new DateTime(2020, 12, 17, 0, 0, 0, 0, DateTimeKind.Local), "safril@pertamina.com", "Safril Sidik", 194020003, "7cUDtt084TSg1vUyltg+xJHXaa+ZQvxJgGKMIZ7cvaA=", "088213669701", "admin", 1, new DateTime(2020, 12, 17, 0, 0, 0, 0, DateTimeKind.Local) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
