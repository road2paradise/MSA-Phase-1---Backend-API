using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentSIMS.Migrations
{
    public partial class alterModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Address_studentId",
                table: "Address",
                column: "studentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Student_studentId",
                table: "Address",
                column: "studentId",
                principalTable: "Student",
                principalColumn: "studentId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Student_studentId",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Address_studentId",
                table: "Address");
        }
    }
}
