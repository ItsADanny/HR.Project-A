public class Quest {
    public int ID;
    public string Name;
    public string ShortDescription;
    public string LongDescription;
    public string MapIcon;
    public int LocationX;
    public int LocationY;
    public bool Completed;

    public Quest(int id, string name, string short_description, string long_description, string map_icon, int location_x, int location_y) {
        ID = id;
        Name = name;
        ShortDescription = short_description;
        LongDescription = long_description;
        MapIcon = map_icon;
        LocationX = location_x;
        LocationY = location_y;
        Completed = false;
    }
}