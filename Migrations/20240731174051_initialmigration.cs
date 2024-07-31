using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppraisalTracker.Migrations
{
    /// <inheritdoc />
    public partial class initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConfigMenuItems",
                columns: table => new
                {
                    ItemId = table.Column<Guid>(type: "uuid", nullable: false),
                    FieldName = table.Column<string>(type: "text", nullable: false),
                    FieldDescription = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfigMenuItems", x => x.ItemId);
                });

            migrationBuilder.CreateTable(
                name: "MeasurableActivities",
                columns: table => new
                {
                    MeasurableActivityId = table.Column<Guid>(type: "uuid", nullable: false),
                    PeriodId = table.Column<Guid>(type: "uuid", nullable: true),
                    ActivityId = table.Column<Guid>(type: "uuid", nullable: true),
                    PerspectiveId = table.Column<Guid>(type: "uuid", nullable: true),
                    SsMartaObjectivesId = table.Column<Guid>(type: "uuid", nullable: true),
                    InitiativeId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasurableActivities", x => x.MeasurableActivityId);
                    table.ForeignKey(
                        name: "FK_MeasurableActivities_ConfigMenuItems_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "ConfigMenuItems",
                        principalColumn: "ItemId");
                    table.ForeignKey(
                        name: "FK_MeasurableActivities_ConfigMenuItems_InitiativeId",
                        column: x => x.InitiativeId,
                        principalTable: "ConfigMenuItems",
                        principalColumn: "ItemId");
                    table.ForeignKey(
                        name: "FK_MeasurableActivities_ConfigMenuItems_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "ConfigMenuItems",
                        principalColumn: "ItemId");
                    table.ForeignKey(
                        name: "FK_MeasurableActivities_ConfigMenuItems_PerspectiveId",
                        column: x => x.PerspectiveId,
                        principalTable: "ConfigMenuItems",
                        principalColumn: "ItemId");
                    table.ForeignKey(
                        name: "FK_MeasurableActivities_ConfigMenuItems_SsMartaObjectivesId",
                        column: x => x.SsMartaObjectivesId,
                        principalTable: "ConfigMenuItems",
                        principalColumn: "ItemId");
                });

            migrationBuilder.CreateTable(
                name: "Implementations",
                columns: table => new
                {
                    ImplementationId = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Comment = table.Column<string>(type: "text", nullable: true),
                    Stakeholder = table.Column<string>(type: "text", nullable: true),
                    Evidence = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MeasurableActivityId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Implementations", x => x.ImplementationId);
                    table.ForeignKey(
                        name: "FK_Implementations_MeasurableActivities_MeasurableActivityId",
                        column: x => x.MeasurableActivityId,
                        principalTable: "MeasurableActivities",
                        principalColumn: "MeasurableActivityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Implementations_MeasurableActivityId",
                table: "Implementations",
                column: "MeasurableActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_MeasurableActivities_ActivityId",
                table: "MeasurableActivities",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_MeasurableActivities_InitiativeId",
                table: "MeasurableActivities",
                column: "InitiativeId");

            migrationBuilder.CreateIndex(
                name: "IX_MeasurableActivities_PeriodId",
                table: "MeasurableActivities",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_MeasurableActivities_PerspectiveId",
                table: "MeasurableActivities",
                column: "PerspectiveId");

            migrationBuilder.CreateIndex(
                name: "IX_MeasurableActivities_SsMartaObjectivesId",
                table: "MeasurableActivities",
                column: "SsMartaObjectivesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Implementations");

            migrationBuilder.DropTable(
                name: "MeasurableActivities");

            migrationBuilder.DropTable(
                name: "ConfigMenuItems");
        }
    }
}
