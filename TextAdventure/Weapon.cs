namespace TextAdventure
{
    public class Weapon : Item
    {
        public int Damage { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="damage"></param>
        public Weapon(string name, string description, int damage) : base(name, description)
        {
            Damage = damage;
        }
    }
}