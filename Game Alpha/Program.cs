static class Program {
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

        // Quests
        // ----------------------------------------------------------------------
        Quest quest_1_cafeTroubles = new Quest(421, "", "", "", "", 5, 5);
        Quest quest_2_swampySituation = new Quest(422, "", "", "", "", 7, 7);
        Quest quest_3_TheOldCastle = new Quest(423, "", "", "", "", 9, 9);

        // Locations
        // ----------------------------------------------------------------------
        Location overworld = new Location(531, "Overworld 🌏", "", 32, 32);
        Location village1 = new Location(531,  "Old Town  🌆", "", 32, 32);
        Location village2 = new Location(531,  "New Town  🏙️", "", 32, 32);
        Location theSwamp = new Location(534,  "The Swamp 🎋", "", 32, 32);

        // Game player
        // ----------------------------------------------------------------------
        // The player always starts with 100% health
        Player player = new Player("The Hero", "⛄︎", weapon_rustySword);

        // Game logic
        // ----------------------------------------------------------------------
        Location current_location = overworld;
        bool game_won = false;
        bool game_over = false;

        while (!game_won || !game_over) {
            current_location.GenMap();
            player.PrintMenu();
            string str_movement_choice = Console.ReadLine().ToLower();
        }
    }
}