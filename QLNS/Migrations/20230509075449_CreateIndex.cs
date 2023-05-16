using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLNS.Migrations
{
    public partial class CreateIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MaHDLD",
                table: "NhanVien",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_NhanVien_MaHDLD",
                table: "NhanVien",
                column: "MaHDLD");

            migrationBuilder.AddForeignKey(
                name: "FK_NhanVien_HopDongLaoDong_MaHDLD",
                table: "NhanVien",
                column: "MaHDLD",
                principalTable: "HopDongLaoDong",
                principalColumn: "MaHDLD",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NhanVien_HopDongLaoDong_MaHDLD",
                table: "NhanVien");

            migrationBuilder.DropIndex(
                name: "IX_NhanVien_MaHDLD",
                table: "NhanVien");

            migrationBuilder.DropColumn(
                name: "MaHDLD",
                table: "NhanVien");
        }
    }
}
