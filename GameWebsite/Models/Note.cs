namespace GameWebsite.Models
{
    public class Note
    {
        public string UserName { get; set; }
        public string NoteText { get; set; }
        public Player? PlayerRef { get; set; }
        public Enemy? EnemyRef { get; set; }
        public Weapon? WeaponRef { get; set; }
        public Potion? PotionRef { get; set; }
        public List<object>? Refrences { get; set; }

    }
}
