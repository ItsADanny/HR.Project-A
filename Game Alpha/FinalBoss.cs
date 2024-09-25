// public class FinalBoss : Monster
// {
//     private int currentPhase;
//     private int[] phaseHealths;
//     private int[] phaseDamageMin;
//     private int[] phaseDamageMax;

//     public FinalBoss(int id, string name, string description, string mapIcon)
//      : base(id, name, description, mapIcon, 100, 10, 20)
//     {
//         currentPhase = 1;
//         phaseHealths = new int[] { 100, 150, 200 };  
//         phaseDamageMin = new int[] { 10, 15, 20 };  
//         phaseDamageMax = new int[] { 20, 25, 30 };  
//         Health = phaseHealths[0]; 
//     }

//     public new int GenAttackDamage()
//     {
//         Random rnd = new Random();
//         return rnd.Next(phaseDamageMin[currentPhase - 1], phaseDamageMax[currentPhase - 1] + 1);
//     }

//     public new void TakeDamage(int damage)
//     {
//         base.TakeDamage(damage);
//         if (Health <= 0 && currentPhase < 3)
//         {
//             currentPhase++;
//             Console.WriteLine($"The boss moves to phase {currentPhase}!");
//             Health = phaseHealths[currentPhase - 1]; 
//         }
//         else if (Health <= 0 && currentPhase == 3)
//         {
//             Console.WriteLine("The final boss has been defeated! You win!");
//         }
//     }

//     public bool IsFinalPhase()
//     {
//         return currentPhase == 3;
//     }
// }