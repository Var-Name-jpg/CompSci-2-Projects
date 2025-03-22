namespace GameWebsite.Data;
using GameWebsite.Models;

/// <summary>
/// Contains game-related data such as weapons, players, potions, and enemies.
/// Provides static dictionaries to store and organize the game entities.
/// </summary>
public static class GameData
{
    /// <summary>
    /// Dictionary of available weapons in the game, categorized by name.
    /// </summary>
    public static Dictionary<string, Weapon> weapons = new()
        {
            { "Fists", new Weapon("Fists", "Your Hands", 5) }, // Unarmed, starting weapon

            // Early-game weapons
            { "Wooden Sword", new Weapon("Wooden Sword", "A sword made out of wood", 10) },
            { "Stone Sword", new Weapon("Stone Sword", "A sword made out of stone", 15) },
            { "Iron Dagger", new Weapon("Iron Dagger", "A sharp but small dagger", 12) },
            { "Club", new Weapon("Club", "A crude but heavy club", 14) },

            // Mid-game weapons
            { "Steel Sword", new Weapon("Steel Sword", "A well-forged steel blade", 20) },
            { "Battle Axe", new Weapon("Battle Axe", "A heavy axe made for combat", 25) },
            { "Spear", new Weapon("Spear", "A long, sharp spear for keeping enemies at bay", 22) },
            { "Magic Staff", new Weapon("Magic Staff", "A staff imbued with dark energy", 18) }, // For countering magic enemies
            { "Silver Blade", new Weapon("Silver Blade", "A sword effective against supernatural foes", 24) }, // Werewolf/Vampire counter

            // Late-game weapons
            { "Flaming Greatsword", new Weapon("Flaming Greatsword", "A massive sword engulfed in flames", 30) },
            { "Thunder Hammer", new Weapon("Thunder Hammer", "A war hammer crackling with lightning", 35) },
            { "Demon Slayer", new Weapon("Demon Slayer", "A cursed blade forged to slay hellish creatures", 40) },
            { "Dark Scythe", new Weapon("Dark Scythe", "A soul-draining scythe wielded by dark forces", 38) },

            // End-game / Boss weapons
            { "Dragon Slayer", new Weapon("Dragon Slayer", "A legendary sword capable of felling dragons", 50) },
            { "Celestial Spear", new Weapon("Celestial Spear", "A divine weapon used by the gods", 55) },
            { "Hydra’s Fang", new Weapon("Hydra’s Fang", "A poisoned dagger made from a hydra’s fang", 45) },
            { "Lich Bane", new Weapon("Lich Bane", "A holy weapon infused with anti-magic properties", 48) }
        };

    /// <summary>
    /// Dictionary of players in the game, categorized by name.
    /// </summary>
    public static Dictionary<string, Player> players = new()
    {
        { "Player", new Player(50, weapons["Fists"]) }
    };

    /// <summary>
    /// Dictionary of potions in the game, categorized by name.
    /// </summary>
    public static Dictionary<string, Potion> potions = new()
        {
            { "Healing Potion", new Potion("Healing Potion", "This potion heals you", PotionEffects.Healing) },
            { "Damage Potion", new Potion("Damage Potion", "This potion increases your damage", PotionEffects.IncreaseAttack) },
            { "Health Potion", new Potion("Health Potion", "This potion increases your max health", PotionEffects.IncreaseHealth) }
        };

    /// <summary>
    /// Dictionary of enemies in the game, categorized by name.
    /// </summary>
    public static Dictionary<string, Enemy> enemies = new()
        {
            { "Goblin", new Enemy("Goblin", 25, 4) },       // Weak enemy
            { "Giant Spider", new Enemy("Giant Spider", 30, 5) }, // Slightly stronger weak enemy
            { "Skeleton", new Enemy("Skeleton", 40, 8) },   // Standard enemy
            { "Orc", new Enemy("Orc", 55, 10) },           // Standard enemy
            { "Troll", new Enemy("Troll", 80, 12) },       // Stronger than the player
            { "Vampire", new Enemy("Vampire", 70, 14) },   // Balanced but tough
            { "Dark Wizard", new Enemy("Dark Wizard", 60, 15) }, // Magic-based enemy
            { "Werewolf", new Enemy("Werewolf", 75, 12) }, // Fast but not too strong
            { "Dragon", new Enemy("Dragon", 150, 25) },    // Boss-level
            { "Lich", new Enemy("Lich", 90, 18) },        // Dangerous spellcaster
            { "Demon", new Enemy("Demon", 110, 20) },     // Mini-boss
            { "Zombie", new Enemy("Zombie", 35, 6) },     // Weak but annoying
            { "Wraith", new Enemy("Wraith", 45, 9) },     // Ghostly but dangerous
            { "Gargoyle", new Enemy("Gargoyle", 85, 15) }, // Tough stone enemy
            { "Hydra", new Enemy("Hydra", 180, 30) }      // Ultimate boss
        };
}
