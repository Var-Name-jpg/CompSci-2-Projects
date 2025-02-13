namespace TextAdventure
{
    public class Player : ICharacter
    {
        public string Name { get; set; }
        public int MaxHealth { get; set; }
        public int Health { get; set; }
        public int Damage { get; set; }
        public Weapon CurrentWeapon { get; set; }
        public int CurrentX { get; set; }
        public int CurrentY { get; set; }

        private int totalDamageDealt = 0;
        private int totalDamageTaken = 0;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="maxHealth"></param>
        /// <param name="health"></param>
        /// <param name="damage"></param>
        /// <param name="currentWeapon"></param>
        /// <param name="currentX"></param>
        /// <param name="currentY"></param>
        /// <param name="name"></param>
        public Player(int maxHealth, int health, int damage, Weapon currentWeapon, int currentX, int currentY, string name = "Player")
        {
            Name = name;
            MaxHealth = maxHealth;
            Health = health;
            Damage = damage;
            CurrentX = currentX;
            CurrentY = currentY;
            CurrentWeapon = currentWeapon;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="roomMap"></param>
        public void Move(int x, int y, Room[,] roomMap)
        {
            roomMap[this.CurrentY, this.CurrentX].ThingInRoom = null;
            this.CurrentX = x; this.CurrentY = y;
            roomMap[this.CurrentY, this.CurrentX].CheckRoom(this);
        }

        public void FightLoop(Enemy enemy)
        {
            Console.WriteLine($"{Name} enters combat with {enemy.Name}!");

            int initialPlayerHealth = Health;
            int initialEnemyHealth = enemy.Health;

            while (Health > 0 && enemy.Health > 0)
            {
                // Player attacks enemy
                Fight(enemy);

                if (enemy.Health <= 0)
                {
                    Console.WriteLine($"{enemy.Name} has been defeated!");
                    break;
                }

                // Enemy fights back
                enemy.Fight(this);

                if (Health <= 0)
                {
                    Console.WriteLine($"{Name} has been defeated!");
                    break;
                }
            }

            // Display fight summary
            DisplayFightSummary(enemy, initialPlayerHealth, initialEnemyHealth);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="enemy"></param>
        public void Fight(ICharacter enemy)
        {
            Console.WriteLine($"{Name} attacks {enemy.Name} for {this.Damage} damage!");
            enemy.Health -= this.Damage;
            totalDamageDealt += this.Damage;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="damage"></param>
        public void TakeDamage(int damage)
        {
            Health -= damage;
            totalDamageTaken += damage;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="enemy"></param>
        /// <param name="initialPlayerHealth"></param>
        /// <param name="initialEnemyHealth"></param>
        private void DisplayFightSummary(Enemy enemy, int initialPlayerHealth, int initialEnemyHealth)
        {
            Console.WriteLine("\n===== FIGHT SUMMARY =====");
            Console.WriteLine($"{Name} started with {initialPlayerHealth} HP and dealt {totalDamageDealt} total damage.");
            Console.WriteLine($"{enemy.Name} started with {initialEnemyHealth} HP and dealt {totalDamageTaken} total damage.");
            Console.WriteLine(Health > 0 ? $"{Name} wins the battle!" : $"{enemy.Name} wins the battle!");
            Console.WriteLine("=========================");
        }
    }
}