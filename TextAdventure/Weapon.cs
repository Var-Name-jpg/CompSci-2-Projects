namespace TextAdventure
{
    public class Weapon : Item
    {
        public int Damage { get; set; }

        /// <summary>
        /// Creates an instance of weapon
        /// </summary>
        /// <param name="name">Weapon name</param>
        /// <param name="description">Weapon description</param>
        /// <param name="damage">Weapon damage</param>
        public Weapon(string name, string description, int damage) : base(name, description)
        {
            Damage = damage;
        }
    }
}