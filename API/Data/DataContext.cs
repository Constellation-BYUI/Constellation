using API.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataContext : IdentityDbContext< AppUser, AppRole, int, 
                    IdentityUserClaim<int>, AppUserRole, IdentityUserLogin<int>,
                    IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<UserLike> Likes {get; set;} 
        public DbSet<Message> Messages {get; set;} 
        public DbSet<Group> Groups {get; set;} 
        public DbSet<Connection> Connections {get; set;} 

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

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
            .HasKey(k => new {k.SourceUserId, k.LikedUserId});

            builder.Entity<UserLike>()
            .HasOne(su => su.SourceUser)
            .WithMany(lu => lu.LikedUsers)
            .HasForeignKey(suid => suid.SourceUserId)
            .OnDelete(DeleteBehavior.Cascade);

             builder.Entity<UserLike>()
            .HasOne(lu => lu.LikedUser)
            .WithMany(lbu => lbu.LikedByUsers)
            .HasForeignKey(luid => luid.LikedUserId)
            .OnDelete(DeleteBehavior.Cascade);

            //Messaging
            builder.Entity<Message>()
            .HasOne(u => u.Recipient)
            .WithMany(mr => mr.MessagesRecieved)
            .OnDelete(DeleteBehavior.Restrict);

              builder.Entity<Message>()
            .HasOne(u => u.Sender)
            .WithMany(ms => ms.MessagesSent)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}