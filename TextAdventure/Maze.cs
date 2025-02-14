namespace TextAdventure
{
    public class Maze
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public Room[,] MazeArray { get; private set; }
        private static readonly string Red_Square = "\U0001F7E5";   // Represents walls
        private static readonly string Blue_Square = "\U0001F7E6"; // Represents not walls
        private static readonly string Green_Square = "\U0001F7E9"; // Represents player pos

        public Enum difficulty { get; set; } = GameDifficulties.Normal;

        private Random rand = new Random();

        /// <summary>
        /// Creates an instance of maze
        /// </summary>
        /// <param name="width">Width of maze</param>
        /// <param name="height">Height of maze</param>
        public Maze(int width, int height)
        {
            Width = width % 2 == 0 ? width + 1 : width;   // Ensure odd dimensions
            Height = height % 2 == 0 ? height + 1 : height;
            MazeArray = new Room[Height, Width];
            GenerateMaze();
        }

        /// <summary>
        /// Fills the maze with walls to start
        /// </summary>
        public void GenerateMaze()
        {
            // Initialize the maze with walls
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    MazeArray[y, x] = new Room(true, string.Empty);
                    MazeArray[y, x].RoomColor = Red_Square; 
                }
            }

            // Start the maze generation from a random odd position
            int startX = rand.Next(1, Width - 1);
            int startY = rand.Next(1, Height - 1);
            if (startX % 2 == 0) startX++;
            if (startY % 2 == 0) startY++;

            MazeArray[startY, startX].RoomColor = Blue_Square;
            MazeArray[startY, startX].IsWall = false;
            CarveMaze(startX, startY);
        }

        /// <summary>
        /// Recursively carves out a maze using the recursive backtracking algorithm.
        /// </summary>
        /// <param name="x">The x-coordinate of the current cell.</param>
        /// <param name="y">The y-coordinate of the current cell.</param>
        /// <remarks>
        /// This method shuffles the possible movement directions and attempts to carve 
        /// a passage in a random order. It ensures that the maze remains within bounds 
        /// and only carves into unvisited cells, represented by <c>Red_Square</c>. 
        /// When a valid move is found, it updates the maze grid, marking cells as paths 
        /// (changing their color to <c>Blue_Square</c>) and setting <c>IsWall</c> to false.
        /// The function then recursively calls itself to continue the carving process.
        /// </remarks>
        public void CarveMaze(int x, int y)
        {
            int[][] directions = { new[] { 0, -2 }, new[] { 2, 0 }, new[] { 0, 2 }, new[] { -2, 0 } };
            Shuffle(directions);

            foreach (var dir in directions)
            {
                int nx = x + dir[0], ny = y + dir[1];

                if (nx > 0 && ny > 0 && nx < Width - 1 && ny < Height - 1 && MazeArray[ny, nx].RoomColor == Red_Square)
                {
                    // Carve a passage
                    MazeArray[ny, nx].RoomColor = Blue_Square;
                    MazeArray[y + dir[1] / 2, x + dir[0] / 2].RoomColor = Blue_Square;
                    MazeArray[ny, nx].IsWall = false;
                    MazeArray[y + dir[1] / 2, x + dir[0] / 2].IsWall = false;
                    CarveMaze(nx, ny);
                }
            }
        }

        /// <summary>
        /// Populates the maze with potions, weapons, and enemies based on the game's difficulty level.
        /// </summary>
        /// <param name="potionDict">A dictionary of available potions, where the key is the potion's name and the value is the potion object.</param>
        /// <param name="weaponDict">A dictionary of available weapons, where the key is the weapon's name and the value is the weapon object.</param>
        /// <param name="enemyDict">A dictionary of available enemies, where the key is the enemy's name and the value is the enemy object.</param>
        /// <remarks>
        /// This method iterates through each cell in the maze and randomly assigns an item, weapon, or enemy to walkable (non-wall) tiles.
        /// The probability of each type of item appearing depends on the current game difficulty:
        /// <list type="bullet">
        /// <item><c>Easy</c>: Higher chance of potions, moderate chance of weapons, fewer enemies.</item>
        /// <item><c>Normal</c>: Balanced distribution of potions, weapons, and enemies.</item>
        /// <item><c>Hard</c>: Fewer potions, more weapons and enemies.</item>
        /// <item><c>VeryHard</c>: Very few potions, higher enemy presence.</item>
        /// </list>
        /// The method uses a random roll (0-99) to determine what, if anything, is placed in each room.
        /// </remarks>
        public void FillMaze(Dictionary<string, Potion> potionDict, Dictionary<string, Weapon> weaponDict, Dictionary<string, Enemy> enemyDict)
        {
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    if (!MazeArray[i, j].IsWall) // Only fill walkable tiles
                    {
                        int roll = rand.Next(100); // Roll between 0 and 99

                        switch (difficulty)
                        {
                            case GameDifficulties.Easy:
                                if (roll < 50)
                                    MazeArray[i, j].ThingInRoom = potionDict.ElementAt(rand.Next(potionDict.Count)).Value;
                                else if (roll < 70)
                                    MazeArray[i, j].ThingInRoom = weaponDict.ElementAt(rand.Next(weaponDict.Count)).Value;
                                else if (roll < 80)
                                    MazeArray[i, j].ThingInRoom = enemyDict.ElementAt(rand.Next(enemyDict.Count)).Value;
                                break;

                            case GameDifficulties.Normal:
                                if (roll < 35)
                                    MazeArray[i, j].ThingInRoom = potionDict.ElementAt(rand.Next(potionDict.Count)).Value;
                                else if (roll < 55)
                                    MazeArray[i, j].ThingInRoom = weaponDict.ElementAt(rand.Next(weaponDict.Count)).Value;
                                else if (roll < 75)
                                    MazeArray[i, j].ThingInRoom = enemyDict.ElementAt(rand.Next(enemyDict.Count)).Value;
                                break;

                            case GameDifficulties.Hard:
                                if (roll < 20)
                                    MazeArray[i, j].ThingInRoom = potionDict.ElementAt(rand.Next(potionDict.Count)).Value;
                                else if (roll < 40)
                                    MazeArray[i, j].ThingInRoom = weaponDict.ElementAt(rand.Next(weaponDict.Count)).Value;
                                else if (roll < 70)
                                    MazeArray[i, j].ThingInRoom = enemyDict.ElementAt(rand.Next(enemyDict.Count)).Value;
                                break;

                            case GameDifficulties.VeryHard:
                                if (roll < 10)
                                    MazeArray[i, j].ThingInRoom = potionDict.ElementAt(rand.Next(potionDict.Count)).Value;
                                else if (roll < 30)
                                    MazeArray[i, j].ThingInRoom = weaponDict.ElementAt(rand.Next(weaponDict.Count)).Value;
                                else if (roll < 80)
                                    MazeArray[i, j].ThingInRoom = enemyDict.ElementAt(rand.Next(enemyDict.Count)).Value;
                                break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Updates the visual representation of the maze, marking the player's position and setting room colors accordingly.
        /// </summary>
        /// <param name="player">The player object representing the current position in the maze.</param>
        /// <remarks>
        /// This method places the player in their current location within the maze and updates the room colors based on their state:
        /// <list type="bullet">
        /// <item>Walls are colored <c>Red_Square</c>.</item>
        /// <item>Walkable spaces are colored <c>Blue_Square</c>.</item>
        /// <item>The player's position is highlighted with <c>Green_Square</c>.</item>
        /// </list>
        /// It ensures that the map reflects the latest player movement while preserving the integrity of walls and pathways.
        /// </remarks>
        public void UpdateMap(Player player)
        {
            MazeArray[player.CurrentY, player.CurrentX].ThingInRoom = player;

            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    if (MazeArray[i, j].ThingInRoom != player)
                    {
                        if (MazeArray[i, j].IsWall == true)
                        {
                            MazeArray[i, j].RoomColor = Red_Square;
                        }
                        else
                        {
                            MazeArray[i, j].RoomColor = Blue_Square;
                        }
                    }
                    else
                    {
                        MazeArray[i, j].RoomColor = Green_Square;
                    }
                }
            }
        }

        /// <summary>
        /// ...prints the maze to console
        /// </summary>
        public void PrintMaze()
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    Console.Write(MazeArray[y, x].RoomColor);
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Randomly shuffles the elements of a two-dimensional array using the Fisher-Yates shuffle algorithm.
        /// </summary>
        /// <param name="array">A jagged array of integer pairs to be shuffled in place.</param>
        /// <remarks>
        /// This method iterates through the array in reverse order, swapping each element with a randomly selected earlier element.
        /// It ensures that the order of the elements is randomized, which is useful for procedural generation, such as maze carving.
        /// </remarks>
        public void Shuffle(int[][] array)
        {
            for (int i = array.Length - 1; i > 0; i--)
            {
                int j = rand.Next(i + 1);
                var temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
        }
    }
}