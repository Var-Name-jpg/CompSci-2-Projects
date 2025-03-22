namespace GameWebsite.Models
{
    /// <summary>
    /// Represents a notebook for managing a collection of notes.
    /// Implements the <see cref="INoteBook"/> interface.
    /// </summary>
    public class NoteBook : INoteBook
    {
        /// <summary>
        /// The list of notes stored in the notebook.
        /// </summary>
        private List<Note> Notes { get; set; } = new List<Note>();

        /// <summary>
        /// Retrieves a note at the specified index.
        /// </summary>
        /// <param name="index">The index of the note to retrieve.</param>
        /// <returns>The note object at the specified index.</returns>
        public Note GetNote(int index)
        {
            return Notes[index];
        }

        /// <summary>
        /// Adds a new note to the notebook with optional references to game entities.
        /// </summary>
        /// <param name="userName">The username of the note's creator.</param>
        /// <param name="noteText">The text content of the note.</param>
        /// <param name="player">Optional reference to a player entity.</param>
        /// <param name="enemy">Optional reference to an enemy entity.</param>
        /// <param name="weapon">Optional reference to a weapon entity.</param>
        /// <param name="potion">Optional reference to a potion entity.</param>
        public void AddNote(string userName, string noteText, Player? player, Enemy? enemy, Weapon? weapon, Potion? potion)
        {
            // Create the note with references
            Note toAdd = new Note
            {
                UserName = userName,
                NoteText = noteText,
                Refrences = new List<object>()
            };

            // Add references to the list if they are not null
            if (player != null)
            {
                toAdd.Refrences.Add(player);
            }
            if (enemy != null)
            {
                toAdd.Refrences.Add(enemy);
            }
            if (weapon != null)
            {
                toAdd.Refrences.Add(weapon);
            }
            if (potion != null)
            {
                toAdd.Refrences.Add(potion);
            }

            // Add the note to the list
            Notes.Add(toAdd);
        }

        /// <summary>
        /// Removes a note at the specified index from the notebook.
        /// </summary>
        /// <param name="index">The index of the note to be removed.</param>
        public void RemoveNote(int index) => Notes.RemoveAt(index);

        /// <summary>
        /// Gets the total count of notes currently stored in the notebook.
        /// </summary>
        /// <returns>The number of notes in the notebook.</returns>
        public int GetNoteCount() => Notes.Count();
    }
}
