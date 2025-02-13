namespace TextAdventure
{
    public abstract class Item
    {
        public string Name { get; set; }
        public string Description { get; set; }

        /// <summary>
        /// This creates a usable insatnce of Item
        /// </summary>
        /// <param name="name">Name of the item</param>
        /// <param name="description">A short description of the item</param>
        public Item(string name, string description)
        {
            Name = name;
            Description = description;
        }

        /// <summary>
        /// This returns a string for "an" or "a"
        /// It's cleaner to do this than to write "a(n)"
        /// </summary>
        /// <param name="itemName">The string we will be testing the first letter of</param>
        /// <returns>A string of either "an" or "a"</returns>
        public string ReturnIndefiniteArticle(string itemName)
        {
            char firstLetter = char.ToLower(itemName[0]);
            string vowels = "aeiou";

            return vowels.Contains(firstLetter) ? "an" : "a";
        }

        /// <summary>
        /// Weapons: Compares weapon in the room to current weapon
        /// keeps current if the new one is worse
        /// 
        /// Potions: Picks up and immediately uses the potion
        /// </summary>
        /// <returns>returns a string saying what happened with the item</returns>
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
        /// Returns a formatted string representation of this item.
        /// Overrides <see cref="object.ToString"/>.
        /// </summary>
        /// <returns>A string describing the item.</returns>
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