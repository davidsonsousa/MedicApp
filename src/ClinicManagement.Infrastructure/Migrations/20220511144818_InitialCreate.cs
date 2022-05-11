using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicManagement.Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clinics",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VanityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UserCreated = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UserModified = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clinics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VanityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UserCreated = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UserModified = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VanityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address_Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address_Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber_CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber_Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserCreated = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UserModified = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VanityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address_Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClinicId = table.Column<long>(type: "bigint", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UserCreated = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UserModified = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Branches_Clinics_ClinicId",
                        column: x => x.ClinicId,
                        principalTable: "Clinics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VanityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    AdditionalInformation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UserCreated = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UserModified = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DateTimeSchedule_Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateTimeSchedule_End = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PersonId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LanguagePerson",
                columns: table => new
                {
                    LanguageId = table.Column<long>(type: "bigint", nullable: false),
                    PersonId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguagePerson", x => new { x.LanguageId, x.PersonId });
                    table.ForeignKey(
                        name: "FK_LanguagePerson_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LanguagePerson_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VanityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BranchId = table.Column<long>(type: "bigint", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UserCreated = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UserModified = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departments_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppointmentPatient",
                columns: table => new
                {
                    AppointmentId = table.Column<long>(type: "bigint", nullable: false),
                    PatientId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentPatient", x => new { x.AppointmentId, x.PatientId });
                    table.ForeignKey(
                        name: "FK_AppointmentPatient_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppointmentPatient_People_PatientId",
                        column: x => x.PatientId,
                        principalTable: "People",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DepartmentEmployee",
                columns: table => new
                {
                    DepartmentId = table.Column<long>(type: "bigint", nullable: false),
                    EmployeeId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentEmployee", x => new { x.DepartmentId, x.EmployeeId });
                    table.ForeignKey(
                        name: "FK_DepartmentEmployee_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepartmentEmployee_People_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkSchedules",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VanityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    DepartmentId = table.Column<long>(type: "bigint", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UserCreated = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UserModified = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DateTimeSchedule_Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateTimeSchedule_End = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PersonId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkSchedules_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkSchedules_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkScheduleEmployee",
                columns: table => new
                {
                    WorkScheduleId = table.Column<long>(type: "bigint", nullable: false),
                    EmployeeId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkScheduleEmployee", x => new { x.EmployeeId, x.WorkScheduleId });
                    table.ForeignKey(
                        name: "FK_WorkScheduleEmployee_People_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "People",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorkScheduleEmployee_WorkSchedules_WorkScheduleId",
                        column: x => x.WorkScheduleId,
                        principalTable: "WorkSchedules",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Clinics",
                columns: new[] { "Id", "IsDeleted", "Name", "UserCreated", "UserModified" },
                values: new object[,]
                {
                    { 1L, false, "Whatever Medical Center", null, null },
                    { 2L, false, "Random Clinic", null, null }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Code", "IsDeleted", "Name", "UserCreated", "UserModified" },
                values: new object[,]
                {
                    { 1L, "CZ", false, "Czech", null, null },
                    { 2L, "EN", false, "English", null, null },
                    { 3L, "PL", false, "Polish", null, null },
                    { 4L, "RU", false, "Russian", null, null }
                });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "DateOfBirth", "Discriminator", "IsDeleted", "Name", "Surname", "UserCreated", "UserModified", "Address_City", "Address_Country", "Address_State", "Address_Street", "Address_ZipCode", "PhoneNumber_CountryCode", "PhoneNumber_Number" },
                values: new object[,]
                {
                    { 1L, new DateTime(1970, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Doctor", false, "John", "Doe", null, null, "Prague", "CZ", null, "ul. Doktorova 1010/10", "110 00", "420", "987654321" },
                    { 2L, new DateTime(1975, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Doctor", false, "Mary", "Sue", null, null, "Prague", "CZ", null, "ul. Nemocinice 2020/20", "220 00", "420", "789456123" },
                    { 3L, new DateTime(1980, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nurse", false, "Pavla", "Novakova", null, null, "Prague", "CZ", null, "ul. Sersterska 3030/30", "330 00", "420", "777888999" },
                    { 4L, new DateTime(1985, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nurse", false, "Lenka", "Novakova", null, null, "Prague", "CZ", null, "ul. Sersterska 3031/31", "330 00", "420", "888444333" }
                });

            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "Id", "ClinicId", "IsDeleted", "Name", "UserCreated", "UserModified", "Address_City", "Address_Country", "Address_State", "Address_Street", "Address_ZipCode" },
                values: new object[,]
                {
                    { 1L, 1L, false, "WMC - Prague 1", null, null, "Prague", "CZ", null, "ul. Ulicova 1011/10", "110 00" },
                    { 2L, 1L, false, "WMC - Prague 3", null, null, "Prague", "CZ", null, "ul. Ulicova 3033/30", "330 00" },
                    { 3L, 2L, false, "RC - Prague 5", null, null, "Prague", "CZ", null, "ul. Ulicova 5055/50", "550 00" },
                    { 4L, 2L, false, "RC - Prague 9", null, null, "Prague", "CZ", null, "ul. Ulicova 9000/90", "990 00" }
                });

            migrationBuilder.InsertData(
                table: "LanguagePerson",
                columns: new[] { "LanguageId", "PersonId" },
                values: new object[,]
                {
                    { 1L, 1L },
                    { 1L, 2L },
                    { 1L, 3L },
                    { 1L, 4L },
                    { 2L, 1L },
                    { 2L, 2L },
                    { 3L, 4L },
                    { 4L, 3L }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "BranchId", "IsDeleted", "Name", "UserCreated", "UserModified" },
                values: new object[,]
                {
                    { 1L, 1L, false, "General practitioner", null, null },
                    { 2L, 1L, false, "Urology", null, null },
                    { 3L, 1L, false, "Paediatrics", null, null },
                    { 4L, 2L, false, "Internal medicine", null, null },
                    { 5L, 2L, false, "Cardiology", null, null },
                    { 6L, 2L, false, "Ophthalmology", null, null }
                });

            migrationBuilder.InsertData(
                table: "DepartmentEmployee",
                columns: new[] { "DepartmentId", "EmployeeId" },
                values: new object[,]
                {
                    { 1L, 1L },
                    { 1L, 3L },
                    { 2L, 2L },
                    { 2L, 4L }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentPatient_PatientId",
                table: "AppointmentPatient",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PersonId",
                table: "Appointments",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_VanityId",
                table: "Appointments",
                column: "VanityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Branches_ClinicId",
                table: "Branches",
                column: "ClinicId");

            migrationBuilder.CreateIndex(
                name: "IX_Branches_VanityId",
                table: "Branches",
                column: "VanityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clinics_VanityId",
                table: "Clinics",
                column: "VanityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentEmployee_EmployeeId",
                table: "DepartmentEmployee",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_BranchId",
                table: "Departments",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_VanityId",
                table: "Departments",
                column: "VanityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LanguagePerson_PersonId",
                table: "LanguagePerson",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Languages_VanityId",
                table: "Languages",
                column: "VanityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_People_VanityId",
                table: "People",
                column: "VanityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkScheduleEmployee_WorkScheduleId",
                table: "WorkScheduleEmployee",
                column: "WorkScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkSchedules_DepartmentId",
                table: "WorkSchedules",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkSchedules_PersonId",
                table: "WorkSchedules",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkSchedules_VanityId",
                table: "WorkSchedules",
                column: "VanityId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppointmentPatient");

            migrationBuilder.DropTable(
                name: "DepartmentEmployee");

            migrationBuilder.DropTable(
                name: "LanguagePerson");

            migrationBuilder.DropTable(
                name: "WorkScheduleEmployee");

            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "WorkSchedules");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropTable(
                name: "Clinics");
        }
    }
}
