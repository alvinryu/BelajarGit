using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class TypoUniveristyId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tb_M_Education_Tb_M_University_Univeristy_Id",
                table: "Tb_M_Education");

            migrationBuilder.RenameColumn(
                name: "Univeristy_Id",
                table: "Tb_M_Education",
                newName: "University_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Tb_M_Education_Univeristy_Id",
                table: "Tb_M_Education",
                newName: "IX_Tb_M_Education_University_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tb_M_Education_Tb_M_University_University_Id",
                table: "Tb_M_Education",
                column: "University_Id",
                principalTable: "Tb_M_University",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tb_M_Education_Tb_M_University_University_Id",
                table: "Tb_M_Education");

            migrationBuilder.RenameColumn(
                name: "University_Id",
                table: "Tb_M_Education",
                newName: "Univeristy_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Tb_M_Education_University_Id",
                table: "Tb_M_Education",
                newName: "IX_Tb_M_Education_Univeristy_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tb_M_Education_Tb_M_University_Univeristy_Id",
                table: "Tb_M_Education",
                column: "Univeristy_Id",
                principalTable: "Tb_M_University",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
