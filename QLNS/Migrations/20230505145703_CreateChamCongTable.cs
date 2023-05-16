using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLNS.Migrations
{
    public partial class CreateChamCongTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChamCong",
                columns: table => new
                {
                    MaCC = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaNV = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayChamCong = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SoGioLamViec = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChamCong", x => x.MaCC);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChamCong");
        }
    }
}
