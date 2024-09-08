using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Itinerary_Generator.Migrations
{
    /// <inheritdoc />
    public partial class Data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LookupTypes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookupTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    ActivityID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    lookupTypesID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.ActivityID);
                    table.ForeignKey(
                        name: "FK_Activities_LookupTypes_lookupTypesID",
                        column: x => x.lookupTypesID,
                        principalTable: "LookupTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "preferences",
                columns: table => new
                {
                    PreferenceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    ActivityType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lookupTypesID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_preferences", x => x.PreferenceID);
                    table.ForeignKey(
                        name: "FK_preferences_LookupTypes_lookupTypesID",
                        column: x => x.lookupTypesID,
                        principalTable: "LookupTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transports",
                columns: table => new
                {
                    TransportID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StartLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EndLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lookupTypesID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transports", x => x.TransportID);
                    table.ForeignKey(
                        name: "FK_Transports_LookupTypes_lookupTypesID",
                        column: x => x.lookupTypesID,
                        principalTable: "LookupTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Itineraries",
                columns: table => new
                {
                    ItineraryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    TotalCost = table.Column<int>(type: "int", nullable: false),
                    PDFGenerated = table.Column<bool>(type: "bit", nullable: false),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Itineraries", x => x.ItineraryID);
                    table.ForeignKey(
                        name: "FK_Itineraries_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Days",
                columns: table => new
                {
                    DayID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItineraryID = table.Column<int>(type: "int", nullable: false),
                    TransportID = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Time = table.Column<TimeOnly>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Days", x => x.DayID);
                    table.ForeignKey(
                        name: "FK_Days_Itineraries_ItineraryID",
                        column: x => x.ItineraryID,
                        principalTable: "Itineraries",
                        principalColumn: "ItineraryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Days_Transports_TransportID",
                        column: x => x.TransportID,
                        principalTable: "Transports",
                        principalColumn: "TransportID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DailyActivities",
                columns: table => new
                {
                    DailyActivityID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActivityID = table.Column<int>(type: "int", nullable: false),
                    DayID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyActivities", x => x.DailyActivityID);
                    table.ForeignKey(
                        name: "FK_DailyActivities_Activities_ActivityID",
                        column: x => x.ActivityID,
                        principalTable: "Activities",
                        principalColumn: "ActivityID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DailyActivities_Days_DayID",
                        column: x => x.DayID,
                        principalTable: "Days",
                        principalColumn: "DayID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DailyTransports",
                columns: table => new
                {
                    DailyTransportID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransportID = table.Column<int>(type: "int", nullable: false),
                    DayID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyTransports", x => x.DailyTransportID);
                    table.ForeignKey(
                        name: "FK_DailyTransports_Days_DayID",
                        column: x => x.DayID,
                        principalTable: "Days",
                        principalColumn: "DayID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DailyTransports_Transports_TransportID",
                        column: x => x.TransportID,
                        principalTable: "Transports",
                        principalColumn: "TransportID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_lookupTypesID",
                table: "Activities",
                column: "lookupTypesID");

            migrationBuilder.CreateIndex(
                name: "IX_DailyActivities_ActivityID",
                table: "DailyActivities",
                column: "ActivityID");

            migrationBuilder.CreateIndex(
                name: "IX_DailyActivities_DayID",
                table: "DailyActivities",
                column: "DayID");

            migrationBuilder.CreateIndex(
                name: "IX_DailyTransports_DayID",
                table: "DailyTransports",
                column: "DayID");

            migrationBuilder.CreateIndex(
                name: "IX_DailyTransports_TransportID",
                table: "DailyTransports",
                column: "TransportID");

            migrationBuilder.CreateIndex(
                name: "IX_Days_ItineraryID",
                table: "Days",
                column: "ItineraryID");

            migrationBuilder.CreateIndex(
                name: "IX_Days_TransportID",
                table: "Days",
                column: "TransportID");

            migrationBuilder.CreateIndex(
                name: "IX_Itineraries_UserID",
                table: "Itineraries",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_preferences_lookupTypesID",
                table: "preferences",
                column: "lookupTypesID");

            migrationBuilder.CreateIndex(
                name: "IX_Transports_lookupTypesID",
                table: "Transports",
                column: "lookupTypesID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DailyActivities");

            migrationBuilder.DropTable(
                name: "DailyTransports");

            migrationBuilder.DropTable(
                name: "preferences");

            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "Days");

            migrationBuilder.DropTable(
                name: "Itineraries");

            migrationBuilder.DropTable(
                name: "Transports");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "LookupTypes");
        }
    }
}
