namespace GameWebsite.Models
{
    public class Player
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Damage { get; set; }
        public Weapon CurrentWeapon { get; set; }
        public string Id { get; set; }

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
