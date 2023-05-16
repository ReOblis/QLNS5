using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLNS.Migrations
{
    public partial class CreateChucVuTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChucVu",
                columns: table => new
                {
                    MaChucVu = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenChucVu = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChucVu", x => x.MaChucVu);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChucVu");
        }
    }
}
