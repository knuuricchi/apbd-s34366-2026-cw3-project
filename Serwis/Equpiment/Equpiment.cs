namespace Serwis;

public abstract class Equipment
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    
    public string Name { get; set; }
    
    public EquipmentStatus Status { get; set; } = EquipmentStatus.AVAILABLE;

    public string InventoryNumber { get; set; }
    
    protected Equipment(string name)
    {
        Name = name;
    }

    public override string ToString()
    {
        return $"ID: {Id} | {Name} ({InventoryNumber}) - {Status} ({GetType().Name.ToUpper()})";
    }
}
