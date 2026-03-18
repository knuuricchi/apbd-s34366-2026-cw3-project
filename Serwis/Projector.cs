namespace Serwis;

public class Projector : Equipment
{
    public int Lumens { get; set; }
    public string Resolution { get; set; }

    public Projector(string name) : base(name)
    {
    }
}
