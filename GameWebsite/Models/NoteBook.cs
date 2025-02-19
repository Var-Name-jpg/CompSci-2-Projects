namespace GameWebsite.Models
{
    public class NoteBook : INoteBook
    {
        List<Note> Notes {  get; set; } = new List<Note>();

        public Note GetNote(int index)
        {
            return Notes[index];
        }

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

        public void RemoveNote(int index) => Notes.RemoveAt(index);

        public int GetNoteCount() => Notes.Count();
    }
}
