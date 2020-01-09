using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VumbaSoft.AdventureWorks.Data.Migrations
{
    public partial class Added_Demographic_Tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Continent",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Population = table.Column<int>(nullable: true),
                    Remarks = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Continent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomCareType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Remarks = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomCareType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContinentRegion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    ContinentId = table.Column<int>(nullable: false),
                    Population = table.Column<int>(nullable: true),
                    Remarks = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContinentRegion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContinentRegion_Continent_ContinentId",
                        column: x => x.ContinentId,
                        principalTable: "Continent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    ContinentRegionId = table.Column<int>(nullable: false),
                    Population = table.Column<int>(nullable: true),
                    Remarks = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Country_ContinentRegion_ContinentRegionId",
                        column: x => x.ContinentRegionId,
                        principalTable: "ContinentRegion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Region",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    CountryId = table.Column<int>(nullable: false),
                    Population = table.Column<int>(nullable: true),
                    Remarks = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Region", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Region_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Province",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    RegionId = table.Column<int>(nullable: false),
                    Population = table.Column<int>(nullable: true),
                    Remarks = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Province", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Province_Region_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Region",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "District",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    ProvinceId = table.Column<int>(nullable: false),
                    Population = table.Column<int>(nullable: true),
                    Remarks = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_District", x => x.Id);
                    table.ForeignKey(
                        name: "FK_District_Province_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "Province",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Locality",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    DistrictId = table.Column<int>(nullable: false),
                    Population = table.Column<int>(nullable: true),
                    Remarks = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locality", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locality_District_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "District",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    LocalityId = table.Column<int>(nullable: false),
                    Population = table.Column<int>(nullable: true),
                    Remarks = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                    table.ForeignKey(
                        name: "FK_City_Locality_LocalityId",
                        column: x => x.LocalityId,
                        principalTable: "Locality",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tenant",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    CityID = table.Column<int>(nullable: false),
                    Adress = table.Column<string>(nullable: false),
                    IsInTrial = table.Column<bool>(nullable: false),
                    TrialStartDate = table.Column<DateTime>(nullable: true),
                    TrialEndDate = table.Column<DateTime>(nullable: true),
                    PaidOut = table.Column<bool>(nullable: false),
                    PeriodPaidOutId = table.Column<bool>(nullable: false),
                    PaidStartDate = table.Column<DateTime>(nullable: true),
                    PaidEndDate = table.Column<DateTime>(nullable: true),
                    Disabled = table.Column<bool>(nullable: false),
                    DisabledReason = table.Column<string>(nullable: false),
                    PaidDate = table.Column<DateTime>(nullable: true),
                    NextBillingDate = table.Column<DateTime>(nullable: true),
                    IsPremium = table.Column<bool>(nullable: false),
                    IsVIP = table.Column<bool>(nullable: false),
                    IsLocked = table.Column<bool>(nullable: false),
                    LockedDate = table.Column<DateTime>(nullable: false),
                    LockedReason = table.Column<string>(nullable: false),
                    Activated = table.Column<bool>(nullable: false),
                    ActivatedDate = table.Column<DateTime>(nullable: true),
                    ActivatedReason = table.Column<string>(nullable: false),
                    Upgraded = table.Column<bool>(nullable: false),
                    UpgradedDate = table.Column<DateTime>(nullable: true),
                    Enabled = table.Column<bool>(nullable: false),
                    PostalCode = table.Column<string>(nullable: false),
                    BusinessName = table.Column<string>(nullable: false),
                    CustomCareTypeID = table.Column<int>(nullable: true),
                    LogoPath = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tenant_City_CityID",
                        column: x => x.CityID,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AdventureworkFacility",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    CityId = table.Column<int>(nullable: false),
                    TenantId = table.Column<int>(nullable: false),
                    Population = table.Column<int>(nullable: true),
                    Remarks = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdventureworkFacility", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdventureworkFacility_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AdventureworkFacility_Tenant_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdventureworkFacility_CityId",
                table: "AdventureworkFacility",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_AdventureworkFacility_TenantId",
                table: "AdventureworkFacility",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_City_LocalityId",
                table: "City",
                column: "LocalityId");

            migrationBuilder.CreateIndex(
                name: "IX_ContinentRegion_ContinentId",
                table: "ContinentRegion",
                column: "ContinentId");

            migrationBuilder.CreateIndex(
                name: "IX_Country_ContinentRegionId",
                table: "Country",
                column: "ContinentRegionId");

            migrationBuilder.CreateIndex(
                name: "IX_District_ProvinceId",
                table: "District",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_Locality_DistrictId",
                table: "Locality",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Province_RegionId",
                table: "Province",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Region_CountryId",
                table: "Region",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Tenant_CityID",
                table: "Tenant",
                column: "CityID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdventureworkFacility");

            migrationBuilder.DropTable(
                name: "CustomCareType");

            migrationBuilder.DropTable(
                name: "Tenant");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Locality");

            migrationBuilder.DropTable(
                name: "District");

            migrationBuilder.DropTable(
                name: "Province");

            migrationBuilder.DropTable(
                name: "Region");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "ContinentRegion");

            migrationBuilder.DropTable(
                name: "Continent");
        }
    }
}
