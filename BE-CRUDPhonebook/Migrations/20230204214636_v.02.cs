using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BECRUDPhonebook.Migrations
{
    /// <inheritdoc />
    public partial class v02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Phonebook",
                table: "Phonebook");

            migrationBuilder.RenameTable(
                name: "Phonebook",
                newName: "Phonebooks");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Phonebooks",
                table: "Phonebooks",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Phonebooks",
                table: "Phonebooks");

            migrationBuilder.RenameTable(
                name: "Phonebooks",
                newName: "Phonebook");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Phonebook",
                table: "Phonebook",
                column: "Id");
        }
    }
}
