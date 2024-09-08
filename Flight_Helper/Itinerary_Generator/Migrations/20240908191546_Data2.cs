using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Itinerary_Generator.Migrations
{
    /// <inheritdoc />
    public partial class Data2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_LookupTypes_lookupTypesID",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_preferences_LookupTypes_lookupTypesID",
                table: "preferences");

            migrationBuilder.DropForeignKey(
                name: "FK_Transports_LookupTypes_lookupTypesID",
                table: "Transports");

            migrationBuilder.RenameColumn(
                name: "lookupTypesID",
                table: "Transports",
                newName: "LookupTypesID");

            migrationBuilder.RenameIndex(
                name: "IX_Transports_lookupTypesID",
                table: "Transports",
                newName: "IX_Transports_LookupTypesID");

            migrationBuilder.RenameColumn(
                name: "lookupTypesID",
                table: "preferences",
                newName: "LookupTypesID");

            migrationBuilder.RenameIndex(
                name: "IX_preferences_lookupTypesID",
                table: "preferences",
                newName: "IX_preferences_LookupTypesID");

            migrationBuilder.RenameColumn(
                name: "lookupTypesID",
                table: "Activities",
                newName: "LookupTypesID");

            migrationBuilder.RenameIndex(
                name: "IX_Activities_lookupTypesID",
                table: "Activities",
                newName: "IX_Activities_LookupTypesID");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_LookupTypes_LookupTypesID",
                table: "Activities",
                column: "LookupTypesID",
                principalTable: "LookupTypes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_preferences_LookupTypes_LookupTypesID",
                table: "preferences",
                column: "LookupTypesID",
                principalTable: "LookupTypes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transports_LookupTypes_LookupTypesID",
                table: "Transports",
                column: "LookupTypesID",
                principalTable: "LookupTypes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_LookupTypes_LookupTypesID",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_preferences_LookupTypes_LookupTypesID",
                table: "preferences");

            migrationBuilder.DropForeignKey(
                name: "FK_Transports_LookupTypes_LookupTypesID",
                table: "Transports");

            migrationBuilder.RenameColumn(
                name: "LookupTypesID",
                table: "Transports",
                newName: "lookupTypesID");

            migrationBuilder.RenameIndex(
                name: "IX_Transports_LookupTypesID",
                table: "Transports",
                newName: "IX_Transports_lookupTypesID");

            migrationBuilder.RenameColumn(
                name: "LookupTypesID",
                table: "preferences",
                newName: "lookupTypesID");

            migrationBuilder.RenameIndex(
                name: "IX_preferences_LookupTypesID",
                table: "preferences",
                newName: "IX_preferences_lookupTypesID");

            migrationBuilder.RenameColumn(
                name: "LookupTypesID",
                table: "Activities",
                newName: "lookupTypesID");

            migrationBuilder.RenameIndex(
                name: "IX_Activities_LookupTypesID",
                table: "Activities",
                newName: "IX_Activities_lookupTypesID");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_LookupTypes_lookupTypesID",
                table: "Activities",
                column: "lookupTypesID",
                principalTable: "LookupTypes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_preferences_LookupTypes_lookupTypesID",
                table: "preferences",
                column: "lookupTypesID",
                principalTable: "LookupTypes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transports_LookupTypes_lookupTypesID",
                table: "Transports",
                column: "lookupTypesID",
                principalTable: "LookupTypes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
