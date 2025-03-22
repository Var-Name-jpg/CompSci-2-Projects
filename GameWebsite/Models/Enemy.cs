namespace GameWebsite.Models
{
    /// <summary>
    /// Represents an enemy in the game with health, damage, and an identifier.
    /// Implements the ICharacter interface.
    /// </summary>
    public class Enemy : ICharacter
    {
        /// <summary>
        /// The name of the enemy.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The health points of the enemy.
        /// Determines how much damage the enemy can take before being defeated.
        /// </summary>
        public int Health { get; set; }

        /// <summary>
        /// The damage points the enemy deals to players.
        /// </summary>
        public int Damage { get; set; }

        /// <summary>
        /// A unique identifier for the enemy, generated from its name.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Initializes a new instance of the Enemy class.
        /// </summary>
        /// <param name="name">The name of the enemy.</param>
        /// <param name="health">The health points of the enemy.</param>
        /// <param name="damage">The damage points the enemy deals.</param>
        public Enemy(string name, int health, int damage)
        {
            // Replace spaces in the name with underscores to create a unique ID
            Id = name.Replace(" ", "_");
            Name = name;
            Health = health;
            Damage = damage;
        }
    }
}
