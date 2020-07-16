using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentSIMS.Migrations
{
    public partial class b : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    addressID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    streetNumber = table.Column<int>(nullable: false),
                    street = table.Column<string>(nullable: true),
                    suburb = table.Column<string>(nullable: true),
                    city = table.Column<string>(nullable: true),
                    postcode = table.Column<int>(nullable: false),
                    studentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.addressID);
                    table.ForeignKey(
                        name: "FK_Address_Student_studentId",
                        column: x => x.studentId,
                        principalTable: "Student",
                        principalColumn: "studentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_studentId",
                table: "Address",
                column: "studentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");
        }
    }
}
