using System;

public abstract class InventoryItem
{
    public string Name { get; set; }
    public double Weight { get; set; }

    public InventoryItem(string name, double weight)
    {
        Name = name;
        Weight = weight;
    }

    public override string ToString()
    {
        return $"{Name}, {Weight}kg";
    }
}
