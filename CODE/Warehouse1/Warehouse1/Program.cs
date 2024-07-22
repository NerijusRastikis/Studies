class Program
{
    static void Main()
    {
        var foodWarehouse = new Warehouse<FoodItem>("food.csv");
        var weaponWarehouse = new Warehouse<WeaponItem>("weapons.csv");
        var medicalWarehouse = new Warehouse<MedicalItem>("medical.csv");

        Display.InitializeWarehouses(foodWarehouse, weaponWarehouse, medicalWarehouse);
        Display.ShowMenu();
    }
}
