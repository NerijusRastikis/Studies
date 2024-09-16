using Apartments;
using Apartments.Entities;

namespace Appartments
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using ApartmentsContext context = new ApartmentsContext();

            var poilsioSvajos = new Institution
            {
                InstitutionId = 1,
                Title = "Poilsio Svajos"
            };
            var nakvynesNamai = new Institution
            {
                InstitutionId = 2,
                Title = "Nakvynes Namai"
            };
            var theSleepover = new Institution
            {
                InstitutionId = 3,
                Title = "The Sleepover"
            };
            context.Institutions.AddRange(poilsioSvajos, nakvynesNamai, theSleepover);
            context.SaveChanges();

            var tomasTomaitis = new Owner
            {
                OwnerId = 1,
                Name = "Tomas Tomaitis",
                Phone = 12,
                Email = "tomas.tomaitis@apartments.com"
            };
            var petrasPetraitis = new Owner
            {
                OwnerId = 2,
                Name = "Petras Petraitis",
                Phone = 123,
                Email = "petras.petraitis@apartments.com"
            };
            var kristinaKristinaitiene = new Owner
            {
                OwnerId = 3,
                Name = "Kristina Kristinaitiene",
                Phone = 1234,
                Email = "kristina.kristinaitiene@apartments.com"
            };
            context.Owners.AddRange(tomasTomaitis, petrasPetraitis, kristinaKristinaitiene);
            context.SaveChanges();

            var lithuaniaKaunas = new Place
            {
                PlaceId = 1,
                Country = "Lithuania",
                City = "Kaunas"
            };
            var lithuaniaSiauliai = new Place
            {
                PlaceId = 2,
                Country = "Lithuania",
                City = "Siauliai"
            };
            var polandWarsaw = new Place
            {
                PlaceId = 3,
                Country = "Poland",
                City = "Warsaw"
            };
            context.Places.AddRange(lithuaniaKaunas, lithuaniaSiauliai, polandWarsaw);
            context.SaveChanges();
        }
    }
}
