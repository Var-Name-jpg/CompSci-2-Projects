namespace GameWebsite.Models
{
    public interface INoteBook
    {
        public Note GetNote(int index);
        public int GetNoteCount();
        public void AddNote(string userName, string noteText, Player? player, Enemy? enemy, Weapon? weapon, Potion? potion);
        public void RemoveNote(int  index);
    }
}
