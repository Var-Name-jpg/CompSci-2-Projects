namespace GameWebsite.Models
{
    /// <summary>
    /// Represents a weapon item in the game, which is used to deal damage to enemies.
    /// Inherits from the <see cref="Item"/> class.
    /// </summary>
    public class Weapon : Item
    {
        /// <summary>
        /// The amount of damage the weapon can deal.
        /// </summary>
        public int Damage { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Weapon"/> class.
        /// </summary>
        /// <param name="name">The name of the weapon.</param>
        /// <param name="description">A description of the weapon and its characteristics.</param>
        /// <param name="damage">The damage value of the weapon.</param>
        public Weapon(string name, string description, int damage) : base(name, description)
        {
            Damage = damage;
        }
    }
}
