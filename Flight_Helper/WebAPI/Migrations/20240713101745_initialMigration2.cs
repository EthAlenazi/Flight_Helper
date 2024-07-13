using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class initialMigration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cost",
                table: "Transports");

            migrationBuilder.DropColumn(
                name: "Cost",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Accommodations");

            migrationBuilder.DropColumn(
                name: "Cost",
                table: "Accommodations");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Transports",
                newName: "TransportTypeID");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Activities",
                newName: "Note");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Accommodations",
                newName: "Note");

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Transports",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ActivityTpyeActivityTypeID",
                table: "Activities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ActivityTypeID",
                table: "Activities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AccommodationTypeID",
                table: "Accommodations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AccommodationType",
                columns: table => new
                {
                    AccommodationTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccommodationType", x => x.AccommodationTypeID);
                });

            migrationBuilder.CreateTable(
                name: "ActivityType",
                columns: table => new
                {
                    ActivityTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityType", x => x.ActivityTypeID);
                });

            migrationBuilder.CreateTable(
                name: "TransportTypes",
                columns: table => new
                {
                    TransportTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportTypes", x => x.TransportTypeID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transports_TransportTypeID",
                table: "Transports",
                column: "TransportTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_ActivityTpyeActivityTypeID",
                table: "Activities",
                column: "ActivityTpyeActivityTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Accommodations_AccommodationTypeID",
                table: "Accommodations",
                column: "AccommodationTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Accommodations_AccommodationType_AccommodationTypeID",
                table: "Accommodations",
                column: "AccommodationTypeID",
                principalTable: "AccommodationType",
                principalColumn: "AccommodationTypeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_ActivityType_ActivityTpyeActivityTypeID",
                table: "Activities",
                column: "ActivityTpyeActivityTypeID",
                principalTable: "ActivityType",
                principalColumn: "ActivityTypeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transports_TransportTypes_TransportTypeID",
                table: "Transports",
                column: "TransportTypeID",
                principalTable: "TransportTypes",
                principalColumn: "TransportTypeID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accommodations_AccommodationType_AccommodationTypeID",
                table: "Accommodations");

            migrationBuilder.DropForeignKey(
                name: "FK_Activities_ActivityType_ActivityTpyeActivityTypeID",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Transports_TransportTypes_TransportTypeID",
                table: "Transports");

            migrationBuilder.DropTable(
                name: "AccommodationType");

            migrationBuilder.DropTable(
                name: "ActivityType");

            migrationBuilder.DropTable(
                name: "TransportTypes");

            migrationBuilder.DropIndex(
                name: "IX_Transports_TransportTypeID",
                table: "Transports");

            migrationBuilder.DropIndex(
                name: "IX_Activities_ActivityTpyeActivityTypeID",
                table: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_Accommodations_AccommodationTypeID",
                table: "Accommodations");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "Transports");

            migrationBuilder.DropColumn(
                name: "ActivityTpyeActivityTypeID",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "ActivityTypeID",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "AccommodationTypeID",
                table: "Accommodations");

            migrationBuilder.RenameColumn(
                name: "TransportTypeID",
                table: "Transports",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "Note",
                table: "Activities",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Note",
                table: "Accommodations",
                newName: "Name");

            migrationBuilder.AddColumn<decimal>(
                name: "Cost",
                table: "Transports",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Cost",
                table: "Activities",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Activities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Accommodations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Cost",
                table: "Accommodations",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
