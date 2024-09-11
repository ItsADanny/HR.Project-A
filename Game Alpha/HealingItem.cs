using System.Data.Common;

public class HealingItem {
    public int ID;
    public string Name;
    public string Description;
    public string Icon;
    public int HealingAmount;

    public HealingItem(int id, string name, string description, string icon, int healingamount) {
        ID = id;
        Name = name;
        Description = description;
        Icon = icon;
        HealingAmount = healingamount;
    }
}