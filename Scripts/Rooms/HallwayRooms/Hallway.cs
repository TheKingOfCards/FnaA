public class Hallway : Room
{
    public Hallway()
    {
        adjacentRooms.Add("ToiletL");
        adjacentRooms.Add("ToiletR");
        adjacentRooms.Add("BeforeOfficeL");
        adjacentRooms.Add("BeforeOfficeR");
        adjacentRooms.Add("MainRoom");
    }
}