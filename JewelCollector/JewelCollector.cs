namespace jewelproject;
/// <summary>
/// Classe onde o jogo é construído.
/// </summary>
public class JewelCollector
{
    static void Main()
    {
        Map mapa = new Map();
        mapa.addJewell(new Red(1,9));
        mapa.addJewell(new Red(8,8));
        mapa.addJewell(new Green(9,1));
        mapa.addJewell(new Green(7,6));
        mapa.addJewell(new Blue(3,4));
        mapa.addJewell(new Blue(2,1));
        mapa.addObstacle(new Water(5,0));
        mapa.addObstacle(new Water(5,1));
        mapa.addObstacle(new Water(5,2));
        mapa.addObstacle(new Water(5,3));
        mapa.addObstacle(new Water(5,4));
        mapa.addObstacle(new Water(5,5));
        mapa.addObstacle(new Water(5,6));
        mapa.addObstacle(new Tree(5,9));
        mapa.addObstacle(new Tree(3,9));
        mapa.addObstacle(new Tree(8,3));
        mapa.addObstacle(new Tree(2,5));
        mapa.addObstacle(new Tree(1,4));
        Robot robo = new Robot(0,0);
        mapa.addRobot(robo);
        mapa.PrintMap();


        bool running = true;
        
        do {
            Console.WriteLine("Enter the command: ");
            string command = Console.ReadLine();
  
            if (command.Equals("quit")) {
                running = false;
            } else if (command.Equals("w")) {
                mapa.moveRobotUp(robo);
                mapa.PrintMap();
                robo.PrintPoints();
            } else if (command.Equals("a")) {
                mapa.moveRobotLeft(robo);
                mapa.PrintMap();
                robo.PrintPoints();          
            } else if (command.Equals("s")) {
                mapa.moveRobotDown(robo);
                mapa.PrintMap();
                robo.PrintPoints();
            } else if (command.Equals("d")) {
                mapa.moveRobotRight(robo);
                mapa.PrintMap();
                robo.PrintPoints();
            } else if (command.Equals("g")) {
                mapa.findJewel(robo);
                mapa.PrintMap();
                robo.PrintPoints();
            }
            if(running){
                running = robo.checkEnergy();
            }
            mapa.novaFase(robo);
        } while (running);
    }

}
