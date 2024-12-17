using System;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using static CookedGutz;
using K4os.Compression.LZ4.Internal;
using Org.BouncyCastle.Utilities;
using System.Xml.Linq;
using Org.BouncyCastle.Asn1.Cmp;

public class CookedGutz
{
    public static List<Character> characters = new List<Character>();
    public struct Menu
    {
        public string[] MenuOp;

        public Menu(string[] Menu)
        {
            MenuOp = Menu;
        }
    }
    public static void Main(string[] args)
    {
        string connectionString = "server=localhost;database=character_creation;user=root;password=1234;";
        string query = "SELECT * FROM characters";

        using (MySqlConnection conn = new MySqlConnection(connectionString))
        {
            conn.Open();

            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.ExecuteNonQuery();
            }
            Console.WriteLine("Query executed successfully!");
        }

        Console.Title = "𝕋𝕙𝕣𝕖𝕒𝕕𝕤 𝕠𝕗 𝔻𝕖𝕤𝕥𝕚𝕟𝕪";
        Menu menu = new Menu(new string[]
    {
        "New Game",
        "Load Game",
        "Campaign Mode",
        "Credits",
        "Exit"
    });
        CharacterDisp characterDisplay = new CharacterDisp();
        characterDisplay.LoadCharactersFromDatabase();

        bool entireloop = true;
        while (entireloop)
        {
            CookedGutz luto = new CookedGutz();

            System.Console.WriteLine();
            System.Console.WriteLine(@"
████████╗██╗░░██╗██████╗░███████╗░█████╗░██████╗░░██████╗  ░█████╗░███████╗
╚══██╔══╝██║░░██║██╔══██╗██╔════╝██╔══██╗██╔══██╗██╔════╝  ██╔══██╗██╔════╝
░░░██║░░░███████║██████╔╝█████╗░░███████║██║░░██║╚█████╗░  ██║░░██║█████╗░░
░░░██║░░░██╔══██║██╔══██╗██╔══╝░░██╔══██║██║░░██║░╚═══██╗  ██║░░██║██╔══╝░░
░░░██║░░░██║░░██║██║░░██║███████╗██║░░██║██████╔╝██████╔╝  ╚█████╔╝██║░░░░░
░░░╚═╝░░░╚═╝░░╚═╝╚═╝░░╚═╝╚══════╝╚═╝░░╚═╝╚═════╝░╚═════╝░  ░╚════╝░╚═╝░░░░░

██████╗░███████╗░██████╗████████╗██╗███╗░░██╗██╗░░░██╗
██╔══██╗██╔════╝██╔════╝╚══██╔══╝██║████╗░██║╚██╗░██╔╝
██║░░██║█████╗░░╚█████╗░░░░██║░░░██║██╔██╗██║░╚████╔╝░
██║░░██║██╔══╝░░░╚═══██╗░░░██║░░░██║██║╚████║░░╚██╔╝░░
██████╔╝███████╗██████╔╝░░░██║░░░██║██║░╚███║░░░██║░░░
╚═════╝░╚══════╝╚═════╝░░░░╚═╝░░░╚═╝╚═╝░░╚══╝░░░╚═╝░░░ ");
            System.Console.WriteLine("______________________");
            System.Console.WriteLine();
            for (int i = 0; i < menu.MenuOp.Length; i++)
            {
                System.Console.WriteLine($"|{i + 1}| {menu.MenuOp[i]} ");
            }

            string menuent = System.Console.ReadLine();
            bool menuValidInput = true;

            foreach (char c in menuent)
            {
                if (!char.IsDigit(c))
                {
                    menuValidInput = false;
                    break;
                }
            }
            if (menuValidInput)
            {
                try
                {
                    int Menu = Convert.ToInt32(menuent);
                    System.Console.WriteLine();
                    Console.Clear();
                    if (Menu >= 1 || Menu <= menu.MenuOp.Length)
                    {
                        if (Menu < 1 || Menu > menu.MenuOp.Length)
                        {
                            System.Console.WriteLine("Not Right!");
                            continue;
                        }
                        if (Menu == 1)
                        {

                            string[] edad = { "Young", "Mature", "Old" };
                            string[] katawan = { "Ectomorph", "Mesomorph", "Endomorph", "Hourglass", "Inverted", "Triangle", "Rectangle", "Pear", "Apple", "Oval", "Athletic", "Lollipop", "Muscular", "Feminine" };
                            string[] Muka = { "Oval", "Round", "Square", "Long", "Heart", "Rectangle", "Triangle", "Diamond", "Inverted Triangle", "Hexagon", "Oval-Square Hybrid" };
                            string[] buhok = { "Bob Cut", "Pixie Cut", "Layered Hair", "Straight Lob", "Beach Waves", "French Braid", "High Ponytail", "Messy Bun", "Curtain Bangs", "Half-Up, Half-Down", "Buzz Cut", "Undercut", "Shag Cut", "Afro", "Pompadour", "Faux Hawk", "Taper Fade", "Slick Back", "Twists", "Long Layers with Side Part" };
                            string[] buhokkulay = { "Black", "Brown", "Blonde", "Red", "Gray", "White", "Auburn", "Chestnut", "Platinum Blonde", "Strawberry Blonde" };
                            string[] kilay = { "Arched", "Straight", "Rounded", "S-Shaped", "Tapered", "Thick", "Thin", "Feathered", "Straight and Thick", "Angled", "Short", "Long", "Unibrow", "High-Set", "Low-Set" };
                            string[] kilaykulay = { "Black", "Brown", "Blonde", "Red", "Gray", "White", "Auburn", "Chestnut", "Platinum Blonde", "Strawberry Blonde" };
                            string[] ilong = { "Straight", "Roman", "Aquiline", "Button", "Snub", "Nubian", "Flat", "Long", "Wide", "Pointed", "Hooked", "Celestial", "Humpback", "Fleshy", "Asymmetrical Nose" };
                            string[] labi = { "Full Lips", "Thin Lips", "Round Lips", "Heart-Shaped Lips", "Bow-Shaped Lips", "Wide Lips", "Downward-Turned Lips", "Upturned Lips", "Asymmetrical Lips", "Flat Lips" };
                            string[] labikulay = { "Dusty peach", "Tickled pink", "Berry pearl", "Mystic mauve", "Uptown pink", "Rose Red", "Perfect pink", "Plum berry", "Juicy Pink", "French Silk", "Petal pink", "Boldly fuchsia", "Virtuous Rose", "More Mulberry", "Naturally Mocha", "Dreamy Mauve", "Petal pink", "Truly pink", "Daring coral", "Persistent pink" };
                            string[] balat = { "Porcelain", "Ivory", "Light Beige", "Sand", "Buff", "Golden Beige", "Warm Tan", "Honey", "Caramel", "Toffee", "Almond", "Chestnut", "Mocha", "Espresso", "Ebony" };
                            string[] kukokulay = { "Nude Beige", "Soft Pink", "Creamy White", "Classic Red", "Deep Burgundy", "Jet Black", "Rose Gold", "Silver Chrome", "Gold Glitter", "Coral", "Sky Blue", "Sunny Yellow", "Navy Blue", "Forest Green", "Charcoal Gray" };
                            string[] headwear = { "Baseball Cap", "Beanie", "Bucket Hat", "Snapback", "Trucker Hat", "Fedora", "Pillbox Hat", "Top Hat", "Beret", "Cloche Hat", "Turban", "Hijab", "Kufi", "Sombrero", "Taqiyah", "Wide-Brim Hat", "Fascinator", "Visor", "Cowboy Hat", "Headband with a Knot" };
                            string[] tops = { "T-Shirt", "Tank Top", "Hoodie", "Sweatshirt", "Crop Top", "Blazer", "Dress Shirt", "Blouse", "Waistcoat (Vest)", "Peplum Top", "Leather Jacket", "Denim Jacket", "Bomber Jacket", "Cardigan", "Puffer Jacket", "Compression Shirt", "Kurta", "Sports Bra", "Kimono", "Graphic Tee", "Racerback Tank", "Off-Shoulder Top", "Tube Top" };
                            string[] bottoms = { "Jeans", "Shorts", "Cargo Pants", "Joggers", "Sweatpants", "Chinos", "Slacks", "Dress Pants", "Trousers", "Palazzo Pants", "Cigarette Pants", "A-Line Skirt", "Pencil Skirt", "Pleated Skirt", "Mini Skirt", "Maxi Skirt", "Sarong", "Dhoti", "Lungi", "Harem Pants", "Leggings", "Yoga Pants", "Compression Shorts", "Ripped Jeans", "Culottes" };
                            string[] shoes = { "Sneakers", "Loafers", "Sandals", "Flip-flops", "Clogs", "Slip-ons", "Espadrilles", "Hiking Boots", "Ankle Boots", "Running Shoes", "Water Shoes", "Boat Shoes", "Mules", "Ballet Flats", "Combat Boots", "Oxford Shoes", "Derby Shoes", "High-Top Sneakers", "Slides", "Platform Shoes" };
                            string[] earrings = { "Stud", "Hoop", "Drop", "Chandelier", "Ear Cuffs", "Ear Jackets", "Tassel", "Threader", "Huggie", "Clip-On", "None" };
                            string[] glasses = { "Cat-Eye", "Round", "Square", "Aviator", "Wayfarer", "Browline", "Oversized", "Hexagonal", "Transparent", "Color-Tinted", "Steampunk", "None" };
                            string[] masks = { "Face Mask (Medical)", "Cloth", "Half", "Full-Face", "Venetian", "Sleep Mask", "Gas", "Party", "Animal Print", "Superhero", "None" };
                            string[] eyePatches = { "Classic Black", "Leather", "Velvet", "Decorative", "Surgical", "Pirate", "Cat Eye", "Steampunk", "Printed", "Velvet Ribbon", "None" };
                            string[] necklaces = { "Choker", "Pendant", "Statement", "Chain", "Bib", "Collar", "Rope", "Layered", "Pearl", "Twist", "None" };
                            string[] ties = { "Necktie", "Bow", "Skinny", "Cravat", "Ascot", "Bolo", "Bowtie Clip", "Knit", "Clip-on", "Foulard", "None" };
                            string[] watches = { "Dress Watch", "Luxury", "Statement", "Skeleton", "Chronograph", "Bracelet Watch", "Pearl/Gemstone Watch", "Vintage", "Minimalist", "Bold Fashion", "None" };
                            string[] rings = { "Solitaire", "Cocktail", "Signet", "Stackable", "Eternity", "Vintage", "Cluster", "Cuff", "Knuckle", "Wedding Band", "Promise Ring", "Cross", "Mood", "Wedding Ring Set", "Toe Ring", "None" };
                            string[] bracelets = { "Tennis", "Cuff", "Bangle", "Charm", "Hinge", "Beaded", "Leather", "ID", "Statement", "Mesh", "Wrap", "Pearl", "Chain", "Fabric", "Gold/Silver", "Tribal", "Rhinestone", "None" };
                            string[] armBands = { "Fitness Tracker Bands", "Leather Straps", "Reflective Armbands", "Compression Armbands", "Sports Sweatbands", "Elastic Fabric Bands", "Metallic or Chain Armbands", "Lace or Decorative Armbands", "LED Light Armbands (for Running)", "Arm Tattoo Sleeves", "None" };
                            string[] gloves = { "Leather", "Fingerless", "Knit", "Opera", "Lace", "Wool", "Riding", "Vintage", "Suede", "Statement", "None" };
                            string[] belts = { "Leather Belts", "Canvas Belts", "Braided Belts", "Elastic Stretch Belts", "Reversible Belts", "Chain Belts", "Rope Belts", "Utility/Tool Belts", "Corset Belts", "Designer Belts with Logo Buckles", "None" };

                            System.Console.WriteLine(" Create Your CHARACTER: ");
                            System.Console.WriteLine("_____________________");

                            int pedad = GetUserChoice(edad, "Pick Your Age: ");
                            Console.WriteLine($"You selected: {edad[pedad - 1]}");

                            int gen = 0;
                            while (true)
                            {
                                System.Console.WriteLine("Pick Your Gender: \n Enter |1|Male |2|Female");
                                string input = System.Console.ReadLine();
                                bool isValidNumber = true;

                                foreach (char c in input)
                                {
                                    if (!char.IsDigit(c))
                                    {
                                        isValidNumber = false;
                                        break;
                                    }
                                }
                                if (input.Length < 1 || input.Length > 1)
                                {
                                    System.Console.WriteLine("Too Much!");
                                    continue;
                                }

                                if (isValidNumber)
                                {
                                    gen = Convert.ToInt32(input);

                                    if (gen == 1)
                                    {
                                        Console.WriteLine("You selected: MALE");
                                        break;
                                    }
                                    if (gen == 2)
                                    {
                                        Console.WriteLine("You selected: FEMALE");
                                        break;
                                    }
                                    else
                                    {
                                        System.Console.WriteLine("Invalid input! Please pick a number from the options.");
                                        continue;
                                    }
                                }
                                else
                                {
                                    System.Console.WriteLine("Invalid input! Please enter a valid number.");
                                    continue;
                                }
                            }
                            int Body = GetUserChoice(katawan, "Pick Your Body Type:");
                            Console.WriteLine($"You selected: {katawan[Body - 1]}");

                            int Face = GetUserChoice(Muka, "Pick Your Face Shape:");
                            Console.WriteLine($"You selected: {Muka[Face - 1]}");

                            int mamula = 0;
                            while (true)
                            {
                                System.Console.WriteLine("Do You Want TO Turn The BLUSH ON? \n|1|YES \n|2|NO");
                                string input = System.Console.ReadLine();
                                bool isValidNumber = true;

                                foreach (char c in input)
                                {
                                    if (!char.IsDigit(c))
                                    {
                                        isValidNumber = false;
                                        break;
                                    }
                                }
                                if (input.Length < 1 || input.Length > 1)
                                {
                                    System.Console.WriteLine("Too Much!");
                                    continue;
                                }
                                if (isValidNumber)
                                {
                                    mamula = Convert.ToInt32(input);

                                    if (mamula == 1)
                                    {
                                        Console.WriteLine("You selected: YES");
                                        break;
                                    }
                                    if (mamula == 2)
                                    {
                                        Console.WriteLine("You selected: NO");
                                        break;
                                    }
                                    else
                                    {
                                        System.Console.WriteLine("Invalid input! Please pick a number from the options.");
                                        continue;
                                    }
                                }
                                else
                                {
                                    System.Console.WriteLine("Invalid input! Please enter a valid number.");
                                    continue;
                                }
                            }
                            int Hairstyle = GetUserChoice(buhok, "Pick Your Hairstyle:");
                            Console.WriteLine($"You selected: {buhok[Hairstyle - 1]}");

                            int Haircolor = GetUserChoice(buhokkulay, "Pick Your Hair Color:");
                            Console.WriteLine($"You selected: {buhokkulay[Haircolor - 1]}");

                            int kilaytype = GetUserChoice(kilay, "Pick Your Eyebrow Shape:");
                            Console.WriteLine($"You selected: {kilay[kilaytype - 1]}");

                            int kilaycolor = GetUserChoice(kilaykulay, "Pick Your Eyebrow Color:");
                            Console.WriteLine($"You selected: {kilaykulay[kilaycolor - 1]}");

                            int Nose = GetUserChoice(ilong, "Pick Your Nose Shape:");
                            Console.WriteLine($"You selected: {ilong[Nose - 1]}");

                            int Lipsshape = GetUserChoice(labi, "Pick Your Lip Shape:");
                            Console.WriteLine($"You selected: {labi[Lipsshape - 1]}");

                            int Lipscolor = GetUserChoice(labikulay, "Pick Your Lip Color:");
                            Console.WriteLine($"You selected: {labikulay[Lipscolor - 1]}");

                            int Skintone = GetUserChoice(balat, "Pick Your Skin Tone:");
                            Console.WriteLine($"You selected: {balat[Skintone - 1]}");

                            int Nailcolor = GetUserChoice(kukokulay, "Pick Your Nail Color:");
                            Console.WriteLine($"You selected: {kukokulay[Nailcolor - 1]}");

                            int Headwear = GetUserChoice(headwear, "Pick Your Headwear:");
                            Console.WriteLine($"You selected: {headwear[Headwear - 1]}");

                            int Top = GetUserChoice(tops, "Pick Your Top:");
                            Console.WriteLine($"You selected: {tops[Top - 1]}");

                            int Bottom = GetUserChoice(bottoms, "Pick Your Bottoms:");
                            Console.WriteLine($"You selected: {bottoms[Bottom - 1]}");

                            int Shoes = GetUserChoice(shoes, "Pick Your Shoes:");
                            Console.WriteLine($"You selected: {shoes[Shoes - 1]}");

                            int Earrings = GetUserChoice(earrings, "Pick Your Earrings:");
                            Console.WriteLine($"You selected: {earrings[Earrings - 1]}");

                            int Glasses = GetUserChoice(glasses, "Pick Your Glasses:");
                            Console.WriteLine($"You selected: {glasses[Glasses - 1]}");

                            int Mask = GetUserChoice(masks, "Pick Your Mask:");
                            Console.WriteLine($"You selected: {masks[Mask - 1]}");

                            int Eyepatches = GetUserChoice(eyePatches, "Pick Your Eye Patch:");
                            Console.WriteLine($"You selected: {eyePatches[Eyepatches - 1]}");

                            int Necklaces = GetUserChoice(necklaces, "Pick Your Necklace:");
                            Console.WriteLine($"You selected: {necklaces[Necklaces - 1]}");

                            int Tie = GetUserChoice(ties, "Pick Your Tie:");
                            Console.WriteLine($"You selected: {ties[Tie - 1]}");

                            int Watch = GetUserChoice(watches, "Pick Your Watch:");
                            Console.WriteLine($"You selected: {watches[Watch - 1]}");

                            int Ring = GetUserChoice(rings, "Pick Your Ring:");
                            Console.WriteLine($"You selected: {rings[Ring - 1]}");

                            int Bracelet = GetUserChoice(bracelets, "Pick Your Bracelet:");
                            Console.WriteLine($"You selected: {bracelets[Bracelet - 1]}");

                            int Armband = GetUserChoice(armBands, "Pick Your Arm Band:");
                            Console.WriteLine($"You selected: {armBands[Armband - 1]}");

                            int Gloves = GetUserChoice(gloves, "Pick Your Gloves:");
                            Console.WriteLine($"You selected: {gloves[Gloves - 1]}");

                            int Belt = GetUserChoice(belts, "Pick Your Belt:");
                            Console.WriteLine($"You selected: {belts[Belt - 1]}");

                            int tatas = 0;

                            string nem = string.Empty;

                            while (true)
                            {
                                System.Console.WriteLine("Do You Want To Turn TATTOO ON? \n|1|YES \n|2|NO");
                                string input = System.Console.ReadLine();
                                bool isValidNumber = true;

                                foreach (char c in input)
                                {
                                    if (!char.IsDigit(c))
                                    {
                                        isValidNumber = false;
                                        break;
                                    }
                                }
                                if (input.Length < 1 || input.Length > 1)
                                {
                                    System.Console.WriteLine("Too Much!");
                                    continue;
                                }

                                if (isValidNumber)
                                {
                                    tatas = Convert.ToInt32(input);

                                    if (tatas == 1)
                                    {
                                        Console.WriteLine("You selected: YES");
                                        break;
                                    }
                                    if (tatas == 2)
                                    {
                                        Console.WriteLine("You selected: NO");
                                        break;
                                    }
                                    else
                                    {
                                        System.Console.WriteLine("Invalid input! Please pick a number from the options.");
                                        continue;
                                    }
                                }
                                else
                                {
                                    System.Console.WriteLine("Invalid input! Please enter a valid number.");
                                    continue;
                                }
                            }
                            Character character = new Character();

                            nem = string.Empty;

                            while (true)
                            {
                                Console.WriteLine("Enter Your Name:");
                                nem = Console.ReadLine();
                                System.Console.WriteLine();
                                if (character.SetCharName(nem) == false)
                                {
                                    continue;
                                }
                                if (characters.Any(c => c.Name.Equals(nem)))
                                {
                                    Console.WriteLine("This name already exists. Please choose a different name.");
                                    continue;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            character = new Character()
                            {
                                Name = nem,
                                Age = edad[pedad - 1],
                                Gender = (gen == 1 ? "Male" : "Female"),
                                BodyType = katawan[Body - 1],
                                FaceShape = Muka[Face - 1],
                                blush_on = (mamula == 1 ? "YES" : "NO"),
                                Hairstyle = buhok[Hairstyle - 1],
                                HairColor = buhokkulay[Haircolor - 1],
                                EyebrowType = kilay[kilaytype - 1],
                                EyebrowColor = kilaykulay[kilaycolor - 1],
                                Nose = ilong[Nose - 1],
                                LipShape = labi[Lipsshape - 1],
                                LipColor = labikulay[Lipscolor - 1],
                                SkinTone = balat[Skintone - 1],
                                NailColor = kukokulay[Nailcolor - 1],
                                Headwear = headwear[Headwear - 1],
                                Top = tops[Top - 1],
                                Bottom = bottoms[Bottom - 1],
                                Shoes = shoes[Shoes - 1],
                                Earrings = earrings[Earrings - 1],
                                Glasses = glasses[Glasses - 1],
                                Mask = masks[Mask - 1],
                                EyePatch = eyePatches[Eyepatches - 1],
                                Necklace = necklaces[Necklaces - 1],
                                Tie = ties[Tie - 1],
                                Watch = watches[Watch - 1],
                                Ring = rings[Ring - 1],
                                Bracelet = bracelets[Bracelet - 1],
                                ArmBand = armBands[Armband - 1],
                                Gloves = gloves[Gloves - 1],
                                Belt = belts[Belt - 1],
                                TattooOn = (tatas == 1 ? "YES" : "NO")
                            };

                            characters.Add(character);

                            characterDisplay.DisplayChar(character);
                            characterDisplay.DisplayCharOutfit(character);
                            characterDisplay.DisplayCharAccessories(character);

                            characterDisplay.InsertCharacterData(character);
                            Console.Clear();
                            bool gomenu = true;

                            while (gomenu)
                            {
                                System.Console.WriteLine("|1|Go Back to Main Menu.");
                                string input = System.Console.ReadLine();
                                bool isValidNumber = true;
                                foreach (char c in input)
                                {
                                    if (!char.IsDigit(c))
                                    {
                                        isValidNumber = false;
                                        break;
                                    }
                                }
                                if (input.Length < 1 || input.Length > 1)
                                {
                                    System.Console.WriteLine("Too Much!");
                                    continue;
                                }

                                if (isValidNumber)
                                {
                                    int menmenu = Convert.ToInt32(input);

                                    if (menmenu == 1)
                                    {
                                        Console.Clear();
                                        break;
                                    }
                                    else
                                    {
                                        System.Console.WriteLine("Invalid input! Please pick a number from the options.");
                                        continue;
                                    }
                                }
                                else
                                {
                                    System.Console.WriteLine("Invalid input! Please enter a valid number.");
                                    continue;
                                }
                            }
                        }
                        if (Menu == 2)
                        {
                            CharacterDisp cd = new CharacterDisp();
                            while (true)
                            {
                                if (characters.Count == 0)
                                {
                                    Console.WriteLine("No characters available. Please create a character first.");
                                    System.Console.WriteLine("Press Enter to Go Back Main Menu.");
                                    System.Console.ReadKey();
                                    break;
                                }
                                Console.WriteLine("Select an option:");
                                Console.WriteLine("|1| Load character");
                                Console.WriteLine("|2| Load ALL character's");
                                Console.WriteLine("|3| Delete character");
                                Console.WriteLine("|4| Go Back to Main Menu");
                                Console.WriteLine();
                                Console.Write("Enter option: ");
                                try
                                {
                                    byte selectOption = Convert.ToByte(Console.ReadLine());
                                    Console.Clear();
                                    if (selectOption < 1 || selectOption > 4)
                                    {
                                        throw new IndexOutOfRangeException("Not an Option");
                                    }
                                    if (selectOption == 1)
                                    {
                                        Console.WriteLine("Select a character by Name:");
                                        for (int i = 0; i < characterDisplay.Getname().Count; i++)
                                        {
                                            if (characters.Count == 0)
                                            {
                                                Console.WriteLine("No characters available. Please create a character first.");
                                                System.Console.WriteLine("Press Enter to Go Back Main Menu.");
                                                System.Console.ReadKey();
                                                return;
                                            }
                                            Console.WriteLine();
                                            Character character = characters[i];
                                            Console.WriteLine($"Name: {characterDisplay.Getname()[i]}");
                                        }
                                        Console.Write("Enter character Name to select: ");
                                        try
                                        {
                                            string selectId = Console.ReadLine();

                                            if (string.IsNullOrEmpty(selectId))
                                            {
                                                Console.WriteLine("You must enter a character name.");
                                                continue;
                                            }
                                            List<string> characterInfo = characterDisplay.SelectCharacter(selectId);
                                            if (characterInfo == null || characterInfo.Count < 33)
                                            {
                                                Console.WriteLine("Character not found.");
                                                continue;
                                            }
                                            Console.WriteLine($" \nName: {characterInfo[1]}, \nAge: {characterInfo[2]}, \nGender: {characterInfo[3]}, " +
                                              $"\nBody Type: {characterInfo[4]}, \nFace Shape: {characterInfo[5]}, \nBlush On: {characterInfo[6]}, " +
                                              $"\nHairstyle: {characterInfo[7]}, \nHair Color: {characterInfo[8]}, \nEyebrow Type: {characterInfo[9]}, " +
                                              $"\nEyebrow Color: {characterInfo[10]}, \nNose: {characterInfo[11]}, \nLip Shape: {characterInfo[12]}, " +
                                              $"\nLip Color: {characterInfo[13]}, \nSkin Tone: {characterInfo[14]},\nNail Color: {characterInfo[15]}, " +
                                              $"\nHeadwear: {characterInfo[16]}, \nTop: {characterInfo[17]}, \nBottom: {characterInfo[18]}, \nShoes: {characterInfo[19]}, " +
                                              $"\nEarrings: {characterInfo[20]}, \nGlasses: {characterInfo[21]}, \nMask: {characterInfo[22]}, " +
                                              $"\nEye Patch: {characterInfo[23]}, \nNecklace: {characterInfo[24]}, \nTie: {characterInfo[25]}, " +
                                              $"\nWatch: {characterInfo[26]}, \nRing: {characterInfo[27]}, \nBracelet: {characterInfo[28]}, " +
                                              $"\nArm Band: {characterInfo[29]},\nGloves: {characterInfo[30]}, \nBelt: {characterInfo[31]}, " +
                                              $"\nTattoo On: {characterInfo[32]}");

                                            Console.WriteLine("Do you want to delete this character? \n|1|Yes\n|2|No");
                                            int confirmDelete = Convert.ToInt32(Console.ReadLine());
                                            if (confirmDelete == 1)
                                            {
                                                cd.DeleteChar(selectId, characters);
                                                Console.WriteLine("Character deleted. No more characters available.");
                                                Console.WriteLine("Press Enter to Go Back to Main Menu.");
                                                Console.ReadKey();
                                                break;
                                            }
                                            else if (confirmDelete == 2)
                                            {
                                                Console.WriteLine("Character deletion canceled.");
                                            }
                                            else
                                            {
                                                Console.WriteLine("Invalid input.");
                                            }
                                            Console.WriteLine("Press Enter to go Back");
                                            Console.ReadKey();
                                        }
                                        catch (FormatException)
                                        {
                                            Console.WriteLine("Invalid input. Please enter a numeric ID.");
                                            break;
                                        }
                                        catch (IndexOutOfRangeException)
                                        {
                                            Console.WriteLine("Invalid ID. No character found with that ID.");
                                            break;
                                        }

                                    }
                                    if (selectOption == 2)
                                    {
                                        for (int i = 0; i < characterDisplay.Getname().Count; i++)
                                        {
                                            if (characters.Count > 0)
                                            {
                                                Character character = characters[i];
                                                string selectid = characterDisplay.Getname()[i];
                                                List<string> characterInfo = characterDisplay.SelectCharacter(selectid);
                                                if (characterInfo == null || characterInfo.Count < 33)
                                                {
                                                    Console.WriteLine("Character not found.");
                                                    continue;
                                                }
                                                Console.WriteLine($" \nName: {characterInfo[1]}, \nAge: {characterInfo[2]}, \nGender: {characterInfo[3]}, " +
                                                  $"\nBody Type: {characterInfo[4]}, \nFace Shape: {characterInfo[5]}, \nBlush On: {characterInfo[6]}, " +
                                                  $"\nHairstyle: {characterInfo[7]}, \nHair Color: {characterInfo[8]}, \nEyebrow Type: {characterInfo[9]}, " +
                                                  $"\nEyebrow Color: {characterInfo[10]}, \nNose: {characterInfo[11]}, \nLip Shape: {characterInfo[12]}, " +
                                                  $"\nLip Color: {characterInfo[13]}, \nSkin Tone: {characterInfo[14]},\nNail Color: {characterInfo[15]}, " +
                                                  $"\nHeadwear: {characterInfo[16]}, \nTop: {characterInfo[17]}, \nBottom: {characterInfo[18]}, \nShoes: {characterInfo[19]}, " +
                                                  $"\nEarrings: {characterInfo[20]}, \nGlasses: {characterInfo[21]}, \nMask: {characterInfo[22]}, " +
                                                  $"\nEye Patch: {characterInfo[23]}, \nNecklace: {characterInfo[24]}, \nTie: {characterInfo[25]}, " +
                                                  $"\nWatch: {characterInfo[26]}, \nRing: {characterInfo[27]}, \nBracelet: {characterInfo[28]}, " +
                                                  $"\nArm Band: {characterInfo[29]},\nGloves: {characterInfo[30]}, \nBelt: {characterInfo[31]}, " +
                                                  $"\nTattoo On: {characterInfo[32]}" +
                                                  $"\n==================================");
                                                Console.WriteLine("Press Enter to go Next");
                                                var ke = Console.ReadKey();
                                                if (ke.Equals(characterDisplay.Getname()[i]))
                                                {
                                                    Console.WriteLine("No characters available.");
                                                    System.Console.WriteLine("Press Enter to Go Back Main Menu.");
                                                    System.Console.ReadKey();
                                                    Console.Clear();
                                                    return;
                                                }
                                            }
                                        }
                                        Console.WriteLine("Press Enter to go Back");
                                        Console.ReadKey();

                                    }
                                    Console.Clear();
                                    if (selectOption == 3)
                                    {
                                        if (characters.Count > 0)
                                        {
                                            Console.WriteLine("Select a character by Name:");
                                            Console.WriteLine("");
                                            for (int i = 0; i < characterDisplay.Getname().Count; i++)
                                            {
                                                Character character = characters[i];
                                                Console.WriteLine($"Name: {characterDisplay.Getname()[i]}");
                                            }

                                            Console.Write("Enter character Name to delete: ");
                                            try
                                            {
                                                string selectId = Console.ReadLine();
                                                Console.Clear();
                                                if (string.IsNullOrEmpty(selectId))
                                                {
                                                    Console.WriteLine("You must enter a character name.");
                                                    continue;
                                                }

                                                Console.WriteLine($"Selected Character: {selectId}. Do you want to delete this character? \n|1|Yes\n|2|No");
                                                int confirmDelete = Convert.ToInt32(Console.ReadLine());
                                                if (confirmDelete == 1)
                                                {
                                                    cd.DeleteChar(selectId, characters);
                                                    Console.WriteLine("Character deleted. No more characters available.");
                                                    Console.WriteLine("Press Enter to Go Back to Main Menu.");
                                                    Console.ReadKey();
                                                    break;
                                                }
                                                if (confirmDelete == 2)
                                                {
                                                    Console.WriteLine("Character deletion canceled.");
                                                }
                                                Console.WriteLine("Press Enter to go back to Main Menu");
                                                Console.ReadKey();
                                                break;
                                            }
                                            catch (FormatException)
                                            {
                                                Console.WriteLine("Invalid input. Please enter a numeric ID.");
                                                break;
                                            }
                                            catch (IndexOutOfRangeException)
                                            {
                                                Console.WriteLine("Invalid ID. No character found with that ID.");
                                                break;
                                            }
                                        }
                                    }
                                    if (selectOption == 4)
                                    {
                                        Console.WriteLine("Press Enter to Go Back to Main Menu");
                                        Console.ReadKey();
                                        Console.Clear();
                                        break;
                                    }
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e.Message);
                                }
                            }
                        }
                        if (Menu == 3)
                        {
                            string Story = (@"|Act 1: The Forgotten Wardrobe|
                                In the bustling city of Everlyn, tucked between towering skyscrapers 
                                and narrow alleyways, there stood an old shop called Ethereal Attire.
                                Most people walked past it, barely sparing a glance, but for those who
                                ventured inside, it felt like stepping into another world.
                                The air smelled faintly of lavender and cedar, and every corner was
                                crammed with clothing racks, overflowing with garments from every
                                era imaginable. Among the clutter of vintage suits, shimmering gowns,
                                and cloaks that seemed to shift in color under the dim light, there was
                                an unassuming wardrobe at the back of the store.
                                It was tall and wooden, with carvings of twisting vines and roses on its doors.
                                A small plaque hung above it, reading: 'The Game Awaits.'
                                Luna William George was an ordinary teenager with an extraordinary imagination.
                                A lover of fantasy novels and DIY fashion, she spent most of her time designing outfits
                                inspired by her favorite stories.
                                On her 16th birthday, her best friend Ellie dragged her to Ethereal Attire,
                                promising a surprise. 'I swear, Luna,' Ellie said, practically dragging her inside,
                                'this place is you in the store.'");
                            foreach (char c in Story)
                            {
                                System.Console.Write(c);
                                Thread.Sleep(10);
                            }
                            System.Console.WriteLine("\nTo Be Continued... Press Enter to Go Back Main Menu.");
                            System.Console.ReadKey();
                            Console.Clear();
                            continue;
                        }
                        if (Menu == 4)
                        {
                            System.Console.WriteLine(" PROGRAMMERIST ");
                            System.Console.WriteLine(" CARNITES, JHON LEONIEL M.");
                            System.Console.WriteLine();
                            System.Console.WriteLine(" DOCUMENTATIONIST ");
                            System.Console.WriteLine(" SARTE, EDRIAN ");
                            System.Console.WriteLine();
                            System.Console.WriteLine(" GUTIERREZ, JOHN MIGUEL C.");

                            System.Console.WriteLine("Press Enter to Go Back Main Menu.");
                            System.Console.ReadKey();
                            Console.Clear();
                            continue;
                        }
                        if (Menu == 5)
                        {
                            System.Console.WriteLine("You Are Exiting the GAME...");
                            entireloop = false;
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid input." + e);
                    continue;
                }
            }
        }
    }
    private static int GetUserChoice(string[] options, string Word)
    {
        int userChoice = -1;
        bool validInput = false;

        while (!validInput)
        {
            try
            {
                Console.WriteLine(Word);
                Console.WriteLine("Please choose from the following options:");
                Console.WriteLine();
                for (int i = 0; i < options.Length; i++)
                {
                    Console.WriteLine($"|{i + 1}| {options[i]}");
                }
                Console.Write("Enter the number of your choice: ");
                string input = Console.ReadLine();
                Console.WriteLine();
                if (IsNumber(input))
                {
                    userChoice = ConvertToNumber(input);

                    if (userChoice >= 1 && userChoice <= options.Length)
                    {
                        validInput = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please choose a valid number from the options.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a numeric value.");
                }
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e);
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e);
            }
        }
        return userChoice;
    }
    private static bool IsNumber(string input)
    {
        foreach (char c in input)
        {
            if (!char.IsDigit(c))
            {
                return false;
            }
        }
        return true;
    }
    private static int ConvertToNumber(string input)
    {
        int result = 0;
        foreach (char c in input)
        {
            result = result * 10 + (c - '0');
        }
        return result;
    }
}
public interface CHACHARAC
{
    bool SetCharName(string Name);
}
public abstract class CharacterName
{
    public string Name { get; private set; }
    public abstract bool SetCharName(string name);
}
public class Character : CharacterName, CHACHARAC
{
    public string Name { get; set; }
    public int Id { get; set; }
    public string Age { get; set; }
    public string Gender { get; set; }
    public string BodyType { get; set; }
    public string FaceShape { get; set; }
    public string blush_on { get; set; }
    public string Hairstyle { get; set; }
    public string HairColor { get; set; }
    public string EyebrowType { get; set; }
    public string EyebrowColor { get; set; }
    public string Nose { get; set; }
    public string LipShape { get; set; }
    public string LipColor { get; set; }
    public string SkinTone { get; set; }
    public string NailColor { get; set; }
    public string Headwear { get; set; }
    public string Top { get; set; }
    public string Bottom { get; set; }
    public string Shoes { get; set; }
    public string Earrings { get; set; }
    public string Glasses { get; set; }
    public string Mask { get; set; }
    public string EyePatch { get; set; }
    public string Necklace { get; set; }
    public string Tie { get; set; }
    public string Watch { get; set; }
    public string Ring { get; set; }
    public string Bracelet { get; set; }
    public string ArmBand { get; set; }
    public string Gloves { get; set; }
    public string Belt { get; set; }
    public string TattooOn { get; set; }

    public Character() { }
    public Character(string name)
    {
        this.Name = name;
    }
    public override bool SetCharName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Invalid name. Please enter a name that is not empty.");
            return false;
        }
        if (ContainsSpecialCharacters(name))
        {
            Console.WriteLine("Invalid name. Please enter a name that does not contain special characters.");
            return false;
        }
        if (name.Length < 2 || name.Length > 16)
        {
            Console.WriteLine("Please enter a name that is between 2 and 16 characters.");
            return false;
        }
        if (IsNumber(name))
        {
            Console.WriteLine("Invalid name. Please enter a name that is not all numbers.");
            return false;
        }
        name = Name;
        return true;
    }
    private static bool ContainsSpecialCharacters(string name)
    {
        foreach (char c in name)
        {
            if (!char.IsLetterOrDigit(c) && !char.IsWhiteSpace(c))
            {
                return true;
            }
        }
        return false;
    }
    private bool IsNumber(string name)
    {
        foreach (char c in name)
        {
            if (!char.IsDigit(c))
            {
                return false;
            }
        }
        return true;
    }
}
public class CharacterDisp
{
    public void DisplayChar(Character character)
    {
        Console.WriteLine();
        Console.WriteLine("Your CHARACTER Has Been CREATED!");

        Console.WriteLine();
        Console.WriteLine("CHARACTER: " + character.Name);
        Console.WriteLine("AGE: " + character.Age);
        Console.WriteLine("GENDER: " + character.Gender);
        Console.WriteLine("BODY TYPE: " + character.BodyType);
        Console.WriteLine("FACE SHAPE: " + character.FaceShape);
        Console.WriteLine("BLUSH ON: " + character.blush_on);
        Console.WriteLine("HAIR STYLE: " + character.Hairstyle);
        Console.WriteLine("HAIR COLOR: " + character.HairColor);
        Console.WriteLine("EYEBROW TYPE: " + character.EyebrowType);
        Console.WriteLine("EYEBROW COLOR: " + character.EyebrowColor);
        Console.WriteLine("NOSE: " + character.Nose);
        Console.WriteLine("LIPS: " + character.LipShape);
        Console.WriteLine("LIPS COLOR: " + character.LipColor);
        Console.WriteLine("SKIN TONE: " + character.SkinTone);
        Console.WriteLine("NAIL COLOR: " + character.NailColor);
    }
    public void DisplayCharOutfit(Character character)
    {
        Console.WriteLine("|OUTFIT|");
        Console.WriteLine("HEAD WEAR: " + character.Headwear);
        Console.WriteLine("TOP: " + character.Top);
        Console.WriteLine("BOTTOM: " + character.Bottom);
        Console.WriteLine("SHOES: " + character.Shoes);
    }
    public void DisplayCharAccessories(Character character)
    {
        Console.WriteLine("|ACCESSORIES|");
        Console.WriteLine("EARRINGS: " + character.Earrings);
        Console.WriteLine("GLASSES: " + character.Glasses);
        Console.WriteLine("MASK: " + character.Mask);
        Console.WriteLine("EYE PATCH: " + character.EyePatch);
        Console.WriteLine("NECKLACE: " + character.Necklace);
        Console.WriteLine("TIE: " + character.Tie);
        Console.WriteLine("WATCH: " + character.Watch);
        Console.WriteLine("RING: " + character.Ring);
        Console.WriteLine("BRACELET: " + character.Bracelet);
        Console.WriteLine("ARMBAND: " + character.ArmBand);
        Console.WriteLine("GLOVES: " + character.Gloves);
        Console.WriteLine("BELT: " + character.Belt);
        Console.WriteLine("TATTOO ON: " + character.TattooOn);
    }
    public void InsertCharacterData(Character character)
    {
        string connectionString = "server=localhost;database=character_creation;user=root;password=1234;";

        MySqlConnection conn = new MySqlConnection(connectionString);
        try
        {
            conn.Open();

            string sql = $"INSERT INTO characters ( name, age, gender, body_type, face_shape, blush_on," +
                $" hairstyle, hair_color, eyebrow_type, eyebrow_color, nose, lip_shape, lip_color, skin_tone," +
                $" nail_color, headwear, top, bottom, shoes, earrings, glasses, mask, eye_patch, necklace," +
                $" tie, watch, ring, bracelet, arm_band, gloves, belt, tattoo_on) " +
                $"VALUES ( '{character.Name}', '{character.Age}', '{character.Gender}', '{character.BodyType}', '{character.FaceShape}', '{character.blush_on}', '{character.Hairstyle}', '{character.HairColor}', '{character.EyebrowType}', '{character.EyebrowColor}', '{character.Nose}', '{character.LipShape}', '{character.LipColor}', '{character.SkinTone}', '{character.NailColor}'," +
                $" '{character.Headwear}', '{character.Top}', '{character.Bottom}', '{character.Shoes}', '{character.Earrings}', '{character.Glasses}', '{character.Mask}', '{character.EyePatch}', '{character.Necklace}', '{character.Tie}', '{character.Watch}', '{character.Ring}', '{character.Bracelet}', '{character.ArmBand}', '{character.Gloves}', '{character.Belt}', '{character.TattooOn}');";

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();

            conn.Close();
        }
        catch (MySqlException e)
        {
            Console.WriteLine("An error occurred while connecting to the database: " + e.Message);
        }
    }
    public void SelectChar(string name)
    {
        string connectionString = "server=localhost;database=character_creation;user=root;password=1234;";
        string query = "SELECT * FROM characters";

        using (MySqlConnection conn = new MySqlConnection(connectionString))
        {
            List<Character> characters = new List<Character>();
            Character character = new Character();
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var newCharacter = new Character(reader["name"].ToString())
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        Age = reader["age"].ToString(),
                        Gender = reader["gender"].ToString(),
                        BodyType = reader["body_type"].ToString(),
                        FaceShape = reader["face_shape"].ToString(),
                        blush_on = reader["blush_on"].ToString(),
                        Hairstyle = reader["hairstyle"].ToString(),
                        HairColor = reader["hair_color"].ToString(),
                        EyebrowType = reader["eyebrow_type"].ToString(),
                        EyebrowColor = reader["eyebrow_color"].ToString(),
                        Nose = reader["nose"].ToString(),
                        LipShape = reader["lip_shape"].ToString(),
                        LipColor = reader["lip_color"].ToString(),
                        SkinTone = reader["skin_tone"].ToString(),
                        NailColor = reader["nail_color"].ToString(),
                        Headwear = reader["headwear"].ToString(),
                        Top = reader["top"].ToString(),
                        Bottom = reader["bottom"].ToString(),
                        Shoes = reader["shoes"].ToString(),
                        Earrings = reader["earrings"].ToString(),
                        Glasses = reader["glasses"].ToString(),
                        Mask = reader["mask"].ToString(),
                        EyePatch = reader["eye_patch"].ToString(),
                        Necklace = reader["necklace"].ToString(),
                        Tie = reader["tie"].ToString(),
                        Watch = reader["watch"].ToString(),
                        Ring = reader["ring"].ToString(),
                        Bracelet = reader["bracelet"].ToString(),
                        ArmBand = reader["arm_band"].ToString(),
                        Gloves = reader["gloves"].ToString(),
                        Belt = reader["belt"].ToString(),
                        TattooOn = reader["tattoo_on"].ToString()
                    };
                    characters.Add(newCharacter);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
    }
    public List<string> Getname()
    {
        List<string> charName = new List<string>();
        string connectionString = "server=localhost;database=character_creation;user=root;password=1234;";
        try
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            string query = "SELECT name FROM characters;";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                charName.Add(reader["name"].ToString());
            }
            reader.Close();
            conn.Close();

        }
        catch (MySqlException e)
        {
            Console.WriteLine(e.Message);
        }
        return charName;
    }

    public List<string> SelectCharacter(string name)
    {
        string connectionString = "server=localhost;database=character_creation;user=root;password=1234;";
        string query = $"SELECT * FROM characters WHERE name = '{name}';";
        List<string> charactersinfo = new List<string>();

        using (MySqlConnection conn = new MySqlConnection(connectionString))
        {
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    charactersinfo.Add(reader["id"].ToString());
                    charactersinfo.Add(reader["name"].ToString());
                    charactersinfo.Add(reader["age"].ToString());
                    charactersinfo.Add(reader["gender"].ToString());
                    charactersinfo.Add(reader["body_type"].ToString());
                    charactersinfo.Add(reader["face_shape"].ToString());
                    charactersinfo.Add(reader["blush_on"].ToString());
                    charactersinfo.Add(reader["hairstyle"].ToString());
                    charactersinfo.Add(reader["hair_color"].ToString());
                    charactersinfo.Add(reader["eyebrow_type"].ToString());
                    charactersinfo.Add(reader["eyebrow_color"].ToString());
                    charactersinfo.Add(reader["nose"].ToString());
                    charactersinfo.Add(reader["lip_shape"].ToString());
                    charactersinfo.Add(reader["lip_color"].ToString());
                    charactersinfo.Add(reader["skin_tone"].ToString());
                    charactersinfo.Add(reader["nail_color"].ToString());
                    charactersinfo.Add(reader["headwear"].ToString());
                    charactersinfo.Add(reader["top"].ToString());
                    charactersinfo.Add(reader["bottom"].ToString());
                    charactersinfo.Add(reader["shoes"].ToString());
                    charactersinfo.Add(reader["earrings"].ToString());
                    charactersinfo.Add(reader["glasses"].ToString());
                    charactersinfo.Add(reader["mask"].ToString());
                    charactersinfo.Add(reader["eye_patch"].ToString());
                    charactersinfo.Add(reader["necklace"].ToString());
                    charactersinfo.Add(reader["tie"].ToString());
                    charactersinfo.Add(reader["watch"].ToString());
                    charactersinfo.Add(reader["ring"].ToString());
                    charactersinfo.Add(reader["bracelet"].ToString());
                    charactersinfo.Add(reader["arm_band"].ToString());
                    charactersinfo.Add(reader["gloves"].ToString());
                    charactersinfo.Add(reader["belt"].ToString());
                    charactersinfo.Add(reader["tattoo_on"].ToString());

                    conn.Close();
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
        return charactersinfo;
    }

    public void DeleteChar(string name, List<Character> characters)
    {
        string connectionString = "server=localhost;database=character_creation;user=root;password=1234;";
        string query = $"DELETE FROM characters WHERE name = @name;";

        using (MySqlConnection conn = new MySqlConnection(connectionString))
        {
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@name", name);

            try
            {
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Character characterToRemove = null;

                    foreach (var character in characters)
                    {
                        if (character.Name == name)
                        {
                            characterToRemove = character;
                            break;
                        }
                    }

                    if (characterToRemove != null)
                    {
                        characters.Remove(characterToRemove);
                        Console.WriteLine("Character deleted successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Character not found, may have already been removed.");
                    }
                }
                else
                {
                    Console.WriteLine("Character not found, deletion failed.");
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
    }
    public void LoadCharactersFromDatabase()
    {
        string connectionString = "server=localhost;database=character_creation;user=root;password=1234;";
        string query = "SELECT * FROM characters";

        using (MySqlConnection conn = new MySqlConnection(connectionString))
        {
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var newCharacter = new Character(reader["name"].ToString())
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        Age = reader["age"].ToString(),
                        Gender = reader["gender"].ToString(),
                        BodyType = reader["body_type"].ToString(),
                        FaceShape = reader["face_shape"].ToString(),
                        blush_on = reader["blush_on"].ToString(),
                        Hairstyle = reader["hairstyle"].ToString(),
                        HairColor = reader["hair_color"].ToString(),
                        EyebrowType = reader["eyebrow_type"].ToString(),
                        EyebrowColor = reader["eyebrow_color"].ToString(),
                        Nose = reader["nose"].ToString(),
                        LipShape = reader["lip_shape"].ToString(),
                        LipColor = reader["lip_color"].ToString(),
                        SkinTone = reader["skin_tone"].ToString(),
                        NailColor = reader["nail_color"].ToString(),
                        Headwear = reader["headwear"].ToString(),
                        Top = reader["top"].ToString(),
                        Bottom = reader["bottom"].ToString(),
                        Shoes = reader["shoes"].ToString(),
                        Earrings = reader["earrings"].ToString(),
                        Glasses = reader["glasses"].ToString(),
                        Mask = reader["mask"].ToString(),
                        EyePatch = reader["eye_patch"].ToString(),
                        Necklace = reader["necklace"].ToString(),
                        Tie = reader["tie"].ToString(),
                        Watch = reader["watch"].ToString(),
                        Ring = reader["ring"].ToString(),
                        Bracelet = reader["bracelet"].ToString(),
                        ArmBand = reader["arm_band"].ToString(),
                        Gloves = reader["gloves"].ToString(),
                        Belt = reader["belt"].ToString(),
                        TattooOn = reader["tattoo_on"].ToString()
                    };
                    characters.Add(newCharacter);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
    }

}
public class DatabaseTest
{
    private string connectionString = "server=localhost;database=character_creation;user=root;password=1234;";

    public void TestConnection()
    {
        try
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                Console.WriteLine("Connection successful!");
            }
        }
        catch (MySqlException e)
        {
            Console.WriteLine("Connection failed: " + e.Message);
        }
    }
}