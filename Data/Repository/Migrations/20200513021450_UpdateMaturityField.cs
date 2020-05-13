using Microsoft.EntityFrameworkCore.Migrations;

namespace NetCoreMovies.Data.Repository.Migrations
{
    public partial class UpdateMaturityField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Maturity",
                table: "Movies",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Maturity",
                table: "Movies",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
