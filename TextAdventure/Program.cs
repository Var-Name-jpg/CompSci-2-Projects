namespace TextAdventure
{
    class Program
    {
        const int width = 21;  // Must be odd
        const int height = 21; // Must be odd

        static Maze adventureMaze = new Maze(width, height);

        static Dictionary<string, Weapon> weapons = new()
        {
            { "None", new Weapon("Fists", "Your Hands", 5)},
            { "Wooden Sword", new Weapon("Wooden Sword", "A sword made out of wood", 10) },
            { "Stone Sword", new Weapon("Stone Sword", "A sword made out of stone", 15) }
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
        /// 
        /// </summary>
        /// <param name="player"></param>
        /// <param name="testX"></param>
        /// <param name="testY"></param>
        static void MoveCheck(Room[,] map, Player player, int testX, int testY)
        {
            if (!map[testY, testX].IsWall)
            {
                player.Move(testX, testY, map);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="map"></param>
        /// <param name="player"></param>
        static void GameLoop(Maze map, Player player)
        {
            Console.Clear();

            map.UpdateMap(player);
            map.PrintMaze();
            Console.WriteLine(player.CurrentWeapon.ToString());

            switch (Char.ToLower(Console.ReadKey(true).KeyChar))
            {
                case 'w':
                    MoveCheck(map.MazeArray, player, player.CurrentX, player.CurrentY - 1);
                    break;

                case 'a':
                    MoveCheck(map.MazeArray, player, player.CurrentX - 1, player.CurrentY);
                    break;

                case 's':
                    MoveCheck(map.MazeArray, player, player.CurrentX, player.CurrentY + 1);
                    break;

                case 'd':
                    MoveCheck(map.MazeArray, player, player.CurrentX + 1, player.CurrentY);
                    break;
            }

        }

        /// <summary>
        /// 
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
        /// 
        /// </summary>
        /// <param name="player"></param>
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
        /// Instruction string
        /// </summary>
        static string instructions = "INSTRUCTIONS:\n" +
            "WASD to move\n" +
            "Weapons of higher strength than your current weapon will automatically equip\n" +
            "Potions encountered will automatically be used\n" +
            "Try and get to the end of the maze without dying!";

        /// <summary>
        /// Main Method
        /// This deseves five big booms:
        /// BOOM! BOOM! BOOM! BOOM! BOOM!
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
                GameLoop(adventureMaze, player);
            }
        }

    }
}
