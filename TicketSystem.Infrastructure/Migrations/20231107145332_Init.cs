using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TicketSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("38dfd248-adb7-43bd-9ff0-348357283ba2"), "00000000-0000-0000-0000-000000000000", "User", "USER" },
                    { new Guid("6b5c44d7-29ec-440e-bccb-63d5cf34fbc4"), "00000000-0000-0000-0000-000000000000", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("10000000-0000-0000-0000-000000000000"), 0, "3187d9e9-2817-4dfc-a349-211c71b07805", "hauwelaert.yanick@gmail.com", false, "Yanick", "Hauwelaert", false, null, "HAUWELAERT.YANICK@GMAIL.COM", "YANICKHAUWELAERT", "AQAAAAIAAYagAAAAEOpfZzhQUMpqQaC8JZb01GpzLplBXH33olLH7HgLhIZ34HC0fhE3s7ofieiHCEtuwg==", null, false, "848e1df3-fa5b-4a1a-997a-1f48bc7efd27", false, "YanickHauwelaert" },
                    { new Guid("20000000-0000-0000-0000-000000000000"), 0, "ecde44eb-6e88-4976-92c0-c86525a1f793", "TestUser1@gmail.com", false, "Test1", "User", false, null, "TESTUSER1@GMAIL.COM", "TESTUSER1", "AQAAAAIAAYagAAAAEEOOJVlhOXyYhbTUUBhHA4TCKorWee6lF9fChlB/xUT8eTt+tXCvIINNf8yzgwe4UQ==", null, false, "33236f14-6925-413e-948f-9f39e267f4ad", false, "TestUser1" },
                    { new Guid("30000000-0000-0000-0000-000000000000"), 0, "acf9b30d-3125-476a-afa1-f4b026b5e396", "TestUser2@gmail.com", false, "Test2", "User", false, null, "TESTUSER2@GMAIL.COM", "TESTUSER2", "AQAAAAIAAYagAAAAEA9QtLUqzu3sT4r/mTbrfXI0xcq1zMJcpUU2Xt7z5E1OqozEw+q2Q/ku/zG/KRy4kA==", null, false, "f105fbff-49a0-46e2-a4be-6d8c5be3d0dd", false, "TestUser2" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("00000000-1000-0000-0000-000000000000"), "Hardware" },
                    { new Guid("00000000-2000-0000-0000-000000000000"), "Software" },
                    { new Guid("00000000-3000-0000-0000-000000000000"), "Other" }
                });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "CategoryId", "CreationDate", "Description", "Status", "Subject", "UserId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-1000-0000-000000000000"), new Guid("00000000-2000-0000-0000-000000000000"), new DateTime(2023, 11, 7, 0, 0, 0, 0, DateTimeKind.Local), "The software keeps freezing when i try to start it", "InProcces", "Program X freez", new Guid("30000000-0000-0000-0000-000000000000") },
                    { new Guid("00000000-0000-2000-0000-000000000000"), new Guid("00000000-1000-0000-0000-000000000000"), new DateTime(2023, 11, 7, 0, 0, 0, 0, DateTimeKind.Local), "Hard drive constantly 100% usage", "None", "Hardrive usage", new Guid("20000000-0000-0000-0000-000000000000") },
                    { new Guid("00000000-0000-3000-0000-000000000000"), new Guid("00000000-3000-0000-0000-000000000000"), new DateTime(2023, 11, 7, 0, 0, 0, 0, DateTimeKind.Local), "I get the a lot of blue screens with the following error code some error code", "Done", "blue screen", new Guid("20000000-0000-0000-0000-000000000000") },
                    { new Guid("00000000-0000-4000-0000-000000000000"), new Guid("00000000-1000-0000-0000-000000000000"), new DateTime(2023, 11, 7, 0, 0, 0, 0, DateTimeKind.Local), "Fans keep spinning really loud", "None", "Loud fans", new Guid("20000000-0000-0000-0000-000000000000") }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[,]
                {
                    { 1, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "Admin", new Guid("10000000-0000-0000-0000-000000000000") },
                    { 2, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress", "hauwelaert.yanick@gmail.com", new Guid("10000000-0000-0000-0000-000000000000") },
                    { 3, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier", "10000000-0000-0000-0000-000000000000", new Guid("10000000-0000-0000-0000-000000000000") },
                    { 4, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name", "YanickHauwelaert", new Guid("10000000-0000-0000-0000-000000000000") },
                    { 5, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "User", new Guid("20000000-0000-0000-0000-000000000000") },
                    { 6, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress", "TestUser1@gmail.com", new Guid("20000000-0000-0000-0000-000000000000") },
                    { 7, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier", "20000000-0000-0000-0000-000000000000", new Guid("20000000-0000-0000-0000-000000000000") },
                    { 8, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name", "TestUser1", new Guid("20000000-0000-0000-0000-000000000000") },
                    { 9, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "User", new Guid("30000000-0000-0000-0000-000000000000") },
                    { 10, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress", "TestUser2@gmail.com", new Guid("30000000-0000-0000-0000-000000000000") },
                    { 11, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier", "30000000-0000-0000-0000-000000000000", new Guid("30000000-0000-0000-0000-000000000000") },
                    { 12, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name", "TestUser2", new Guid("30000000-0000-0000-0000-000000000000") }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("6b5c44d7-29ec-440e-bccb-63d5cf34fbc4"), new Guid("10000000-0000-0000-0000-000000000000") },
                    { new Guid("38dfd248-adb7-43bd-9ff0-348357283ba2"), new Guid("20000000-0000-0000-0000-000000000000") },
                    { new Guid("38dfd248-adb7-43bd-9ff0-348357283ba2"), new Guid("30000000-0000-0000-0000-000000000000") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
