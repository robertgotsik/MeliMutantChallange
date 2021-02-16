using Microsoft.EntityFrameworkCore.Migrations;

namespace MeliMutantChallange.Migrations
{
    public partial class newMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Adns",
                table: "Adns");

            migrationBuilder.RenameTable(
                name: "Adns",
                newName: "Adn");

            migrationBuilder.RenameColumn(
                name: "dna",
                table: "Adn",
                newName: "dnaPersisted");

            migrationBuilder.AlterColumn<short>(
                name: "type",
                table: "Adn",
                type: "smallint",
                nullable: true,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Adn",
                table: "Adn",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Adn",
                table: "Adn");

            migrationBuilder.RenameTable(
                name: "Adn",
                newName: "Adns");

            migrationBuilder.RenameColumn(
                name: "dnaPersisted",
                table: "Adns",
                newName: "dna");

            migrationBuilder.AlterColumn<short>(
                name: "type",
                table: "Adns",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0,
                oldClrType: typeof(short),
                oldType: "smallint",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Adns",
                table: "Adns",
                column: "Id");
        }
    }
}
