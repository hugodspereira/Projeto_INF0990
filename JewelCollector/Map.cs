namespace jewelproject;
/// <summary>
/// Classe Map que gera o mapa que o jogo acontece, bem como distribui as joias e obstáculos.
/// </summary>
public class Map
{
    private int ladoDoMapa = 10;
    public MapObject[,] map = new MapObject[10,10];
    private MapObject objetoDaPosicao= new MapObject();
    private MapObject objetoAnterior = new MapObject();

    /// <summary>
    /// Construtor do Mapa do Jogo.
    /// </summary>
    public Map(){
        for (int i = 0; i < map.GetLength(0); i++) {
            for (int j = 0; j < map.GetLength(1); j++) {
                map[i, j] = new MapObject();
            }
        }
    }
    
    /// <summary>
    /// Método que instância MapObject no mapa do jogo.
    /// </summary>
    private void criaMapa(){
        for (int i = 0; i < map.GetLength(0); i++) {
            for (int j = 0; j < map.GetLength(1); j++) {
                map[i, j] = new MapObject();
            }
        }
    }
    
    /// <summary>
    /// Imprime mapa na tela.
    /// </summary>
    public void PrintMap() {
        for (int i = 0; i < map.GetLength(0); i++) {
            for (int j = 0; j < map.GetLength(1); j++) {
                Console.Write(map[i, j].symbol + " ");
            }
            Console.Write("\n");
        }
    }

    /// <summary>
    /// Adiciona objeto do tipo Obstacle no mapa.
    /// </summary>
    /// <param name="obstacle"> Objeto do tipo Obstacle instanciado.</param>
    public void addObstacle(Obstacle obstacle){
        map[obstacle.x, obstacle.y] = obstacle;
    }

    /// <summary>
    /// Objeto do tipo Jewel a ser adicionado no mapa.
    /// </summary>
    /// <param name="jewel"> Objeto do tipo Jewel</param>
    public void addJewell(Jewel jewel){
        map[jewel.x, jewel.y] = jewel;
    }

    /// <summary>
    /// Adiciona robô no mapa.
    /// </summary>
    /// <param name="robot">Objeto do tipo robô adicionado no mapa do jogo.</param>
    public void addRobot(Robot robot){
        map[robot.x, robot.y] = robot;
    }

    /// <summary>
    /// Método para mover o robô para baixo.
    /// </summary>
    /// <param name="robot">Objeto do tipo Robot a ser movido.</param>
    public void moveRobotDown(Robot robot){
        try
        {
            if(map[robot.x+1, robot.y].symbol == "--"){
               robot.moveDown();
               objetoAnterior = objetoDaPosicao;
               objetoDaPosicao = map[robot.x,robot.y];
               map[robot.x,robot.y] = robot;
               map[robot.xant, robot.y] = objetoAnterior;
               radiate(robot);
            } else if(map[robot.x+1, robot.y].symbol == "!!"){
                Radioactive radioactive= new Radioactive();
                robot.moveDown();
                robot.lostEnergy(radioactive.radiacao*3);
                map[robot.x,robot.y] = robot;
                map[robot.xant, robot.y] = new MapObject();                
            }
        }
        catch (System.Exception)
        {
            Console.WriteLine("Robô não pode descer");
        }
    }

    /// <summary>
    /// Método para mover o robô para cima.
    /// </summary>
    /// <param name="robot">Objeto do tipo Robot a ser movido.</param>
    public void moveRobotUp(Robot robot){
        try
        {
            if(map[robot.x-1, robot.y].symbol == "--"){
                robot.moveUp();
                objetoAnterior = objetoDaPosicao;
                objetoDaPosicao = map[robot.x,robot.y];
                map[robot.x,robot.y] = robot;
                map[robot.xant, robot.y] = objetoAnterior;
                radiate(robot);
            } else if(map[robot.x-1, robot.y].symbol == "!!"){
                Radioactive radioactive= new Radioactive();
                robot.moveUp();
                robot.lostEnergy(radioactive.radiacao*3);
                map[robot.x,robot.y] = robot;
                map[robot.xant, robot.y] = new MapObject();                
            }
        }
        catch (System.Exception)
        {
            Console.WriteLine("Robô não pode subir");
        }
        
    }

    /// <summary>
    /// Método para mover o robô para esquerda.
    /// </summary>
    /// <param name="robot">Objeto do tipo Robot a ser movido.</param>
    public void moveRobotLeft(Robot robot){
        try
        {
            if(map[robot.x, robot.y-1].symbol == "--"){
                robot.moveLeft();
                objetoAnterior = objetoDaPosicao;
                objetoDaPosicao = map[robot.x,robot.y];
                map[robot.x,robot.y] = robot;
                map[robot.x, robot.yant] = objetoAnterior;
                radiate(robot);
            } else if(map[robot.x, robot.y-1].symbol == "!!"){
                Radioactive radioactive= new Radioactive();
                robot.moveLeft();
                robot.lostEnergy(radioactive.radiacao*3);
                map[robot.x,robot.y] = robot;
                map[robot.x, robot.yant] = new MapObject();                
            }
        }
        catch (System.Exception)
        {
            Console.WriteLine("Robô não pode ir para a esquerda.");
        }
    }

    /// <summary>
    /// Método para mover o robô para direita.
    /// </summary>
    /// <param name="robot">Objeto do tipo Robot a ser movido.</param>
    public void moveRobotRight(Robot robot){
        try
        {
            if(map[robot.x, robot.y+1].symbol == "--"){
                robot.moveRight();
                objetoAnterior = objetoDaPosicao;
                objetoDaPosicao = map[robot.x,robot.y];
                map[robot.x,robot.y] = robot;
                map[robot.x, robot.yant] = objetoAnterior;
                radiate(robot);
            } else if(map[robot.x, robot.y+1].symbol == "!!"){
                Radioactive radioactive= new Radioactive();
                robot.moveRight();
                robot.lostEnergy(radioactive.radiacao*3);
                map[robot.x,robot.y] = robot;
                map[robot.x, robot.yant] = new MapObject();                
            }
        }
        catch (System.Exception)
        {
            Console.WriteLine("Robô não pode ir para a direita.");
        }

    }

    /// <summary>
    /// Método que tira jóia do mapa e passa para o robô.
    /// </summary>
    /// <param name="robot"> Objeto do robô que receberá a joia.</param>
    public void findJewel(Robot robot){
        int[] linha = {-1,0,1};
        int[] coluna = {-1,0,1};
        if(robot.x == 0){
            linha = linha.Where((source, index) => index != 0).ToArray();
        }
        if (robot.y == 0){
            coluna = coluna.Where((source, index) => index != 0).ToArray();
        }

        if (robot.x == map.GetLength(0)-1){
            linha = linha.Where((source, index) => index != 2).ToArray();            
        }

        if (robot.y == map.GetLength(1)-1){
            coluna = coluna.Where((source, index) => index != 2).ToArray();
        }

        foreach(int i in linha)
        {
            foreach (int j in coluna)
            {
                if(map[robot.x+i, robot.y+j] is Red){
                    robot.addJewell(new Red(0,0));
                    map[robot.x+i, robot.y+j] = new MapObject();
                }else if (map[robot.x+i, robot.y+j] is Blue){
                    robot.addJewell(new Blue(0,0));
                    robot.rechargeEnergy(new Blue(0,0).giveEnergy());
                    map[robot.x+i, robot.y+j] = new MapObject();
                }else if (map[robot.x+i, robot.y+j] is Green){
                    robot.addJewell(new Green(0,0));
                    map[robot.x+i, robot.y+j] = new MapObject();
                }else if (map[robot.x+i, robot.y+j] is Tree){
                    robot.rechargeEnergy(new Tree(0,0).giveEnergy());
                }
            }                
        }
    }

    /// <summary>
    /// Radiação emitida que tira energia do robô.
    /// </summary>
    /// <param name="robot"> Objeto do tipo robô.</param>
    private void radiate(Robot robot){
        int[] linha = {-1,0,1};
        int[] coluna = {-1,0,1};
        if(robot.x == 0){
            linha = linha.Where((source, index) => index != 0).ToArray();
        }
        if (robot.y == 0){
            coluna = coluna.Where((source, index) => index != 0).ToArray();
        }

        if (robot.x == map.GetLength(0)-1){
            linha = linha.Where((source, index) => index != 2).ToArray();            
        }

        if (robot.y == map.GetLength(1)-1){
            coluna = coluna.Where((source, index) => index != 2).ToArray();
        }
        
        Radioactive radioactive = new Radioactive();
        foreach(int i in linha)
        {
            foreach (int j in coluna)
            {
                if (i == 0 && j == 0)
                {}else if(map[robot.x+i, robot.y+j] is Radioactive){
                    robot.lostEnergy(radioactive.radiacao);
                }
            }
        }
    }


    /// <summary>
    /// Verifica o número de jóias no mapa e começa nova fase caso tenham acabado.
    /// </summary>
    /// <param name="robo">Objeto do tipo robô</param>
    public void novaFase(Robot robo){
        int quantidadeDeJoias = 0;
        for (int i = 0; i < map.GetLength(0); i++) {
            for (int j = 0; j < map.GetLength(1); j++) {
                if(map[i,j] is Jewel){
                    quantidadeDeJoias++;
                }
            }
        }

        if (quantidadeDeJoias == 0)
        {
            Console.WriteLine("******************************************************");
            Console.WriteLine("*** Você concluiu esta fase. Vamos para a próxima! ***");
            Console.WriteLine("******************************************************");
            this.novoMapa();
            robo.zeraPosicao();
            this.addRobot(robo);
            this.PrintMap();
        }
    }


    /// <summary>
    /// Cria o mapa inserindo as jóias e obstáculos de modo aleatoŕio.
    /// </summary>
    private void novoMapa(){
        ladoDoMapa++;
        map = new MapObject[ladoDoMapa, ladoDoMapa];
        this.criaMapa();

        Random itens = new Random();
        int numeroDeItens = (ladoDoMapa*ladoDoMapa)/16;

        for (int i = 0; i < numeroDeItens; i++)
        {
            int tipoDeJoia = itens.Next(3); 
            if (tipoDeJoia > 1)
            {
                this.addJewell(new Blue(itens.Next(ladoDoMapa), itens.Next(ladoDoMapa))); 
            } else if (tipoDeJoia > 0){
                this.addJewell(new Green(itens.Next(ladoDoMapa), itens.Next(ladoDoMapa)));
            } else {
                this.addJewell(new Red(itens.Next(ladoDoMapa), itens.Next(ladoDoMapa)));
            }

            for (int j = 0; j < 2; j++){
                int tipoDeObstaculo = itens.Next(2);
                if (tipoDeObstaculo > 0){
                    this.addObstacle(new Tree(itens.Next(ladoDoMapa), itens.Next(ladoDoMapa)));
                } else {
                    this.addObstacle(new Water(itens.Next(ladoDoMapa), itens.Next(ladoDoMapa)));
                }
            }
        }

        map[itens.Next(ladoDoMapa), itens.Next(ladoDoMapa)] = new Radioactive();
    }

}
