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
// ==============================
//
// 2nd number meaning:
// ==============================
// 0 = Non-quest specific item
// 1 = Quest specific item
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

// Template for the items in the game
// ----------------------------------------------------------------------
HealingItem template_healingItem_goldenJollyBee = new HealingItem(301, "Golden Jollybee", "A little looming bee found around the jolly trees.", "🐝", 25);
HealingItem template_healingItem_ponderingPotion = new HealingItem(302, "Pondering Potion", "A Potion of Pondering", "🧪", 100);
HealingItem template_healingItem_zoomShroom = new HealingItem(303, "Zoom Shroom", "the zoom shrooms are easily found along paths", "🍄", 50);

Weapon template_weapon_rustySword = new Weapon(201, "Rusty Sword", "a rusty sword, this one was given to you by a wandering wit.", 3, 6);
Weapon template_weapon_familyHeirloomSword = new Weapon(212, "the family heirloom", "this sword was a family heirloom previously owned by the goblins that run the cafe", 10, 16);
Weapon template_weapon_doubleFuckSword = new Weapon(213, "The Double Fuck", "A pair of arched swords used to combat. these deal quite some damage", 20, 25);
Weapon template_weapon_swordOfSheez = new Weapon(214, "Sword of Sheez", "acquired after finishing off the spider king.\nit is stored within his body as he had eaten a legendary warrior a while back", 35, 50);

Item template_item_blankKey = new Item(101, "Blank key", "A blank key with which we can make a functioning key", "🗝️", "Unfinished key");

// Game player
// ----------------------------------------------------------------------
// The player always starts with 100% health
Player player = new Player("The Hero", template_weapon_rustySword);






