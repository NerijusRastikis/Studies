﻿using AsmensRegistravimoSistemaI2.Models;

namespace AsmensRegistravimoSistemaI2.Database.InitialData
{
    public static class AddressesInitialData
    {
        public static List<Address> Addresses => new()
        {
            new Address
            {
                Id = new Guid("00000000-0000-0000-0000-000000000001"),
                Town = "Saulėkalnis",
                Street = "Žydinčių Pieščių alėja",
                HouseNumber = "24",
                ApartmentNumber = 15
            },
            new Address
            {
                Id = new Guid("00000000-0000-0000-0000-000000000002"),
                Town = "Uolynėlis",
                Street = "Kalnų viršūnės gatvė",
                HouseNumber = "8A",
                ApartmentNumber = 15
            },
            new Address
            {
                Id = new Guid("00000000-0000-0000-0000-000000000003"),
                Town = "Ežerpilis",
                Street = "Ramybės Šilų prospektas",
                HouseNumber = "56",
                ApartmentNumber = 12
            },
            new Address
            {
                Id = new Guid("00000000-0000-0000-0000-000000000004"),
                Town = "Šiloklėnis",
                Street = "Šimtamečių Ąžuolų gatvė",
                HouseNumber = "101",
                ApartmentNumber = 8
            },
            new Address
            {
                Id = new Guid("00000000-0000-0000-0000-000000000005"),
                Town = "Gintarkrantė",
                Street = "Pajūrio Saulėlydžio takas",
                HouseNumber = "7",
                ApartmentNumber = 5
            }
        };

    }
}
