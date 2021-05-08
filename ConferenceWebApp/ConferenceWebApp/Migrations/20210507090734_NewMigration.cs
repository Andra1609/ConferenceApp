using Microsoft.EntityFrameworkCore.Migrations;

namespace ConferenceWebApp.Migrations
{
    public partial class NewMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sponsors_Conferences_ConferenceID",
                table: "Sponsors");

            migrationBuilder.DropIndex(
                name: "IX_Sponsors_ConferenceID",
                table: "Sponsors");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Sponsors_ConferenceID",
                table: "Sponsors",
                column: "ConferenceID");

            migrationBuilder.AddForeignKey(
                name: "FK_Sponsors_Conferences_ConferenceID",
                table: "Sponsors",
                column: "ConferenceID",
                principalTable: "Conferences",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
