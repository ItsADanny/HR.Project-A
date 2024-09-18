public class Location {
    public int ID;
    public string Name;
    public string Description;
    public int LocationSizeX;
    public int LocationSizeY;
    public List<Quest> Quests;
    public List<Monster> Monsters;
    public List<WorldStructure> WorldStructures;
    public Player Player;
    
    public Location(int id, string name, string description, int location_size_x, int location_size_y, Player player) {
        ID = id;
        Name = name;
        Description = description;
        LocationSizeX = location_size_x;
        LocationSizeY = location_size_y;
        Quests = new List<Quest>();
        Monsters = new List<Monster>();
        WorldStructures = new List<WorldStructure>();
        Player = player;
    }

    public void AddQuests(Quest quest) => Quests.Add(quest);

    public void AddQuests(List<Quest> quests) {
        foreach (Quest quest in quests) {
            Quests.Add(quest);
        }
    }

    public void AddMonster(Monster monster) => Monsters.Add(monster);

    public void AddMonsters(List<Monster> monsters) {
        foreach (Monster monster in monsters) {
            Monsters.Add(monster);
        }
    }

    // This function will generate the map that will be displayed to the user
    public void GenMap() {
        string fancyMapBorder = "O}=====--=----=---={ " + Name + " }=---=----=--====={O";
        // Map border
        Console.WriteLine(fancyMapBorder);

        // Loop to generate the height of the map
        for (int y = 0; y < LocationSizeY; y++) {
            string map_row = "";

            // Loop to generate the map row
            for (int x = 0; x < LocationSizeX | x < fancyMapBorder.Length; x++) {
                bool somethingIsAlreadyOnThisLocation = false;

                foreach (Quest quest in Quests) {
                    if (quest.LocationX == x & quest.LocationY == y) {
                        if (!somethingIsAlreadyOnThisLocation) {
                            map_row += quest.MapIcon;
                            somethingIsAlreadyOnThisLocation = true;
                        }
                    }
                }

                foreach (Monster monster in Monsters) {
                    if (monster.LocationX == x & monster.LocationY == y) {
                        if (!somethingIsAlreadyOnThisLocation) {
                            map_row += monster.MapIcon;
                            somethingIsAlreadyOnThisLocation = true;
                        }
                    }
                }

                foreach (WorldStructure worldStructure in WorldStructures) {
                    if (worldStructure.LocationX == x & worldStructure.LocationY == y) {
                        if (!somethingIsAlreadyOnThisLocation) {
                            map_row += worldStructure.MapIcon;
                            somethingIsAlreadyOnThisLocation = true;
                        }
                    }
                }

                if (Player.PositionX == x & Player.PositionY == y) {
                    if (!somethingIsAlreadyOnThisLocation) {
                        map_row += Player.MapIcon;
                        somethingIsAlreadyOnThisLocation = true;
                    }
                }

                if (!somethingIsAlreadyOnThisLocation) {
                    map_row += " ";
                }
            }

            // Print the map row
            Console.WriteLine(map_row);
        }

        // Map border
        Console.WriteLine(fancyMapBorder);
    }

    public void checkPlayerLocationForDamage() {
        foreach (WorldStructure worldStructure in WorldStructures) {
            if (worldStructure.LocationX == Player.PositionX & worldStructure.LocationY == Player.PositionY & worldStructure.HurtsPlayer) {
                //Add damage function
            }
        }
    }

    public void checkPlayerLocationForQuest() {
        foreach (Quest quest in Quests) {
            if (quest.LocationX == Player.PositionX & quest.LocationY == Player.PositionY) {
                //Add damage function
            }
        }
    }
}