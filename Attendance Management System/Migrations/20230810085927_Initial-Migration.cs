using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Attendance_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdminSignUp",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    contactNumber = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    password = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminSignUp", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Approval",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    location = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    company = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    year = table.Column<int>(type: "int", nullable: false),
                    month = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    no1 = table.Column<int>(type: "int", nullable: false),
                    empId1 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    approval1 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    remark1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    no2 = table.Column<int>(type: "int", nullable: false),
                    empId2 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    approval2 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    remark2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Approval", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Attendance",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    location = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    company = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    year = table.Column<int>(type: "int", nullable: false),
                    month = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    day = table.Column<int>(type: "int", nullable: false),
                    sId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    designation = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    employeeName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    arrivalDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    departureDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    shiftType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    arrivalTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    departureTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    duration = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    penalty = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    remarks = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendance", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    location = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    status = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Privilage",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Privilage", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Registration",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    serviceId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    designation = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    location = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    company = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registration", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SignIn",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    password = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SignIn", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SignUp",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    companyName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    companyAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    contactPerson = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    contactNumber = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    userName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    password = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SignUp", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "UserPrivilege",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    level = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPrivilege", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminSignUp");

            migrationBuilder.DropTable(
                name: "Approval");

            migrationBuilder.DropTable(
                name: "Attendance");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "Privilage");

            migrationBuilder.DropTable(
                name: "Registration");

            migrationBuilder.DropTable(
                name: "SignIn");

            migrationBuilder.DropTable(
                name: "SignUp");

            migrationBuilder.DropTable(
                name: "UserPrivilege");
        }
    }
}
