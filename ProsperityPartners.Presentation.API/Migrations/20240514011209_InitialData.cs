using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProsperityPartners.Presentation.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "CompanyId", "Address", "Created", "CreatedBy", "LastModified", "LastModifiedBy", "Name", "Owner" },
                values: new object[,]
                {
                    { new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), "123 Downtown Mutare, Zimbabwe", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Twilight Tech World", "Brian Masase" },
                    { new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "123 Main Street Mutare, Zimbabwe", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Prosperity Partners", "Sam Fukuzeya" }
                });

            migrationBuilder.InsertData(
                table: "DeductionCodes",
                columns: new[] { "DeductionCodeId", "Code", "CompanyId", "Created", "CreatedBy", "LastModified", "LastModifiedBy" },
                values: new object[] { new Guid("13a377c0-ea91-4ed3-8f73-80de96cf1026"), "254576666323587", new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "CompanyId", "Created", "CreatedBy", "Email", "FirstName", "LastModified", "LastModifiedBy", "LastName", "Phone", "Position" },
                values: new object[,]
                {
                    { new Guid("8c80bee5-6411-4beb-80a0-b92dfc330bd7"), new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "nyasha.musongora@gmail.com", "Nyasha", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Musongora", "1234567890", "Manager" },
                    { new Guid("b44608fb-1fe8-43c4-9ad3-fa34b91a64e4"), new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "panashe.mhlanga@gmail.com", "Panashe", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Mhlanga", "1234567890", "Accountant" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DeductionCodes",
                keyColumn: "DeductionCodeId",
                keyValue: new Guid("13a377c0-ea91-4ed3-8f73-80de96cf1026"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("8c80bee5-6411-4beb-80a0-b92dfc330bd7"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("b44608fb-1fe8-43c4-9ad3-fa34b91a64e4"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"));
        }
    }
}
