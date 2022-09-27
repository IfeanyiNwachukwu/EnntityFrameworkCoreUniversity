using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFDbLibrary.Migrations
{
    public partial class Create_Improvement_Plans : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          

            migrationBuilder.CreateTable(
                name: "ImprovementPlans",
                columns: table => new
                {
                    BusinessEntityId = table.Column<int>(type: "int", nullable: false),
                    PlanStart = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImprovementPlans", x => x.BusinessEntityId);
                    table.ForeignKey(
                        name: "FK_ImprovementPlans_Employee_BusinessEntityId",
                        column: x => x.BusinessEntityId,
                        principalSchema: "HumanResources",
                        principalTable: "Employee",
                        principalColumn: "BusinessEntityID",
                        onDelete: ReferentialAction.Cascade);
                });

          
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImprovementPlans");

            migrationBuilder.DropIndex(
                name: "AK_Vendor_AccountNumber",
                schema: "Purchasing",
                table: "Vendor");

            migrationBuilder.DropIndex(
                name: "AK_UnitMeasure_Name",
                schema: "Production",
                table: "UnitMeasure");

            migrationBuilder.DropIndex(
                name: "AK_StateProvince_Name",
                schema: "Person",
                table: "StateProvince");

            migrationBuilder.DropIndex(
                name: "AK_StateProvince_StateProvinceCode_CountryRegionCode",
                schema: "Person",
                table: "StateProvince");

            migrationBuilder.DropIndex(
                name: "AK_ShipMethod_Name",
                schema: "Purchasing",
                table: "ShipMethod");

            migrationBuilder.DropIndex(
                name: "AK_Shift_Name",
                schema: "HumanResources",
                table: "Shift");

            migrationBuilder.DropIndex(
                name: "AK_ScrapReason_Name",
                schema: "Production",
                table: "ScrapReason");

            migrationBuilder.DropIndex(
                name: "AK_SalesTerritory_Name",
                schema: "Sales",
                table: "SalesTerritory");

            migrationBuilder.DropIndex(
                name: "AK_SalesOrderHeader_SalesOrderNumber",
                schema: "Sales",
                table: "SalesOrderHeader");

            migrationBuilder.DropIndex(
                name: "AK_ProductSubcategory_Name",
                schema: "Production",
                table: "ProductSubcategory");

            migrationBuilder.DropIndex(
                name: "AK_ProductModel_Name",
                schema: "Production",
                table: "ProductModel");

            migrationBuilder.DropIndex(
                name: "AK_ProductCategory_Name",
                schema: "Production",
                table: "ProductCategory");

            migrationBuilder.DropIndex(
                name: "AK_Product_Name",
                schema: "Production",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "AK_Product_ProductNumber",
                schema: "Production",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "AK_Location_Name",
                schema: "Production",
                table: "Location");

            migrationBuilder.DropIndex(
                name: "AK_Employee_LoginID",
                schema: "HumanResources",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "AK_Employee_NationalIDNumber",
                schema: "HumanResources",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "AK_Department_Name",
                schema: "HumanResources",
                table: "Department");

            migrationBuilder.DropIndex(
                name: "AK_Customer_AccountNumber",
                schema: "Sales",
                table: "Customer");

            migrationBuilder.DropIndex(
                name: "AK_CurrencyRate_CurrencyRateDate_FromCurrencyCode_ToCurrencyCode",
                schema: "Sales",
                table: "CurrencyRate");

            migrationBuilder.DropIndex(
                name: "AK_Currency_Name",
                schema: "Sales",
                table: "Currency");

            migrationBuilder.DropIndex(
                name: "AK_Culture_Name",
                schema: "Production",
                table: "Culture");

            migrationBuilder.DropIndex(
                name: "AK_CreditCard_CardNumber",
                schema: "Sales",
                table: "CreditCard");

            migrationBuilder.DropIndex(
                name: "AK_CountryRegion_Name",
                schema: "Person",
                table: "CountryRegion");

            migrationBuilder.DropIndex(
                name: "AK_ContactType_Name",
                schema: "Person",
                table: "ContactType");

            migrationBuilder.DropIndex(
                name: "AK_AddressType_Name",
                schema: "Person",
                table: "AddressType");

            migrationBuilder.DropIndex(
                name: "IX_Address_AddressLine1_AddressLine2_City_StateProvinceID_PostalCode",
                schema: "Person",
                table: "Address");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Purchasing",
                table: "Vendor",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "Company name.",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "Company name.");

            migrationBuilder.AlterColumn<string>(
                name: "AccountNumber",
                schema: "Purchasing",
                table: "Vendor",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "",
                comment: "Vendor account (identification) number.",
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15,
                oldNullable: true,
                oldComment: "Vendor account (identification) number.");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Production",
                table: "UnitMeasure",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "Unit of measure description.",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "Unit of measure description.");

            migrationBuilder.AlterColumn<string>(
                name: "TransactionType",
                schema: "Production",
                table: "TransactionHistoryArchive",
                type: "nchar(1)",
                fixedLength: true,
                maxLength: 1,
                nullable: false,
                defaultValue: "",
                comment: "W = Work Order, S = Sales Order, P = Purchase Order",
                oldClrType: typeof(string),
                oldType: "nchar(1)",
                oldFixedLength: true,
                oldMaxLength: 1,
                oldNullable: true,
                oldComment: "W = Work Order, S = Sales Order, P = Purchase Order");

            migrationBuilder.AlterColumn<string>(
                name: "TransactionType",
                schema: "Production",
                table: "TransactionHistory",
                type: "nchar(1)",
                fixedLength: true,
                maxLength: 1,
                nullable: false,
                defaultValue: "",
                comment: "W = WorkOrder, S = SalesOrder, P = PurchaseOrder",
                oldClrType: typeof(string),
                oldType: "nchar(1)",
                oldFixedLength: true,
                oldMaxLength: 1,
                oldNullable: true,
                oldComment: "W = WorkOrder, S = SalesOrder, P = PurchaseOrder");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Sales",
                table: "Store",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "Name of the store.",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "Name of the store.");

            migrationBuilder.AlterColumn<string>(
                name: "StateProvinceCode",
                schema: "Person",
                table: "StateProvince",
                type: "nchar(3)",
                fixedLength: true,
                maxLength: 3,
                nullable: false,
                defaultValue: "",
                comment: "ISO standard state or province code.",
                oldClrType: typeof(string),
                oldType: "nchar(3)",
                oldFixedLength: true,
                oldMaxLength: 3,
                oldNullable: true,
                oldComment: "ISO standard state or province code.");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Person",
                table: "StateProvince",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "State or province description.",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "State or province description.");

            migrationBuilder.AlterColumn<string>(
                name: "CountryRegionCode",
                schema: "Person",
                table: "StateProvince",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: false,
                defaultValue: "",
                comment: "ISO standard country or region code. Foreign key to CountryRegion.CountryRegionCode. ",
                oldClrType: typeof(string),
                oldType: "nvarchar(3)",
                oldMaxLength: 3,
                oldNullable: true,
                oldComment: "ISO standard country or region code. Foreign key to CountryRegion.CountryRegionCode. ");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                schema: "Sales",
                table: "SpecialOffer",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "Discount type category.",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "Discount type category.");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "Sales",
                table: "SpecialOffer",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                comment: "Discount description.",
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true,
                oldComment: "Discount description.");

            migrationBuilder.AlterColumn<string>(
                name: "Category",
                schema: "Sales",
                table: "SpecialOffer",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "Group the discount applies to such as Reseller or Customer.",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "Group the discount applies to such as Reseller or Customer.");

            migrationBuilder.AlterColumn<string>(
                name: "ShoppingCartID",
                schema: "Sales",
                table: "ShoppingCartItem",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "Shopping cart identification number.",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "Shopping cart identification number.");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Purchasing",
                table: "ShipMethod",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "Shipping company name.",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "Shipping company name.");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "HumanResources",
                table: "Shift",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "Shift description.",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "Shift description.");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Production",
                table: "ScrapReason",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "Failure description.",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "Failure description.");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Sales",
                table: "SalesTerritory",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "Sales territory description",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "Sales territory description");

            migrationBuilder.AlterColumn<string>(
                name: "Group",
                schema: "Sales",
                table: "SalesTerritory",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "Geographic area to which the sales territory belong.",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "Geographic area to which the sales territory belong.");

            migrationBuilder.AlterColumn<string>(
                name: "CountryRegionCode",
                schema: "Sales",
                table: "SalesTerritory",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: false,
                defaultValue: "",
                comment: "ISO standard country or region code. Foreign key to CountryRegion.CountryRegionCode. ",
                oldClrType: typeof(string),
                oldType: "nvarchar(3)",
                oldMaxLength: 3,
                oldNullable: true,
                oldComment: "ISO standard country or region code. Foreign key to CountryRegion.CountryRegionCode. ");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Sales",
                table: "SalesTaxRate",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "Tax rate description.",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "Tax rate description.");

            migrationBuilder.AlterColumn<string>(
                name: "ReasonType",
                schema: "Sales",
                table: "SalesReason",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "Category the sales reason belongs to.",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "Category the sales reason belongs to.");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Sales",
                table: "SalesReason",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "Sales reason description.",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "Sales reason description.");

            migrationBuilder.AlterColumn<string>(
                name: "UnitMeasureCode",
                schema: "Purchasing",
                table: "ProductVendor",
                type: "nchar(3)",
                fixedLength: true,
                maxLength: 3,
                nullable: false,
                defaultValue: "",
                comment: "The product's unit of measure.",
                oldClrType: typeof(string),
                oldType: "nchar(3)",
                oldFixedLength: true,
                oldMaxLength: 3,
                oldNullable: true,
                oldComment: "The product's unit of measure.");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Production",
                table: "ProductSubcategory",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "Subcategory description.",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "Subcategory description.");

            migrationBuilder.AlterColumn<string>(
                name: "ReviewerName",
                schema: "Production",
                table: "ProductReview",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "Name of the reviewer.",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "Name of the reviewer.");

            migrationBuilder.AlterColumn<string>(
                name: "EmailAddress",
                schema: "Production",
                table: "ProductReview",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "Reviewer's e-mail address.",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "Reviewer's e-mail address.");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Production",
                table: "ProductModel",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "Product model description.",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "Product model description.");

            migrationBuilder.AlterColumn<string>(
                name: "Shelf",
                schema: "Production",
                table: "ProductInventory",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "",
                comment: "Storage compartment within an inventory location.",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true,
                oldComment: "Storage compartment within an inventory location.");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "Production",
                table: "ProductDescription",
                type: "nvarchar(400)",
                maxLength: 400,
                nullable: false,
                defaultValue: "",
                comment: "Description of the product.",
                oldClrType: typeof(string),
                oldType: "nvarchar(400)",
                oldMaxLength: 400,
                oldNullable: true,
                oldComment: "Description of the product.");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Production",
                table: "ProductCategory",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "Category description.",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "Category description.");

            migrationBuilder.AlterColumn<string>(
                name: "ProductNumber",
                schema: "Production",
                table: "Product",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "",
                comment: "Unique product identification number.",
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25,
                oldNullable: true,
                oldComment: "Unique product identification number.");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Production",
                table: "Product",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "Name of the product.",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "Name of the product.");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Person",
                table: "PhoneNumberType",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "Name of the telephone number type",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "Name of the telephone number type");

            migrationBuilder.AlterColumn<string>(
                name: "PersonType",
                schema: "Person",
                table: "Person",
                type: "nchar(2)",
                fixedLength: true,
                maxLength: 2,
                nullable: false,
                defaultValue: "",
                comment: "Primary type of person: SC = Store Contact, IN = Individual (retail) customer, SP = Sales person, EM = Employee (non-sales), VC = Vendor contact, GC = General contact",
                oldClrType: typeof(string),
                oldType: "nchar(2)",
                oldFixedLength: true,
                oldMaxLength: 2,
                oldNullable: true,
                oldComment: "Primary type of person: SC = Store Contact, IN = Individual (retail) customer, SP = Sales person, EM = Employee (non-sales), VC = Vendor contact, GC = General contact");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                schema: "Person",
                table: "Person",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "Last name of the person.",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "Last name of the person.");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                schema: "Person",
                table: "Person",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "First name of the person.",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "First name of the person.");

            migrationBuilder.AlterColumn<string>(
                name: "PasswordSalt",
                schema: "Person",
                table: "Password",
                type: "varchar(10)",
                unicode: false,
                maxLength: 10,
                nullable: false,
                defaultValue: "",
                comment: "Random value concatenated with the password string before the password is hashed.",
                oldClrType: typeof(string),
                oldType: "varchar(10)",
                oldUnicode: false,
                oldMaxLength: 10,
                oldNullable: true,
                oldComment: "Random value concatenated with the password string before the password is hashed.");

            migrationBuilder.AlterColumn<string>(
                name: "PasswordHash",
                schema: "Person",
                table: "Password",
                type: "varchar(128)",
                unicode: false,
                maxLength: 128,
                nullable: false,
                defaultValue: "",
                comment: "Password for the e-mail account.",
                oldClrType: typeof(string),
                oldType: "varchar(128)",
                oldUnicode: false,
                oldMaxLength: 128,
                oldNullable: true,
                oldComment: "Password for the e-mail account.");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Production",
                table: "Location",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "Location description.",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "Location description.");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "ErrorLog",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                defaultValue: "",
                comment: "The user who executed the batch in which the error occurred.",
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128,
                oldNullable: true,
                oldComment: "The user who executed the batch in which the error occurred.");

            migrationBuilder.AlterColumn<string>(
                name: "ErrorMessage",
                table: "ErrorLog",
                type: "nvarchar(4000)",
                maxLength: 4000,
                nullable: false,
                defaultValue: "",
                comment: "The message text of the error that occurred.",
                oldClrType: typeof(string),
                oldType: "nvarchar(4000)",
                oldMaxLength: 4000,
                oldNullable: true,
                oldComment: "The message text of the error that occurred.");

            migrationBuilder.AlterColumn<string>(
                name: "NationalIDNumber",
                schema: "HumanResources",
                table: "Employee",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "",
                comment: "Unique national identification number such as a social security number.",
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15,
                oldNullable: true,
                oldComment: "Unique national identification number such as a social security number.");

            migrationBuilder.AlterColumn<string>(
                name: "MaritalStatus",
                schema: "HumanResources",
                table: "Employee",
                type: "nchar(1)",
                fixedLength: true,
                maxLength: 1,
                nullable: false,
                defaultValue: "",
                comment: "M = Married, S = Single",
                oldClrType: typeof(string),
                oldType: "nchar(1)",
                oldFixedLength: true,
                oldMaxLength: 1,
                oldNullable: true,
                oldComment: "M = Married, S = Single");

            migrationBuilder.AlterColumn<string>(
                name: "LoginID",
                schema: "HumanResources",
                table: "Employee",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                comment: "Network login.",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true,
                oldComment: "Network login.");

            migrationBuilder.AlterColumn<string>(
                name: "JobTitle",
                schema: "HumanResources",
                table: "Employee",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "Work title such as Buyer or Sales Representative.",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "Work title such as Buyer or Sales Representative.");

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                schema: "HumanResources",
                table: "Employee",
                type: "nchar(1)",
                fixedLength: true,
                maxLength: 1,
                nullable: false,
                defaultValue: "",
                comment: "M = Male, F = Female",
                oldClrType: typeof(string),
                oldType: "nchar(1)",
                oldFixedLength: true,
                oldMaxLength: 1,
                oldNullable: true,
                oldComment: "M = Male, F = Female");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "HumanResources",
                table: "Department",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "Name of the department.",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "Name of the department.");

            migrationBuilder.AlterColumn<string>(
                name: "GroupName",
                schema: "HumanResources",
                table: "Department",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "Name of the group to which the department belongs.",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "Name of the group to which the department belongs.");

            migrationBuilder.AlterColumn<string>(
                name: "XmlEvent",
                table: "DatabaseLog",
                type: "xml",
                nullable: false,
                defaultValue: "",
                comment: "The raw XML data generated by database trigger.",
                oldClrType: typeof(string),
                oldType: "xml",
                oldNullable: true,
                oldComment: "The raw XML data generated by database trigger.");

            migrationBuilder.AlterColumn<string>(
                name: "TSQL",
                table: "DatabaseLog",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                comment: "The exact Transact-SQL statement that was executed.",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "The exact Transact-SQL statement that was executed.");

            migrationBuilder.AlterColumn<string>(
                name: "Event",
                table: "DatabaseLog",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                defaultValue: "",
                comment: "The type of DDL statement that was executed.",
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128,
                oldNullable: true,
                oldComment: "The type of DDL statement that was executed.");

            migrationBuilder.AlterColumn<string>(
                name: "DatabaseUser",
                table: "DatabaseLog",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                defaultValue: "",
                comment: "The user who implemented the DDL change.",
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128,
                oldNullable: true,
                oldComment: "The user who implemented the DDL change.");

            migrationBuilder.AlterColumn<string>(
                name: "ToCurrencyCode",
                schema: "Sales",
                table: "CurrencyRate",
                type: "nchar(3)",
                fixedLength: true,
                maxLength: 3,
                nullable: false,
                defaultValue: "",
                comment: "Exchange rate was converted to this currency code.",
                oldClrType: typeof(string),
                oldType: "nchar(3)",
                oldFixedLength: true,
                oldMaxLength: 3,
                oldNullable: true,
                oldComment: "Exchange rate was converted to this currency code.");

            migrationBuilder.AlterColumn<string>(
                name: "FromCurrencyCode",
                schema: "Sales",
                table: "CurrencyRate",
                type: "nchar(3)",
                fixedLength: true,
                maxLength: 3,
                nullable: false,
                defaultValue: "",
                comment: "Exchange rate was converted from this currency code.",
                oldClrType: typeof(string),
                oldType: "nchar(3)",
                oldFixedLength: true,
                oldMaxLength: 3,
                oldNullable: true,
                oldComment: "Exchange rate was converted from this currency code.");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Sales",
                table: "Currency",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "Currency name.",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "Currency name.");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Production",
                table: "Culture",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "Culture description.",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "Culture description.");

            migrationBuilder.AlterColumn<string>(
                name: "CardType",
                schema: "Sales",
                table: "CreditCard",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "Credit card name.",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "Credit card name.");

            migrationBuilder.AlterColumn<string>(
                name: "CardNumber",
                schema: "Sales",
                table: "CreditCard",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "",
                comment: "Credit card number.",
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25,
                oldNullable: true,
                oldComment: "Credit card number.");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Person",
                table: "CountryRegion",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "Country or region name.",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "Country or region name.");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Person",
                table: "ContactType",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "Contact type description.",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "Contact type description.");

            migrationBuilder.AlterColumn<string>(
                name: "UnitMeasureCode",
                schema: "Production",
                table: "BillOfMaterials",
                type: "nchar(3)",
                fixedLength: true,
                maxLength: 3,
                nullable: false,
                defaultValue: "",
                comment: "Standard code identifying the unit of measure for the quantity.",
                oldClrType: typeof(string),
                oldType: "nchar(3)",
                oldFixedLength: true,
                oldMaxLength: 3,
                oldNullable: true,
                oldComment: "Standard code identifying the unit of measure for the quantity.");

            migrationBuilder.AlterColumn<string>(
                name: "Database Version",
                table: "AWBuildVersion",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "",
                comment: "Version number of the database in 9.yy.mm.dd.00 format.",
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25,
                oldNullable: true,
                oldComment: "Version number of the database in 9.yy.mm.dd.00 format.");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Person",
                table: "AddressType",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "Address type description. For example, Billing, Home, or Shipping.",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "Address type description. For example, Billing, Home, or Shipping.");

            migrationBuilder.AlterColumn<string>(
                name: "PostalCode",
                schema: "Person",
                table: "Address",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "",
                comment: "Postal code for the street address.",
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15,
                oldNullable: true,
                oldComment: "Postal code for the street address.");

            migrationBuilder.AlterColumn<string>(
                name: "City",
                schema: "Person",
                table: "Address",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "",
                comment: "Name of the city.",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldNullable: true,
                oldComment: "Name of the city.");

            migrationBuilder.AlterColumn<string>(
                name: "AddressLine1",
                schema: "Person",
                table: "Address",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                defaultValue: "",
                comment: "First street address line.",
                oldClrType: typeof(string),
                oldType: "nvarchar(60)",
                oldMaxLength: 60,
                oldNullable: true,
                oldComment: "First street address line.");

            migrationBuilder.AlterColumn<string>(
                name: "SalesOrderNumber",
                schema: "Sales",
                table: "SalesOrderHeader",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                computedColumnSql: "(isnull(N'SO'+CONVERT([nvarchar](23),[SalesOrderID]),N'*** ERROR ***'))",
                stored: false,
                comment: "Unique sales order identification number.",
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25,
                oldNullable: true,
                oldComputedColumnSql: "(isnull(N'SO'+CONVERT([nvarchar](23),[SalesOrderID]),N'*** ERROR ***'))",
                oldStored: false,
                oldComment: "Unique sales order identification number.");

            migrationBuilder.AlterColumn<string>(
                name: "AccountNumber",
                schema: "Sales",
                table: "Customer",
                type: "varchar(10)",
                unicode: false,
                maxLength: 10,
                nullable: false,
                computedColumnSql: "(isnull('AW'+[dbo].[ufnLeadingZeros]([CustomerID]),''))",
                stored: false,
                comment: "Unique number identifying the customer assigned by the accounting system.",
                oldClrType: typeof(string),
                oldType: "varchar(10)",
                oldUnicode: false,
                oldMaxLength: 10,
                oldNullable: true,
                oldComputedColumnSql: "(isnull('AW'+[dbo].[ufnLeadingZeros]([CustomerID]),''))",
                oldStored: false,
                oldComment: "Unique number identifying the customer assigned by the accounting system.");

            migrationBuilder.CreateIndex(
                name: "AK_Vendor_AccountNumber",
                schema: "Purchasing",
                table: "Vendor",
                column: "AccountNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_UnitMeasure_Name",
                schema: "Production",
                table: "UnitMeasure",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_StateProvince_Name",
                schema: "Person",
                table: "StateProvince",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_StateProvince_StateProvinceCode_CountryRegionCode",
                schema: "Person",
                table: "StateProvince",
                columns: new[] { "StateProvinceCode", "CountryRegionCode" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_ShipMethod_Name",
                schema: "Purchasing",
                table: "ShipMethod",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_Shift_Name",
                schema: "HumanResources",
                table: "Shift",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_ScrapReason_Name",
                schema: "Production",
                table: "ScrapReason",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_SalesTerritory_Name",
                schema: "Sales",
                table: "SalesTerritory",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_SalesOrderHeader_SalesOrderNumber",
                schema: "Sales",
                table: "SalesOrderHeader",
                column: "SalesOrderNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_ProductSubcategory_Name",
                schema: "Production",
                table: "ProductSubcategory",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_ProductModel_Name",
                schema: "Production",
                table: "ProductModel",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_ProductCategory_Name",
                schema: "Production",
                table: "ProductCategory",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_Product_Name",
                schema: "Production",
                table: "Product",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_Product_ProductNumber",
                schema: "Production",
                table: "Product",
                column: "ProductNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_Location_Name",
                schema: "Production",
                table: "Location",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_Employee_LoginID",
                schema: "HumanResources",
                table: "Employee",
                column: "LoginID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_Employee_NationalIDNumber",
                schema: "HumanResources",
                table: "Employee",
                column: "NationalIDNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_Department_Name",
                schema: "HumanResources",
                table: "Department",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_Customer_AccountNumber",
                schema: "Sales",
                table: "Customer",
                column: "AccountNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_CurrencyRate_CurrencyRateDate_FromCurrencyCode_ToCurrencyCode",
                schema: "Sales",
                table: "CurrencyRate",
                columns: new[] { "CurrencyRateDate", "FromCurrencyCode", "ToCurrencyCode" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_Currency_Name",
                schema: "Sales",
                table: "Currency",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_Culture_Name",
                schema: "Production",
                table: "Culture",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_CreditCard_CardNumber",
                schema: "Sales",
                table: "CreditCard",
                column: "CardNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_CountryRegion_Name",
                schema: "Person",
                table: "CountryRegion",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_ContactType_Name",
                schema: "Person",
                table: "ContactType",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_AddressType_Name",
                schema: "Person",
                table: "AddressType",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Address_AddressLine1_AddressLine2_City_StateProvinceID_PostalCode",
                schema: "Person",
                table: "Address",
                columns: new[] { "AddressLine1", "AddressLine2", "City", "StateProvinceID", "PostalCode" },
                unique: true,
                filter: "[AddressLine2] IS NOT NULL");
        }
    }
}
