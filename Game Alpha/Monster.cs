public class Monster
{
    public int ID;
    public string Name;
    public string Description;
    public string MapIcon;
    public int Health;
    public int DamageRangeMin;
    public int DamageRangeMax;
    public int LocationX;
    public int LocationY;
    
    public Monster(int id, string name, string description, string map_icon, int health, int damage_range_min, int damage_range_max)
    {
        ID = id;
        Name = name;
        Description = description;
        MapIcon = map_icon;
        Health = health;
        DamageRangeMin = damage_range_min;
        DamageRangeMax = damage_range_max;
        //By default monsters will not get a location. This will need to be defined with the method DefineLocation()
        LocationX = 0;
        LocationY = 0;
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

    public bool IsAlive() {
        if (Health > 0) {
            return true;
        }
        return false;
    }

    public void DefineLocation(int location_x, int location_y) {
        LocationX = location_x;
        LocationY = location_y;
    }

}