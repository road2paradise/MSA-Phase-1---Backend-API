using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentSIMS.Migrations
{
    public partial class AddedFK1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Student_studentId",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Address_studentId",
                table: "Address");

            migrationBuilder.AlterColumn<int>(
                name: "studentId",
                table: "Address",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "studentId",
                table: "Address",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

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
                onDelete: ReferentialAction.Restrict);
        }
    }
}
