using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace NotMyFault.Migrations
{
    public partial class test : Migration
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
                name: "CandiRqrmts",
                columns: table => new
                {
                    CandiRqrmtId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Availability = table.Column<int>(type: "int", nullable: false),
                    Expertise = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MinCredit = table.Column<int>(type: "int", nullable: false),
                    RecruitmentForeignKey = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandiRqrmts", x => x.CandiRqrmtId);
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
                name: "SNAEntry",
                columns: table => new
                {
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MyAdminAdministratorId = table.Column<int>(type: "int", nullable: true),
                    MySNASupptNAllegId = table.Column<int>(type: "int", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SNAEntry", x => x.Timestamp);
                    table.ForeignKey(
                        name: "FK_SNAEntry_Admins_MyAdminAdministratorId",
                        column: x => x.MyAdminAdministratorId,
                        principalTable: "Admins",
                        principalColumn: "AdministratorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Recruitments",
                columns: table => new
                {
                    RecruitmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProjectForeignKey = table.Column<int>(type: "int", nullable: true),
                    RecruitmentForeignKey = table.Column<int>(type: "int", nullable: true),
                    RoleDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recruitments", x => x.RecruitmentId);
                    table.ForeignKey(
                        name: "FK_Recruitments_CandiRqrmts_RecruitmentForeignKey",
                        column: x => x.RecruitmentForeignKey,
                        principalTable: "CandiRqrmts",
                        principalColumn: "CandiRqrmtId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    CompanyAddr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Earnest = table.Column<long>(type: "bigint", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: true),
                    Credit = table.Column<int>(type: "int", nullable: true),
                    DistributionId = table.Column<int>(type: "int", nullable: true),
                    EmailAddr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkedinUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MySkills = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransactionTranId = table.Column<long>(type: "bigint", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NickName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Thumbnail = table.Column<byte>(type: "tinyint", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
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
                        name: "FK_BankDetails_User_DeveloperForeignKey",
                        column: x => x.DeveloperForeignKey,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeveloperRecruitment",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RecruitmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeveloperRecruitment", x => new { x.UserId, x.RecruitmentId });
                    table.ForeignKey(
                        name: "FK_DeveloperRecruitment_User_RecruitmentId",
                        column: x => x.RecruitmentId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeveloperRecruitment_Recruitments_UserId",
                        column: x => x.UserId,
                        principalTable: "Recruitments",
                        principalColumn: "RecruitmentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Endorsments",
                columns: table => new
                {
                    EndorsmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EndorsGivenForeignKey = table.Column<int>(type: "int", nullable: false),
                    EndorsGiverForeignKey = table.Column<int>(type: "int", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    subject = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endorsments", x => x.EndorsmentId);
                    table.ForeignKey(
                        name: "FK_Endorsments_User_EndorsGivenForeignKey",
                        column: x => x.EndorsGivenForeignKey,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Endorsments_User_EndorsGiverForeignKey",
                        column: x => x.EndorsGiverForeignKey,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Interviews",
                columns: table => new
                {
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IntervieweeUserId = table.Column<int>(type: "int", nullable: true),
                    InterviewerUserId = table.Column<int>(type: "int", nullable: true),
                    RecruitmentForeignKey = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interviews", x => x.Time);
                    table.ForeignKey(
                        name: "FK_Interviews_User_IntervieweeUserId",
                        column: x => x.IntervieweeUserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Interviews_User_InterviewerUserId",
                        column: x => x.InterviewerUserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Interviews_Recruitments_RecruitmentForeignKey",
                        column: x => x.RecruitmentForeignKey,
                        principalTable: "Recruitments",
                        principalColumn: "RecruitmentId",
                        onDelete: ReferentialAction.Cascade);
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
                        name: "FK_Projects_User_InitiatorIdForeignKey",
                        column: x => x.InitiatorIdForeignKey,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Projects_User_LeaderIdForeignKey",
                        column: x => x.LeaderIdForeignKey,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Review",
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
                    table.PrimaryKey("PK_Review", x => x.Timestamp);
                    table.ForeignKey(
                        name: "FK_Review_User_RevieweeIdForeignKey",
                        column: x => x.RevieweeIdForeignKey,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Review_User_ReviewerIdForeignKey",
                        column: x => x.ReviewerIdForeignKey,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SupptNAllegs",
                columns: table => new
                {
                    SupptNAllegId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MyUserUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupptNAllegs", x => x.SupptNAllegId);
                    table.ForeignKey(
                        name: "FK_SupptNAllegs_User_MyUserUserId",
                        column: x => x.MyUserUserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BuyerProject",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuyerProject", x => new { x.UserId, x.ProjectId });
                    table.ForeignKey(
                        name: "FK_BuyerProject_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BuyerProject_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DeveloperProject",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeveloperProject", x => new { x.UserId, x.ProjectId });
                    table.ForeignKey(
                        name: "FK_DeveloperProject_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeveloperProject_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Distributions",
                columns: table => new
                {
                    DistributionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProjectForeignKey = table.Column<int>(type: "int", nullable: false),
                    divisor = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    ByDevUserId = table.Column<int>(type: "int", nullable: true),
                    ProjectForeignKey = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternalConver", x => x.Timestamp);
                    table.ForeignKey(
                        name: "FK_InternalConver_User_ByDevUserId",
                        column: x => x.ByDevUserId,
                        principalTable: "User",
                        principalColumn: "UserId",
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
                    LikerUserId = table.Column<int>(type: "int", nullable: true),
                    ProjectForeignKey = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likes", x => x.Timestamp);
                    table.ForeignKey(
                        name: "FK_Likes_User_LikerUserId",
                        column: x => x.LikerUserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Likes_Projects_ProjectForeignKey",
                        column: x => x.ProjectForeignKey,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Negotiations",
                columns: table => new
                {
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MyBuyerUserId = table.Column<int>(type: "int", nullable: true),
                    ProjectForeignKey = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Negotiations", x => x.Timestamp);
                    table.ForeignKey(
                        name: "FK_Negotiations_User_MyBuyerUserId",
                        column: x => x.MyBuyerUserId,
                        principalTable: "User",
                        principalColumn: "UserId",
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
                    MyProjProjectId = table.Column<int>(type: "int", nullable: true),
                    TransactionForeignKey = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TradeBoxes", x => x.TradeBoxId);
                    table.ForeignKey(
                        name: "FK_TradeBoxes_Projects_MyProjProjectId",
                        column: x => x.MyProjProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserProject",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProject", x => new { x.UserId, x.ProjectId });
                    table.ForeignKey(
                        name: "FK_UserProject_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserProject_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NegoEntries",
                columns: table => new
                {
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BuyerUserId = table.Column<int>(type: "int", nullable: true),
                    DeveloperUserId = table.Column<int>(type: "int", nullable: true),
                    NegoForeignKey = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NegoEntries", x => x.Timestamp);
                    table.ForeignKey(
                        name: "FK_NegoEntries_User_BuyerUserId",
                        column: x => x.BuyerUserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NegoEntries_User_DeveloperUserId",
                        column: x => x.DeveloperUserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NegoEntries_Negotiations_NegoForeignKey",
                        column: x => x.NegoForeignKey,
                        principalTable: "Negotiations",
                        principalColumn: "Timestamp",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TranId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateAborted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateCompleted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsAborted = table.Column<bool>(type: "bit", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    MyBuyerUserId = table.Column<int>(type: "int", nullable: true),
                    ProjectForeignKey = table.Column<int>(type: "int", nullable: false),
                    TranAmount = table.Column<long>(type: "bigint", nullable: false),
                    TransactionForeignKey = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TranId);
                    table.ForeignKey(
                        name: "FK_Transactions_User_MyBuyerUserId",
                        column: x => x.MyBuyerUserId,
                        principalTable: "User",
                        principalColumn: "UserId",
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
                name: "IX_InternalConver_ByDevUserId",
                table: "InternalConver",
                column: "ByDevUserId");

            migrationBuilder.CreateIndex(
                name: "IX_InternalConver_ProjectForeignKey",
                table: "InternalConver",
                column: "ProjectForeignKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Interviews_IntervieweeUserId",
                table: "Interviews",
                column: "IntervieweeUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Interviews_InterviewerUserId",
                table: "Interviews",
                column: "InterviewerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Interviews_RecruitmentForeignKey",
                table: "Interviews",
                column: "RecruitmentForeignKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Likes_LikerUserId",
                table: "Likes",
                column: "LikerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_ProjectForeignKey",
                table: "Likes",
                column: "ProjectForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_NegoEntries_BuyerUserId",
                table: "NegoEntries",
                column: "BuyerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_NegoEntries_DeveloperUserId",
                table: "NegoEntries",
                column: "DeveloperUserId");

            migrationBuilder.CreateIndex(
                name: "IX_NegoEntries_NegoForeignKey",
                table: "NegoEntries",
                column: "NegoForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_Negotiations_MyBuyerUserId",
                table: "Negotiations",
                column: "MyBuyerUserId");

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
                column: "ProjectForeignKey",
                unique: true,
                filter: "[ProjectForeignKey] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Recruitments_RecruitmentForeignKey",
                table: "Recruitments",
                column: "RecruitmentForeignKey",
                unique: true,
                filter: "[RecruitmentForeignKey] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Review_RevieweeIdForeignKey",
                table: "Review",
                column: "RevieweeIdForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_Review_ReviewerIdForeignKey",
                table: "Review",
                column: "ReviewerIdForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_SNAEntry_MyAdminAdministratorId",
                table: "SNAEntry",
                column: "MyAdminAdministratorId");

            migrationBuilder.CreateIndex(
                name: "IX_SNAEntry_MySNASupptNAllegId",
                table: "SNAEntry",
                column: "MySNASupptNAllegId");

            migrationBuilder.CreateIndex(
                name: "IX_SupptNAllegs_MyUserUserId",
                table: "SupptNAllegs",
                column: "MyUserUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TradeBoxes_MyProjProjectId",
                table: "TradeBoxes",
                column: "MyProjProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_MyBuyerUserId",
                table: "Transactions",
                column: "MyBuyerUserId");

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
                name: "IX_User_DistributionId",
                table: "User",
                column: "DistributionId");

            migrationBuilder.CreateIndex(
                name: "IX_User_TransactionTranId",
                table: "User",
                column: "TransactionTranId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProject_ProjectId",
                table: "UserProject",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_SNAEntry_SupptNAllegs_MySNASupptNAllegId",
                table: "SNAEntry",
                column: "MySNASupptNAllegId",
                principalTable: "SupptNAllegs",
                principalColumn: "SupptNAllegId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Recruitments_Projects_ProjectForeignKey",
                table: "Recruitments",
                column: "ProjectForeignKey",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Distributions_DistributionId",
                table: "User",
                column: "DistributionId",
                principalTable: "Distributions",
                principalColumn: "DistributionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Transactions_TransactionTranId",
                table: "User",
                column: "TransactionTranId",
                principalTable: "Transactions",
                principalColumn: "TranId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_User_InitiatorIdForeignKey",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_User_LeaderIdForeignKey",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_User_MyBuyerUserId",
                table: "Transactions");

            migrationBuilder.DropTable(
                name: "BankDetails");

            migrationBuilder.DropTable(
                name: "BuyerProject");

            migrationBuilder.DropTable(
                name: "DeveloperProject");

            migrationBuilder.DropTable(
                name: "DeveloperRecruitment");

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
                name: "Review");

            migrationBuilder.DropTable(
                name: "SNAEntry");

            migrationBuilder.DropTable(
                name: "UserProject");

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
                name: "CandiRqrmts");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Distributions");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "TradeBoxes");

            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
