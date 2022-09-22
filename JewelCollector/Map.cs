namespace jewelproject;

public class Map
{
    public MapObject[,] map = new MapObject[10,10];
    List<Jewel> jewels = new List<Jewel>{};
    List<Obstacle> obstacles = new List<Obstacle>{};
    Robot? robot;
    

    public Map(){
        for (int i = 0; i < map.GetLength(0); i++) {
            for (int j = 0; j < map.GetLength(1); j++) {
                map[i, j] = new MapObject();
            }
        }
    }
    
    public void PrintMap() {
        for (int i = 0; i < map.GetLength(0); i++) {
            for (int j = 0; j < map.GetLength(1); j++) {
                Console.Write(map[i, j].symbol + " ");
            }
            Console.Write("\n");
        }
    }

    public void addObstacle(Obstacle obstacle){
        this.obstacles.Add(obstacle);
        map[obstacle.x, obstacle.y] = obstacle;
    }

    public void addJewell(Jewel jewel){
        this.jewels.Add(jewel);
        map[jewel.x, jewel.y] = jewel;
    }

    public void addRobot(Robot robot){
        this.robot = robot;
        map[robot.x, robot.y] = robot;
    }

    public void moveRobotDown(){
        if (this.robot.y < map.GetLength(0)){
            robot.moveDown();
            map[robot.x,robot.y] = robot;
            map[robot.x, robot.yant] = new MapObject();

        }
    }

    public void moveRobotUp(){
        if (this.robot.y > 0){
            robot.moveUp();
            map[robot.x,robot.y] = robot;
            map[robot.x, robot.yant] = new MapObject();

        }
    }

    public void moveRobotLeft(){
        if (this.robot.x < map.GetLength(0)){
            robot.moveLeft();
            map[robot.x,robot.y] = robot;
            map[robot.xant, robot.y] = new MapObject();

        }
    }

    public void moveRobotRight(){
        if (this.robot.y < map.GetLength(0)){
            robot.moveRight();
            map[robot.x,robot.y] = robot;
            map[robot.xant, robot.y] = new MapObject();
        }else{
            Console.WriteLine("não pode andar");
        }
    }

    private void getJewel(){
        if (map[this.robot.x, this.robot.y].symbol.Equals("JR") ||
        map[this.robot.x, this.robot.y].symbol.Equals("JG") ||
        map[this.robot.x, this.robot.y].symbol.Equals("JB"))
        {
                       
        }        
    }
}
