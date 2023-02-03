using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BE_CRUDPhonebook.Migrations
{
    public partial class v02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Text_Comments",
                table: "Phonebook",
                newName: "TextComments");

            migrationBuilder.RenameColumn(
                name: "Phone_Number",
                table: "Phonebook",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "Last_Name",
                table: "Phonebook",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "First_Name",
                table: "Phonebook",
                newName: "FirstName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TextComments",
                table: "Phonebook",
                newName: "Text_Comments");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Phonebook",
                newName: "Phone_Number");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Phonebook",
                newName: "Last_Name");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Phonebook",
                newName: "First_Name");
        }
    }
}
