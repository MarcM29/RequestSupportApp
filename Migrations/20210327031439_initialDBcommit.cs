using Microsoft.EntityFrameworkCore.Migrations;

namespace RequestSupportApp.Migrations
{
    public partial class initialDBcommit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(nullable: true),
                    DepartmentName = table.Column<string>(nullable: true),
                    EmployeeName = table.Column<string>(nullable: true),
                    ProjectDesc = table.Column<string>(nullable: true),
                    TicketDate = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ticket");
        }
    }
}
