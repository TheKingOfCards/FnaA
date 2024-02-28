public class BeforeOfficeLeft : Room
{
    public BeforeOfficeLeft()
    {
        id = "BeforeOfficeRight";
        path = "Right";
        
        adjacentRooms.Add("Hallway");
        adjacentRooms.Add("OfficeL");
    }
}