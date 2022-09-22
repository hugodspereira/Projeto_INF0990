namespace jewelproject;

public class Blue: Jewel
{
    private const string V = "JB";

    public Blue(int x, int y)
    {
        symbol = V;
        value = 10;
        this.x = x;
        this.y = y;
    }
}
