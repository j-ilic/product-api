using Microsoft.EntityFrameworkCore.Migrations;

namespace Products.Infrastructure.Persistence.Migrations
{
    public partial class SeedProductData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "CompanyPrefix", "ItemReference", "CompanyName", "ProductName" },
                values: new object[,]
                {
                    { "3319361", "407205", "Sanford LLC", "Beans - Kidney, Red Dry" },
                    { "563974", "4156235", "Gusikowski-Leuschke", "Cranberries - Dry" },
                    { "00169691", "87387", "Smitham Group", "Almonds Ground Blanched" },
                    { "451802", "2638491", "Koelpin, Kozey and Grimes", "Fond - Neutral" },
                    { "828415", "5417914", "Weber-Reichel", "Flower - Leather Leaf Fern" },
                    { "7408273", "664337", "Stark-McCullough", "Turkey - Whole, Fresh" },
                    { "900706", "8213657", "Weimann-Casper", "Sea Bass - Whole" },
                    { "1210999912", "123", "Heidenreich-Kessler", "Ecolab - Hobart Washarm End Cap" },
                    { "4499823", "351572", "Daugherty, Hettinger and Koelpin", "Smoked Tongue" },
                    { "378922", "8414833", "Rowe-Gibson", "Chutney Sauce - Mango" },
                    { "814875", "5090895", "Cummerata-Schaden", "Pork - Tenderloin, Fresh" },
                    { "108653", "1180386", "Rath, Ferry and Moen", "Wine - Spumante Bambino White" },
                    { "4619611", "162323", "Rolfson, Collins and Runolfsson", "Contreau" },
                    { "7002011", "482701", "Orn, Ortiz and Keebler", "Bread - Mini Hamburger Bun" },
                    { "107956107956", "2", "Rodriguez, Beier and Ratke", "Salmon - Atlantic, Fresh, Whole" },
                    { "745230", "6232899", "Nitzsche-Gerlach", "Truffle - Whole Black Peeled" },
                    { "021276", "9837077", "Feil Inc", "Coffee Cup 8oz 5338cd" },
                    { "051578", "9086830", "Kuvalis, Doyle and Flatley", "Chicken - Leg / Back Attach" },
                    { "178540", "3505943", "Tromp-Pacocha", "Cheese - Ricotta" },
                    { "127083", "5256251", "Watsica-Labadie", "Crush - Grape, 355 Ml" },
                    { "060643", "9948173", "Beer, Batz and Koch", "Chicken Breast Wing On" },
                    { "608240", "2412148", "Von, Gusikowski and Farrell", "Beef - Top Butt Aaa" },
                    { "077605", "5749311", "Shanahan, Bernier and Funk", "Trout - Smoked" },
                    { "28600054", "41912", "Mosciski, Maggio and DuBuque", "Scallops - U - 10" },
                    { "349605", "4548221", "Harvey-Weber", "Wine - Zonnebloem Pinotage" },
                    { "770270770270", "9", "Halvorson, Schinner and Smitham", "Pepper Squash" },
                    { "472731472731", "2", "Dicki Group", "Soup - Knorr, Chicken Noodle" },
                    { "655062", "1232213", "Zboncak Inc", "Vermouth - White, Cinzano" },
                    { "623828", "4865650", "Wolf and Sons", "Food Colouring - Orange" },
                    { "823413", "4397760", "Johnson-Donnelly", "Grouper - Fresh" },
                    { "3209622", "461277", "Windler-Stark", "Longos - Greek Salad" },
                    { "793681", "9774282", "Carroll-Hammes", "Jicama" },
                    { "485771", "5339535", "Morar-Schulist", "Lamb - Whole Head Off,nz" },
                    { "676413", "8849362", "Hayes-Schumm", "Triple Sec - Mcguinness" },
                    { "4984121", "901844", "O'Reilly Inc", "Pork - Back, Long Cut, Boneless" },
                    { "196645", "1236529", "Lynch-Fay", "Broccoli - Fresh" },
                    { "600851600851", "2", "O'Conner-Turner", "Wild Boar - Tenderloin" },
                    { "013332", "4770766", "Little, King and Zboncak", "Wine - Red Oakridge Merlot" },
                    { "446617", "9353565", "Koelpin Inc", "Wine - Sauvignon Blanc Oyster" },
                    { "5023208822", "521", "Smitham, Swaniawski and Upton", "Hagen Daza - Dk Choocolate" },
                    { "51151534", "78331", "Schmidt-Quigley", "Apple - Delicious, Red" },
                    { "096652", "6172545", "Wisoky-Roob", "Pork - Kidney" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "CompanyPrefix", "ItemReference", "CompanyName", "ProductName" },
                values: new object[,]
                {
                    { "917969", "3602750", "Aufderhar Group", "Cheese - Ricotta" },
                    { "997970", "9212388", "Stark-Ward", "Pasta - Ravioli" },
                    { "905710", "9832832", "Jakubowski-Veum", "Plate - Foam, Bread And Butter" },
                    { "812302", "5276620", "Spinka, Hauck and Bogan", "Juice Peach Nectar" },
                    { "327884", "7703818", "Welch and Sons", "Crab - Blue, Frozen" },
                    { "342472", "6004566", "Macejkovic, Towne and Spencer", "Tamarind Paste" },
                    { "791586", "5775051", "Raynor LLC", "Gooseberry" },
                    { "368305", "2620417", "Macejkovic-Murazik", "Chocolate Eclairs" },
                    { "758601", "2337085", "Schmeler-Lind", "Muffin Mix - Corn Harvest" },
                    { "516232", "7222702", "Leffler-Torphy", "Juice - Apple, 341 Ml" },
                    { "83250532", "52838", "Fisher Inc", "Chicken - Whole" },
                    { "1999335", "642804", "Gibson-Cormier", "Compound - Raspberry" },
                    { "5032891234", "138", "Sawayn-Gibson", "Pepper - Red Chili" },
                    { "584202", "2876851", "Bailey LLC", "Sugar - Brown, Individual" },
                    { "2871566", "145216", "Lueilwitz, Schumm and Walsh", "Beef - Bresaola" },
                    { "885734", "8756756", "Deckow LLC", "Muffins - Assorted" },
                    { "3733204", "647520", "Orn-Langosh", "Extract - Lemon" },
                    { "227113", "5935575", "Walsh-Schamberger", "Wine - Chateau Bonnet" },
                    { "40777411", "36953", "Larson, Reilly and Cruickshank", "Tea - Green" },
                    { "587451", "1074506", "Lindgren, Witting and Wiegand", "Pork - Loin, Center Cut" },
                    { "7942595", "565126", "Hilpert Group", "Pate - Cognac" },
                    { "2973701", "682407", "Bednar-Mitchell", "Bols Melon Liqueur" },
                    { "086906", "1437603", "Blanda-Hagenes", "Pasta - Penne, Rigate, Dry" },
                    { "9488123", "147805", "Kunze, Wilkinson and Sawayn", "Bread - Multigrain, Loaf" },
                    { "585675", "4259784", "Torphy-Becker", "Wine - Merlot Vina Carmen" },
                    { "964495", "3508204", "Halvorson and Sons", "Cotton Wet Mop 16 Oz" },
                    { "178504", "2577266", "Thompson LLC", "Straws - Cocktale" },
                    { "213645", "6152432", "McGlynn Inc", "Pickles - Gherkins" },
                    { "39266333", "21526", "Mertz, O'Conner and Heaney", "Fruit Mix - Light" },
                    { "6314853123", "877", "Gleichner, Rodriguez and Wilkinson", "Scallops - In Shell" },
                    { "043907", "3406731", "Nolan-Walter", "Beans - Kidney White" },
                    { "4584903", "679405", "Heller, Koepp and Powlowski", "Beer - Camerons Cream Ale" },
                    { "983682", "4365465", "Dickens and Sons", "Mousse - Mango" },
                    { "686748", "9119606", "Steuber-Stracke", "Cheese - Grie Des Champ" },
                    { "719065", "9765179", "Legros-Cruickshank", "Salami - Genova" },
                    { "8393604321", "179", "Wolf Inc", "Veal - Eye Of Round" },
                    { "870953", "8728496", "Dach-Herzog", "Lychee - Canned" },
                    { "950316", "2380884", "Keeling, Nikolaus and Larkin", "Berry Brulee" },
                    { "428651", "7619450", "Cole LLC", "Creme De Cacao Mcguines" },
                    { "764493764493", "4", "Okuneva, Schneider and Collins", "Pumpkin" },
                    { "33314622", "53619", "Weissnat and Sons", "Mustard Prepared" },
                    { "110720", "5041310", "O'Hara LLC", "V8 Pet" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "CompanyPrefix", "ItemReference", "CompanyName", "ProductName" },
                values: new object[,]
                {
                    { "826025", "1130405", "Little Group", "Salt - Sea" },
                    { "543540", "3141656", "Kozey Group", "Wine - Clavet Saint Emilion" },
                    { "443750", "5573641", "Cole, Kemmer and Turner", "Spring Roll Veg Mini" },
                    { "511751", "6644044", "Spencer, Block and Marks", "Jam - Blackberry, 20 Ml Jar" },
                    { "2180435", "909583", "Gottlieb, Stroman and Grimes", "Wine - Magnotta - Cab Franc" },
                    { "528209", "7791950", "Morissette LLC", "Shallots" },
                    { "390007", "9160738", "Carter-Reynolds", "Cornflakes" },
                    { "317580317580", "7", "Medhurst-Romaguera", "Pork - Ground" },
                    { "750917", "7528000", "Becker, Schaefer and Greenholt", "Walkers Special Old Whiskey" },
                    { "140037", "9818542", "Torp-Reynolds", "Beef - Shank" },
                    { "0107222", "797011", "Armstrong-Schinner", "Honey - Comb" },
                    { "069124", "1253252", "Mondelēz International", "Milka Oreo" },
                    { "591271", "5771945", "Lakin, Prosacco and Terry", "Chicken Giblets" },
                    { "678362", "4156060", "Lynch, Yundt and Howe", "Plastic Arrow Stir Stick" },
                    { "823332", "6492584", "Durgan, Hahn and Runolfsdottir", "Carrots - Purple, Organic" },
                    { "2777462999", "401", "Gottlieb-Denesik", "Bread - Hamburger Buns" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Product",
                keyColumns: new[] { "CompanyPrefix", "ItemReference" },
                keyValues: new object[] { "00169691", "87387" });

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumns: new[] { "CompanyPrefix", "ItemReference" },
                keyValues: new object[] { "0107222", "797011" });

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumns: new[] { "CompanyPrefix", "ItemReference" },
                keyValues: new object[] { "013332", "4770766" });

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumns: new[] { "CompanyPrefix", "ItemReference" },
                keyValues: new object[] { "021276", "9837077" });

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumns: new[] { "CompanyPrefix", "ItemReference" },
                keyValues: new object[] { "043907", "3406731" });

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumns: new[] { "CompanyPrefix", "ItemReference" },
                keyValues: new object[] { "051578", "9086830" });

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumns: new[] { "CompanyPrefix", "ItemReference" },
                keyValues: new object[] { "060643", "9948173" });

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumns: new[] { "CompanyPrefix", "ItemReference" },
                keyValues: new object[] { "069124", "1253252" });

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumns: new[] { "CompanyPrefix", "ItemReference" },
                keyValues: new object[] { "077605", "5749311" });

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumns: new[] { "CompanyPrefix", "ItemReference" },
                keyValues: new object[] { "086906", "1437603" });

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumns: new[] { "CompanyPrefix", "ItemReference" },
                keyValues: new object[] { "096652", "6172545" });

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumns: new[] { "CompanyPrefix", "ItemReference" },
                keyValues: new object[] { "107956107956", "2" });

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumns: new[] { "CompanyPrefix", "ItemReference" },
                keyValues: new object[] { "108653", "1180386" });

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumns: new[] { "CompanyPrefix", "ItemReference" },
                keyValues: new object[] { "110720", "5041310" });

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumns: new[] { "CompanyPrefix", "ItemReference" },
                keyValues: new object[] { "1210999912", "123" });

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumns: new[] { "CompanyPrefix", "ItemReference" },
                keyValues: new object[] { "127083", "5256251" });

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumns: new[] { "CompanyPrefix", "ItemReference" },
                keyValues: new object[] { "140037", "9818542" });

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumns: new[] { "CompanyPrefix", "ItemReference" },
                keyValues: new object[] { "178504", "2577266" });

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumns: new[] { "CompanyPrefix", "ItemReference" },
                keyValues: new object[] { "178540", "3505943" });

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumns: new[] { "CompanyPrefix", "ItemReference" },
                keyValues: new object[] { "196645", "1236529" });

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumns: new[] { "CompanyPrefix", "ItemReference" },
                keyValues: new object[] { "1999335", "642804" });

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumns: new[] { "CompanyPrefix", "ItemReference" },
                keyValues: new object[] { "213645", "6152432" });

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumns: new[] { "CompanyPrefix", "ItemReference" },
                keyValues: new object[] { "2180435", "909583" });

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumns: new[] { "CompanyPrefix", "ItemReference" },
                keyValues: new object[] { "227113", "5935575" });

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumns: new[] { "CompanyPrefix", "ItemReference" },
                keyValues: new object[] { "2777462999", "401" });

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumns: new[] { "CompanyPrefix", "ItemReference" },
                keyValues: new object[] { "28600054", "41912" });

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumns: new[] { "CompanyPrefix", "ItemReference" },
                keyValues: new object[] { "2871566", "145216" });

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumns: new[] { "CompanyPrefix", "ItemReference" },
                keyValues: new object[] { "2973701", "682407" });

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumns: new[] { "CompanyPrefix", "ItemReference" },
                keyValues: new object[] { "317580317580", "7" });

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumns: new[] { "CompanyPrefix", "ItemReference" },
                keyValues: new object[] { "3209622", "461277" });

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumns: new[] { "CompanyPrefix", "ItemReference" },
                keyValues: new object[] { "327884", "7703818" });

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumns: new[] { "CompanyPrefix", "ItemReference" },
                keyValues: new object[] { "3319361", "407205" });

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumns: new[] { "CompanyPrefix", "ItemReference" },
                keyValues: new object[] { "33314622", "53619" });

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumns: new[] { "CompanyPrefix", "ItemReference" },
                keyValues: new object[] { "342472", "6004566" });

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumns: new[] { "CompanyPrefix", "ItemReference" },
                keyValues: new object[] { "349605", "4548221" });

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumns: new[] { "CompanyPrefix", "ItemReference" },
                keyValues: new object[] { "368305", "2620417" });

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumns: new[] { "CompanyPrefix", "ItemReference" },
                keyValues: new object[] { "3733204", "647520" });

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumns: new[] { "CompanyPrefix", "ItemReference" },
                keyValues: new object[] { "378922", "8414833" });

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumns: new[] { "CompanyPrefix", "ItemReference" },
                keyValues: new object[] { "390007", "9160738" });

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumns: new[] { "CompanyPrefix", "ItemReference" },
                keyValues: new object[] { "39266333", "21526" });

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumns: new[] { "CompanyPrefix", "ItemReference" },
                keyValues: new object[] { "40777411", "36953" });

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumns: new[] { "CompanyPrefix", "ItemReference" },
                keyValues: new object[] { "428651", "7619450" });

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumns: new[] { "CompanyPrefix", "ItemReference" },
                keyValues: new object[] { "443750", "5573641" });

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumns: new[] { "CompanyPrefix", "ItemReference" },
                keyValues: new object[] { "446617", "9353565" });

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumns: new[] { "CompanyPrefix", "ItemReference" },
                keyValues: new object[] { "4499823", "351572" });

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumns: new[] { "CompanyPrefix", "ItemReference" },
                keyValues: new object[] { "451802", "2638491" });

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumns: new[] { "CompanyPrefix", "ItemReference" },
                keyValues: new object[] { "4584903", "679405" });

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumns: new[] { "CompanyPrefix", "ItemReference" },
                keyValues: new object[] { "4619611", "162323" });

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumns: new[] { "CompanyPrefix", "ItemReference" },
                keyValues: new object[] { "472731472731", "2" });

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumns: new[] { "CompanyPrefix", "ItemReference" },
                keyValues: new object[] { "485771", "5339535" });

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumns: new[] { "CompanyPrefix", "ItemReference" },
                keyValues: new object[] { "4984121", "901844" });

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumns: new[] { "CompanyPrefix", "ItemReference" },
                keyValues: new object[] { "5023208822", "521" });

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumns: new[] { "CompanyPrefix", "ItemReference" },
                keyValues: new object[] { "5032891234", "138" });

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumns: new[] { "CompanyPrefix", "ItemReference" },
                keyValues: new object[] { "51151534", "78331" });

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumns: new[] { "CompanyPrefix", "ItemReference" },
                keyValues: new object[] { "511751", "6644044" });

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumns: new[] { "CompanyPrefix", "ItemReference" },
                keyValues: new object[] { "516232", "7222702" });

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumns: new[] { "CompanyPrefix", "ItemReference" },
                keyValues: new object[] { "528209", "7791950" });

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumns: new[] { "CompanyPrefix", "ItemReference" },
                keyValues: new object[] { "543540", "3141656" });

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumns: new[] { "CompanyPrefix", "ItemReference" },
                keyValues: new object[] { "563974", "4156235" });

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumns: new[] { "CompanyPrefix", "ItemReference" },
                keyValues: new object[] { "584202", "2876851" });

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumns: new[] { "CompanyPrefix", "ItemReference" },
                keyValues: new object[] { "585675", "4259784" });

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumns: new[] { "CompanyPrefix", "ItemReference" },
                keyValues: new object[] { "587451", "1074506" });

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumns: new[] { "CompanyPrefix", "ItemReference" },
                keyValues: new object[] { "591271", "5771945" });

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumns: new[] { "CompanyPrefix", "ItemReference" },
                keyValues: new object[] { "600851600851", "2" });

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumns: new[] { "CompanyPrefix", "ItemReference" },
                keyValues: new object[] { "608240", "2412148" });

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumns: new[] { "CompanyPrefix", "ItemReference" },
                keyValues: new object[] { "623828", "4865650" });

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumns: new[] { "CompanyPrefix", "ItemReference" },
                keyValues: new object[] { "6314853123", "877" });

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumns: new[] { "CompanyPrefix", "ItemReference" },
                keyValues: new object[] { "655062", "1232213" });

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumns: new[] { "CompanyPrefix", "ItemReference" },
                keyValues: new object[] { "676413", "8849362" });

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumns: new[] { "CompanyPrefix", "ItemReference" },
                keyValues: new object[] { "678362", "4156060" });

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumns: new[] { "CompanyPrefix", "ItemReference" },
                keyValues: new object[] { "686748", "9119606" });

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumns: new[] { "CompanyPrefix", "ItemReference" },
                keyValues: new object[] { "7002011", "482701" });

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumns: new[] { "CompanyPrefix", "ItemReference" },
                keyValues: new object[] { "719065", "9765179" });

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumns: new[] { "CompanyPrefix", "ItemReference" },
                keyValues: new object[] { "7408273", "664337" });

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumns: new[] { "CompanyPrefix", "ItemReference" },
                keyValues: new object[] { "745230", "6232899" });

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumns: new[] { "CompanyPrefix", "ItemReference" },
                keyValues: new object[] { "750917", "7528000" });

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumns: new[] { "CompanyPrefix", "ItemReference" },
                keyValues: new object[] { "758601", "2337085" });

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumns: new[] { "CompanyPrefix", "ItemReference" },
                keyValues: new object[] { "764493764493", "4" });

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumns: new[] { "CompanyPrefix", "ItemReference" },
                keyValues: new object[] { "770270770270", "9" });

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumns: new[] { "CompanyPrefix", "ItemReference" },
                keyValues: new object[] { "791586", "5775051" });

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumns: new[] { "CompanyPrefix", "ItemReference" },
                keyValues: new object[] { "793681", "9774282" });

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumns: new[] { "CompanyPrefix", "ItemReference" },
                keyValues: new object[] { "7942595", "565126" });

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumns: new[] { "CompanyPrefix", "ItemReference" },
                keyValues: new object[] { "812302", "5276620" });

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumns: new[] { "CompanyPrefix", "ItemReference" },
                keyValues: new object[] { "814875", "5090895" });

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumns: new[] { "CompanyPrefix", "ItemReference" },
                keyValues: new object[] { "823332", "6492584" });

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumns: new[] { "CompanyPrefix", "ItemReference" },
                keyValues: new object[] { "823413", "4397760" });

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumns: new[] { "CompanyPrefix", "ItemReference" },
                keyValues: new object[] { "826025", "1130405" });

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumns: new[] { "CompanyPrefix", "ItemReference" },
                keyValues: new object[] { "828415", "5417914" });

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumns: new[] { "CompanyPrefix", "ItemReference" },
                keyValues: new object[] { "83250532", "52838" });

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumns: new[] { "CompanyPrefix", "ItemReference" },
                keyValues: new object[] { "8393604321", "179" });

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumns: new[] { "CompanyPrefix", "ItemReference" },
                keyValues: new object[] { "870953", "8728496" });

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumns: new[] { "CompanyPrefix", "ItemReference" },
                keyValues: new object[] { "885734", "8756756" });

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumns: new[] { "CompanyPrefix", "ItemReference" },
                keyValues: new object[] { "900706", "8213657" });

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumns: new[] { "CompanyPrefix", "ItemReference" },
                keyValues: new object[] { "905710", "9832832" });

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumns: new[] { "CompanyPrefix", "ItemReference" },
                keyValues: new object[] { "917969", "3602750" });

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumns: new[] { "CompanyPrefix", "ItemReference" },
                keyValues: new object[] { "9488123", "147805" });

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumns: new[] { "CompanyPrefix", "ItemReference" },
                keyValues: new object[] { "950316", "2380884" });

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumns: new[] { "CompanyPrefix", "ItemReference" },
                keyValues: new object[] { "964495", "3508204" });

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumns: new[] { "CompanyPrefix", "ItemReference" },
                keyValues: new object[] { "983682", "4365465" });

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumns: new[] { "CompanyPrefix", "ItemReference" },
                keyValues: new object[] { "997970", "9212388" });
        }
    }
}
