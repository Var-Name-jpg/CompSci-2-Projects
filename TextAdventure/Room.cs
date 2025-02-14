namespace TextAdventure
{
    public class Room
    {
        public bool IsWall { get; set; }
        public object? ThingInRoom { get; set; }
        public string RoomColor { get; set; }

        /// <summary>
        /// Creates an instance of Room
        /// </summary>
        /// <param name="isWall">Is it a wall or not?</param>
        /// <param name="roomColor">For the emojis</param>
        /// <param name="thingInRoom">Object in the room</param>
        public Room(bool isWall, string roomColor, object? thingInRoom = null)
        {
            IsWall = isWall;
            RoomColor = roomColor;
            ThingInRoom = thingInRoom;
        }
    }
}