using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KeyRotation.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MyEntities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyEntities", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "MyEntities",
                columns: new[] { "Id", "Date", "Name" },
                values: new object[,]
                {
                    { new Guid("258492ae-0133-47fc-b3f1-75c0ac33a291"), new DateTime(2022, 11, 18, 23, 14, 3, 492, DateTimeKind.Local).AddTicks(7687), "Fund 1" },
                    { new Guid("59d1e381-5484-4580-9eb4-8fc364075225"), new DateTime(2023, 2, 1, 23, 14, 3, 492, DateTimeKind.Local).AddTicks(7708), "Fund 6" },
                    { new Guid("952347f8-11af-4bf3-ab62-91e9794d56ec"), new DateTime(2023, 1, 17, 23, 14, 3, 492, DateTimeKind.Local).AddTicks(7707), "Fund 5" },
                    { new Guid("e867c517-ce35-4fe5-8cae-b944dbfd9d54"), new DateTime(2022, 12, 18, 23, 14, 3, 492, DateTimeKind.Local).AddTicks(7705), "Fund 3" },
                    { new Guid("f2b16552-389a-442c-a176-ee46b3ce53a7"), new DateTime(2023, 1, 2, 23, 14, 3, 492, DateTimeKind.Local).AddTicks(7706), "Fund 4" },
                    { new Guid("f55add9c-350a-4b14-bd1d-f13aca067846"), new DateTime(2022, 12, 3, 23, 14, 3, 492, DateTimeKind.Local).AddTicks(7702), "Fund 2" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MyEntities");
        }
    }
}
