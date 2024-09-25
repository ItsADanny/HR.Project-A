public class Player
{
    public string Name;
    public string MapIcon;
    public int Health;
    public List<Item> Inventory;
    public List<Weapon> Armory;
    public List<HealingItem> HealingItems;
    public Weapon CurrentWeapon;
    public Quest CurrentQuest;
    public int PositionX;
    public int PositionY;

    public Player(string name, string map_icon, Weapon weapon) {
        Name = name;
        MapIcon = map_icon;
        Health = 100;
        Inventory = new List<Item>();
        Armory = new List<Weapon>();
        Armory.Add(weapon);
        HealingItems = new List<HealingItem>();
        CurrentWeapon = weapon;
        CurrentQuest = new Quest(420, "No quest", "", "", 0, 0, null,null );
        PositionX = 0;
        PositionY = 0;
    }

    public void AddItem(Item item) {
        Inventory.Add(item);
    }

    public void AddItem(List<Item> item) {
        Inventory.AddRange(item);
    }

    public void AddWeapon(Weapon weapon) {
        Armory.Add(weapon);
    }

    public void AddWeapon(List<Weapon> weapon) {
        Armory.AddRange(weapon);
    }

    public void AddHealingItem(HealingItem healingItem) {
        HealingItems.Add(healingItem);
    }

    public void AddHealingItem(List<HealingItem> healingItem) {
        HealingItems.AddRange(healingItem);
    }

    public void RemoveItem(int int_itemID) {
        bool ItemRemoved = false;
        List<Item> Edited_Inventory = new List<Item>();
        foreach (Item item in Inventory) {
            if (item.ID != int_itemID) {
                Edited_Inventory.Add(item);
            } else {
                if (ItemRemoved) {
                    Edited_Inventory.Add(item);
                } else {
                    ItemRemoved = true;
                }
            }
        }
        Inventory = Edited_Inventory;
    }

    public void RemoveHealingItem(string str_HealingItemName) {
        List<HealingItem> Edited_HealingItemInventory = new List<HealingItem>();
        bool ItemRemoved = false;
        foreach (HealingItem healingItem in HealingItems) {
            if (healingItem.Name != str_HealingItemName) {
                Edited_HealingItemInventory.Add(healingItem);
            } else {
                if (ItemRemoved) {
                    Edited_HealingItemInventory.Add(healingItem);
                } else {
                    ItemRemoved = true;
                }
            }
        }
    }

    public void HealthReduce(int damage)
    {
        Health = Math.Clamp(Health - damage, 0, 100);
        //get player health
        //if player encounters damage
        //reduce health by damage amount
    }

    public void HealthIncrease(int healing)
    {

        Health = Math.Clamp(Health + healing, 0, 100);

        //get player health 
        //if item activated from inventory 
        // increase health by given healing amount
    }

    public bool IsAlive() {
        if (Health > 0) {
            return true;
        }
        return false;
    }

    public void Attack(Monster monster)
   {
       if (CurrentWeapon != null)
       {
           int damage = CurrentWeapon.GenAttackDamage();
           monster.TakeDamage(damage);
           Console.WriteLine($"{Name} attacks {monster.Name} with {CurrentWeapon.Name} for {damage} damage.");
       }
       else
       {
           Console.WriteLine($"{Name} has no weapon to attack with!");
       }
   }

    public void PrintMenu()
    {
        Console.WriteLine(" ");
        Console.WriteLine($" Compass  | Player: {Name}");
        Console.WriteLine("==========|===========================================");
        Console.WriteLine($"   \x1b[36mN\x1b[37m      | Health           : \x1b[32m{Health}\x1b[37m");
        Console.WriteLine($"   |      | Current weapon   : \x1b[91m{CurrentWeapon.Name}\x1b[37m");
        Console.WriteLine($"\x1b[36mW\x1b[37m--0--\x1b[36mE\x1b[37m   | Current position : X: \x1b[94m{PositionX}\x1b[37m Y: \x1b[94m{PositionY}\x1b[37m");
        Console.WriteLine($"   |      | Current quest    : \x1b[93m{CurrentQuest.Name}\x1b[37m");
        Console.WriteLine("   \x1b[36mS\x1b[37m      |");
        Console.WriteLine(" ");
        Console.WriteLine("Movement options (\x1b[94mN\x1b[37m/\x1b[94mE\x1b[37m/\x1b[94mS\x1b[37m/\x1b[94mW\x1b[37m) (\x1b[94m↑\x1b[37m, \x1b[94m→\x1b[37m, \x1b[94m↓\x1b[37m, \x1b[94m←\x1b[37m),\nOpen Inventory (\x1b[94mI\x1b[37m), Switch Weapon (\x1b[94mR\x1b[37m) Open Quests (\x1b[94mQ\x1b[37m)");
    }

    public void SwitchWeaponMenu() {
        Console.Clear();
        Dictionary<int, Weapon> dict_armory = new Dictionary<int, Weapon>();
        int i = 1;
        foreach (Weapon weapon in Armory) {
            Console.WriteLine($"{i} {weapon.Name} - 🗡️  Damage: ({weapon.DamageRangeMin} - {weapon.DamageRangeMax})");
            dict_armory.Add(i, weapon);
            i++;
        }
        Console.WriteLine("\n");
        Console.WriteLine("======================================================");
        Console.WriteLine("Options: switch to weapon (number), Quit (Q)");
        bool valid_awnser = false;
        while (!valid_awnser) {
            string str_choice = Console.ReadLine();
            bool isInt = false;
            int int_choice;
            try {
                int_choice = Convert.ToInt32(str_choice);
                isInt = true;
            } catch {
                int_choice = 0;
            }

            if (isInt) {
                Console.WriteLine($"Current weapon has been changed to {dict_armory[int_choice].Name}");
                CurrentWeapon = dict_armory[int_choice];
                Thread.Sleep (1000);
                valid_awnser = true;
            } else if (str_choice.ToLower() == "q") {
                valid_awnser = true;
            } else {
                Console.WriteLine($"{Name} : Oh no i don't give a valid awnser, i am going to try that again");
            }
        }
    }

    //ItsDanny - This is still being worked on, and will be updated soon
    // public void Inventroy() {
    //     Console.Clear();
    //     Dictionary<int, Dictionary<int, string>> dict_inventory = new Dictionary<int, Dictionary<int, string>>();
    //     int i = 1;
    //     foreach (Item item in Inventory) {
    //         foreach (Dictionary<int, string> dict)
    //     }
    // }
}