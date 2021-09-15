﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Products.Infrastructure.Persistence;

namespace Products.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210915200831_SeedProductData")]
    partial class SeedProductData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Products.Domain.Entities.Inventory", b =>
                {
                    b.Property<string>("InventoryId")
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)")
                        .HasColumnName("InventoryID");

                    b.Property<DateTime>("InventoryDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("InventoryLocation")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("InventoryId");

                    b.ToTable("Inventory");
                });

            modelBuilder.Entity("Products.Domain.Entities.InventoryItem", b =>
                {
                    b.Property<string>("InventoryId")
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)")
                        .HasColumnName("InventoryID");

                    b.Property<string>("CompanyPrefix")
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<string>("ItemReference")
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)");

                    b.Property<string>("SerialNumber")
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<byte>("Filter")
                        .HasColumnType("tinyint");

                    b.Property<string>("HexTag")
                        .IsRequired()
                        .HasMaxLength(24)
                        .HasColumnType("nvarchar(24)");

                    b.Property<string>("TagUri")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("InventoryId", "CompanyPrefix", "ItemReference", "SerialNumber");

                    b.HasIndex("CompanyPrefix", "ItemReference");

                    b.ToTable("InventoryItem");
                });

            modelBuilder.Entity("Products.Domain.Entities.Product", b =>
                {
                    b.Property<string>("CompanyPrefix")
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<string>("ItemReference")
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("CompanyPrefix", "ItemReference");

                    b.ToTable("Product");

                    b.HasData(
                        new
                        {
                            CompanyPrefix = "3319361",
                            ItemReference = "407205",
                            CompanyName = "Sanford LLC",
                            ProductName = "Beans - Kidney, Red Dry"
                        },
                        new
                        {
                            CompanyPrefix = "6314853123",
                            ItemReference = "877",
                            CompanyName = "Gleichner, Rodriguez and Wilkinson",
                            ProductName = "Scallops - In Shell"
                        },
                        new
                        {
                            CompanyPrefix = "39266333",
                            ItemReference = "21526",
                            CompanyName = "Mertz, O'Conner and Heaney",
                            ProductName = "Fruit Mix - Light"
                        },
                        new
                        {
                            CompanyPrefix = "213645",
                            ItemReference = "6152432",
                            CompanyName = "McGlynn Inc",
                            ProductName = "Pickles - Gherkins"
                        },
                        new
                        {
                            CompanyPrefix = "178504",
                            ItemReference = "2577266",
                            CompanyName = "Thompson LLC",
                            ProductName = "Straws - Cocktale"
                        },
                        new
                        {
                            CompanyPrefix = "964495",
                            ItemReference = "3508204",
                            CompanyName = "Halvorson and Sons",
                            ProductName = "Cotton Wet Mop 16 Oz"
                        },
                        new
                        {
                            CompanyPrefix = "585675",
                            ItemReference = "4259784",
                            CompanyName = "Torphy-Becker",
                            ProductName = "Wine - Merlot Vina Carmen"
                        },
                        new
                        {
                            CompanyPrefix = "9488123",
                            ItemReference = "147805",
                            CompanyName = "Kunze, Wilkinson and Sawayn",
                            ProductName = "Bread - Multigrain, Loaf"
                        },
                        new
                        {
                            CompanyPrefix = "086906",
                            ItemReference = "1437603",
                            CompanyName = "Blanda-Hagenes",
                            ProductName = "Pasta - Penne, Rigate, Dry"
                        },
                        new
                        {
                            CompanyPrefix = "2973701",
                            ItemReference = "682407",
                            CompanyName = "Bednar-Mitchell",
                            ProductName = "Bols Melon Liqueur"
                        },
                        new
                        {
                            CompanyPrefix = "7942595",
                            ItemReference = "565126",
                            CompanyName = "Hilpert Group",
                            ProductName = "Pate - Cognac"
                        },
                        new
                        {
                            CompanyPrefix = "587451",
                            ItemReference = "1074506",
                            CompanyName = "Lindgren, Witting and Wiegand",
                            ProductName = "Pork - Loin, Center Cut"
                        },
                        new
                        {
                            CompanyPrefix = "40777411",
                            ItemReference = "36953",
                            CompanyName = "Larson, Reilly and Cruickshank",
                            ProductName = "Tea - Green"
                        },
                        new
                        {
                            CompanyPrefix = "227113",
                            ItemReference = "5935575",
                            CompanyName = "Walsh-Schamberger",
                            ProductName = "Wine - Chateau Bonnet"
                        },
                        new
                        {
                            CompanyPrefix = "3733204",
                            ItemReference = "647520",
                            CompanyName = "Orn-Langosh",
                            ProductName = "Extract - Lemon"
                        },
                        new
                        {
                            CompanyPrefix = "885734",
                            ItemReference = "8756756",
                            CompanyName = "Deckow LLC",
                            ProductName = "Muffins - Assorted"
                        },
                        new
                        {
                            CompanyPrefix = "2871566",
                            ItemReference = "145216",
                            CompanyName = "Lueilwitz, Schumm and Walsh",
                            ProductName = "Beef - Bresaola"
                        },
                        new
                        {
                            CompanyPrefix = "584202",
                            ItemReference = "2876851",
                            CompanyName = "Bailey LLC",
                            ProductName = "Sugar - Brown, Individual"
                        },
                        new
                        {
                            CompanyPrefix = "5032891234",
                            ItemReference = "138",
                            CompanyName = "Sawayn-Gibson",
                            ProductName = "Pepper - Red Chili"
                        },
                        new
                        {
                            CompanyPrefix = "1999335",
                            ItemReference = "642804",
                            CompanyName = "Gibson-Cormier",
                            ProductName = "Compound - Raspberry"
                        },
                        new
                        {
                            CompanyPrefix = "83250532",
                            ItemReference = "52838",
                            CompanyName = "Fisher Inc",
                            ProductName = "Chicken - Whole"
                        },
                        new
                        {
                            CompanyPrefix = "516232",
                            ItemReference = "7222702",
                            CompanyName = "Leffler-Torphy",
                            ProductName = "Juice - Apple, 341 Ml"
                        },
                        new
                        {
                            CompanyPrefix = "043907",
                            ItemReference = "3406731",
                            CompanyName = "Nolan-Walter",
                            ProductName = "Beans - Kidney White"
                        },
                        new
                        {
                            CompanyPrefix = "4584903",
                            ItemReference = "679405",
                            CompanyName = "Heller, Koepp and Powlowski",
                            ProductName = "Beer - Camerons Cream Ale"
                        },
                        new
                        {
                            CompanyPrefix = "983682",
                            ItemReference = "4365465",
                            CompanyName = "Dickens and Sons",
                            ProductName = "Mousse - Mango"
                        },
                        new
                        {
                            CompanyPrefix = "686748",
                            ItemReference = "9119606",
                            CompanyName = "Steuber-Stracke",
                            ProductName = "Cheese - Grie Des Champ"
                        },
                        new
                        {
                            CompanyPrefix = "678362",
                            ItemReference = "4156060",
                            CompanyName = "Lynch, Yundt and Howe",
                            ProductName = "Plastic Arrow Stir Stick"
                        },
                        new
                        {
                            CompanyPrefix = "591271",
                            ItemReference = "5771945",
                            CompanyName = "Lakin, Prosacco and Terry",
                            ProductName = "Chicken Giblets"
                        },
                        new
                        {
                            CompanyPrefix = "069124",
                            ItemReference = "1253252",
                            CompanyName = "Mondelēz International",
                            ProductName = "Milka Oreo"
                        },
                        new
                        {
                            CompanyPrefix = "0107222",
                            ItemReference = "797011",
                            CompanyName = "Armstrong-Schinner",
                            ProductName = "Honey - Comb"
                        },
                        new
                        {
                            CompanyPrefix = "140037",
                            ItemReference = "9818542",
                            CompanyName = "Torp-Reynolds",
                            ProductName = "Beef - Shank"
                        },
                        new
                        {
                            CompanyPrefix = "750917",
                            ItemReference = "7528000",
                            CompanyName = "Becker, Schaefer and Greenholt",
                            ProductName = "Walkers Special Old Whiskey"
                        },
                        new
                        {
                            CompanyPrefix = "317580317580",
                            ItemReference = "7",
                            CompanyName = "Medhurst-Romaguera",
                            ProductName = "Pork - Ground"
                        },
                        new
                        {
                            CompanyPrefix = "390007",
                            ItemReference = "9160738",
                            CompanyName = "Carter-Reynolds",
                            ProductName = "Cornflakes"
                        },
                        new
                        {
                            CompanyPrefix = "528209",
                            ItemReference = "7791950",
                            CompanyName = "Morissette LLC",
                            ProductName = "Shallots"
                        },
                        new
                        {
                            CompanyPrefix = "2180435",
                            ItemReference = "909583",
                            CompanyName = "Gottlieb, Stroman and Grimes",
                            ProductName = "Wine - Magnotta - Cab Franc"
                        },
                        new
                        {
                            CompanyPrefix = "823332",
                            ItemReference = "6492584",
                            CompanyName = "Durgan, Hahn and Runolfsdottir",
                            ProductName = "Carrots - Purple, Organic"
                        },
                        new
                        {
                            CompanyPrefix = "511751",
                            ItemReference = "6644044",
                            CompanyName = "Spencer, Block and Marks",
                            ProductName = "Jam - Blackberry, 20 Ml Jar"
                        },
                        new
                        {
                            CompanyPrefix = "543540",
                            ItemReference = "3141656",
                            CompanyName = "Kozey Group",
                            ProductName = "Wine - Clavet Saint Emilion"
                        },
                        new
                        {
                            CompanyPrefix = "826025",
                            ItemReference = "1130405",
                            CompanyName = "Little Group",
                            ProductName = "Salt - Sea"
                        },
                        new
                        {
                            CompanyPrefix = "110720",
                            ItemReference = "5041310",
                            CompanyName = "O'Hara LLC",
                            ProductName = "V8 Pet"
                        },
                        new
                        {
                            CompanyPrefix = "33314622",
                            ItemReference = "53619",
                            CompanyName = "Weissnat and Sons",
                            ProductName = "Mustard Prepared"
                        },
                        new
                        {
                            CompanyPrefix = "764493764493",
                            ItemReference = "4",
                            CompanyName = "Okuneva, Schneider and Collins",
                            ProductName = "Pumpkin"
                        },
                        new
                        {
                            CompanyPrefix = "428651",
                            ItemReference = "7619450",
                            CompanyName = "Cole LLC",
                            ProductName = "Creme De Cacao Mcguines"
                        },
                        new
                        {
                            CompanyPrefix = "950316",
                            ItemReference = "2380884",
                            CompanyName = "Keeling, Nikolaus and Larkin",
                            ProductName = "Berry Brulee"
                        },
                        new
                        {
                            CompanyPrefix = "870953",
                            ItemReference = "8728496",
                            CompanyName = "Dach-Herzog",
                            ProductName = "Lychee - Canned"
                        },
                        new
                        {
                            CompanyPrefix = "8393604321",
                            ItemReference = "179",
                            CompanyName = "Wolf Inc",
                            ProductName = "Veal - Eye Of Round"
                        },
                        new
                        {
                            CompanyPrefix = "719065",
                            ItemReference = "9765179",
                            CompanyName = "Legros-Cruickshank",
                            ProductName = "Salami - Genova"
                        },
                        new
                        {
                            CompanyPrefix = "758601",
                            ItemReference = "2337085",
                            CompanyName = "Schmeler-Lind",
                            ProductName = "Muffin Mix - Corn Harvest"
                        },
                        new
                        {
                            CompanyPrefix = "368305",
                            ItemReference = "2620417",
                            CompanyName = "Macejkovic-Murazik",
                            ProductName = "Chocolate Eclairs"
                        },
                        new
                        {
                            CompanyPrefix = "791586",
                            ItemReference = "5775051",
                            CompanyName = "Raynor LLC",
                            ProductName = "Gooseberry"
                        },
                        new
                        {
                            CompanyPrefix = "28600054",
                            ItemReference = "41912",
                            CompanyName = "Mosciski, Maggio and DuBuque",
                            ProductName = "Scallops - U - 10"
                        },
                        new
                        {
                            CompanyPrefix = "608240",
                            ItemReference = "2412148",
                            CompanyName = "Von, Gusikowski and Farrell",
                            ProductName = "Beef - Top Butt Aaa"
                        },
                        new
                        {
                            CompanyPrefix = "060643",
                            ItemReference = "9948173",
                            CompanyName = "Beer, Batz and Koch",
                            ProductName = "Chicken Breast Wing On"
                        },
                        new
                        {
                            CompanyPrefix = "127083",
                            ItemReference = "5256251",
                            CompanyName = "Watsica-Labadie",
                            ProductName = "Crush - Grape, 355 Ml"
                        },
                        new
                        {
                            CompanyPrefix = "178540",
                            ItemReference = "3505943",
                            CompanyName = "Tromp-Pacocha",
                            ProductName = "Cheese - Ricotta"
                        },
                        new
                        {
                            CompanyPrefix = "051578",
                            ItemReference = "9086830",
                            CompanyName = "Kuvalis, Doyle and Flatley",
                            ProductName = "Chicken - Leg / Back Attach"
                        },
                        new
                        {
                            CompanyPrefix = "021276",
                            ItemReference = "9837077",
                            CompanyName = "Feil Inc",
                            ProductName = "Coffee Cup 8oz 5338cd"
                        },
                        new
                        {
                            CompanyPrefix = "745230",
                            ItemReference = "6232899",
                            CompanyName = "Nitzsche-Gerlach",
                            ProductName = "Truffle - Whole Black Peeled"
                        },
                        new
                        {
                            CompanyPrefix = "107956107956",
                            ItemReference = "2",
                            CompanyName = "Rodriguez, Beier and Ratke",
                            ProductName = "Salmon - Atlantic, Fresh, Whole"
                        },
                        new
                        {
                            CompanyPrefix = "7002011",
                            ItemReference = "482701",
                            CompanyName = "Orn, Ortiz and Keebler",
                            ProductName = "Bread - Mini Hamburger Bun"
                        },
                        new
                        {
                            CompanyPrefix = "4619611",
                            ItemReference = "162323",
                            CompanyName = "Rolfson, Collins and Runolfsson",
                            ProductName = "Contreau"
                        },
                        new
                        {
                            CompanyPrefix = "108653",
                            ItemReference = "1180386",
                            CompanyName = "Rath, Ferry and Moen",
                            ProductName = "Wine - Spumante Bambino White"
                        },
                        new
                        {
                            CompanyPrefix = "814875",
                            ItemReference = "5090895",
                            CompanyName = "Cummerata-Schaden",
                            ProductName = "Pork - Tenderloin, Fresh"
                        },
                        new
                        {
                            CompanyPrefix = "378922",
                            ItemReference = "8414833",
                            CompanyName = "Rowe-Gibson",
                            ProductName = "Chutney Sauce - Mango"
                        },
                        new
                        {
                            CompanyPrefix = "4499823",
                            ItemReference = "351572",
                            CompanyName = "Daugherty, Hettinger and Koelpin",
                            ProductName = "Smoked Tongue"
                        },
                        new
                        {
                            CompanyPrefix = "1210999912",
                            ItemReference = "123",
                            CompanyName = "Heidenreich-Kessler",
                            ProductName = "Ecolab - Hobart Washarm End Cap"
                        },
                        new
                        {
                            CompanyPrefix = "900706",
                            ItemReference = "8213657",
                            CompanyName = "Weimann-Casper",
                            ProductName = "Sea Bass - Whole"
                        },
                        new
                        {
                            CompanyPrefix = "7408273",
                            ItemReference = "664337",
                            CompanyName = "Stark-McCullough",
                            ProductName = "Turkey - Whole, Fresh"
                        },
                        new
                        {
                            CompanyPrefix = "828415",
                            ItemReference = "5417914",
                            CompanyName = "Weber-Reichel",
                            ProductName = "Flower - Leather Leaf Fern"
                        },
                        new
                        {
                            CompanyPrefix = "451802",
                            ItemReference = "2638491",
                            CompanyName = "Koelpin, Kozey and Grimes",
                            ProductName = "Fond - Neutral"
                        },
                        new
                        {
                            CompanyPrefix = "00169691",
                            ItemReference = "87387",
                            CompanyName = "Smitham Group",
                            ProductName = "Almonds Ground Blanched"
                        },
                        new
                        {
                            CompanyPrefix = "563974",
                            ItemReference = "4156235",
                            CompanyName = "Gusikowski-Leuschke",
                            ProductName = "Cranberries - Dry"
                        },
                        new
                        {
                            CompanyPrefix = "077605",
                            ItemReference = "5749311",
                            CompanyName = "Shanahan, Bernier and Funk",
                            ProductName = "Trout - Smoked"
                        },
                        new
                        {
                            CompanyPrefix = "349605",
                            ItemReference = "4548221",
                            CompanyName = "Harvey-Weber",
                            ProductName = "Wine - Zonnebloem Pinotage"
                        },
                        new
                        {
                            CompanyPrefix = "342472",
                            ItemReference = "6004566",
                            CompanyName = "Macejkovic, Towne and Spencer",
                            ProductName = "Tamarind Paste"
                        },
                        new
                        {
                            CompanyPrefix = "770270770270",
                            ItemReference = "9",
                            CompanyName = "Halvorson, Schinner and Smitham",
                            ProductName = "Pepper Squash"
                        },
                        new
                        {
                            CompanyPrefix = "327884",
                            ItemReference = "7703818",
                            CompanyName = "Welch and Sons",
                            ProductName = "Crab - Blue, Frozen"
                        },
                        new
                        {
                            CompanyPrefix = "812302",
                            ItemReference = "5276620",
                            CompanyName = "Spinka, Hauck and Bogan",
                            ProductName = "Juice Peach Nectar"
                        },
                        new
                        {
                            CompanyPrefix = "905710",
                            ItemReference = "9832832",
                            CompanyName = "Jakubowski-Veum",
                            ProductName = "Plate - Foam, Bread And Butter"
                        },
                        new
                        {
                            CompanyPrefix = "997970",
                            ItemReference = "9212388",
                            CompanyName = "Stark-Ward",
                            ProductName = "Pasta - Ravioli"
                        },
                        new
                        {
                            CompanyPrefix = "917969",
                            ItemReference = "3602750",
                            CompanyName = "Aufderhar Group",
                            ProductName = "Cheese - Ricotta"
                        },
                        new
                        {
                            CompanyPrefix = "096652",
                            ItemReference = "6172545",
                            CompanyName = "Wisoky-Roob",
                            ProductName = "Pork - Kidney"
                        },
                        new
                        {
                            CompanyPrefix = "51151534",
                            ItemReference = "78331",
                            CompanyName = "Schmidt-Quigley",
                            ProductName = "Apple - Delicious, Red"
                        },
                        new
                        {
                            CompanyPrefix = "5023208822",
                            ItemReference = "521",
                            CompanyName = "Smitham, Swaniawski and Upton",
                            ProductName = "Hagen Daza - Dk Choocolate"
                        },
                        new
                        {
                            CompanyPrefix = "446617",
                            ItemReference = "9353565",
                            CompanyName = "Koelpin Inc",
                            ProductName = "Wine - Sauvignon Blanc Oyster"
                        },
                        new
                        {
                            CompanyPrefix = "013332",
                            ItemReference = "4770766",
                            CompanyName = "Little, King and Zboncak",
                            ProductName = "Wine - Red Oakridge Merlot"
                        },
                        new
                        {
                            CompanyPrefix = "600851600851",
                            ItemReference = "2",
                            CompanyName = "O'Conner-Turner",
                            ProductName = "Wild Boar - Tenderloin"
                        },
                        new
                        {
                            CompanyPrefix = "196645",
                            ItemReference = "1236529",
                            CompanyName = "Lynch-Fay",
                            ProductName = "Broccoli - Fresh"
                        },
                        new
                        {
                            CompanyPrefix = "4984121",
                            ItemReference = "901844",
                            CompanyName = "O'Reilly Inc",
                            ProductName = "Pork - Back, Long Cut, Boneless"
                        },
                        new
                        {
                            CompanyPrefix = "676413",
                            ItemReference = "8849362",
                            CompanyName = "Hayes-Schumm",
                            ProductName = "Triple Sec - Mcguinness"
                        },
                        new
                        {
                            CompanyPrefix = "485771",
                            ItemReference = "5339535",
                            CompanyName = "Morar-Schulist",
                            ProductName = "Lamb - Whole Head Off,nz"
                        },
                        new
                        {
                            CompanyPrefix = "793681",
                            ItemReference = "9774282",
                            CompanyName = "Carroll-Hammes",
                            ProductName = "Jicama"
                        },
                        new
                        {
                            CompanyPrefix = "3209622",
                            ItemReference = "461277",
                            CompanyName = "Windler-Stark",
                            ProductName = "Longos - Greek Salad"
                        },
                        new
                        {
                            CompanyPrefix = "823413",
                            ItemReference = "4397760",
                            CompanyName = "Johnson-Donnelly",
                            ProductName = "Grouper - Fresh"
                        },
                        new
                        {
                            CompanyPrefix = "623828",
                            ItemReference = "4865650",
                            CompanyName = "Wolf and Sons",
                            ProductName = "Food Colouring - Orange"
                        },
                        new
                        {
                            CompanyPrefix = "655062",
                            ItemReference = "1232213",
                            CompanyName = "Zboncak Inc",
                            ProductName = "Vermouth - White, Cinzano"
                        },
                        new
                        {
                            CompanyPrefix = "472731472731",
                            ItemReference = "2",
                            CompanyName = "Dicki Group",
                            ProductName = "Soup - Knorr, Chicken Noodle"
                        },
                        new
                        {
                            CompanyPrefix = "443750",
                            ItemReference = "5573641",
                            CompanyName = "Cole, Kemmer and Turner",
                            ProductName = "Spring Roll Veg Mini"
                        },
                        new
                        {
                            CompanyPrefix = "2777462999",
                            ItemReference = "401",
                            CompanyName = "Gottlieb-Denesik",
                            ProductName = "Bread - Hamburger Buns"
                        });
                });

            modelBuilder.Entity("Products.Domain.Entities.InventoryItem", b =>
                {
                    b.HasOne("Products.Domain.Entities.Inventory", "Inventory")
                        .WithMany("InventoryItems")
                        .HasForeignKey("InventoryId")
                        .HasConstraintName("FK_InventoryItem_Inventory")
                        .IsRequired();

                    b.HasOne("Products.Domain.Entities.Product", "Product")
                        .WithMany("InventoryItems")
                        .HasForeignKey("CompanyPrefix", "ItemReference")
                        .HasConstraintName("FK_InventoryItem_Product")
                        .IsRequired();

                    b.Navigation("Inventory");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Products.Domain.Entities.Inventory", b =>
                {
                    b.Navigation("InventoryItems");
                });

            modelBuilder.Entity("Products.Domain.Entities.Product", b =>
                {
                    b.Navigation("InventoryItems");
                });
#pragma warning restore 612, 618
        }
    }
}