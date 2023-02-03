using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BE_CRUDPhonebook.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Phonebook",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    First_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Last_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone_Number = table.Column<int>(type: "int", nullable: false),
                    Text_Comments = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phonebook", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Phonebook");
        }
    }
}
