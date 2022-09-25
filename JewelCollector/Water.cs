namespace jewelproject;
/// <summary>
/// Classe Water que é obstáculo do jogo.
/// </summary>
public class Water : Obstacle
{
    /// <summary>
    /// Construtor da classe Water.
    /// </summary>
    /// <param name="x">Inteiro da posição da linha no mapa.</param>
    /// <param name="y">Inteiro da posição da coluna no mapa.</param>
    public Water(int x, int y){
        this.symbol = "##";
        this.x = x;
        this.y = y;

    }
}
