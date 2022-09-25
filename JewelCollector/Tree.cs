namespace jewelproject;
/// <summary>
/// Classe Tree que é obstáculo do jogo.
/// </summary>
public class Tree : Obstacle, Energyzer
{
    /// <summary>
    /// Construtor da classe Tree.
    /// </summary>
    /// <param name="x">Inteiro da posição da linha no mapa.</param>
    /// <param name="y">Inteiro da posição da coluna no mapa.</param>
    public Tree(int x, int y){
        this.symbol = "$$";
        this.x = x;
        this.y = y;

    }

    /// <summary>
    /// Dá energia para robô.
    /// </summary>
    /// <returns>Inteiro com a quantia de energia que o robô recebe.</returns>
    public int giveEnergy(){
        return 3;
    }
}
