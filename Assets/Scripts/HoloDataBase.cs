using SQLite4Unity3d;

[Table("mytable")]
public class HoloDataBase
{
    [PrimaryKey, AutoIncrement]
    public int HoloId { get; set;}
    public bool IsSelected { get; set;}
    public string HoloName { get; set;}
    public string HoloZone { get; set;}
}