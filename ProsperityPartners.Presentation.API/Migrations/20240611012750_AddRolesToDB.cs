using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProsperityPartners.Presentation.API.Migrations
{
    /// <inheritdoc />
    public partial class AddRolesToDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DeductionCodes",
                keyColumn: "DeductionCodeId",
                keyValue: new Guid("854e846e-60a4-4aa8-b91b-8e37358aecc2"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("4fb166b5-4843-4939-9292-80e2ebd2a880"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("d957ddc3-e91e-49a2-b715-b3cef7f2d155"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3fe22b93-b8ff-4be7-8c97-52807a7af91e", null, "User", "USER" },
                    { "db6432e8-d3ba-4022-a63c-8fa469775a06", null, "Manager", "MANAGER" },
                    { "eb8efba1-2452-4a1c-853d-7e39ae32ea78", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "DeductionCodes",
                columns: new[] { "DeductionCodeId", "Code", "CompanyId", "Created", "CreatedBy", "LastModified", "LastModifiedBy" },
                values: new object[] { new Guid("6ee1a53d-195f-4fae-9fe2-5d655fb02b18"), "254576666323587", new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "CompanyId", "Created", "CreatedBy", "Email", "FirstName", "LastModified", "LastModifiedBy", "LastName", "Phone", "Position" },
                values: new object[,]
                {
                    { new Guid("d8ed12cd-6ae2-4ccb-8ef8-21d8e1066a39"), new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "panashe.mhlanga@gmail.com", "Panashe", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Mhlanga", "1234567890", "Accountant" },
                    { new Guid("e75f5420-5491-4c9d-8eb5-b2f3889c66b8"), new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "nyasha.musongora@gmail.com", "Nyasha", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Musongora", "1234567890", "Manager" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3fe22b93-b8ff-4be7-8c97-52807a7af91e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db6432e8-d3ba-4022-a63c-8fa469775a06");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eb8efba1-2452-4a1c-853d-7e39ae32ea78");

            migrationBuilder.DeleteData(
                table: "DeductionCodes",
                keyColumn: "DeductionCodeId",
                keyValue: new Guid("6ee1a53d-195f-4fae-9fe2-5d655fb02b18"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("d8ed12cd-6ae2-4ccb-8ef8-21d8e1066a39"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("e75f5420-5491-4c9d-8eb5-b2f3889c66b8"));

            migrationBuilder.InsertData(
                table: "DeductionCodes",
                columns: new[] { "DeductionCodeId", "Code", "CompanyId", "Created", "CreatedBy", "LastModified", "LastModifiedBy" },
                values: new object[] { new Guid("854e846e-60a4-4aa8-b91b-8e37358aecc2"), "254576666323587", new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "CompanyId", "Created", "CreatedBy", "Email", "FirstName", "LastModified", "LastModifiedBy", "LastName", "Phone", "Position" },
                values: new object[,]
                {
                    { new Guid("4fb166b5-4843-4939-9292-80e2ebd2a880"), new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "nyasha.musongora@gmail.com", "Nyasha", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Musongora", "1234567890", "Manager" },
                    { new Guid("d957ddc3-e91e-49a2-b715-b3cef7f2d155"), new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "panashe.mhlanga@gmail.com", "Panashe", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Mhlanga", "1234567890", "Accountant" }
                });
        }
    }
}
