using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<AppUser> Users {get; set;} 
        public DbSet<UserLike> Likes {get; set;} 
        public DbSet<Message> Messages {get; set;} 

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
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