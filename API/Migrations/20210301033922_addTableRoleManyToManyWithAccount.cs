using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class addTableRoleManyToManyWithAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tb_M_Role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_M_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tb_M_RoleAccount",
                columns: table => new
                {
                    Role_Id = table.Column<int>(type: "int", nullable: false),
                    Account_NIK = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_M_RoleAccount", x => new { x.Role_Id, x.Account_NIK });
                    table.ForeignKey(
                        name: "FK_Tb_M_RoleAccount_Tb_M_Account_Account_NIK",
                        column: x => x.Account_NIK,
                        principalTable: "Tb_M_Account",
                        principalColumn: "NIK",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tb_M_RoleAccount_Tb_M_Role_Role_Id",
                        column: x => x.Role_Id,
                        principalTable: "Tb_M_Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tb_M_RoleAccount_Account_NIK",
                table: "Tb_M_RoleAccount",
                column: "Account_NIK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tb_M_RoleAccount");

            migrationBuilder.DropTable(
                name: "Tb_M_Role");
        }
    }
}
