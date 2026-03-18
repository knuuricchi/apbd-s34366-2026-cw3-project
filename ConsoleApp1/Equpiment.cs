namespace ConsoleApp1;

public abstract class Equipment
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    
    public string Name { get; set; }
    
    public EquipmentStatus Status { get; set; } = EquipmentStatus.Available;

    public string InventoryNumber { get; set; }
    
    public string Manufacturer { get; set; }

    protected Equipment(string name)
    {
        Name = name;
    }

    public override string ToString()
    {
        return $"{Name} ({InventoryNumber}) - {Status}";
    }
}
