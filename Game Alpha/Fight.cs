public class Fight
    {
        public static void StartFight(Player player, Monster monster)
        {
            Console.WriteLine($"A wild {monster.Name} has appeared!");

            // Ask the player if they want to fight or run away
            Console.WriteLine("Do you want to fight or run away? (Type 'fight' or 'run')");
            string choice = Console.ReadLine().ToLower();

            if (choice == "run")
            {
                Console.WriteLine("You have run away from the fight!");
                return; // Exit the fight method
            }
            else if (choice != "fight")
            {
                Console.WriteLine("Invalid choice. You are forced to fight.");
            }

            // Proceed with the fight
            FightPlayerAgainstMonster(player, monster);
        }

        private static void FightPlayerAgainstMonster(Player player, Monster monster)
        {
            while (player.Health > 0 && monster.IsAlive())
            {
                player.Attack(monster);
                if (monster.IsAlive())
                {
                    int damage = monster.GenAttackDamage();
                    player.HealthReduce(damage);
                    Console.WriteLine($"{monster.Name} attacks {player.Name} for {damage} damage.");
                }

                Console.WriteLine($"Player Health: {player.Health}, Monster Health: {monster.Health}");
            }

            if (player.Health <= 0)
            {
                Console.WriteLine("You have been defeated.");
            }
            else if (!monster.IsAlive())
            {
                Console.WriteLine($"You have defeated the {monster.Name}!");
            }
        }
    }