using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pweb_kilme_.Migrations
{
    /// <inheritdoc />
    public partial class AddNombreToQuintum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                schema: "pwebdb",
                table: "quinta",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nombre",
                schema: "pwebdb",
                table: "quinta");
        }
    }
}
