﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QwikThrift.Migrations
{
    public partial class seedDataAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "PasswordHash", "Role", "Username" },
                values: new object[,]
                {
                    { 1, "nunya@bidness.com", "굖鋠㤰䇸ꅄᒑⓈꊲ⚓�］꺑᝚ꋴ띎ऎ쥸퓋⿉ʭ욪빖�牔⾉떛", 0, "Admin" },
                    { 2, "NoMoSpam@byte.me", "弼薉뱦烙Њ噲䵦ഛᛪ䫽拐誆ײ脻♹她冀侗願뼞伝꣺빙﯌㝵沈覅�", 1, "Josh" },
                    { 3, "IRanOutOfCleaverNames@my.brain", "튛㖧ட㷛㓬邯∤쟿낍�⠴꬯흡勵詫ꎠ毃띩ꡅ蒪ᥕŇ竫ၗ文惲䶺蓷対颱㾾", 2, "Scott" },
                    { 4, "totallyRealEmail@fakeEmails.com", "巰锳䈨頴上跒鹓ㄣ⼦๲懺蝘茓ꝿ焗ᩝ᠇摝췭鿄돜䳝ᔃ⭊�靛腇簲꽀", 2, "Tyler" },
                    { 5, "Victor@cursedObjects.net", "룐蝹온魎绸懪吇摧峒�钿诼❆볫忳郘뮅配㧈쥐໼⏜�翔輇陋틤끆", 2, "VictorianDiningSet" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "AuthorizedById", "CategoryDescription", "CategoryName" },
                values: new object[,]
                {
                    { 1, 1, "Cars, boats, planes, tanks, basically anything that moves and goesvroom-vroom or even zappy-zap.", "Vehicles" },
                    { 2, 1, "if (CanSit || CanPlaceStuffOn) Category = \"Furnature\"", "Furniture" },
                    { 3, 1, "Things that beep-boop and make nerds (like us) happy.", "Technology" }
                });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "MessageId", "Body", "RecipientId", "SenderId", "Subject", "Timestamp" },
                values: new object[,]
                {
                    { 1, "Hello \"Tyler,\" or should I call you Jeremy! You thought you could get rid of me that easily! FOOOOOOOOL! I am everywhere, I am nowhere, I am your personal living nightmare.", 4, 5, "Victorian Dining Set. Not Haunted", new DateTime(2023, 7, 3, 17, 42, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Hi Scott, I have some questions about the bus you have for sale. Do you know if this magical bus can traverse dimensions? I’m looking to get rid of some… unique furniture and I really need it FAR away. I can’t say much, I think I’m being watched! I’ll give you whatever you want, I don’t know where else to turn. This is the first piece of good news. Got to go!!!!!", 3, 4, "School Bus Camper", new DateTime(2023, 7, 3, 17, 46, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Tyler, I’m not sure what you mean by that. As I mentioned in my post, I’ve really only driven it once and it didn’t go well. You’re more than welcome to come see for yourself, but I will not be setting foot in that thing again. You can take it for a test drive if you need to, but I’ll need the money up front if you’re planning on leaving the neighborhood. I’ll have it towed to a nearby parking lot and we can meet up there.", 4, 3, "RE:School Bus Camper", new DateTime(2023, 7, 3, 19, 12, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "So listen, this “car” is a rusty hunk of metal. I’d give ya 300 bucks if you haul it to me.", 2, 3, "Totally Fine Car", new DateTime(2023, 8, 21, 13, 17, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "You got to be out your mind! This car is in pristine condition!! How dare you! This is the super-luxury-deluxe model! It even has two rear view mirrors for optimal viewing!", 3, 2, "RE:Totally Fine Car", new DateTime(2023, 8, 21, 14, 32, 0, 0, DateTimeKind.Unspecified) },
                    { 6, "Why would the passenger need a mirror in the first place?! So they can also see what they’re towing in this rust bucket?! This thing couldn't make it out of the driveway without losing a muffler! What's the deal with those tires? Are they forever melted to the pavement?", 2, 3, "RE:Totally Fine Car", new DateTime(2023, 8, 21, 14, 44, 0, 0, DateTimeKind.Unspecified) },
                    { 7, "Look, the tires are free if you buy the car! You care about tires anyway! You got perfectly good rims to ride on! You darn city folk and your fancy things like tires wouldn’t know a good car if it bit ya where the sun don’t shine [spit pings off spitoon]. Tell ya what city slicker, you can have it for $1,000 final offer!", 3, 2, "RE:Totally Fine Car", new DateTime(2023, 8, 21, 15, 6, 0, 0, DateTimeKind.Unspecified) },
                    { 8, "Alright captain, I think I like your style. You didn't have to narrate those cool spit actions, but you went ahead and did anyway, like a boss. I’ll take your deal old man. Meet downtown tomorrow. High noon.", 2, 3, "RE:Totally Fine Car", new DateTime(2023, 8, 21, 15, 28, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Listings",
                columns: new[] { "ListingId", "CategoryId", "Description", "ListingTime", "OwnerId", "Price", "SaleStatus", "Title" },
                values: new object[,]
                {
                    { 1, 1, "Runs great! Drives straight down the road (on curved roads). Has minor cosmetic damage to the front-end. Only 1,286,032 miles! $25,600 FIRM, no low-ballers, I KNOW WHAT I HAVE!", new DateTime(2018, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 23000f, false, "Totally Fine Car." },
                    { 2, 1, "I bought this bus a few years back with the intention of making the ultimate camper. The woman I bought it from was kinda crazy and told me it was magic. It does have a deceptively spacious interior! I didn't think anything of her magic claim until I took my first trip about a year later. I pressed the wrong button and ended up in a homeless man's bloodstream. There are some things in this world you just can't unsee! If anyone out there knows how to drive a school bus with magical powers, it's yours for just $5,500. Price is firm, the therapy bills are beginning to add up.", new DateTime(2000, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 5500f, false, "School Bus Camper" },
                    { 3, 3, "Recovered from vehicle wreckage. Rare time-travel device only used 9 times! Like-new condition! Must travel at 88mph to activate, highly recommend a faster car than a DMC Delorian! I considered trying to install it in my new truck I mysteriously acquired, but I don't know much about it and honestly, I've had about enough time traveling mishaps for one lifetime. One of a kind item, not sure what it's worth so make me an offer.", new DateTime(1985, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 10000f, false, "Flux Capacitor" },
                    { 4, 2, "Need to sell ASAP, moving far, FAR, VERY FAR away soon. Table is self-clearing, food just flies off on its own! No input needed, just line the floor with plastic and clearing the table after dinner will be a thing of the past. I'd recommend not using any sharp utensils, maybe stick to disposable cutlery. Dining set is self-healing! We caught it on fire once, it burned up completely but was ready for dinner the very next day! My loss is your gain on this antique table and chairs as I moving as soon as my house is done burning which could be anywhere from today to a week from now. Come pick up this lovely dining set free of charge! No really, please! You can have it! Oh God, it knows what we'reeadfdsaf", new DateTime(2023, 9, 25, 17, 13, 0, 548, DateTimeKind.Local).AddTicks(2840), 4, 0f, false, "Victorian Dining Set. Not Haunted." }
                });

            migrationBuilder.InsertData(
                table: "ImageReferences",
                columns: new[] { "ImageReferenceId", "Description", "Filename", "ListingId", "Name", "Path" },
                values: new object[,]
                {
                    { 1, "", "fineCar.png", 1, "Fine Car", "\\images\\listings\\1\\" },
                    { 2, "", "fineCarInside.png", 1, "inside", "\\images\\listings\\1\\" },
                    { 3, "", "magicBus.jpg", 2, "Magic Bus", "\\images\\listings\\2\\" },
                    { 4, "", "magicBusInside.png", 2, "Inside 1", "\\images\\listings\\2\\" },
                    { 5, "", "magicBusInside2.jpg", 2, "Inside 2", "\\images\\listings\\2\\" },
                    { 6, "", "timeTravelDev.jpg", 3, "flux capacitor", "\\images\\listings\\3\\" },
                    { 7, "", "notHauntedTable.png", 4, "Probably haunted table", "\\images\\listings\\4\\" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ImageReferences",
                keyColumn: "ImageReferenceId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ImageReferences",
                keyColumn: "ImageReferenceId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ImageReferences",
                keyColumn: "ImageReferenceId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ImageReferences",
                keyColumn: "ImageReferenceId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ImageReferences",
                keyColumn: "ImageReferenceId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ImageReferences",
                keyColumn: "ImageReferenceId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ImageReferences",
                keyColumn: "ImageReferenceId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Listings",
                keyColumn: "ListingId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Listings",
                keyColumn: "ListingId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Listings",
                keyColumn: "ListingId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Listings",
                keyColumn: "ListingId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);
        }
    }
}
