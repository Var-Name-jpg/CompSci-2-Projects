namespace GameWebsite.Models
{
    public class Enemy : ICharacter
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Damage { get; set; }
        public string Id { get; set; }

        public Enemy(string name, int health, int damage)
        {
            Id = name.Replace(" ", "_");
            Name = name;
            Health = health;
            Damage = damage;
        }
    }
}
