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

    public void RemoveItem(int int_itemID) {
        List<Item> Eddited_Inventory = new List<Item>();
        foreach (Item item in Inventory) {
            if (item.ID != int_itemID) {
                Eddited_Inventory.Add(item);
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
        Console.WriteLine("Movement options (N/E/S/W), Open Inventory (I), Switch Weapon (R) Open Quests (Q)");
    }
}