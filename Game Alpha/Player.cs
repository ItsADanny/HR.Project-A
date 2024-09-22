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
        HealingItems = new List<HealingItem>();
        CurrentWeapon = weapon;
        CurrentQuest = new Quest(420, "No Quest", "", "", 0, 0);
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
           int damage = 10; // Assuming Weapon class has a Damage property
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
        Console.WriteLine($"   N      | Health           : {Health}");
        Console.WriteLine($"   |      | Current weapon   : {CurrentWeapon.Name}");
        Console.WriteLine($"W--0--E   | Current position : X: {PositionX} Y: {PositionY}");
        Console.WriteLine($"   |      | Current quest    : {CurrentQuest.Name}");
        Console.WriteLine("   S      |");
        Console.WriteLine(" ");
        Console.WriteLine("Movement options (N/E/S/W) (↑, →, ↓, ←),\nOpen Inventory (I), Switch Weapon (R) Open Quests (Q)");
    }
}