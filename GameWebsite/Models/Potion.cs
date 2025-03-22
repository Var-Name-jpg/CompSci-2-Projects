namespace GameWebsite.Models
{
    /// <summary>
    /// Defines the different effects a potion can have in the game.
    /// </summary>
    public enum PotionEffects
    {
        /// <summary>
        /// Restores health to the player.
        /// </summary>
        Healing,

        /// <summary>
        /// Increases the player's attack power.
        /// </summary>
        IncreaseAttack,

        /// <summary>
        /// Increases the player's maximum health.
        /// </summary>
        IncreaseHealth
    }

    /// <summary>
    /// Represents a potion item in the game, which provides specific effects to the player.
    /// Inherits from the <see cref="Item"/> class.
    /// </summary>
    public class Potion : Item
    {
        /// <summary>
        /// The effect of the potion, determining its benefit to the player.
        /// </summary>
        public PotionEffects Effect { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Potion"/> class.
        /// </summary>
        /// <param name="name">The name of the potion.</param>
        /// <param name="description">A description of the potion and its effects.</param>
        /// <param name="effect">The effect of the potion.</param>
        public Potion(string name, string description, PotionEffects effect) : base(name, description)
        {
            Effect = effect;
        }
    }
}
