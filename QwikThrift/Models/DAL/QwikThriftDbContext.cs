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

            //seed users
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserId = 1,
                    Username = "Admin",
                    Email = "nunya@bidness.com",
                    Password = "SuperSecure99",
                    Role = UserRoles.Administrator
                },
                new User
                {
                    UserId = 2,
                    Username = "Josh",
                    Email = "NoMoSpam@byte.me",
                    Password = "IGoodAtPasswording1",
                    Role = UserRoles.Moderator
                },
                new User
                {
                    UserId = 3,
                    Username = "Scott",
                    Email = "IRanOutOfCleaverNames@my.brain",
                    Password = "Scott1",
                    Role = UserRoles.User
                },
                new User
                {
                    UserId = 4,
                    Username = "Tyler",
                    Email = "totallyRealEmail@fakeEmails.com",
                    Password = "H4ckr",
                    Role = UserRoles.User
                },
                new User
                {
                    UserId = 5,
                    Username = "VictorianDiningSet",
                    Email = "Victor@cursedObjects.net",
                    Password = "LetMeIn",
                    Role = UserRoles.User
                });

            //seed categories
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    CategoryId = 1,
                    AuthorizedById = 1,
                    CategoryName = "Vehicles",
                    CategoryDescription = "Cars, boats, planes, tanks, basically anything that moves and goes" +
                    "vroom-vroom or even zappy-zap."
                },
                new Category
                {
                    CategoryId = 2,
                    AuthorizedById = 1,
                    CategoryName = "Furniture",
                    CategoryDescription = "if (CanSit || CanPlaceStuffOn) Category = \"Furnature\""
                },
                new Category
                {
                    CategoryId = 3,
                    AuthorizedById = 1,
                    CategoryName = "Technology",
                    CategoryDescription = "Things that beep-boop and make nerds (like us) happy."
                });

            //seed listings
            modelBuilder.Entity<Listing>().HasData(
                new Listing
                { 
                    ListingId = 1,
                    CategoryId = 1,
                    OwnerId = 2,
                    Title = "Totally Fine Car.",
                    Description = "Runs great! Drives straight down the road (on curved roads). Has minor cosmetic " +
                    "damage to the front-end. Only 1,286,032 miles! $25,600 FIRM, no low-ballers, I KNOW WHAT I HAVE!",
                    Price = 23000,
                    SaleStatus = false,
                    ListingTime = DateTime.Parse("March 4, 2018")
                },
                new Listing
                {
                    ListingId = 2,
                    CategoryId = 1,
                    OwnerId = 3,
                    Title = "School Bus Camper",
                    Description = "I bought this bus a few years back with the intention of making the ultimate camper. " +
                    "The woman I bought it from was kinda crazy and told me it was magic. It does have a deceptively " +
                    "spacious interior! I didn't think anything of her magic claim until I took my first trip about a " +
                    "year later. I pressed the wrong button and ended up in a homeless man's bloodstream. There are some " +
                    "things in this world you just can't unsee! If anyone out there knows how to drive a school bus with " +
                    "magical powers, it's yours for just $5,500. Price is firm, the therapy bills are beginning to add up.",
                    Price = 5500,
                    SaleStatus = false,
                    ListingTime = DateTime.Parse("July 23, 2000")
                },
                new Listing
                {
                    ListingId = 3,
                    CategoryId = 3,
                    OwnerId = 2,
                    Title = "Flux Capacitor",
                    Description = "Recovered from vehicle wreckage. Rare time-travel device only used 9 times! Like-new " +
                    "condition! Must travel at 88mph to activate, highly recommend a faster car than a DMC Delorian! I " +
                    "considered trying to install it in my new truck I mysteriously acquired, but I don't know much about " +
                    "it and honestly, I've had about enough time traveling mishaps for one lifetime. One of a kind item, " +
                    "not sure what it's worth so make me an offer.",
                    Price = 10000,
                    SaleStatus = false,
                    ListingTime = DateTime.Parse("November 7, 1985")
                },
                new Listing
                {
                    ListingId = 4,
                    CategoryId = 2,
                    OwnerId = 4,
                    Title = "Victorian Dining Set. Not Haunted.",
                    Description = "Need to sell ASAP, moving far, FAR, VERY FAR away soon. Table is self-clearing, food just " +
                    "flies off on its own! No input needed, just line the floor with plastic and clearing the table after " +
                    "dinner will be a thing of the past. I'd recommend not using any sharp utensils, maybe stick to disposable " +
                    "cutlery. Dining set is self-healing! We caught it on fire once, it burned up completely but was ready for " +
                    "dinner the very next day! My loss is your gain on this antique table and chairs as I moving as soon as my " +
                    "house is done burning which could be anywhere from today to a week from now. Come pick up this lovely " +
                    "dining set free of charge! No really, please! You can have it! Oh God, it knows what we'reeadfdsaf",
                    Price = 0,
                    SaleStatus = false,
                    ListingTime = DateTime.Now
                });

            //seed ImagesReferences
            modelBuilder.Entity<ImageReference>().HasData(
                new ImageReference
                {
                    ImageReferenceId = 1,
                    ListingId = 1,
                    Description = "",
                    Name = "Fine Car",
                    Filename = "fineCar.png",
                    Path = "\\images\\listings\\1\\"
                },
                new ImageReference
                {
                    ImageReferenceId = 2,
                    ListingId = 1,
                    Description = "",
                    Name = "inside",
                    Filename = "fineCarInside.png",
                    Path = "\\images\\listings\\1\\"
                },
                new ImageReference
                {
                    ImageReferenceId = 3,
                    ListingId = 2,
                    Description = "",
                    Name = "Magic Bus",
                    Filename = "magicBus.jpg",
                    Path = "\\images\\listings\\2\\"
                },
                new ImageReference
                {
                    ImageReferenceId = 4,
                    ListingId = 2,
                    Description = "",
                    Name = "Inside 1",
                    Filename = "magicBusInside.png",
                    Path = "\\images\\listings\\2\\"
                },
                new ImageReference
                {
                    ImageReferenceId = 5,
                    ListingId = 2,
                    Description = "",
                    Name = "Inside 2",
                    Filename = "magicBusInside2.jpg",
                    Path = "\\images\\listings\\2\\"
                },
                new ImageReference
                {
                    ImageReferenceId = 6,
                    ListingId = 3,
                    Description = "",
                    Name = "flux capacitor",
                    Filename = "timeTravelDev.jpg",
                    Path = "\\images\\listings\\3\\"
                },
                new ImageReference
                {
                    ImageReferenceId = 7,
                    ListingId = 4,
                    Description = "",
                    Name = "Probably haunted table",
                    Filename = "notHauntedTable.png",
                    Path = "\\images\\listings\\4\\"
                });

            //seed message data.
            modelBuilder.Entity<Message>().HasData(
                new Message
                {
                    MessageId = 1,
                    RecipientId = 4,
                    SenderId = 5,
                    Subject = "Victorian Dining Set. Not Haunted",
                    Body = "Hello \"Tyler,\" or should I call you Jeremy! You thought you could get rid of " +
                    "me that easily! FOOOOOOOOL! I am everywhere, I am nowhere, I am your personal living " +
                    "nightmare.",
                    Timestamp = DateTime.Parse("July 3, 2023 17:42")
                },
                new Message
                {
                    MessageId = 2,
                    RecipientId = 3,
                    SenderId = 4,
                    Subject = "School Bus Camper",
                    Body = "Hi Scott, I have some questions about the bus you have for sale. Do you know if " +
                    "this magical bus can traverse dimensions? I’m looking to get rid of some… unique furniture " +
                    "and I really need it FAR away. I can’t say much, I think I’m being watched! I’ll give you " +
                    "whatever you want, I don’t know where else to turn. This is the first piece of good news. " +
                    "Got to go!!!!!",
                    Timestamp = DateTime.Parse("July 3, 2023 17:46")
                },
                new Message
                {
                    MessageId = 3,
                    RecipientId = 4,
                    SenderId = 3,
                    Subject = "RE:School Bus Camper",
                    Body = "Tyler, I’m not sure what you mean by that. As I mentioned in my post, I’ve really " +
                    "only driven it once and it didn’t go well. You’re more than welcome to come see for yourself, " +
                    "but I will not be setting foot in that thing again. You can take it for a test drive if you " +
                    "need to, but I’ll need the money up front if you’re planning on leaving the neighborhood. I’ll " +
                    "have it towed to a nearby parking lot and we can meet up there.",
                    Timestamp = DateTime.Parse("July 3, 2023 19:12")
                },
                new Message
                {
                    MessageId = 4,
                    RecipientId = 2,
                    SenderId = 3,
                    Subject = "Totally Fine Car",
                    Body = "So listen, this “car” is a rusty hunk of metal. I’d give ya 300 bucks if you haul it to me.",
                    Timestamp = DateTime.Parse("August 21, 2023 13:17")
                },
                new Message
                {
                    MessageId = 5,
                    RecipientId = 3,
                    SenderId = 2,
                    Subject = "RE:Totally Fine Car",
                    Body = "You got to be out your mind! This car is in pristine condition!! How dare you! This is the " +
                    "super-luxury-deluxe model! It even has two rear view mirrors for optimal viewing!",
                    Timestamp = DateTime.Parse("August 21, 2023 14:32")
                },
                new Message
                {
                    MessageId = 6,
                    RecipientId = 2,
                    SenderId = 3,
                    Subject = "RE:Totally Fine Car",
                    Body = "Why would the passenger need a mirror in the first place?! So they can also see what they’re " +
                    "towing in this rust bucket?! This thing couldn't make it out of the driveway without losing a muffler! " +
                    "What's the deal with those tires? Are they forever melted to the pavement?",
                    Timestamp = DateTime.Parse("August 21, 2023 14:44")
                },
                new Message
                {
                    MessageId = 7,
                    RecipientId = 3,
                    SenderId = 2,
                    Subject = "RE:Totally Fine Car",
                    Body = "Look, the tires are free if you buy the car! You care about tires anyway! You got perfectly good " +
                    "rims to ride on! You darn city folk and your fancy things like tires wouldn’t know a good car if it bit " +
                    "ya where the sun don’t shine [spit pings off spitoon]. Tell ya what city slicker, you can have it for " +
                    "$1,000 final offer!",
                    Timestamp = DateTime.Parse("August 21, 2023 15:06")
                },
                new Message
                {
                    MessageId = 8,
                    RecipientId = 2,
                    SenderId = 3,
                    Subject = "RE:Totally Fine Car",
                    Body = "Alright captain, I think I like your style. You didn't have to narrate those cool spit actions, " +
                    "but you went ahead and did anyway, like a boss. I’ll take your deal old man. Meet downtown tomorrow. " +
                    "High noon.",
                    Timestamp = DateTime.Parse("August 21, 2023 15:28")
                });
        }
    }
}
