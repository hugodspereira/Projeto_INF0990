namespace jewelproject;
/// <summary>
/// Classe Radioactive que gera o objeto radioativo.
/// </summary>
public class Radioactive : MapObject
{
    public int radiacao {get; private set;} = 10;

    /// <summary>
    /// Construtor da Classe Radioactive.
    /// </summary>
    public Radioactive(){
        this.symbol= "!!";
    }
}
