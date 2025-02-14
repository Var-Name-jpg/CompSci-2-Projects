namespace TextAdventure
{
    public class Enemy : ICharacter
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Damage { get; set; }

        private int totalDamageDealt = 0;
        private int totalDamageTaken = 0;

        /// <summary>
        /// Creates an instance of Enemy
        /// </summary>
        /// <param name="name">Enemy name</param>
        /// <param name="health">Enemy health</param>
        /// <param name="damage">Enemy damage</param>
        public Enemy(string name, int health, int damage)
        {
            Name = name;
            Health = health;
            Damage = damage;
        }

        /// <summary>
        /// Makes this instance of enemy fight player
        /// </summary>
        /// <param name="player">The player</param>
        public void Fight(ICharacter player)
        {
            Console.WriteLine($"{Name} attacks {player.Name} for {this.Damage} damage!");
            player.Health -= this.Damage;
        }
    }
}