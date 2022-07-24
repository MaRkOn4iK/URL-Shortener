using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Data.Migrations
{
    public partial class changeAppUserIdFromIntToStringInUrlModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UrlModels_AspNetUsers_ApplicationUserId1",
                table: "UrlModels");

            migrationBuilder.DropIndex(
                name: "IX_UrlModels_ApplicationUserId1",
                table: "UrlModels");


            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "UrlModels");


            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "UrlModels",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_UrlModels_ApplicationUserId",
                table: "UrlModels",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UrlModels_AspNetUsers_ApplicationUserId",
                table: "UrlModels",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UrlModels_AspNetUsers_ApplicationUserId",
                table: "UrlModels");

            migrationBuilder.DropIndex(
                name: "IX_UrlModels_ApplicationUserId",
                table: "UrlModels");

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationUserId",
                table: "UrlModels",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "UrlModels",
                type: "nvarchar(450)",
                nullable: true);



            migrationBuilder.CreateIndex(
                name: "IX_UrlModels_ApplicationUserId1",
                table: "UrlModels",
                column: "ApplicationUserId1");



            migrationBuilder.AddForeignKey(
                name: "FK_UrlModels_AspNetUsers_ApplicationUserId1",
                table: "UrlModels",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
