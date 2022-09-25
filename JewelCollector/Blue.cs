namespace jewelproject;
/// <summary>
/// Classe Blue que é um dos tipos de jóia do jogo. Está da 10 pontos para o Robô e 5 de energia.
/// </summary>
public class Blue: Jewel, Energyzer
{
    private const string V = "JB";

    /// <summary>
    /// Construtor da classe Blue.
    /// </summary>
    /// <param name="x">Inteiro da posição da linha no mapa.</param>
    /// <param name="y">Inteiro da posição da coluna no mapa.</param>
    public Blue(int x, int y)
    {
        symbol = V;
        value = 10;
        this.x = x;
        this.y = y; 
    }

    /// <summary>
    /// Dá energia para robô.
    /// </summary>
    /// <returns>Inteiro com a quantia de energia que o robô recebe.</returns>
    public int giveEnergy(){
        return 5;
    }
}
