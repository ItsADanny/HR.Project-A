public class Monster
{
    public int ID;
    public string Name;
    public string Description;
    public int Health;
    public int DamageRangeMin;
    public int DamageRangeMax;
    
    public Monster(int id, string name, string description, int health, int damage_range_min, int damage_range_max)
    {
        ID = id;
        Name = name;
        Description = description;
        Health = health;
        DamageRangeMin = damage_range_min;
        DamageRangeMax = damage_range_max;
    }

    public int GenAttackDamage() {
        Random rnd = new Random();
        return rnd.Next(DamageRangeMin, (DamageRangeMax + 1));
    }

    public void TakeDamage(int damage) {
        if (Health - damage < 0) {
            Health = 0;
        } else {
            Health -= damage;
        }
    }

    public bool isAlive() {
        if (Health > 0) {
            return true;
        }
        return false;
    }

    

}