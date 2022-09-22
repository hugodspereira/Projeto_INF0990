namespace jewelproject;

public class MapObject
{
    public string symbol {get; protected set;}= "--";
    public int x,y;

    public MapObject(){
        this.x = 0;
        this.y = 0;
    }
}
