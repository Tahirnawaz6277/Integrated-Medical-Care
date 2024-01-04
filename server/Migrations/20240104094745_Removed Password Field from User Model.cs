using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IMC_Integrated_Medical_Care_.Migrations
{
    /// <inheritdoc />
    public partial class RemovedPasswordFieldfromUserModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "password",
                table: "AspNetUsers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "password",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
