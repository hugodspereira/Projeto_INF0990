namespace jewelproject;
public class Robot : MapObject
{
    private const string V = "ME";
    public int xant, yant; 
    List<Jewel> bag = new List<Jewel>{};
    public int value = 0;

    public Robot(int x, int y)
    {
        symbol = V;
        this.x = x;
        this.y = y;
    }

    public void moveDown(){

        yant = this.y;
        this.y = y++;
    }
    public void moveUp(){
        yant = this.y;
        this.y = y--;
    }

    public void moveLeft(){
        xant = this.x;
        this.x = x--;
    }

    public void moveRight(){
        xant = this.x;
        this.x = x++;
    }

    public void addJewell(Jewel jewel){
        bag.Add(jewel);
    }

    public int countJewel(){
        return bag.Count();
    }

    private int totalValue(){
        this.value = 0;
        foreach (Jewel jewel in bag)
        {
            this.value = this.value + jewel.value;
        }
        return this.value;
    }







}
