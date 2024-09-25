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
    }

  public void QuestDetails(){
    Console.WriteLine ($"Quest: {Name}\nDescription: {Description}\nStatus: {Status}");
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
}
