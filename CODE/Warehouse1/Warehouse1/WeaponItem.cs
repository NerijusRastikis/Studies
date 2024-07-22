public class WeaponItem : InventoryItem
{
    public int Damage { get; set; }

    public WeaponItem(string name, double weight, int damage)
        : base(name, weight)
    {
        Damage = damage;
    }

    public override string ToString()
    {
        return $"{base.ToString()}, {Damage}dmg";
    }
}