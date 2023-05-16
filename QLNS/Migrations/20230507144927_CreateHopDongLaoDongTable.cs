using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLNS.Migrations
{
    public partial class CreateHopDongLaoDongTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HopDongLaoDong",
                columns: table => new
                {
                    MaHDLD = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaNV = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoaiHDLD = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThoiHan = table.Column<double>(type: "nvarchar(max)", nullable: false),
                    DiaDiemLamViec = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaLuong = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhuCap = table.Column<double>(type: "nvarchar(max)", nullable: false),
                    ChucVu = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HopDongLaoDong", x => x.MaHDLD);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HopDongLaoDong");
        }
    }
}
