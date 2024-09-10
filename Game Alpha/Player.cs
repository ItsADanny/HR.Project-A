public class Player
{
    public int ID;
    public string Name;
    public int Health;
    public List<Item> Inventory;
    public List<Weapon> Armory;
    public List<HealingItem> HealingItems;

    public Player(int id, string name) {
        ID = id;
        Name = name;
        Health = 100;
        Inventory = new List<Item>();
        HealingItems = new List<HealingItems>();

        Weapon startingWeapon = new Weapon();

        Armory.Add();
    }

}