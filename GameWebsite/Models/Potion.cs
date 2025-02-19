namespace GameWebsite.Models
{
    public enum PotionEffects
    {
        Healing,
        IncreaseAttack,
        IncreaseHealth
    }

    public class Potion : Item
    {
        public PotionEffects Effect { get; set; }

        public Potion(string name, string description, PotionEffects effect) : base(name, description)
        {
            Effect = effect;
        }
    }
}
