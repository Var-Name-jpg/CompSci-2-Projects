namespace GameWebsite.Models
{
    /// <summary>
    /// Represents a player in the game, including their health, damage, and equipped weapon.
    /// </summary>
    public class Player
    {
        /// <summary>
        /// The name of the player.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The maximum health points of the player.
        /// Determines how much damage the player can endure before being defeated.
        /// </summary>
        public int Health { get; set; }

        /// <summary>
        /// The damage points the player can deal based on their equipped weapon.
        /// </summary>
        public int Damage { get; set; }

        /// <summary>
        /// The weapon currently equipped by the player.
        /// </summary>
        public Weapon CurrentWeapon { get; set; }

        /// <summary>
        /// A unique identifier for the player, generated from their name.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Player"/> class.
        /// </summary>
        /// <param name="maxHealth">The maximum health points of the player.</param>
        /// <param name="currentWeapon">The weapon currently equipped by the player.</param>
        /// <param name="name">The name of the player. Defaults to "Player" if not specified.</param>
        public Player(int maxHealth, Weapon currentWeapon, string name = "Player")
        {
            Name = name;
            Health = maxHealth;
            Damage = currentWeapon.Damage;
            CurrentWeapon = currentWeapon;
            Id = name.Replace(" ", "_");
        }
    }
}
