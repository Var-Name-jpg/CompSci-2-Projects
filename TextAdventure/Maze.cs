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
        /// This creates an instance of Maze
        /// </summary>
        /// <param name="width">How many pixels long it is</param>
        /// <param name="height">How many pixels long it is</param>
        public Maze(int width, int height)
        {
            Width = width % 2 == 0 ? width + 1 : width;   // Ensure odd dimensions
            Height = height % 2 == 0 ? height + 1 : height;
            MazeArray = new Room[Height, Width];
            GenerateMaze();
        }

        /// <summary>
        /// This generates the entire maze using the algorithms
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
        /// Basic carving algorithm
        /// </summary>
        /// <param name="x">Starting X pos</param>
        /// <param name="y">Starting Y pos</param>
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
        /// Fills maze dynamically based on difficulty
        /// </summary>
        /// <param name="potionDict">Dictionary of all potions</param>
        /// <param name="weaponDict">Dictionary of all weapons</param>
        /// <param name="enemyDict">Dictionary of all enemies</param>
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
                                if (roll < 50) // 50% Potion
                                    MazeArray[i, j].ThingInRoom = potionDict.ElementAt(rand.Next(potionDict.Count));
                                else if (roll < 70) // 20% Weapon
                                    MazeArray[i, j].ThingInRoom = weaponDict.ElementAt(rand.Next(weaponDict.Count));
                                else if (roll < 80) // 10% Enemy
                                    MazeArray[i, j].ThingInRoom = enemyDict.ElementAt(rand.Next(enemyDict.Count));
                                else
                                    MazeArray[i, j].ThingInRoom = null; // 20% Empty
                                break;

                            case GameDifficulties.Normal:
                                if (roll < 35) // 35% Potion
                                    MazeArray[i, j].ThingInRoom = potionDict.ElementAt(rand.Next(potionDict.Count));
                                else if (roll < 55) // 20% Weapon
                                    MazeArray[i, j].ThingInRoom = weaponDict.ElementAt(rand.Next(weaponDict.Count));
                                else if (roll < 75) // 20% Enemy
                                    MazeArray[i, j].ThingInRoom = enemyDict.ElementAt(rand.Next(enemyDict.Count));
                                else
                                    MazeArray[i, j].ThingInRoom = null; // 25% Empty
                                break;

                            case GameDifficulties.Hard:
                                if (roll < 20) // 20% Potion
                                    MazeArray[i, j].ThingInRoom = potionDict.ElementAt(rand.Next(potionDict.Count));
                                else if (roll < 40) // 20% Weapon
                                    MazeArray[i, j].ThingInRoom = weaponDict.ElementAt(rand.Next(weaponDict.Count));
                                else if (roll < 70) // 30% Enemy
                                    MazeArray[i, j].ThingInRoom = enemyDict.ElementAt(rand.Next(enemyDict.Count));
                                else
                                    MazeArray[i, j].ThingInRoom = null; // 30% Empty
                                break;

                            case GameDifficulties.VeryHard:
                                if (roll < 10) // 10% Potion
                                    MazeArray[i, j].ThingInRoom = potionDict.ElementAt(rand.Next(potionDict.Count));
                                else if (roll < 30) // 20% Weapon
                                    MazeArray[i, j].ThingInRoom = weaponDict.ElementAt(rand.Next(weaponDict.Count));
                                else if (roll < 80) // 50% Enemy
                                    MazeArray[i, j].ThingInRoom = enemyDict.ElementAt(rand.Next(enemyDict.Count));
                                else
                                    MazeArray[i, j].ThingInRoom = null; // 20% Empty
                                break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="player"></param>
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
        /// Just prints the maze to the console
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
        /// Randomizes the "facing" direction of the carver
        /// </summary>
        /// <param name="array">The map</param>
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