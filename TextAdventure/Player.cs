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
        /// Creates an instance of player
        /// </summary>
        /// <param name="maxHealth">Player max health</param>
        /// <param name="health">Player current health</param>
        /// <param name="damage">Player damage</param>
        /// <param name="currentWeapon">Current equipped weapon</param>
        /// <param name="currentX">Current X Pos</param>
        /// <param name="currentY">Current Y Pos</param>
        /// <param name="name">Player name</param>
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
        /// Updates the player
        /// </summary>
        public void Update()
        {
            this.Damage = this.CurrentWeapon.Damage;
        }

        /// <summary>
        /// allows interaction between player and enemy
        /// </summary>
        /// <param name="enemy">Instance of enemy object</param>
        public void Fight(ICharacter enemy)
        {
            Console.WriteLine($"{Name} attacks {enemy.Name} for {this.Damage} damage!");
            enemy.Health -= this.Damage;
        }
    }
}