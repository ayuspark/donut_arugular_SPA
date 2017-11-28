using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace donut_arugular_SPA.Migrations
{
    public partial class features_and_ModelFeature_joinTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Features",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Features", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ModelFeatures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FeatureId = table.Column<int>(type: "int", nullable: false),
                    ModelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelFeatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModelFeatures_Features_FeatureId",
                        column: x => x.FeatureId,
                        principalTable: "Features",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModelFeatures_Models_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ModelFeatures_FeatureId",
                table: "ModelFeatures",
                column: "FeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_ModelFeatures_ModelId",
                table: "ModelFeatures",
                column: "ModelId");
            
            migrationBuilder.Sql("INSERT INTO Features (Name) VALUES ('Moon-roof')");
            migrationBuilder.Sql("INSERT INTO Features (Name) VALUES ('Brake')");
            migrationBuilder.Sql("INSERT INTO Features (Name) VALUES ('Gas')");
            migrationBuilder.Sql("INSERT INTO Features (Name) VALUES ('Floor for your dogs')");
            migrationBuilder.Sql("INSERT INTO Features (Name) VALUES ('Touch-screen')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ModelFeatures");

            migrationBuilder.DropTable(
                name: "Features");
        }
    }
}
