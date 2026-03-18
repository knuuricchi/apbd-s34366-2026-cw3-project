namespace Serwis;

public class Laptop : Equipment
{
    public string Cpu { get; set; }
    public int RamGb { get; set; }

    public Laptop(string name) : base(name)
    {
        
    }
}
