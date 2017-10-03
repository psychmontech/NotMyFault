using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace NotMyFault.Migrations
{
    public partial class testing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    AdministratorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NickName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Thumbnail = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.AdministratorId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    CompanyAddr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Earnest = table.Column<int>(type: "int", nullable: true),
                    Credit = table.Column<int>(type: "int", nullable: true),
                    EmailAddr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkedinUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumProjWrkOn = table.Column<int>(type: "int", nullable: true),
                    SelfIntro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    NickName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Thumbnail = table.Column<byte>(type: "tinyint", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CandiRqrmts",
                columns: table => new
                {
                    CandiRqrmtId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Availability = table.Column<int>(type: "int", nullable: false),
                    Expertise = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxNumPrjWkOn = table.Column<int>(type: "int", nullable: false),
                    MinCredit = table.Column<int>(type: "int", nullable: false),
                    RecruitmentForeignKey = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandiRqrmts", x => x.CandiRqrmtId);
                });

            migrationBuilder.CreateTable(
                name: "TradeBoxes",
                columns: table => new
                {
                    TradeBoxId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GdInPlcTs = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GdVerifiedTs = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Goods = table.Column<byte>(type: "tinyint", nullable: false),
                    IsEmpty = table.Column<bool>(type: "bit", nullable: false),
                    IsGdInPlc = table.Column<bool>(type: "bit", nullable: false),
                    IsGdVerified = table.Column<bool>(type: "bit", nullable: false),
                    IsMoneyInPlc = table.Column<bool>(type: "bit", nullable: false),
                    IsMoneyVerified = table.Column<bool>(type: "bit", nullable: false),
                    IsReadyForEx = table.Column<bool>(type: "bit", nullable: false),
                    MoneyInPlcTs = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MoneyVerifiedTs = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TransactionForeignKey = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TradeBoxes", x => x.TradeBoxId);
                });

            migrationBuilder.CreateTable(
                name: "Visitors",
                columns: table => new
                {
                    NickName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAnonumous = table.Column<bool>(type: "bit", nullable: false),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visitors", x => x.NickName);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: false)
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
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
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
                    UserId = table.Column<int>(type: "int", nullable: false)
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
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
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
                    UserId = table.Column<int>(type: "int", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "BankDetails",
                columns: table => new
                {
                    BankDetailsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AcctName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AcctNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeveloperForeignKey = table.Column<int>(type: "int", nullable: false),
                    SwiftCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankDetails", x => x.BankDetailsId);
                    table.ForeignKey(
                        name: "FK_BankDetails_AspNetUsers_DeveloperForeignKey",
                        column: x => x.DeveloperForeignKey,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Endorsments",
                columns: table => new
                {
                    EndorsmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EndorsGivenForeignKey = table.Column<int>(type: "int", nullable: false),
                    EndorsGiverForeignKey = table.Column<int>(type: "int", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endorsments", x => x.EndorsmentId);
                    table.ForeignKey(
                        name: "FK_Endorsments_AspNetUsers_EndorsGivenForeignKey",
                        column: x => x.EndorsGivenForeignKey,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Endorsments_AspNetUsers_EndorsGiverForeignKey",
                        column: x => x.EndorsGiverForeignKey,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BriefDescript = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    DeveloperForeignKey = table.Column<int>(type: "int", nullable: false),
                    FullDescript = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InitiatorIdForeignKey = table.Column<int>(type: "int", nullable: false),
                    LeaderIdForeignKey = table.Column<int>(type: "int", nullable: false),
                    MyGallery = table.Column<byte>(type: "tinyint", nullable: false),
                    NextMeetingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Progress = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    ProjName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProtdCompDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RepoLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Thumbnail = table.Column<byte>(type: "tinyint", nullable: false),
                    Valuation = table.Column<long>(type: "bigint", nullable: false),
                    Visibility = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectId);
                    table.ForeignKey(
                        name: "FK_Projects_AspNetUsers_InitiatorIdForeignKey",
                        column: x => x.InitiatorIdForeignKey,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Projects_AspNetUsers_LeaderIdForeignKey",
                        column: x => x.LeaderIdForeignKey,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RevieweeIdForeignKey = table.Column<int>(type: "int", nullable: false),
                    ReviewerIdForeignKey = table.Column<int>(type: "int", nullable: false),
                    Stars = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Timestamp);
                    table.ForeignKey(
                        name: "FK_Reviews_AspNetUsers_RevieweeIdForeignKey",
                        column: x => x.RevieweeIdForeignKey,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_AspNetUsers_ReviewerIdForeignKey",
                        column: x => x.ReviewerIdForeignKey,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SupptNAllegs",
                columns: table => new
                {
                    SupptNAllegId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MyUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupptNAllegs", x => x.SupptNAllegId);
                    table.ForeignKey(
                        name: "FK_SupptNAllegs_AspNetUsers_MyUserId",
                        column: x => x.MyUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BuyerProject",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuyerProject", x => new { x.Id, x.ProjectId });
                    table.ForeignKey(
                        name: "FK_BuyerProject_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BuyerProject_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DeveloperProject",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeveloperProject", x => new { x.Id, x.ProjectId });
                    table.ForeignKey(
                        name: "FK_DeveloperProject_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeveloperProject_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Distributions",
                columns: table => new
                {
                    DistributionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Divisor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectForeignKey = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Distributions", x => x.DistributionId);
                    table.ForeignKey(
                        name: "FK_Distributions_Projects_ProjectForeignKey",
                        column: x => x.ProjectForeignKey,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InternalConver",
                columns: table => new
                {
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeveloperForeignKey = table.Column<int>(type: "int", nullable: false),
                    ProjectForeignKey = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternalConver", x => x.Timestamp);
                    table.ForeignKey(
                        name: "FK_InternalConver_AspNetUsers_DeveloperForeignKey",
                        column: x => x.DeveloperForeignKey,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InternalConver_Projects_ProjectForeignKey",
                        column: x => x.ProjectForeignKey,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Likes",
                columns: table => new
                {
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsVisitor = table.Column<bool>(type: "bit", nullable: false),
                    ProjectForeignKey = table.Column<int>(type: "int", nullable: false),
                    UserForeignKey = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likes", x => x.Timestamp);
                    table.ForeignKey(
                        name: "FK_Likes_Projects_ProjectForeignKey",
                        column: x => x.ProjectForeignKey,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Likes_AspNetUsers_UserForeignKey",
                        column: x => x.UserForeignKey,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Negotiations",
                columns: table => new
                {
                    NegotiationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BuyerForeignKey = table.Column<int>(type: "int", nullable: false),
                    ProjectForeignKey = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Negotiations", x => x.NegotiationId);
                    table.ForeignKey(
                        name: "FK_Negotiations_AspNetUsers_BuyerForeignKey",
                        column: x => x.BuyerForeignKey,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Negotiations_Projects_ProjectForeignKey",
                        column: x => x.ProjectForeignKey,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PublicOpinions",
                columns: table => new
                {
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MyVisitorNickName = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ProjectForeignKey = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicOpinions", x => x.Timestamp);
                    table.ForeignKey(
                        name: "FK_PublicOpinions_Visitors_MyVisitorNickName",
                        column: x => x.MyVisitorNickName,
                        principalTable: "Visitors",
                        principalColumn: "NickName",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PublicOpinions_Projects_ProjectForeignKey",
                        column: x => x.ProjectForeignKey,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Recruitments",
                columns: table => new
                {
                    RecruitmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsOpen = table.Column<bool>(type: "bit", nullable: false),
                    NameOfTheRole = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectForeignKey = table.Column<int>(type: "int", nullable: true),
                    RecruitmentForeignKey = table.Column<int>(type: "int", nullable: true),
                    RoleDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recruitments", x => x.RecruitmentId);
                    table.ForeignKey(
                        name: "FK_Recruitments_Projects_ProjectForeignKey",
                        column: x => x.ProjectForeignKey,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Recruitments_CandiRqrmts_RecruitmentForeignKey",
                        column: x => x.RecruitmentForeignKey,
                        principalTable: "CandiRqrmts",
                        principalColumn: "CandiRqrmtId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TranId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BuyerForeignKey = table.Column<int>(type: "int", nullable: false),
                    Currency = table.Column<int>(type: "int", nullable: false),
                    DateAborted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateCompleted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsAborted = table.Column<bool>(type: "bit", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    ProjectForeignKey = table.Column<int>(type: "int", nullable: false),
                    TranAmount = table.Column<long>(type: "bigint", nullable: false),
                    TransactionForeignKey = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TranId);
                    table.ForeignKey(
                        name: "FK_Transactions_AspNetUsers_BuyerForeignKey",
                        column: x => x.BuyerForeignKey,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transactions_Projects_ProjectForeignKey",
                        column: x => x.ProjectForeignKey,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transactions_TradeBoxes_TransactionForeignKey",
                        column: x => x.TransactionForeignKey,
                        principalTable: "TradeBoxes",
                        principalColumn: "TradeBoxId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserProject",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProject", x => new { x.Id, x.ProjectId });
                    table.ForeignKey(
                        name: "FK_UserProject_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserProject_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SNAEntries",
                columns: table => new
                {
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MyAdminAdministratorId = table.Column<int>(type: "int", nullable: true),
                    MySNASupptNAllegId = table.Column<int>(type: "int", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SNAEntries", x => x.Timestamp);
                    table.ForeignKey(
                        name: "FK_SNAEntries_Admins_MyAdminAdministratorId",
                        column: x => x.MyAdminAdministratorId,
                        principalTable: "Admins",
                        principalColumn: "AdministratorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SNAEntries_SupptNAllegs_MySNASupptNAllegId",
                        column: x => x.MySNASupptNAllegId,
                        principalTable: "SupptNAllegs",
                        principalColumn: "SupptNAllegId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NegoEntries",
                columns: table => new
                {
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NegoForeignKey = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NegoEntries", x => x.Timestamp);
                    table.ForeignKey(
                        name: "FK_NegoEntries_Negotiations_NegoForeignKey",
                        column: x => x.NegoForeignKey,
                        principalTable: "Negotiations",
                        principalColumn: "NegotiationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeveloperRecruitment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    RecruitmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeveloperRecruitment", x => new { x.Id, x.RecruitmentId });
                    table.ForeignKey(
                        name: "FK_DeveloperRecruitment_Recruitments_Id",
                        column: x => x.Id,
                        principalTable: "Recruitments",
                        principalColumn: "RecruitmentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeveloperRecruitment_AspNetUsers_RecruitmentId",
                        column: x => x.RecruitmentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Interviews",
                columns: table => new
                {
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DevIntwveeForeignKey = table.Column<int>(type: "int", nullable: false),
                    DevIntwverForeignKey = table.Column<int>(type: "int", nullable: false),
                    RecruitmentForeignKey = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interviews", x => x.Time);
                    table.ForeignKey(
                        name: "FK_Interviews_AspNetUsers_DevIntwveeForeignKey",
                        column: x => x.DevIntwveeForeignKey,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Interviews_AspNetUsers_DevIntwverForeignKey",
                        column: x => x.DevIntwverForeignKey,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Interviews_Recruitments_RecruitmentForeignKey",
                        column: x => x.RecruitmentForeignKey,
                        principalTable: "Recruitments",
                        principalColumn: "RecruitmentId",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateIndex(
                name: "IX_BankDetails_DeveloperForeignKey",
                table: "BankDetails",
                column: "DeveloperForeignKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BuyerProject_ProjectId",
                table: "BuyerProject",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_DeveloperProject_ProjectId",
                table: "DeveloperProject",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_DeveloperRecruitment_RecruitmentId",
                table: "DeveloperRecruitment",
                column: "RecruitmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Distributions_ProjectForeignKey",
                table: "Distributions",
                column: "ProjectForeignKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Endorsments_EndorsGivenForeignKey",
                table: "Endorsments",
                column: "EndorsGivenForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_Endorsments_EndorsGiverForeignKey",
                table: "Endorsments",
                column: "EndorsGiverForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_InternalConver_DeveloperForeignKey",
                table: "InternalConver",
                column: "DeveloperForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_InternalConver_ProjectForeignKey",
                table: "InternalConver",
                column: "ProjectForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_Interviews_DevIntwveeForeignKey",
                table: "Interviews",
                column: "DevIntwveeForeignKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Interviews_DevIntwverForeignKey",
                table: "Interviews",
                column: "DevIntwverForeignKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Interviews_RecruitmentForeignKey",
                table: "Interviews",
                column: "RecruitmentForeignKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Likes_ProjectForeignKey",
                table: "Likes",
                column: "ProjectForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_UserForeignKey",
                table: "Likes",
                column: "UserForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_NegoEntries_NegoForeignKey",
                table: "NegoEntries",
                column: "NegoForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_Negotiations_BuyerForeignKey",
                table: "Negotiations",
                column: "BuyerForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_Negotiations_ProjectForeignKey",
                table: "Negotiations",
                column: "ProjectForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_InitiatorIdForeignKey",
                table: "Projects",
                column: "InitiatorIdForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_LeaderIdForeignKey",
                table: "Projects",
                column: "LeaderIdForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_PublicOpinions_MyVisitorNickName",
                table: "PublicOpinions",
                column: "MyVisitorNickName");

            migrationBuilder.CreateIndex(
                name: "IX_PublicOpinions_ProjectForeignKey",
                table: "PublicOpinions",
                column: "ProjectForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_Recruitments_ProjectForeignKey",
                table: "Recruitments",
                column: "ProjectForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_Recruitments_RecruitmentForeignKey",
                table: "Recruitments",
                column: "RecruitmentForeignKey",
                unique: true,
                filter: "[RecruitmentForeignKey] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_RevieweeIdForeignKey",
                table: "Reviews",
                column: "RevieweeIdForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ReviewerIdForeignKey",
                table: "Reviews",
                column: "ReviewerIdForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_SNAEntries_MyAdminAdministratorId",
                table: "SNAEntries",
                column: "MyAdminAdministratorId");

            migrationBuilder.CreateIndex(
                name: "IX_SNAEntries_MySNASupptNAllegId",
                table: "SNAEntries",
                column: "MySNASupptNAllegId");

            migrationBuilder.CreateIndex(
                name: "IX_SupptNAllegs_MyUserId",
                table: "SupptNAllegs",
                column: "MyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_BuyerForeignKey",
                table: "Transactions",
                column: "BuyerForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_ProjectForeignKey",
                table: "Transactions",
                column: "ProjectForeignKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_TransactionForeignKey",
                table: "Transactions",
                column: "TransactionForeignKey",
                unique: true,
                filter: "[TransactionForeignKey] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserProject_ProjectId",
                table: "UserProject",
                column: "ProjectId");
        }

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
                name: "BankDetails");

            migrationBuilder.DropTable(
                name: "BuyerProject");

            migrationBuilder.DropTable(
                name: "DeveloperProject");

            migrationBuilder.DropTable(
                name: "DeveloperRecruitment");

            migrationBuilder.DropTable(
                name: "Distributions");

            migrationBuilder.DropTable(
                name: "Endorsments");

            migrationBuilder.DropTable(
                name: "InternalConver");

            migrationBuilder.DropTable(
                name: "Interviews");

            migrationBuilder.DropTable(
                name: "Likes");

            migrationBuilder.DropTable(
                name: "NegoEntries");

            migrationBuilder.DropTable(
                name: "PublicOpinions");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "SNAEntries");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "UserProject");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Recruitments");

            migrationBuilder.DropTable(
                name: "Negotiations");

            migrationBuilder.DropTable(
                name: "Visitors");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "SupptNAllegs");

            migrationBuilder.DropTable(
                name: "TradeBoxes");

            migrationBuilder.DropTable(
                name: "CandiRqrmts");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
