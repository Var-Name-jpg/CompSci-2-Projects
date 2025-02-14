using System.Xml.Linq;

namespace TextAdventure
{
    class Program
    {
        const int width = 21;  // Must be odd
        const int height = 21; // Must be odd

        static Maze adventureMaze = new Maze(width, height);

        static Dictionary<string, Weapon> weapons = new()
        {
            { "None", new Weapon("Fists", "Your Hands", 5) }, // Unarmed, starting weapon

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

        static Dictionary<string, Potion> potions = new()
        {
            { "Healing Potion", new Potion("Healing Potions", "This potion heals you", PotionEffects.Healing) },
            { "Damage Potion", new Potion("Damage Potion", "This potion increses your damage", PotionEffects.IncreaseAttack) },
            { "Health Potion", new Potion("Health Potion", "This potion increases your max health", PotionEffects.IncreaseHealth) }
        };

        static Dictionary<string, Enemy> enemies = new()
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

        /// <summary>
        /// Moves the player
        /// </summary>
        /// <param name="x">Direction X</param>
        /// <param name="y">Direction Y</param>
        /// <param name="map">Room array</param>
        /// <param name="player">The player</param>
        static void Move(int x, int y, Maze map, Player player)
        {
            map.MazeArray[player.CurrentY, player.CurrentX].ThingInRoom = null;

            CheckRoom(player, map, x, y);
            player.CurrentX = x; player.CurrentY = y;
        }

        /// <summary>
        /// Checks if the player can move to a tile
        /// </summary>
        /// <param name="map">Array of rooms</param>
        /// <param name="player">The player</param>
        /// <param name="testX">X Pos being tested</param>
        /// <param name="testY">Y Pos being tested</param>
        static void MoveCheck(Maze map, Player player, int testX, int testY)
        {
            if (!map.MazeArray[testY, testX].IsWall)
            {
                Move(testX, testY, map, player);
            }
        }

        /// <summary>
        /// Main game loop
        /// </summary>
        /// <param name="map">Array of rooms</param>
        /// <param name="player">The player</param>
        static void GameLoop(Maze map, Player player)
        {
            Console.Clear();

            map.UpdateMap(player);
            map.PrintMaze();
            Console.WriteLine(player.CurrentWeapon.ToString());
            Console.WriteLine("Current Position: " + player.CurrentY + ", " + player.CurrentX);
            Console.WriteLine($"Health: {player.Health}");

            switch (Char.ToLower(Console.ReadKey(true).KeyChar))
            {
                case 'w':
                    MoveCheck(map, player, player.CurrentX, player.CurrentY - 1);
                    break;

                case 'a':
                    MoveCheck(map, player, player.CurrentX - 1, player.CurrentY);
                    break;

                case 's':
                    MoveCheck(map, player, player.CurrentX, player.CurrentY + 1);
                    break;

                case 'd':
                    MoveCheck(map, player, player.CurrentX + 1, player.CurrentY);
                    break;
            }

        }

        /// <summary>
        /// Chooses the difficulty of the game
        /// </summary>
        static void ChooseDifficulty()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("1. Easy\n2. Normal (Default)\n3. Hard\n4. Very Hard");

                    string input = Console.ReadLine();
                    switch (input)
                    {
                        case "1":
                            adventureMaze.difficulty = GameDifficulties.Easy;
                            break;

                        case "2":
                            adventureMaze.difficulty = GameDifficulties.Normal;
                            break;

                        case "3":
                            adventureMaze.difficulty = GameDifficulties.Hard;
                            break;

                        case "4":
                            adventureMaze.difficulty = GameDifficulties.VeryHard;
                            break;

                        default:
                            throw new Exception("Invalid Input!");
                    }

                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        /// <summary>
        /// Runs everything neccessary at the start of the game
        /// </summary>
        /// <param name="player">The player</param>
        static void StartGame(Player player)
        {
            Console.WriteLine($"Hello {player.Name}! Welcome to purgatory.\n");

            while (true)
            {
                Console.WriteLine("1. Start Game\n2. Read Instructions");

                string response = Console.ReadLine().ToLower();

                if (!string.IsNullOrWhiteSpace(response))
                {
                    if (response == "1")
                    {
                        Console.Clear();
                        ChooseDifficulty();
                        break;
                    }
                    else if (response == "2")
                    {
                        Console.Clear();
                        Console.WriteLine(instructions);
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey(true);
                        ChooseDifficulty();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input! Try again\n");
                    }
                }
                else
                {
                    Console.WriteLine("You can't just leave it blank man...\n");
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey(true);
            }
        }

        /// <summary>
        /// Allows the player and an enemy to interact
        /// </summary>
        /// <param name="player">The player</param>
        /// <param name="enemy">Instance of enemy the player is fighting</param>
        static void FightLoop(Player player, Enemy enemy)
        {
            Console.WriteLine($"{player.Name} enters combat with {enemy.Name}!");

            while (player.Health > 0 && enemy.Health > 0)
            {
                // Player attacks enemy
                player.Fight(enemy);

                if (enemy.Health <= 0)
                {
                    Console.WriteLine($"{enemy.Name} has been defeated!");
                    break;
                }

                // Enemy fights back
                enemy.Fight(player);

                if (player.Health <= 0)
                {
                    Console.WriteLine($"YOU DIED.");
                    Console.ReadKey(true);
                    Environment.Exit(0);
                    break;
                }
            }
        }

        /// <summary>
        /// Checks a room for items and applies them to the player
        /// </summary>
        /// <param name="player">The player</param>
        /// <param name="map">Array of rooms</param>
        /// <param name="x">X Pos</param>
        /// <param name="y">Y Pos</param>
        static void CheckRoom(Player player, Maze map, int x, int y)
        {
            switch (map.MazeArray[y, x].ThingInRoom)
            {
                case Weapon weapon:
                    Console.Clear();
                    Console.WriteLine(weapon.PickUpItem(player));
                    Console.WriteLine("Press Any Key To Continue...");
                    Console.ReadKey(true);
                    break;

                case Potion potion:
                    Console.Clear();
                    Console.WriteLine(potion.AddEffect(player, string.Empty));
                    Console.WriteLine("Press Any Key To Continue...");
                    Console.ReadKey(true);
                    break;

                case Enemy enemy:
                    Console.Clear();
                    FightLoop(player, enemy);
                    Console.WriteLine("Press Any Key To Continue...");
                    Console.ReadKey(true);
                    break;
            }
        }

        /// <summary>
        /// Instruction string
        /// </summary>
        static string instructions = "INSTRUCTIONS:\n" +
            "WASD to move\n" +
            "Weapons of higher strength than your current weapon will automatically equip\n" +
            "Potions encountered will automatically be used\n" +
            "You regain health after each encounter\n" +
            "Try and get to the opposite corner of the maze without dying!";

        
        /// <summary>
        /// Main Method Baby
        /// </summary>
        public static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.Write("Please enter your name: ");
            Player player = new Player(50, 50, 0, weapons["None"], 1, 1);

            string name = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(name))
            {
                player.Name = name;
            }

            StartGame(player);

            adventureMaze.GenerateMaze();
            adventureMaze.FillMaze(potions, weapons, enemies);

            while (true)
            {
                player.Update();
                GameLoop(adventureMaze, player);

                if (player.CurrentX == adventureMaze.Width - 2 && player.CurrentY == adventureMaze.Height - 2)
                {
                    Console.Clear();
                    Console.WriteLine("YOU WON! CONGRATULATIONS!!");
                    Console.ReadKey(true);
                    Environment.Exit(0);
                }
            }
        }

    }
}
