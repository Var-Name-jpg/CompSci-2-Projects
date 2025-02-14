namespace TextAdventure
{
    public abstract class Item
    {
        public string Name { get; set; }
        public string Description { get; set; }

        /// <summary>
        /// Creates an instance of Item
        /// </summary>
        /// <param name="name">Item Name</param>
        /// <param name="description">Item Description</param>
        public Item(string name, string description)
        {
            Name = name;
            Description = description;
        }

        /// <summary>
        /// I'm picky
        /// </summary>
        /// <param name="itemName">Sees if the item name starts with a vowel</param>
        /// <returns>"A" or "An" respectively</returns>
        public string ReturnIndefiniteArticle(string itemName)
        {
            char firstLetter = char.ToLower(itemName[0]);
            string vowels = "aeiou";

            return vowels.Contains(firstLetter) ? "an" : "a";
        }

        /// <summary>
        /// Decides what to do with an Item when the player encounters it
        /// </summary>
        /// <param name="player">The player</param>
        /// <returns>A string of what happened with the item</returns>
        public string PickUpItem(Player player)
        {
            string retString = string.Empty;

            string article = ReturnIndefiniteArticle(this.Name);

            if (this is Weapon weapon)
            {
                if (weapon.Damage > player.CurrentWeapon.Damage)
                {
                    player.CurrentWeapon = weapon;

                    retString += $"You picked up {article} {weapon.Name}!\nIt was automatically added to your inventory.";
                }
                else
                {
                    retString += $"You found {article} {weapon.Name}!\nYou left it, as yours is stronger.";
                }
            }
            if (this is Potion potion)
            {
                potion.AddEffect(player, retString);
            }

            return retString;
        }

        /// <summary>
        /// String override
        /// </summary>
        /// <returns>String of the weapon description for the player</returns>
        public override string ToString()
        {
            string retString = string.Empty;

            if (this is Weapon weapon)
            {
                retString += $"Current Weapon: {this.Name} | ";
                retString += $"Desc: {this.Description} | ";
                retString += $"Damage: {weapon.Damage}\n";
            }

            return retString;
        }
    }
}