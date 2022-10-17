using DbLibrary.Migrations.Scripts;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DbLibrary.Migrations
{
    public partial class createView_FullItemDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.SqlResource(@"DbLibrary.Migrations.Scripts.Views.FullItemDetails.v0.sql");

        //C: \Users\USER\Desktop\EntityFrameworkCore6\MainStudy\MainSolution\EfGreen_DbLibrary\DbLibrary\Migrations\Scripts\Views\FullItemDetails.v0.sql
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW IF EXISTS [dbo].vwFullItemDetails");
        }
    }
}
