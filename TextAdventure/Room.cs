namespace TextAdventure
{
    public class Room
    {
        public bool IsWall { get; set; }
        public object? ThingInRoom { get; set; }
        public string RoomColor { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="player"></param>
        public void CheckRoom(Player player)
        {
            switch (this.ThingInRoom)
            {
                case Weapon weapon:
                    Console.Clear();
                    weapon.PickUpItem(player);
                    this.ThingInRoom = null;
                    Console.ReadKey(true);
                    break;

                case Potion potion:
                    Console.Clear();
                    potion.AddEffect(player, "");
                    this.ThingInRoom = null;
                    Console.ReadKey(true);
                    break;

                case Enemy enemy:
                    Console.Clear();
                    player.FightLoop(enemy);
                    this.ThingInRoom = null;
                    Console.ReadKey(true);
                    break;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isWall"></param>
        /// <param name="roomColor"></param>
        /// <param name="thingInRoom"></param>
        public Room(bool isWall, string roomColor, object? thingInRoom = null)
        {
            IsWall = isWall;
            RoomColor = roomColor;
            ThingInRoom = thingInRoom;
        }
    }
}