public class Location {
    
    public int ID;
    public string Name;
    public string Description;
    public List<Quest> Quests
    public List<Monster> Monsters

    
    public Location(int id, string name, string description, List<Quest> quests, List<Monster> monsters) {
        ID = id;
        Name = name;
        Description = description;
        Quests = quests;
        Monsters = monsters;
    }

    public void AddLocation(Quest quest) => Quests.Add(quest);

    public void AddLocations(List<Quest> quests) {
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
}