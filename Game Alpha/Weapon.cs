public class Weapon {

    public int ID;
    public string Name;
    public string Description;
    public int DamageRangeMin;
    public int DamageRangeMax;

    public Weapon(int id, string name, string description, int damage_range_min, int damage_range_max) {
        ID = id;
        Name = name;
        Description = description;
        DamageRangeMin = damage_range_min;
        DamageRangeMax = damage_range_max;
    }

    public int GenAttackDamage() {
        Random rnd = new Random();
        return rnd.Next(DamageRangeMin, (DamageRangeMax + 1));
    }

}