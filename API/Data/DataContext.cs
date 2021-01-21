using System;
using API.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace API.Data
{
    public class DataContext : IdentityDbContext<AppUser, AppRole, int,
        IdentityUserClaim<int>, AppUserRole, IdentityUserLogin<int>,
        IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<UserLike> Likes { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Connection> Connections { get; set; }

        public DbSet<Project> Projects { get; set; }
        public DbSet<UserProject> UserProjects { get; set; }
        public DbSet<ContactLink> ContactLinks { get; set; }
        public DbSet<ProjectLink> ProjectLinks { get; set; }
        public DbSet<Posting> Postings { get; set; }
        public DbSet<PostingType> PostingTypes { get; set; }
        public DbSet<Posting_PostingType> Posting_PostingTypes { get; set; }
        public DbSet<StarredPosting> StarredPosting { get; set; }
        public DbSet<IntrestedCandidate> IntrestedCandidate { get; set; }
        public DbSet<StarredProject> StarredProjects { get; set; }
        public DbSet<StarredUser> StarredUsers { get; set; }
        public DbSet<RecruiterPicks> RecruiterPicks { get; set; }
        public DbSet<UserSkill> UserSkills { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<SkillDiscipline> SkillDisciplines { get; set; }
        public DbSet<Discipline> Disciplines { get; set; }
        public DbSet<SkillLink> SkillLinks { get; set; }
        public DbSet<ProjectPosting> ProjectPosting { get; set; }
        public DbSet<UserSkillLink> UserSkillLinks { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Group>()
                .HasMany(x => x.Connections)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<AppUser>()
                .HasMany(ur => ur.UserRoles)
                .WithOne(u => u.User)
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();

            builder.Entity<AppRole>()
                .HasMany(ur => ur.UserRoles)
                .WithOne(u => u.Role)
                .HasForeignKey(ur => ur.RoleId)
                .IsRequired();


            builder.Entity<UserLike>()
                .HasKey(k => new { k.SourceUserId, k.LikedUserId });

            builder.Entity<UserLike>()
                .HasOne(s => s.SourceUser)
                .WithMany(l => l.LikedUsers)
                .HasForeignKey(s => s.SourceUserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<UserLike>()
                .HasOne(s => s.LikedUser)
                .WithMany(l => l.LikedByUsers)
                .HasForeignKey(s => s.LikedUserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Message>()
                .HasOne(u => u.Recipient)
                .WithMany(m => m.MessagesReceived)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Message>()
                .HasOne(u => u.Sender)
                .WithMany(m => m.MessagesSent)
                .OnDelete(DeleteBehavior.Restrict);

               builder.Entity<Project>().ToTable("Project");

            builder.Entity<UserProject>()
       .HasKey(bc => new { bc.UserID, bc.ProjectID });

            builder.Entity<UserProject>()
                .HasOne(bc => bc.Project)
                .WithMany(b => b.UserProjects)
                .HasForeignKey(bc => bc.UserID);

            builder.Entity<UserProject>()
                .HasOne(bc => bc.Project)
                .WithMany(c => c.UserProjects)
                .HasForeignKey(bc => bc.ProjectID);

            builder.Entity<ContactLink>().ToTable("ContactLink");
            builder.Entity<AppUser>()
               .HasMany(c => c.ContactLinks)
               .WithOne(e => e.Users);

            builder.Entity<ProjectLink>().ToTable("ProjectLink");
            builder.Entity<Project>()
             .HasMany(c => c.ProjectLinks)
             .WithOne(e => e.Projects);

            builder.Entity<StarredPosting>().ToTable("StarredPosting");
            builder.Entity<StarredPosting>()
                .HasKey(b => b.StarredPostingID);

            builder.Entity<StarredPosting>()
                .HasOne(bc => bc.User)
                .WithMany(b => b.StarredPostings)
                .HasForeignKey(bc => bc.UserID);

            builder.Entity<StarredPosting>()
                .HasOne(bc => bc.Posting)
                .WithMany(c => c.StarredPostings)
                .HasForeignKey(bc => bc.PostingID);

            builder.Entity<IntrestedCandidate>().ToTable("IntrestedCandidate");
            builder.Entity<IntrestedCandidate>()
                .HasKey(b => b.IntrestedCandidateID);

            builder.Entity<IntrestedCandidate>()
                .HasOne(bc => bc.User)
                .WithMany(b => b.IntrestedCandidates)
                .HasForeignKey(bc => bc.UserID);

            builder.Entity<IntrestedCandidate>()
                .HasOne(bc => bc.Posting)
                .WithMany(c => c.IntrestedCandidates)
                .HasForeignKey(bc => bc.PostingID);

            builder.Entity<StarredProject>().ToTable("StarredProject");
            builder.Entity<StarredProject>()
                .HasKey(b => b.StarredProjectID);

            builder.Entity<StarredProject>()
                .HasOne(bc => bc.User)
                .WithMany(b => b.StarredProjects)
                .HasForeignKey(bc => bc.UserID);

            builder.Entity<StarredProject>()
                .HasOne(bc => bc.Project)
                .WithMany(c => c.StarredProjects)
                .HasForeignKey(bc => bc.ProjectID);

            builder.Entity<StarredUser>().ToTable("StarredUser");
            //Primary Key
            builder.Entity<StarredUser>()
                .HasKey(b => b.StarredUserID);

            //User who is starring the other person
            builder.Entity<StarredUser>()
                .HasOne(bc => bc.StarOwner)
                .WithMany(b => b.StarredOwner)
                .HasForeignKey(bc => bc.StarredOwnerID);

            //the other User who is being starred
            builder.Entity<StarredUser>()
                .HasOne(bc => bc.StarredPerson)
                .WithMany(c => c.StarredUsers)
                .HasForeignKey(bc => bc.UserStarredID);

            builder.Entity<RecruiterPicks>().ToTable("RecruiterPicks");
            //Primary Key
            builder.Entity<RecruiterPicks>()
                .HasKey(b => b.RecuiterPicksID);

            //User who is starring the other person
            builder.Entity<RecruiterPicks>()
                .HasOne(bc => bc.Recuiter)
                .WithMany(b => b.Recuiter)
                .HasForeignKey(bc => bc.RecuiterID);

            //the other User who is being starred
            builder.Entity<RecruiterPicks>()
                .HasOne(bc => bc.Candidate)
                .WithMany(c => c.Candidates)
                .HasForeignKey(bc => bc.CandidateID);

            builder.Entity<RecruiterPicks>()
             .HasOne(bc => bc.Posting)
             .WithMany(c => c.RecruiterPicks)
             .HasForeignKey(bc => bc.PostingID);

            builder.Entity<ProjectPosting>()
               .HasKey(b => b.ProjectPostingID);

            builder.Entity<ProjectPosting>()
                .HasOne(bc => bc.Project)
                .WithMany(b => b.ProjectPostings)
                .HasForeignKey(bc => bc.ProjectID);
                
            builder.Entity<ProjectPosting>()
                .HasOne(bc => bc.Posting)
                .WithMany(c => c.ProjectPostings)
                .HasForeignKey(bc => bc.PostingID);

            builder.Entity<Skill>().ToTable("Skill");

            builder.Entity<UserSkill>().ToTable("UserSkill");
            builder.Entity<UserSkill>()
             .HasKey(k => k.UserSkillID);
            builder.Entity<UserSkill>()
                .HasOne(bc => bc.Skills)
                .WithMany(b => b.UserSkills)
                .HasForeignKey(bc => bc.SkillID);
            builder.Entity<UserSkill>()
                .HasOne(bc => bc.Users)
                .WithMany(c => c.UserSkills)
                .HasForeignKey(bc => bc.UserID);

            builder.Entity<Discipline>().ToTable("Discipline");

            builder.Entity<SkillDiscipline>().ToTable("SkillDiscipline");
            builder.Entity<SkillDiscipline>()
     .HasKey(bc => new { bc.DisciplineID, bc.SkillID });
            builder.Entity<SkillDiscipline>()
                .HasOne(bc => bc.Skills)
                .WithMany(b => b.SkillDisciplines)
                .HasForeignKey(bc => bc.SkillID);
            builder.Entity<SkillDiscipline>()
                .HasOne(bc => bc.Disciplines)
                .WithMany(c => c.SkillDiscipline)
                .HasForeignKey(bc => bc.DisciplineID);

            builder.Entity<SkillLink>().ToTable("SkillLink");
            builder.Entity<UserSkillLink>().ToTable("UserSkillLink");
            builder.Entity<UserSkillLink>()
           .HasKey(k => k.UserSkillLinkID);
            builder.Entity<UserSkillLink>()
                .HasOne(bc => bc.UserSkills)
                .WithMany(b => b.UserSkillLinks)
                .HasForeignKey(bc => bc.UserSkillID);
            builder.Entity<UserSkillLink>()
                .HasOne(bc => bc.SkillLinks)
                .WithMany(c => c.UserSkillLinks)
                .HasForeignKey(bc => bc.LinkID);

            builder.Entity<Posting>().ToTable("Posting");
            builder.Entity<Posting_PostingType>().ToTable("Posting_PostingType");
            builder.Entity<PostingType>().ToTable("PostingType");

            builder.Entity<ProjectSkills>()
      .HasKey(bc => new { bc.SkillID, bc.ProjectID });
            builder.Entity<ProjectSkills>()
                .HasOne(bc => bc.Skill)
                .WithMany(b => b.ProjectSkills)
                .HasForeignKey(bc => bc.SkillID);
            builder.Entity<ProjectSkills>()
                .HasOne(bc => bc.Project)
                .WithMany(c => c.ProjectSkills)
                .HasForeignKey(bc => bc.ProjectID);

            builder.Entity<PostingSkills>()
  .HasKey(bc => new { bc.SkillID, bc.PostingID });

            builder.Entity<PostingSkills>()
                .HasOne(bc => bc.Skill)
                .WithMany(b => b.PostingSkills)
                .HasForeignKey(bc => bc.SkillID);

            builder.Entity<PostingSkills>()
                .HasOne(bc => bc.Posting)
                .WithMany(c => c.PostingSkills)
                .HasForeignKey(bc => bc.PostingID);

            builder.ApplyUtcDateTimeConverter();
        }
    }

    public static class UtcDateAnnotation
    {
        private const String IsUtcAnnotation = "IsUtc";
        private static readonly ValueConverter<DateTime, DateTime> UtcConverter =
          new ValueConverter<DateTime, DateTime>(v => v, v => DateTime.SpecifyKind(v, DateTimeKind.Utc));

        private static readonly ValueConverter<DateTime?, DateTime?> UtcNullableConverter =
          new ValueConverter<DateTime?, DateTime?>(v => v, v => v == null ? v : DateTime.SpecifyKind(v.Value, DateTimeKind.Utc));

        public static PropertyBuilder<TProperty> IsUtc<TProperty>(this PropertyBuilder<TProperty> builder, Boolean isUtc = true) =>
          builder.HasAnnotation(IsUtcAnnotation, isUtc);

        public static Boolean IsUtc(this IMutableProperty property) =>
          ((Boolean?)property.FindAnnotation(IsUtcAnnotation)?.Value) ?? true;

        /// <summary>
        /// Make sure this is called after configuring all your entities.
        /// </summary>
        public static void ApplyUtcDateTimeConverter(this ModelBuilder builder)
        {
            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                foreach (var property in entityType.GetProperties())
                {
                    if (!property.IsUtc())
                    {
                        continue;
                    }

                    if (property.ClrType == typeof(DateTime))
                    {
                        property.SetValueConverter(UtcConverter);
                    }

                    if (property.ClrType == typeof(DateTime?))
                    {
                        property.SetValueConverter(UtcNullableConverter);
                    }
                }
            }
        }
    }
}