using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLNS.Migrations
{
    public partial class CreateLuongNhanVienTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LuongNhanVien",
                columns: table => new
                {
                    MaLuong = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaNV = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HSLuong = table.Column<double>(type: "float", nullable: false),
                    LCBan = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LuongNhanVien", x => x.MaLuong);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LuongNhanVien");
        }
    }
}
