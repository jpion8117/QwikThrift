﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QwikThrift.Models.DAL;

#nullable disable

namespace QwikThrift.Migrations
{
    [DbContext(typeof(QwikThriftDbContext))]
    partial class QwikThriftDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("QwikThrift.Models.DAL.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"), 1L, 1);

                    b.Property<int>("AuthorizedById")
                        .HasColumnType("int");

                    b.Property<string>("CategoryDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.HasIndex("AuthorizedById");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            AuthorizedById = 1,
                            CategoryDescription = "Cars, boats, planes, tanks, basically anything that moves and goesvroom-vroom or even zappy-zap.",
                            CategoryName = "Vehicles"
                        },
                        new
                        {
                            CategoryId = 2,
                            AuthorizedById = 1,
                            CategoryDescription = "if (CanSit || CanPlaceStuffOn) Category = \"Furnature\"",
                            CategoryName = "Furniture"
                        },
                        new
                        {
                            CategoryId = 3,
                            AuthorizedById = 1,
                            CategoryDescription = "Things that beep-boop and make nerds (like us) happy.",
                            CategoryName = "Technology"
                        });
                });

            modelBuilder.Entity("QwikThrift.Models.DAL.ImageReference", b =>
                {
                    b.Property<int>("ImageReferenceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ImageReferenceId"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Filename")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ListingId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Path")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ImageReferenceId");

                    b.HasIndex("ListingId");

                    b.ToTable("ImageReferences");

                    b.HasData(
                        new
                        {
                            ImageReferenceId = 1,
                            Description = "",
                            Filename = "fineCar.png",
                            ListingId = 1,
                            Name = "Fine Car",
                            Path = "\\images\\listings\\1\\"
                        },
                        new
                        {
                            ImageReferenceId = 2,
                            Description = "",
                            Filename = "fineCarInside.png",
                            ListingId = 1,
                            Name = "inside",
                            Path = "\\images\\listings\\1\\"
                        },
                        new
                        {
                            ImageReferenceId = 3,
                            Description = "",
                            Filename = "magicBus.jpg",
                            ListingId = 2,
                            Name = "Magic Bus",
                            Path = "\\images\\listings\\2\\"
                        },
                        new
                        {
                            ImageReferenceId = 4,
                            Description = "",
                            Filename = "magicBusInside.png",
                            ListingId = 2,
                            Name = "Inside 1",
                            Path = "\\images\\listings\\2\\"
                        },
                        new
                        {
                            ImageReferenceId = 5,
                            Description = "",
                            Filename = "magicBusInside2.jpg",
                            ListingId = 2,
                            Name = "Inside 2",
                            Path = "\\images\\listings\\2\\"
                        },
                        new
                        {
                            ImageReferenceId = 6,
                            Description = "",
                            Filename = "timeTravelDev.jpg",
                            ListingId = 3,
                            Name = "flux capacitor",
                            Path = "\\images\\listings\\3\\"
                        },
                        new
                        {
                            ImageReferenceId = 7,
                            Description = "",
                            Filename = "notHauntedTable.png",
                            ListingId = 4,
                            Name = "Probably haunted table",
                            Path = "\\images\\listings\\4\\"
                        });
                });

            modelBuilder.Entity("QwikThrift.Models.DAL.Listing", b =>
                {
                    b.Property<int>("ListingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ListingId"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ListingTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<bool>("SaleStatus")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ListingId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("OwnerId");

                    b.ToTable("Listings");

                    b.HasData(
                        new
                        {
                            ListingId = 1,
                            CategoryId = 1,
                            Description = "Runs great! Drives straight down the road (on curved roads). Has minor cosmetic damage to the front-end. Only 1,286,032 miles! $25,600 FIRM, no low-ballers, I KNOW WHAT I HAVE!",
                            ListingTime = new DateTime(2018, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OwnerId = 2,
                            Price = 23000f,
                            SaleStatus = false,
                            Title = "Totally Fine Car."
                        },
                        new
                        {
                            ListingId = 2,
                            CategoryId = 1,
                            Description = "I bought this bus a few years back with the intention of making the ultimate camper. The woman I bought it from was kinda crazy and told me it was magic. It does have a deceptively spacious interior! I didn't think anything of her magic claim until I took my first trip about a year later. I pressed the wrong button and ended up in a homeless man's bloodstream. There are some things in this world you just can't unsee! If anyone out there knows how to drive a school bus with magical powers, it's yours for just $5,500. Price is firm, the therapy bills are beginning to add up.",
                            ListingTime = new DateTime(2000, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OwnerId = 3,
                            Price = 5500f,
                            SaleStatus = false,
                            Title = "School Bus Camper"
                        },
                        new
                        {
                            ListingId = 3,
                            CategoryId = 3,
                            Description = "Recovered from vehicle wreckage. Rare time-travel device only used 9 times! Like-new condition! Must travel at 88mph to activate, highly recommend a faster car than a DMC Delorian! I considered trying to install it in my new truck I mysteriously acquired, but I don't know much about it and honestly, I've had about enough time traveling mishaps for one lifetime. One of a kind item, not sure what it's worth so make me an offer.",
                            ListingTime = new DateTime(1985, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OwnerId = 2,
                            Price = 10000f,
                            SaleStatus = false,
                            Title = "Flux Capacitor"
                        },
                        new
                        {
                            ListingId = 4,
                            CategoryId = 2,
                            Description = "Need to sell ASAP, moving far, FAR, VERY FAR away soon. Table is self-clearing, food just flies off on its own! No input needed, just line the floor with plastic and clearing the table after dinner will be a thing of the past. I'd recommend not using any sharp utensils, maybe stick to disposable cutlery. Dining set is self-healing! We caught it on fire once, it burned up completely but was ready for dinner the very next day! My loss is your gain on this antique table and chairs as I moving as soon as my house is done burning which could be anywhere from today to a week from now. Come pick up this lovely dining set free of charge! No really, please! You can have it! Oh God, it knows what we'reeadfdsaf",
                            ListingTime = new DateTime(2023, 9, 28, 18, 48, 25, 760, DateTimeKind.Local).AddTicks(4252),
                            OwnerId = 4,
                            Price = 0f,
                            SaleStatus = false,
                            Title = "Victorian Dining Set. Not Haunted."
                        });
                });

            modelBuilder.Entity("QwikThrift.Models.DAL.Message", b =>
                {
                    b.Property<int>("MessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MessageId"), 1L, 1);

                    b.Property<string>("Body")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("MessageRead")
                        .HasColumnType("bit");

                    b.Property<int>("RecipientId")
                        .HasColumnType("int");

                    b.Property<int>("SenderId")
                        .HasColumnType("int");

                    b.Property<string>("Subject")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.HasKey("MessageId");

                    b.HasIndex("RecipientId");

                    b.HasIndex("SenderId");

                    b.ToTable("Messages");

                    b.HasData(
                        new
                        {
                            MessageId = 1,
                            Body = "Hello \"Tyler,\" or should I call you Jeremy! You thought you could get rid of me that easily! FOOOOOOOOL! I am everywhere, I am nowhere, I am your personal living nightmare.",
                            MessageRead = false,
                            RecipientId = 4,
                            SenderId = 5,
                            Subject = "Victorian Dining Set. Not Haunted",
                            Timestamp = new DateTime(2023, 7, 3, 17, 42, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            MessageId = 2,
                            Body = "Hi Scott, I have some questions about the bus you have for sale. Do you know if this magical bus can traverse dimensions? I’m looking to get rid of some… unique furniture and I really need it FAR away. I can’t say much, I think I’m being watched! I’ll give you whatever you want, I don’t know where else to turn. This is the first piece of good news. Got to go!!!!!",
                            MessageRead = false,
                            RecipientId = 3,
                            SenderId = 4,
                            Subject = "School Bus Camper",
                            Timestamp = new DateTime(2023, 7, 3, 17, 46, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            MessageId = 3,
                            Body = "Tyler, I’m not sure what you mean by that. As I mentioned in my post, I’ve really only driven it once and it didn’t go well. You’re more than welcome to come see for yourself, but I will not be setting foot in that thing again. You can take it for a test drive if you need to, but I’ll need the money up front if you’re planning on leaving the neighborhood. I’ll have it towed to a nearby parking lot and we can meet up there.",
                            MessageRead = false,
                            RecipientId = 4,
                            SenderId = 3,
                            Subject = "RE:School Bus Camper",
                            Timestamp = new DateTime(2023, 7, 3, 19, 12, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            MessageId = 4,
                            Body = "So listen, this “car” is a rusty hunk of metal. I’d give ya 300 bucks if you haul it to me.",
                            MessageRead = false,
                            RecipientId = 2,
                            SenderId = 3,
                            Subject = "Totally Fine Car",
                            Timestamp = new DateTime(2023, 8, 21, 13, 17, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            MessageId = 5,
                            Body = "You got to be out your mind! This car is in pristine condition!! How dare you! This is the super-luxury-deluxe model! It even has two rear view mirrors for optimal viewing!",
                            MessageRead = false,
                            RecipientId = 3,
                            SenderId = 2,
                            Subject = "RE:Totally Fine Car",
                            Timestamp = new DateTime(2023, 8, 21, 14, 32, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            MessageId = 6,
                            Body = "Why would the passenger need a mirror in the first place?! So they can also see what they’re towing in this rust bucket?! This thing couldn't make it out of the driveway without losing a muffler! What's the deal with those tires? Are they forever melted to the pavement?",
                            MessageRead = false,
                            RecipientId = 2,
                            SenderId = 3,
                            Subject = "RE:Totally Fine Car",
                            Timestamp = new DateTime(2023, 8, 21, 14, 44, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            MessageId = 7,
                            Body = "Look, the tires are free if you buy the car! You care about tires anyway! You got perfectly good rims to ride on! You darn city folk and your fancy things like tires wouldn’t know a good car if it bit ya where the sun don’t shine [spit pings off spitoon]. Tell ya what city slicker, you can have it for $1,000 final offer!",
                            MessageRead = false,
                            RecipientId = 3,
                            SenderId = 2,
                            Subject = "RE:Totally Fine Car",
                            Timestamp = new DateTime(2023, 8, 21, 15, 6, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            MessageId = 8,
                            Body = "Alright captain, I think I like your style. You didn't have to narrate those cool spit actions, but you went ahead and did anyway, like a boss. I’ll take your deal old man. Meet downtown tomorrow. High noon.",
                            MessageRead = false,
                            RecipientId = 2,
                            SenderId = 3,
                            Subject = "RE:Totally Fine Car",
                            Timestamp = new DateTime(2023, 8, 21, 15, 28, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("QwikThrift.Models.DAL.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId");

                    b.HasIndex("Username")
                        .IsUnique()
                        .HasFilter("[Username] IS NOT NULL");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Email = "nunya@bidness.com",
                            PasswordHash = "굖鋠㤰䇸ꅄᒑⓈꊲ⚓�］꺑᝚ꋴ띎ऎ쥸퓋⿉ʭ욪빖�牔⾉떛",
                            Role = 0,
                            Username = "Admin"
                        },
                        new
                        {
                            UserId = 2,
                            Email = "NoMoSpam@byte.me",
                            PasswordHash = "弼薉뱦烙Њ噲䵦ഛᛪ䫽拐誆ײ脻♹她冀侗願뼞伝꣺빙﯌㝵沈覅�",
                            Role = 1,
                            Username = "Josh"
                        },
                        new
                        {
                            UserId = 3,
                            Email = "IRanOutOfCleaverNames@my.brain",
                            PasswordHash = "튛㖧ட㷛㓬邯∤쟿낍�⠴꬯흡勵詫ꎠ毃띩ꡅ蒪ᥕŇ竫ၗ文惲䶺蓷対颱㾾",
                            Role = 2,
                            Username = "Scott"
                        },
                        new
                        {
                            UserId = 4,
                            Email = "totallyRealEmail@fakeEmails.com",
                            PasswordHash = "巰锳䈨頴上跒鹓ㄣ⼦๲懺蝘茓ꝿ焗ᩝ᠇摝췭鿄돜䳝ᔃ⭊�靛腇簲꽀",
                            Role = 2,
                            Username = "Tyler"
                        },
                        new
                        {
                            UserId = 5,
                            Email = "Victor@cursedObjects.net",
                            PasswordHash = "룐蝹온魎绸懪吇摧峒�钿诼❆볫忳郘뮅配㧈쥐໼⏜�翔輇陋틤끆",
                            Role = 2,
                            Username = "VictorianDiningSet"
                        });
                });

            modelBuilder.Entity("QwikThrift.Models.DAL.Category", b =>
                {
                    b.HasOne("QwikThrift.Models.DAL.User", "AuthorizedBy")
                        .WithMany()
                        .HasForeignKey("AuthorizedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AuthorizedBy");
                });

            modelBuilder.Entity("QwikThrift.Models.DAL.ImageReference", b =>
                {
                    b.HasOne("QwikThrift.Models.DAL.Listing", "Listing")
                        .WithMany("Images")
                        .HasForeignKey("ListingId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Listing");
                });

            modelBuilder.Entity("QwikThrift.Models.DAL.Listing", b =>
                {
                    b.HasOne("QwikThrift.Models.DAL.Category", "Category")
                        .WithMany("Listings")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("QwikThrift.Models.DAL.User", "Owner")
                        .WithMany("Listings")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("QwikThrift.Models.DAL.Message", b =>
                {
                    b.HasOne("QwikThrift.Models.DAL.User", "Recipient")
                        .WithMany("MessagesRecieved")
                        .HasForeignKey("RecipientId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("QwikThrift.Models.DAL.User", "Sender")
                        .WithMany("MessagesSent")
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Recipient");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("QwikThrift.Models.DAL.Category", b =>
                {
                    b.Navigation("Listings");
                });

            modelBuilder.Entity("QwikThrift.Models.DAL.Listing", b =>
                {
                    b.Navigation("Images");
                });

            modelBuilder.Entity("QwikThrift.Models.DAL.User", b =>
                {
                    b.Navigation("Listings");

                    b.Navigation("MessagesRecieved");

                    b.Navigation("MessagesSent");
                });
#pragma warning restore 612, 618
        }
    }
}
