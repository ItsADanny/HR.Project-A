using System.Security.Cryptography.X509Certificates;

static class Program {
    static Dictionary<bool, Location> DoorToNextLocationCheck(Location currentLocation, Player player) {
        Dictionary<bool, Location> returnValue = new Dictionary<bool, Location>();
        foreach (WorldStructure worldStructure in currentLocation.WorldStructures) {
            if (worldStructure.LocationX == player.PositionX & worldStructure.LocationY == player.PositionY) {
                if (worldStructure.IsDoorToNextLocation) {
                    bool wantsToEnter = worldStructure.AskForNextLocation(player);
                    returnValue.Add(wantsToEnter, worldStructure.NextLocation);
                    return returnValue;
                }
            }
        }
        returnValue.Add(false, null);
        return returnValue;
    }

    static void Main() {
        // ID structure
        // ----------------------------------------------------------------------
        // ID number length = 4 = XXXX
        //
        // 1st number meaning:
        // ==============================
        // 1 = Regular item
        // 2 = Weapon
        // 3 = Healing item
        // 4 = Quest
        // 5 = Location
        // 6 = World structure
        // ==============================
        //
        // 2nd number meaning:
        // ==============================
        // 0 = Non-quest specific item
        // 1 = Quest specific item
        // 2 = It's a quest
        // 3 = It's a location
        // 4 = It's a world structure
        // ==============================
        //
        // 3rd number meaning:
        // ==============================
        // This number indicates the
        // number of the item.
        // 
        // Example:
        // HealingItem "Golden jollybee"
        // ID: 301
        // HealingItem "Pondering potion"
        // ID: 302
        // Weapon "Rusty sword"
        // ID: 201
        // ==============================

        // Healing items in the game
        // ----------------------------------------------------------------------
        HealingItem healingItem_goldenJollyBee = new HealingItem(301, "Golden Jollybee", "A little looming bee found around the jolly trees.", "🐝", 25);
        HealingItem healingItem_ponderingPotion = new HealingItem(302, "Pondering Potion", "A Potion of Pondering", "🧪", 100);
        HealingItem healingItem_zoomShroom = new HealingItem(303, "Zoom Shroom", "the zoom shrooms are easily found along paths", "🍄", 50);

        // Weapons in the game
        // ----------------------------------------------------------------------
        Weapon weapon_rustySword = new Weapon(201, "Rusty Sword", "a rusty sword, this one was given to you by a wandering wit.", 3, 6);
        Weapon weapon_familyHeirloomSword = new Weapon(212, "the family heirloom", "this sword was a family heirloom previously owned by the goblins that run the cafe", 10, 16);
        Weapon weapon_doubleFuckSword = new Weapon(213, "The Double Fuck", "A pair of arched swords used to combat. these deal quite some damage", 20, 25);
        Weapon weapon_swordOfSheez = new Weapon(214, "Sword of Sheez", "acquired after finishing off the spider king.\nit is stored within his body as he had eaten a legendary warrior a while back", 35, 50);

        // items in the game
        // ----------------------------------------------------------------------
        Item item_blankKey = new Item(101, "Blank key", "A blank key with which can be turned into a functioning key", "🗝️", "Unfinished key");

        // Game player
        // ----------------------------------------------------------------------
        // The player always starts with 100% health
        Player player = new Player("The Hero", "⛄︎", weapon_rustySword);

        // Quests
        // ----------------------------------------------------------------------
        Quest quest_1_cafeTroubles = new Quest(421, "cafeTrouble", "The family café is overrun by rats! Your task is to eliminate the infestation", "🍵", 5, 5,weapon_familyHeirloomSword, player);
        Quest quest_2_swampySituation = new Quest(422, "swampySituation", "You need to reach the hut but it'protected by a radius covered with venomous snakes.", "🐍", 7, 7, weapon_doubleFuckSword, player);
        Quest quest_3_TheOldCastle = new Quest(423, "theOldCastle", " The name on the sword has lead you to the old castle where you need to break trough the spirits and spiders to climb the highest tower", "🏰", 9, 9,weapon_swordOfSheez, player);

        // Locations
        // ----------------------------------------------------------------------
        Location overworld = new Location(531, "Overworld   🌏", "", 55, 32, player);
        Location Town = new Location(531, "Town        🌆", "", 55, 32, player);
        Location DarkBelow = new Location(531,  "Dark below  🏯", "", 55, 32, player);
        Location theSwamp = new Location(534,  "The Swamp   🎋", "", 55, 32, player);

        //TEMP
        //Set all the quests on the map
        overworld.AddQuest(quest_1_cafeTroubles);
        overworld.AddQuest(quest_2_swampySituation);
        overworld.AddQuest(quest_3_TheOldCastle);

        //Add Location doors to the map
        //Overworld
        WorldStructure doorToTown_overworld = new WorldStructure(641, "Town", "🌆", true, false, 0, true, Town, 28, 30);
        doorToTown_overworld.defineLocation(25, 7);
        overworld.AddWorldStructure(doorToTown_overworld);

        WorldStructure doorToDarkBelow_overworld = new WorldStructure(642, "Dark Below", "🏯", true, false, 0, true, DarkBelow, 28, 30);
        doorToDarkBelow_overworld.defineLocation(28, 31);
        overworld.AddWorldStructure(doorToDarkBelow_overworld);

        WorldStructure doorToTheSwamp_overworld = new WorldStructure(643, "The Swamp", "🎋", true, false, 0, true, theSwamp, 28, 30);
        doorToTheSwamp_overworld.defineLocation(7, 25);
        overworld.AddWorldStructure(doorToTheSwamp_overworld);

        //Town
        WorldStructure doorToOverworld_town = new WorldStructure(644, "Overworld", "🌏", true, false, 0, true, overworld, 28, 30);
        doorToOverworld_town.defineLocation(28, 31);
        Town.AddWorldStructure(doorToOverworld_town);

        //Dark below
        WorldStructure doorToOverworld_darkBelow = new WorldStructure(645, "Overworld", "🌏", true, false, 0, true, overworld, 28, 30);
        doorToOverworld_darkBelow.defineLocation(28, 31);
        DarkBelow.AddWorldStructure(doorToOverworld_darkBelow);

        //The Swamp
        WorldStructure doorToOverworld_TheSwamp = new WorldStructure(646, "Overworld", "🌏", true, false, 0, true, overworld, 28, 30);
        doorToOverworld_TheSwamp.defineLocation(28, 31);
        theSwamp.AddWorldStructure(doorToOverworld_TheSwamp);

        // Game logic
        // ----------------------------------------------------------------------
        Location current_location = overworld;
        bool start_game = false;
        bool game_won = false;
        bool game_over = false;

        //Show start screen
        Functions.StartScreen();
        Console.Clear();
        while (!start_game) {
            Functions.StartMenu();
            switch (Console.ReadLine().ToLower())
            {
                case "s":
                    Console.Clear();
                    start_game = true;
                    break;
                case "o":
                    Console.Clear();
                    Functions.OptionScreen();
                    bool choice_made = false;
                    while (!choice_made) {
                        int choice = int.Parse(Console.ReadLine());
                        switch (choice) {
                            case 1 :
                                // Choice - Magician
                                player.MapIcon = "\ud83e\uddd9";
                                choice_made = true;
                                break;
                            case 2 :
                                // Choice - Ghost
                                player.MapIcon = "\ud83e\udddd";
                                choice_made = true;
                                break;
                            case 3 :
                                // Choice - Assassin
                                player.MapIcon = "\ud83e\udddd";
                                choice_made = true;
                                break;
                            case 4 :
                                // Choice - Royal
                                player.MapIcon = "\ud83e\udddd";
                                choice_made = true;
                                break;
                            case 5 :
                                // Choice - Fairy
                                player.MapIcon = "\ud83e\udddd";
                                choice_made = true;
                                break;
                            case 6 :
                                // Choice - Elf
                                player.MapIcon = "\ud83e\udddd";
                                choice_made = true;
                                break;
                        }
                    }
                    Console.Clear();
                    break;
                case "c":
                    Functions.CreditScreen();
                    Console.Clear();
                    break;
                case "q":
                    Environment.Exit(0);
                    break;
            }
        }

        while (!game_won || !game_over) {
            Console.Clear();
            current_location.LocationCheck();
            current_location.GenMap();
            player.PrintMenu();
            var input = Console.ReadKey();

            switch (input.Key) {
                case ConsoleKey.S: case ConsoleKey.DownArrow:
                    if (player.PositionY + 1 > current_location.LocationSizeY) {
                        Console.WriteLine($"{player.Name}: Oh no, i can't move that way");
                    } else {
                        Console.WriteLine($"{player.Name}: I moved one place to the North");
                        player.PositionY += 1;
                        current_location.LocationCheck();
                        checkForNewLocation();
                    }
                    break;
                case ConsoleKey.E: case ConsoleKey.RightArrow:
                    if (player.PositionX + 1 > current_location.LocationSizeX) {
                        Console.WriteLine($"{player.Name}: Oh no, i can't move that way");
                    } else {
                        Console.WriteLine($"{player.Name}: I moved one place to the East");
                        player.PositionX += 1;
                        current_location.LocationCheck();
                        checkForNewLocation();
                    }
                    break;
                case ConsoleKey.N: case ConsoleKey.UpArrow:
                    if (player.PositionY - 1 > current_location.LocationSizeY || player.PositionY - 1 < 0) {
                        Console.WriteLine($"{player.Name}: Oh no, i can't move that way");
                    } else {
                        Console.WriteLine($"{player.Name}: I moved one place to the South");
                        player.PositionY -= 1;
                        current_location.LocationCheck();
                        checkForNewLocation();
                    }
                    break;
                case ConsoleKey.W: case ConsoleKey.LeftArrow:
                    if (player.PositionX - 1 > current_location.LocationSizeX || player.PositionX - 1 < 0) {
                        Console.WriteLine($"{player.Name}: Oh no, i can't move that way");
                    } else {
                        Console.WriteLine($"{player.Name}: I moved one place to the West");
                        player.PositionX -= 1;
                        current_location.LocationCheck();
                        checkForNewLocation();
                    }
                    break;
                case ConsoleKey.Q:
                    break;
                case ConsoleKey.I:
                    break;
                case ConsoleKey.R:
                    player.SwitchWeaponMenu();
                    break;
                default:
                    Console.WriteLine($"{player.Name}: Oh no, i can't move that way");
                    break;
            }
        }

        void checkForNewLocation() {
            Dictionary<bool, Location> response = DoorToNextLocationCheck(current_location, player);
            if (response.ContainsKey(true)) {
                current_location.SavedPlayerLocationX = player.PositionX;
                current_location.SavedPlayerLocationY = player.PositionY;
                WorldStructure current_worldStructure;
                foreach (WorldStructure worldStructure in current_location.WorldStructures) {
                    if (worldStructure.LocationX == player.PositionX & worldStructure.LocationY == player.PositionY) {
                        current_worldStructure = worldStructure;
                    }
                }
                current_location = response[true];
                if (current_location.SavedPlayerLocationX == 0 & current_location.SavedPlayerLocationY == 0) {
                    player.PositionX = WorldStructure.PlayerStartPositionX;
                    player.PositionY = WorldStructure.PlayerStartPositionY;
                } else {
                    player.PositionX = current_location.SavedPlayerLocationX;
                    player.PositionY = current_location.SavedPlayerLocationY;
                }
            }
        }
    }
}