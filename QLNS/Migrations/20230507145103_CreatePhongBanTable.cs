using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLNS.Migrations
{
    public partial class CreatePhongBanTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
               name: "PhongBan",
               columns: table => new
               {
                   MaPB = table.Column<string>(type: "nvarchar(450)", nullable: false),
                   TenPB = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: false)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_PhongBan", x => x.MaPB);
               });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhongBan");
        }
    }
}
