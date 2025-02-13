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
        /// Creates an instance of an Enemy
        /// </summary>
        /// <param name="name">Name of the enemy</param>
        /// <param name="health">Health of the enemt</param>
        /// <param name="damage">Enemy's damage</param>
        public Enemy(string name, int health, int damage)
        {
            Name = name;
            Health = health;
            Damage = damage;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="player"></param>
        public void Fight(ICharacter player)
        {
            Console.WriteLine($"{Name} attacks {player.Name} for {this.Damage} damage!");
            player.TakeDamage(this.Damage);
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
    }
}