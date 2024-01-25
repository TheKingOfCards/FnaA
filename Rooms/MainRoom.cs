public class MainRoom : Room
{
    public MainRoom()
    {
        adjacentRooms.Add("Hallway");
        adjacentRooms.Add("GroupRoom");
        name = "MainRoom";
    }
}