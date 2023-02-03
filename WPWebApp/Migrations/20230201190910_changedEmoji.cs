using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WPWebApp.Migrations
{
    public partial class changedEmoji : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                "Alter Table Emojis " +
                "Alter Column Name nvarchar(max)"
                );
            migrationBuilder.Sql(
                "Alter Table ImageDetails " +
                "ADD UserId nvarchar(max) not null"
                );


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {


        }
    }
}
