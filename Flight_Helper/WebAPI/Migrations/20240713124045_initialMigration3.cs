using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class initialMigration3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_ActivityType_ActivityTpyeActivityTypeID",
                table: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_Activities_ActivityTpyeActivityTypeID",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "ActivityTpyeActivityTypeID",
                table: "Activities");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_ActivityTypeID",
                table: "Activities",
                column: "ActivityTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_ActivityType_ActivityTypeID",
                table: "Activities",
                column: "ActivityTypeID",
                principalTable: "ActivityType",
                principalColumn: "ActivityTypeID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_ActivityType_ActivityTypeID",
                table: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_Activities_ActivityTypeID",
                table: "Activities");

            migrationBuilder.AddColumn<int>(
                name: "ActivityTpyeActivityTypeID",
                table: "Activities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Activities_ActivityTpyeActivityTypeID",
                table: "Activities",
                column: "ActivityTpyeActivityTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_ActivityType_ActivityTpyeActivityTypeID",
                table: "Activities",
                column: "ActivityTpyeActivityTypeID",
                principalTable: "ActivityType",
                principalColumn: "ActivityTypeID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
