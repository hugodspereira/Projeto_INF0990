namespace jewelproject;

public class Green : Jewel
{
    private const string V = "JG";

    public Green(int x, int y)
    {
        symbol = V;
        value = 50;
        this.x = x;
        this.y = y;
    }
}
