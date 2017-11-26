using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace donut_arugular_SPA.Migrations
{
    public partial class seedDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Makes",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(int),
                oldMaxLength: 255);

            migrationBuilder.Sql("INSERT INTO Makes (Name) VALUES ('MINI')");
            migrationBuilder.Sql("INSERT INTO Makes (Name) VALUES ('Porsche')");
            migrationBuilder.Sql("INSERT INTO Makes (Name) VALUES ('Subaru')");
            migrationBuilder.Sql("INSERT INTO Makes (Name) VALUES ('BMW')");
            migrationBuilder.Sql("INSERT INTO Makes (Name) VALUES ('Tesla')");
            migrationBuilder.Sql("INSERT INTO Makes (Name) VALUES ('SAAB')");
            migrationBuilder.Sql("INSERT INTO Makes (Name) VALUES ('Volvo')");

            migrationBuilder.Sql("INSERT INTO Models (Name, MakeId) VALUES ('MINI_Cooper', (SELECT Id FROM Makes WHERE Name = 'MINI'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeId) VALUES ('MINI_CountryMan', (SELECT Id FROM Makes WHERE Name = 'MINI'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeId) VALUES ('Volve_Alex', (SELECT Id FROM Makes WHERE Name = 'Volvo'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeId) VALUES ('Subaru_Forester', (SELECT Id FROM Makes WHERE Name = 'Subaru'))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Name",
                table: "Makes",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255);

            migrationBuilder.Sql("DELETE FROM Makes WHERE Name IN (\"MINI\", \"Subaru\", \"Volvo\")");
            migrationBuilder.Sql("DELETE FROM Models");
        }
    }
}
