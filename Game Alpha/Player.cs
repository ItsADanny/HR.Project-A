public class Player
{
    public string Name;
    public int Health;
    public List<Item> Inventory;
    public List<Weapon> Armory;
    public List<HealingItem> HealingItems;
    public Weapon CurrentWeapon;

    public Player(string name, Weapon weapon) {
        Name = name;
        Health = 100;
        Inventory = new List<Item>();
        Armory = new List<Weapon>();
        HealingItems = new List<HealingItem>();
        CurrentWeapon = weapon;
    }

    public void RemoveItem(int int_itemID) {
        List<Item> Eddited_Inventory = new List<Item>();
        foreach (Item item in Inventory) {
            if (item.ID != int_itemID) {
                Eddited_Inventory.Add(item);
            }
        }
    }

}