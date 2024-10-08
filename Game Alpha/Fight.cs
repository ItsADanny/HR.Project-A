public class Fight
{
    private Player player;
    private Monster monster;
    private bool inCombat;

    public Fight(Player player, Monster monster) {
        this.player = player;
        this.monster = monster;
        this.inCombat = true;
    }

    public void StartFight() {
        Console.WriteLine($"{player.Name} encounters {monster.Name}!");

        while (inCombat && player.IsAlive() && monster.IsAlive()) {
            Console.Clear();
            Console.WriteLine("Player health: " + player.Health);
            Console.WriteLine($"{monster.MapIcon} {monster.Name} Health : {monster.Health}");
            Console.WriteLine("");
            Console.WriteLine("======================================================");
            Console.WriteLine("Choose an action: Fight (F), Run (R), Cancel (C):");
            string action = Console.ReadLine().ToLower();

            switch (action) {
                case "f":
                    player.Attack(monster);

                    if (monster.IsAlive()) {
                        int damage = monster.Attack(player);
                        Console.WriteLine($"{player.Name} has taken {damage} damage from {monster.Name}");
                    } else {
                        Console.WriteLine($"{monster.Name} is defeated!");
                        inCombat = false;
                    }
                    break;

                case "r":
                    Console.WriteLine($"{player.Name} runs away from {monster.Name}. Quest failed.");
                    inCombat = false;
                    break;

                case "c":
                    Console.WriteLine($"{player.Name} cancels the fight. Quest canceled.");
                    inCombat = false;
                    break;

                default:
                    Console.WriteLine("Invalid action! Please choose 'F', 'R', or 'C'.");
                    break;
            }
            
            if (!player.IsAlive()) {
                Console.WriteLine($"{player.Name} has been defeated by {monster.Name}. Game over.");
                inCombat = false;
            }

            Thread.Sleep (2000);
        }
    }
}