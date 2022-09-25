namespace jewelproject;
/// <summary>
/// Classe MapObject que compõe a matriz do mapa do jogo.
/// </summary>
/// <param symbol="str"> Símbolo do objeto implementado no jogo.</param>
/// <param x, y="int"> Posição do objeto implementado no jogo.</param>
public class MapObject
{
    public string symbol {get; protected set;}= "--";
    public int x {get; protected set;} = 0;
    public int y {get; protected set;} = 0;

    /// <summary>
    /// Construtor da classe MapObject.
    /// </summary>
    public MapObject(){
    }

    /// <summary>
    /// Método para checar tipo de objeto.
    /// </summary>
    /// <param name="objeto"> MapObject </param>
    /// <returns>Retorna o MapObject</returns>
    public MapObject checkType(MapObject objeto){
        return objeto; 
    }
}
