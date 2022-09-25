namespace jewelproject;
/// <summary>
/// Classe Robot que é personagem do jogo.
/// </summary>
public class Robot : MapObject
{
    private const string V = "ME";
    public int xant, yant; 
    List<Jewel> bag = new List<Jewel>{};
    public int value = 0;
    public int energy = 5;

    /// <summary>
    /// Construtor da classe Robot.
    /// </summary>
    /// <param name="x">Inteiro da posição da linha no mapa.</param>
    /// <param name="y">Inteiro da posição da coluna no mapa.</param>
    public Robot(int x, int y)
    {
        symbol = V;
        this.x = x;
        this.y = y;
    }

    /// <summary>
    /// Altera a posição do robô levando ele para baixo.
    /// </summary>
    public void moveDown(){
        xant = this.x;
        this.energy = this.energy -1;
        this.x = x+1;
    }

    /// <summary>
    /// Altera a posição do robô levando ele para cima.
    /// </summary>
    public void moveUp(){
        xant = this.x;
        this.energy = this.energy -1;
        this.x = x-1;
    }

    /// <summary>
    /// Altera a posição do robô levando ele para esquerda.
    /// </summary>
    public void moveLeft(){
        yant = this.y;
        this.energy = this.energy -1;
        this.y = y-1;
    }

    /// <summary>
    /// Altera a posição do robô levando ele para direita.
    /// </summary>
    public void moveRight(){
        yant = this.y;
        this.energy = this.energy -1;
        this.y = y+1;
    }


    /// <summary>
    /// Adiciona jóia na bag do robô.
    /// </summary>
    /// <param name="jewel">Objetio do tipo jóia a ser adicionado.</param>
    public void addJewell(Jewel jewel){
        bag.Add(jewel);
    }

    /// <summary>
    /// Conta quantas jóias estão na sacola do robô.
    /// </summary>
    /// <returns>Retorna inteiro com o número de jóias.</returns>
        public int countJewel(){
        return bag.Count();
    }


    /// <summary>
    /// Soma o valor das jóias na sacola do Robô.
    /// </summary>
    /// <returns>Retorna inteiro com valor das jóias.</returns>
    private int totalValue(){
        this.value = 0;
        foreach (Jewel jewel in bag)
        {
            this.value = this.value + jewel.value;
        }
        return this.value;
    }

    /// <summary>
    /// Tira energia do robô.
    /// </summary>
    /// <param name="lost">Inteiro com valor a ser retirado de energia.</param>
    public void lostEnergy(int lost){
        this.energy = this.energy - lost;
    }

    /// <summary>
    /// Recarrega energia do robô.
    /// </summary>
    /// <param name="energy">Inteiro com valor do robô a ser recarregado.</param>
    public void rechargeEnergy(int energy){
        this.energy = this.energy + energy;
    }

    /// <summary>
    /// Zera os inteiros com a posição atual e a anterior do robô.
    /// </summary>
    public void zeraPosicao(){
        this.x = 0;
        this.y = 0;
        this.xant = 0;
        this.yant = 0;
    }

    /// <summary>
    /// Verifica quanto de energia o robô tem e retorna boolean indicando se o robô pode continuar a se mexer.
    /// </summary>
    /// <returns>Boolean que indica se robô tem energia para se mover.</returns>
    public bool checkEnergy(){
        if (this.energy <= 0)
        {
            Console.WriteLine("Robô não pode se mover. Fim do Jogo!");
            return false;
        }
        return true;
    }

    /// <summary>
    /// Imprime na tela quantas jóias, valor total em jóias e energia do robô.
    /// </summary>
    public void PrintPoints(){
        Console.WriteLine("Bag total itens: " + countJewel() + " | Bag total value: " + totalValue());
        Console.WriteLine("Energia do robô: " + this.energy);
    }

}
