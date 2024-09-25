public class Quest {
    public int ID;
    public string Name;
    public string Description;
    public string MapIcon;
    public int LocationX;
    public int LocationY;
    public bool Completed;
    public string Status;
    public Weapon RewardWeapon;
    public Player GamePlayer;
    public List<Monster> monsters;


    public Quest(int id, string name, string description, string map_icon, int location_x, int location_y, Weapon rewardweapon, Player gameplayer) {
        ID = id;
        Name = name;
        Description = description;
        MapIcon = map_icon;
        LocationX = location_x;
        LocationY = location_y;
        Completed = false;
        Status = "Not started";
        RewardWeapon = rewardweapon;
        GamePlayer = gameplayer;
        monsters = new List<Monster>();
    }

  public void QuestDetails(){
    Console.WriteLine ($"\nQuest: {Name}\nDescription: {Description}\nStatus: {Status}");
    }
    public void AskToStartQues(){
    Console.WriteLine("You have encountered a quest!");
    Console.WriteLine("Do you accept the quest? (yes/no)");
    string answer = Console.ReadLine().ToLower();
    if (answer == "yes"){
        StartQuest();
    }
    else{
        Console.WriteLine("Quest denied");
    }
}
private void StartQuest(){
    Console.WriteLine("You have accepted the quest!");
    Status = "In progress";
    QuestDetails();
}

public void CompleteQuest(){
    System.Console.WriteLine("You have completed the quest! ");
    Status = "Completed";
    Console.WriteLine("You have received a reward!");
    GamePlayer.AddWeapon(RewardWeapon);
        
    }

    public void AddMonster(Monster monster) {
        monsters.Add(monster);
    }

    public void QuestCompleteCheck() {
        int AreThereStillMonsters = 0;
        foreach (Monster monster in monsters) {
            if (monster.IsAlive()) {
                AreThereStillMonsters++;
            }
        }

        if (AreThereStillMonsters == 0) {
            //Add code to complete the quest
        }
    }
}


