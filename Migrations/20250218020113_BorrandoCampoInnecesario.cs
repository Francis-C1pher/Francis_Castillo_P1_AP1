using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Francis_Castillo_P1_AP1.Migrations
{
    /// <inheritdoc />
    public partial class BorrandoCampoInnecesario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AportesId",
                table: "parcialModelos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AportesId",
                table: "parcialModelos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
