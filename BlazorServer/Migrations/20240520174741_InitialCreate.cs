using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorServer.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrderInfo",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "INTEGER", nullable: false, comment: "訂單流水號"),
                    CreateTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())", comment: "訂單成立時間"),
                    Price = table.Column<int>(type: "INTEGER", nullable: false, defaultValueSql: "(0)", comment: "訂單總金額"),
                    CustomerId = table.Column<int>(type: "INTEGER", nullable: false, comment: "客戶流水號"),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false, defaultValueSql: "(0)", comment: "是否刪除")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderInfo", x => x.OrderId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderInfo");
        }
    }
}
