#nullable disable
using Microsoft.EntityFrameworkCore;

namespace QwikThrift.Models.DAL
{
    public class QwikThriftDbContext : DbContext
    {
        /// <summary>
        /// Stores all messages sent to/from users
        /// </summary>
        public DbSet<Message> Messages { get; set; }

        /// <summary>
        /// Stores all Qwik Thrift users.
        /// </summary>
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //bind UserId of message sender to message
            modelBuilder.Entity<Message>()
                .HasOne<User>(m => m.Sender)
                .WithMany(u => u.MessagesSent)
                .HasForeignKey(m => m.SenderId);

            //bind UserId of message recipient to message
            modelBuilder.Entity<Message>()
                .HasOne(m => m.Recipient)
                .WithMany(u => u.MessagesRecieved)
                .HasForeignKey(m => m.RecipientId);
        }
    }
}
