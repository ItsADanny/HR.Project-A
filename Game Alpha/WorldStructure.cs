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
    public Location NextLocation;
    public static int PlayerStartPositionX;
    public static int PlayerStartPositionY;

    public WorldStructure(int id, string name, string map_icon, bool player_can_walk_on, bool hurts_player, int damage_overtime, bool is_door_to_next_location, Location next_location, int playerStartPositionX, int playerStartPositionY) {
        ID = id;
        Name = name;
        MapIcon = map_icon;
        PlayerCanWalkOn = player_can_walk_on;
        HurtsPlayer = hurts_player;
        DamageToPlayerOverTime = damage_overtime;
        IsDoorToNextLocation = is_door_to_next_location;
        NextLocation = next_location;
        LocationX = 0;
        LocationY = 0;
        PlayerStartPositionX = playerStartPositionX;
        PlayerStartPositionY = playerStartPositionY;
    }

    public void defineLocation(int location_x, int location_y) {
        LocationX = location_x;
        LocationY = location_y;
    }

    public bool AskForNextLocation(Player player) {
        Console.WriteLine($"You landed on {NextLocation.Name}, do you want to enter this location?");
        Console.WriteLine("Options: Yes (Y), No (N)");
        bool validResponse = false;
        bool enterNewLocation = false;
        while (!validResponse) {
            string str_choice = Console.ReadLine();
            switch (str_choice.ToLower())
            {
                case "y":
                    validResponse = true;
                    enterNewLocation = true;
                    break;
                case "n":
                    validResponse = true;
                    break;
                default:
                    Console.WriteLine($"{player.Name} : Oh no i don't give a valid awnser, i am going to try that again");
                    break;
            }
        }
        return enterNewLocation;
    }

}