namespace GameWebsite.Models
{
    /// <summary>
    /// Represents a character in the game, defining the essential properties all characters must have.
    /// </summary>
    public interface ICharacter
    {
        /// <summary>
        /// The name of the character.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// The health points of the character.
        /// Determines how much damage the character can sustain before being defeated.
        /// </summary>
        int Health { get; set; }

        /// <summary>
        /// The damage points the character can deal to others.
        /// </summary>
        int Damage { get; set; }

        /// <summary>
        /// A unique identifier for the character, typically derived from its name.
        /// </summary>
        string Id { get; set; }
    }
}
