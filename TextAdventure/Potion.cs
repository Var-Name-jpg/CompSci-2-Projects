namespace TextAdventure
{
    public class Potion : Item
    {
        public PotionEffects Effect { get; set; }
        public Random rand = new Random();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="effect"></param>
        public Potion(string name, string description, PotionEffects effect) : base(name, description)
        {
            Effect = effect;
        }

        /// <summary>
        /// This takes the effect of the potion in the room and uses it on the player
        /// </summary>
        /// <param name="player">Player the effect is being used on</param>
        /// <param name="str">Output string for <see cref="Item.PickUpItem(Player)"/></param>
        public void AddEffect(Player player, string str)
        {
            switch (Effect.ToString())
            {
                case "Healing":
                    if (player.Health < player.MaxHealth)
                    {
                        int healAmount = rand.Next(1, (int)(player.MaxHealth / 2));
                        player.Health += healAmount;

                        if (player.Health > player.MaxHealth)
                        {
                            player.Health = player.MaxHealth;
                        }

                        str += $"You have gained {healAmount} health, bringing you up to {player.Health}!";
                    }
                    else
                    {

                    }
                    break;

                case "IncreaseAttack":
                    int increaseAmountD = rand.Next(1, 5);
                    player.Damage += increaseAmountD;
                    str += $"Your damage has been increased by {increaseAmountD}!\nYou now deal {player.Damage} damage per hit!";
                    break;

                case "IncreaseHealth":
                    int increaseAmountH = rand.Next(1, 5);
                    str += $"Your health has been increased by {increaseAmountH}!\nYou now have a max health of {player.MaxHealth}!";
                    break;
            }
        }
    }
}