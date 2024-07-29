using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AppraisalTracker.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MeasurableActivities",
                columns: table => new
                {
                    MeasurableActivityId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Period = table.Column<string>(type: "text", nullable: false),
                    Activity = table.Column<string>(type: "text", nullable: false),
                    Perspective = table.Column<string>(type: "text", nullable: false),
                    SsMartaObjectives = table.Column<string>(type: "text", nullable: false),
                    Initiative = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasurableActivities", x => x.MeasurableActivityId);
                });

            migrationBuilder.CreateTable(
                name: "Implementations",
                columns: table => new
                {
                    ImplementationId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Comment = table.Column<string>(type: "text", nullable: true),
                    Stakeholder = table.Column<string>(type: "text", nullable: true),
                    Evidence = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MeasurableActivityId = table.Column<int>(type: "integer", nullable: false)
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Implementations");

            migrationBuilder.DropTable(
                name: "MeasurableActivities");
        }
    }
}
