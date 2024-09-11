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
        CurrentQuest = new Quest(420, "No Quest", "", "", "", 0, 0);
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

    public void PrintMenu()
    {
        Console.WriteLine(" ");
        Console.WriteLine($" Compass  | Player: {Name}");
        Console.WriteLine("==========|===========================================");
        Console.WriteLine($"   N      | Health: {Health}");
        Console.WriteLine($"   |      | Current weapon: {CurrentWeapon.Name}");
        Console.WriteLine($"W--0--E   | Current quest: {CurrentQuest.Name}");
        Console.WriteLine("   |      |");
        Console.WriteLine("   S      |");
        Console.WriteLine(" ");
        Console.WriteLine("Movement options (N/E/S/W), Open Inventory (I), Switch Weapon (R)");
    }
}