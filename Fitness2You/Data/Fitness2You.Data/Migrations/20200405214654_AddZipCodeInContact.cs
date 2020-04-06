namespace Fitness2You.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddZipCodeInContact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ZipCode",
                table: "Contacts",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "Contacts");
        }
    }
}
