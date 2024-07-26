using DoomsdayWarehouse.Models;
using DoomsdayWarehouse.Service;

namespace DoomsdayWarehouse
{
    /*mini projektas

   Šiame projekte sukursite programą, kuri tvarkys Doomsday Warehouse inventorių, naudodama paveldėjimą ir System.IO.File klasę. 
   Programa leis pridėti naujus dalykus į inventorių, išsaugoti inventoriaus informaciją faile ir ją nuskaityti iš failo.
   - Sukurkite generinę klasę Warehouse, kuri saugos skirtingų tipų prekes.
   - Sukurkite abstrkčią bazinę klasę InventoryItem, kuri apibrėžia bendrus inventoriaus elementų atributus - pavadinimą ir svorį. 
   - Sukurkite kelias klases, paveldinčias iš abstrakčios klasės InventoryItem, pavyzdžiui: FoodItem, WeaponItem ir MedicalItem.
   - Konkrečios klasės turi turi papildomus atributus:
         Maistas  - galiojimo datą ir kalorijas, 
         Ginklai - neturi papildomų atributų,
         Medicinina - galiojimo datą ir ligų sąrašą nuo kurių gydo (string).
   - Skirtingi inventoriai turi būti saugomi skirtinguose failuose csv formatu pvz: maistas.csv -> bulvės, 10kg, 2050-01-05, 500kcal
                                                                                                   dešra, 5kg, 2050-11-15, 1000kcal
                                                                                                   ir t.t....       
                                                                                    ginklai.scv -> kalavijas, 2kg
                                                                                                   šautuvas, 3kg
                                                                                                   ir t.t....
                                                                                    medicina.csv -> penicilinas, 0.1kg, 2023-01-01, plaučių uždegimas, bronchitas, angina,  sinusitas, vidurinės ausies uždegimas, tonzilitas
                                                                                                    aspirinas, 0.2kg, 2022-01-01, galvos skausmas, raumenų skausmas, sąnarių skausmas
                                                                                                    ir t.t....                  

   - Kiekvienam konkrečiam inventoriui sukurkite failą csv formatu, kuriame saugosite prekių informaciją

   - Kiekvienam konkrečiam inventoriui (maistas, ginklai, medicina) sukurkite metodą ToCSV, kuris objekte esančia informaciją pavers csv eilute.
   - Kiekvienam konkrečiam inventoriui (maistas, ginklai, medicina) sukurkite metodą FromCSV, kuris csv eilutę pavers objektu.

   - Sukurkite Warehouse metodą void AddItem(T item) kurie leis pridėti naujus daiktus į inventorių ir išsaugos turimo inventoriaus informaciją faile.
   - Sukurkite Warehouse metodą List<T> GetItems(), kuris nuskaitys inventoriaus informaciją iš failo ir grąžins visus inventoriaus elementus.
   - Sukurkite Warehouse metodą T GetItem(string name), kuris grąžins vieną atitinkamą inventoriaus elementą pagal pavadinimą.
   - Sukurkite Warehouse metodą bool Contains(string name), kuris patikrins ar inventoriaus elementas su tokiu pavadinimu egzistuoja.
   - Sukurkite Warehouse metodą void RemoveItem(string name), kuris ištrins inventoriaus elementą pagal pavadinimą.
   - Sukurkite 3 Warehouse klasės objektus, kuriuose saugosite skirtingų tipų (maistas,ginklai,medicina) prekes.



   - Įrašykite į failus testinius duomenis ir išbandykite sukurtas klases naudodami unit test.

   PAPILDOMAI:
   - Sukurkite ExpiringProductsWarehouse klasę, kuri paveldėtų Warehouse klasę ir būtų skirta maisto produktams ir medicinai.
   - ExpiringProductsWarehouse klasėje pridėkite operaciją List<T> FindExpiringProducts().
   - Sukurkite funkcionalumą šiai naudotojo istorijai:
      Vadovas atsiunčia užduotį el. paštu (imituokite el. pašto servisą kurio pagrindinis metodas turi mesti exception) peržiūrėti visų vaistų galiojimo datas 
      ir išrinkti tuos, kurių galiojimo data pasibaigusi daugiau kaip prieš X (skaičius nurodomas vadovo el. laiške) mėnesius.
   */
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            IWarehouse<FoodItem> maistasWarehouse = new Warehouse<FoodItem>("maistas.csv");
            var maistas = maistasWarehouse.GetItems();

            IWarehouse<WeaponItem> weaponWarehouse = new Warehouse<WeaponItem>("ginklai.csv");
            var ginklai = weaponWarehouse.GetItems();

            IWarehouse<MedicalItem> medicinaWarehouse = new Warehouse<MedicalItem>("medicina.csv");
            var medicina = medicinaWarehouse.GetItems();
        }
    }
}
