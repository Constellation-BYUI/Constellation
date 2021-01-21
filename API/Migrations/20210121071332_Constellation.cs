using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class Constellation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContactLink",
                columns: table => new
                {
                    ContactLinkID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ContactLinkLabel = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    ContactLinkUrl = table.Column<string>(type: "TEXT", nullable: true),
                    UsersId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactLink", x => x.ContactLinkID);
                    table.ForeignKey(
                        name: "FK_ContactLink_AspNetUsers_UsersId",
                        column: x => x.UsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Discipline",
                columns: table => new
                {
                    DisciplineID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DisciplineName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discipline", x => x.DisciplineID);
                });

            migrationBuilder.CreateTable(
                name: "Posting",
                columns: table => new
                {
                    PostingID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PostingTitle = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    PostingFor = table.Column<string>(type: "TEXT", nullable: false),
                    PostingOwnerId = table.Column<int>(type: "INTEGER", nullable: true),
                    SharableToTeam = table.Column<bool>(type: "INTEGER", nullable: false),
                    HidePosting = table.Column<bool>(type: "INTEGER", nullable: false),
                    ApplicationURL = table.Column<string>(type: "TEXT", nullable: true),
                    ApplicationDeadline = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Location = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posting", x => x.PostingID);
                    table.ForeignKey(
                        name: "FK_Posting_AspNetUsers_PostingOwnerId",
                        column: x => x.PostingOwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PostingType",
                columns: table => new
                {
                    PostingTypeID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PostingTypeName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostingType", x => x.PostingTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    ProjectID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: false),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PhotoPath = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.ProjectID);
                });

            migrationBuilder.CreateTable(
                name: "Skill",
                columns: table => new
                {
                    SkillID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SkillName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skill", x => x.SkillID);
                });

            migrationBuilder.CreateTable(
                name: "SkillLink",
                columns: table => new
                {
                    SkillLinkID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SkillLinkUrl = table.Column<string>(type: "TEXT", nullable: true),
                    SkilLinkLabel = table.Column<string>(type: "TEXT", nullable: true),
                    SkillLinkOwner = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillLink", x => x.SkillLinkID);
                });

            migrationBuilder.CreateTable(
                name: "StarredUser",
                columns: table => new
                {
                    StarredUserID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserStarredID = table.Column<int>(type: "INTEGER", nullable: false),
                    StarredOwnerID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StarredUser", x => x.StarredUserID);
                    table.ForeignKey(
                        name: "FK_StarredUser_AspNetUsers_StarredOwnerID",
                        column: x => x.StarredOwnerID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StarredUser_AspNetUsers_UserStarredID",
                        column: x => x.UserStarredID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IntrestedCandidate",
                columns: table => new
                {
                    IntrestedCandidateID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserID = table.Column<int>(type: "INTEGER", nullable: false),
                    PostingID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IntrestedCandidate", x => x.IntrestedCandidateID);
                    table.ForeignKey(
                        name: "FK_IntrestedCandidate_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IntrestedCandidate_Posting_PostingID",
                        column: x => x.PostingID,
                        principalTable: "Posting",
                        principalColumn: "PostingID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecruiterPicks",
                columns: table => new
                {
                    RecuiterPicksID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ListTitle = table.Column<string>(type: "TEXT", nullable: true),
                    RecuiterID = table.Column<int>(type: "INTEGER", nullable: false),
                    CandidateID = table.Column<int>(type: "INTEGER", nullable: false),
                    PostingID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecruiterPicks", x => x.RecuiterPicksID);
                    table.ForeignKey(
                        name: "FK_RecruiterPicks_AspNetUsers_CandidateID",
                        column: x => x.CandidateID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecruiterPicks_AspNetUsers_RecuiterID",
                        column: x => x.RecuiterID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecruiterPicks_Posting_PostingID",
                        column: x => x.PostingID,
                        principalTable: "Posting",
                        principalColumn: "PostingID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StarredPosting",
                columns: table => new
                {
                    StarredPostingID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserID = table.Column<int>(type: "INTEGER", nullable: false),
                    PostingID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StarredPosting", x => x.StarredPostingID);
                    table.ForeignKey(
                        name: "FK_StarredPosting_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StarredPosting_Posting_PostingID",
                        column: x => x.PostingID,
                        principalTable: "Posting",
                        principalColumn: "PostingID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Posting_PostingType",
                columns: table => new
                {
                    Posting_PostingTypeID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PostingID = table.Column<int>(type: "INTEGER", nullable: false),
                    PostingTypeID = table.Column<int>(type: "INTEGER", nullable: false),
                    Assigned = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posting_PostingType", x => x.Posting_PostingTypeID);
                    table.ForeignKey(
                        name: "FK_Posting_PostingType_Posting_PostingID",
                        column: x => x.PostingID,
                        principalTable: "Posting",
                        principalColumn: "PostingID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Posting_PostingType_PostingType_PostingTypeID",
                        column: x => x.PostingTypeID,
                        principalTable: "PostingType",
                        principalColumn: "PostingTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectLink",
                columns: table => new
                {
                    ProjectLinkID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProjectLinkLabel = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    ProjectLinkUrl = table.Column<string>(type: "TEXT", nullable: true),
                    ProjectsProjectID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectLink", x => x.ProjectLinkID);
                    table.ForeignKey(
                        name: "FK_ProjectLink_Project_ProjectsProjectID",
                        column: x => x.ProjectsProjectID,
                        principalTable: "Project",
                        principalColumn: "ProjectID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProjectPosting",
                columns: table => new
                {
                    ProjectPostingID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProjectID = table.Column<int>(type: "INTEGER", nullable: false),
                    PostingID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectPosting", x => x.ProjectPostingID);
                    table.ForeignKey(
                        name: "FK_ProjectPosting_Posting_PostingID",
                        column: x => x.PostingID,
                        principalTable: "Posting",
                        principalColumn: "PostingID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectPosting_Project_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Project",
                        principalColumn: "ProjectID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StarredProject",
                columns: table => new
                {
                    StarredProjectID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserID = table.Column<int>(type: "INTEGER", nullable: false),
                    ProjectID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StarredProject", x => x.StarredProjectID);
                    table.ForeignKey(
                        name: "FK_StarredProject_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StarredProject_Project_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Project",
                        principalColumn: "ProjectID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserProjects",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "INTEGER", nullable: false),
                    ProjectID = table.Column<int>(type: "INTEGER", nullable: false),
                    CollaborationTitle = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProjects", x => new { x.UserID, x.ProjectID });
                    table.ForeignKey(
                        name: "FK_UserProjects_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserProjects_Project_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Project",
                        principalColumn: "ProjectID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostingSkills",
                columns: table => new
                {
                    SkillID = table.Column<int>(type: "INTEGER", nullable: false),
                    PostingID = table.Column<int>(type: "INTEGER", nullable: false),
                    PriorityLevel = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostingSkills", x => new { x.SkillID, x.PostingID });
                    table.ForeignKey(
                        name: "FK_PostingSkills_Posting_PostingID",
                        column: x => x.PostingID,
                        principalTable: "Posting",
                        principalColumn: "PostingID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostingSkills_Skill_SkillID",
                        column: x => x.SkillID,
                        principalTable: "Skill",
                        principalColumn: "SkillID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectSkills",
                columns: table => new
                {
                    SkillID = table.Column<int>(type: "INTEGER", nullable: false),
                    ProjectID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectSkills", x => new { x.SkillID, x.ProjectID });
                    table.ForeignKey(
                        name: "FK_ProjectSkills_Project_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Project",
                        principalColumn: "ProjectID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectSkills_Skill_SkillID",
                        column: x => x.SkillID,
                        principalTable: "Skill",
                        principalColumn: "SkillID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SkillDiscipline",
                columns: table => new
                {
                    DisciplineID = table.Column<int>(type: "INTEGER", nullable: false),
                    SkillID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillDiscipline", x => new { x.DisciplineID, x.SkillID });
                    table.ForeignKey(
                        name: "FK_SkillDiscipline_Discipline_DisciplineID",
                        column: x => x.DisciplineID,
                        principalTable: "Discipline",
                        principalColumn: "DisciplineID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SkillDiscipline_Skill_SkillID",
                        column: x => x.SkillID,
                        principalTable: "Skill",
                        principalColumn: "SkillID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSkill",
                columns: table => new
                {
                    UserSkillID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SkillID = table.Column<int>(type: "INTEGER", nullable: false),
                    UserID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSkill", x => x.UserSkillID);
                    table.ForeignKey(
                        name: "FK_UserSkill_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserSkill_Skill_SkillID",
                        column: x => x.SkillID,
                        principalTable: "Skill",
                        principalColumn: "SkillID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSkillLink",
                columns: table => new
                {
                    UserSkillLinkID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LinkID = table.Column<int>(type: "INTEGER", nullable: false),
                    UserSkillID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSkillLink", x => x.UserSkillLinkID);
                    table.ForeignKey(
                        name: "FK_UserSkillLink_SkillLink_LinkID",
                        column: x => x.LinkID,
                        principalTable: "SkillLink",
                        principalColumn: "SkillLinkID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserSkillLink_UserSkill_UserSkillID",
                        column: x => x.UserSkillID,
                        principalTable: "UserSkill",
                        principalColumn: "UserSkillID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContactLink_UsersId",
                table: "ContactLink",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_IntrestedCandidate_PostingID",
                table: "IntrestedCandidate",
                column: "PostingID");

            migrationBuilder.CreateIndex(
                name: "IX_IntrestedCandidate_UserID",
                table: "IntrestedCandidate",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Posting_PostingOwnerId",
                table: "Posting",
                column: "PostingOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Posting_PostingType_PostingID",
                table: "Posting_PostingType",
                column: "PostingID");

            migrationBuilder.CreateIndex(
                name: "IX_Posting_PostingType_PostingTypeID",
                table: "Posting_PostingType",
                column: "PostingTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_PostingSkills_PostingID",
                table: "PostingSkills",
                column: "PostingID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectLink_ProjectsProjectID",
                table: "ProjectLink",
                column: "ProjectsProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectPosting_PostingID",
                table: "ProjectPosting",
                column: "PostingID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectPosting_ProjectID",
                table: "ProjectPosting",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectSkills_ProjectID",
                table: "ProjectSkills",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_RecruiterPicks_CandidateID",
                table: "RecruiterPicks",
                column: "CandidateID");

            migrationBuilder.CreateIndex(
                name: "IX_RecruiterPicks_PostingID",
                table: "RecruiterPicks",
                column: "PostingID");

            migrationBuilder.CreateIndex(
                name: "IX_RecruiterPicks_RecuiterID",
                table: "RecruiterPicks",
                column: "RecuiterID");

            migrationBuilder.CreateIndex(
                name: "IX_SkillDiscipline_SkillID",
                table: "SkillDiscipline",
                column: "SkillID");

            migrationBuilder.CreateIndex(
                name: "IX_StarredPosting_PostingID",
                table: "StarredPosting",
                column: "PostingID");

            migrationBuilder.CreateIndex(
                name: "IX_StarredPosting_UserID",
                table: "StarredPosting",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_StarredProject_ProjectID",
                table: "StarredProject",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_StarredProject_UserID",
                table: "StarredProject",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_StarredUser_StarredOwnerID",
                table: "StarredUser",
                column: "StarredOwnerID");

            migrationBuilder.CreateIndex(
                name: "IX_StarredUser_UserStarredID",
                table: "StarredUser",
                column: "UserStarredID");

            migrationBuilder.CreateIndex(
                name: "IX_UserProjects_ProjectID",
                table: "UserProjects",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_UserSkill_SkillID",
                table: "UserSkill",
                column: "SkillID");

            migrationBuilder.CreateIndex(
                name: "IX_UserSkill_UserID",
                table: "UserSkill",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_UserSkillLink_LinkID",
                table: "UserSkillLink",
                column: "LinkID");

            migrationBuilder.CreateIndex(
                name: "IX_UserSkillLink_UserSkillID",
                table: "UserSkillLink",
                column: "UserSkillID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactLink");

            migrationBuilder.DropTable(
                name: "IntrestedCandidate");

            migrationBuilder.DropTable(
                name: "Posting_PostingType");

            migrationBuilder.DropTable(
                name: "PostingSkills");

            migrationBuilder.DropTable(
                name: "ProjectLink");

            migrationBuilder.DropTable(
                name: "ProjectPosting");

            migrationBuilder.DropTable(
                name: "ProjectSkills");

            migrationBuilder.DropTable(
                name: "RecruiterPicks");

            migrationBuilder.DropTable(
                name: "SkillDiscipline");

            migrationBuilder.DropTable(
                name: "StarredPosting");

            migrationBuilder.DropTable(
                name: "StarredProject");

            migrationBuilder.DropTable(
                name: "StarredUser");

            migrationBuilder.DropTable(
                name: "UserProjects");

            migrationBuilder.DropTable(
                name: "UserSkillLink");

            migrationBuilder.DropTable(
                name: "PostingType");

            migrationBuilder.DropTable(
                name: "Discipline");

            migrationBuilder.DropTable(
                name: "Posting");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "SkillLink");

            migrationBuilder.DropTable(
                name: "UserSkill");

            migrationBuilder.DropTable(
                name: "Skill");
        }
    }
}
