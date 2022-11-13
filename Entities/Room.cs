namespace ClassRoomApi.Entities;

public class Room
{
    public int Id        { get; set; }
    public string Name   { get; set; }
    public int AdminId   { get; set; }
    public int TeacherId { get; set; }
}