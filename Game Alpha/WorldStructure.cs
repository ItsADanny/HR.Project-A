public class WorldStructure
{
    public int ID;
    public string Name;
    public string MapIcon;
    public int LocationX;
    public int LocationY;
    public bool PlayerCanWalkOn;
    public bool HurtsPlayer;
    public int DamageToPlayerOverTime;
    public bool IsDoorToNextLocation;
    public int LocationID;

    public WorldStructure(int id, string name, string map_icon, bool player_can_walk_on, bool hurts_player, int damage_overtime, bool is_door_to_next_location, int location_id) {
        ID = id;
        Name = name;
        MapIcon = map_icon;
        PlayerCanWalkOn = player_can_walk_on;
        HurtsPlayer = hurts_player;
        DamageToPlayerOverTime = damage_overtime;
        IsDoorToNextLocation = is_door_to_next_location;
        LocationID = location_id;
        LocationX = 0;
        LocationY = 0;
    }

    public void defineLocation(int location_x, int location_y) {
        LocationX = location_x;
        LocationY = location_y;
    }

}