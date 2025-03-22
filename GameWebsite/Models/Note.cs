namespace GameWebsite.Models
{
    /// <summary>
    /// Represents a note created by a user, optionally referencing various game entities.
    /// </summary>
    public class Note
    {
        /// <summary>
        /// The username of the individual who created the note.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// The text content of the note.
        /// </summary>
        public string NoteText { get; set; }

        /// <summary>
        /// Optional reference to a player entity related to the note.
        /// </summary>
        public Player? PlayerRef { get; set; }

        /// <summary>
        /// Optional reference to an enemy entity related to the note.
        /// </summary>
        public Enemy? EnemyRef { get; set; }

        /// <summary>
        /// Optional reference to a weapon entity related to the note.
        /// </summary>
        public Weapon? WeaponRef { get; set; }

        /// <summary>
        /// Optional reference to a potion entity related to the note.
        /// </summary>
        public Potion? PotionRef { get; set; }

        /// <summary>
        /// List of objects that hold additional references associated with the note.
        /// Can include players, enemies, weapons, potions, or other relevant objects.
        /// </summary>
        public List<object>? Refrences { get; set; }
    }
}
