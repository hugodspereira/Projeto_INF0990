namespace jewelproject;
/// <summary>
/// Classe Red que é um dos tipos de jóia do jogo. Está da 100 pontos para o Robô.
/// </summary>
public class Red : Jewel
{
    private const string V = "JR";
    
    /// <summary>
    /// Construtor da classe Red.
    /// </summary>
    /// <param name="x">Inteiro da posição da linha no mapa.</param>
    /// <param name="y">Inteiro da posição da coluna no mapa.</param>
    public Red(int x, int y)
    {
        symbol = V;
        value = 100;
        this.x = x;
        this.y = y;

    }
}
