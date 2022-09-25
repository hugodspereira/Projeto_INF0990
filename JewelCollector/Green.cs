namespace jewelproject;
/// <summary>
/// Classe Green que é um dos tipos de jóia do jogo. Está da 50 pontos para o Robô.
/// </summary>
public class Green : Jewel
{
    private const string V = "JG";
    
    /// <summary>
    /// Construtor da classe Green.
    /// </summary>
    /// <param name="x">Inteiro da posição da linha no mapa.</param>
    /// <param name="y">Inteiro da posição da coluna no mapa.</param>
    public Green(int x, int y)
    {
        symbol = V;
        value = 50;
        this.x = x;
        this.y = y;
    }
}
