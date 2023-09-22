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

        /// <summary>
        /// Stores all listings on the site
        /// </summary>
        public DbSet<Listing> Listings { get; set; }

        /// <summary>
        /// Stores file location and metadata for images
        /// </summary>
        public DbSet<ImageReference> ImageReferences { get; set; }

        /// <summary>
        /// Categories that for listings
        /// </summary>
        public DbSet<Category> Categories { get; set; }

        public QwikThriftDbContext(DbContextOptions<QwikThriftDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //bind UserId of message sender to message
            modelBuilder.Entity<Message>()
                .HasOne<User>(m => m.Sender)
                .WithMany(u => u.MessagesSent)
                .HasForeignKey(m => m.SenderId)
                .OnDelete(DeleteBehavior.Restrict);

            //bind UserId of message recipient to message
            modelBuilder.Entity<Message>()
                .HasOne(m => m.Recipient)
                .WithMany(u => u.MessagesRecieved)
                .HasForeignKey(m => m.RecipientId)
                .OnDelete(DeleteBehavior.Restrict);

            //bind UserId of listing owner to listing
            modelBuilder.Entity<Listing>()
                .HasOne<User>(l => l.Owner)
                .WithMany(u => u.Listings)
                .HasForeignKey(l => l.OwnerId)
                .OnDelete(DeleteBehavior.Restrict);

            //bind ImageReferenceId to listing
            modelBuilder.Entity<ImageReference>()
                .HasOne<Listing>(i => i.Listing)
                .WithMany(u => u.Images)
                .HasForeignKey(i => i.ListingId)
                .OnDelete(DeleteBehavior.Restrict);

            //bind categoryId to listings
            modelBuilder.Entity<Listing>()
                .HasOne<Category>(l => l.Category)
                .WithMany(c => c.Listings)
                .HasForeignKey(l => l.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
