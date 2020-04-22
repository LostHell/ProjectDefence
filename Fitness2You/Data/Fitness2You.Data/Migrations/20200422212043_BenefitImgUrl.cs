namespace Fitness2You.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class BenefitImgUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Benefits",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Benefits");
        }
    }
}
