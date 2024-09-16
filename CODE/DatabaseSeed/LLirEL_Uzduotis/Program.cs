using Azure;
using LLirEL_Uzduotis.Entities;

namespace LLirEL_Uzduotis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* 

              Užduotis 1: Sukurkite darbinę duomenų bazę ir užpildykite duomenimis.
              Sukurkite darbinę duomenų bazę, kurią sudaro 5 lentelės: Darbuotojai (Employees), Imone (Company), Projektai (Projects), Skyrius (Departments), ir Vadovas (Managers).
              - Darbuotojas (Employee) turėtų turėti savybes: DarbuotojasId, Vardas, Pavarde.
              - Skyrius (Department) turėtų turėti savybes: SkyriusId, Pavadinimas.
              - Projektas (Project) turėtų turėti savybes: ProjektasId, Pavadinimas.
              - Imone (Company) turėtų turėti savybes: ImoneId, Pavadinimas, Adresas.
              - Vadovas (Manager) turėtų turėti savybes: VadovasId, Vardas, Pavarde.

             Nustatykite tarpusavio ryšius tarp lentelių:
              - Vienas Skyrius turi daug Darbuotojai. (one-to-many)
              - Projektas turi daug Darbuotojų. Darbuototas gali vykdyti daug projektų (many-to-many)
              - Vienas Vadovas vadovauja vienam Skyriui. (one-to-one)
              - Imone turi daug Projektų. Projektą vykdo daug Įmonių (many-to-many)

             Užpildykite DB pirminiais duomenimis:
                    - Sukurkite bent 3 įmones
                    - Sukurkite bent 6 skyrius
                    - Sukurkite bent 10 darbuotojų
                    - Sukurkite bent 5 projektus
                    - Sukurkite bent 3 vadovus
              */

            /*Užduotis 2: Užkraukite darbuotojus kartu su jų projektais. Naudokite Eager Loading. */
            /*Užduotis 3: Užkraukite skyrius kartu su darbuotojais ir projektais. Naudokite Eager Loading. */
            /*Užduotis 4: Užkraukite įmones kartu su projektais ir jų darbuotojais. Naudokite Eager Loading.*/
            /*Užduotis 5: Užkraukite darbuotojus kartu su skyriumi ir vadovu. Naudokite Eager Loading.*/
            /*Užduotis 6: Užkraukite vadovus kartu su jų skyriais ir darbuotojais. Naudokite Eager Loading.*/
            /*Užduotis 7: Užkraukite skyrius kartu su jų vadovais ir jų darbuotojų projektais. Naudokite Eager Loading.*/
            /*Užduotis 8: Užkraukite įmones kartu su projektais, darbuotojais ir jų skyriais. Naudokite Eager Loading.*/
            /*Užduotis 9: Užkraukite visus projektus kartu su įmonėmis, darbuotojais ir jų vadovais. Naudokite Eager Loading.*/


            using var context = new EmployeeContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            PopulateDatabase(context);
        }
        private static void PopulateCompanies(EmployeeContext context)
        {
            var google = new Company()
            {
                CompanyName = "Google",
                CompanyAddress = "Amphitheatre Parkway\r\nMountain View, CA 94043, USA"
            };
            var microsoft = new Company()
            {
                CompanyName = "Microsoft",
                CompanyAddress = "Address: Al. Jerozolimskie 195A, 02-222 Warsaw, Poland"
            };
            var nvidia = new Company()
            {
                CompanyName = "NVidia",
                CompanyAddress = "Address: 2788 San Tomas Expressway, Santa Clara, CA 95051, USA"
            };

            context.Companies.AddRange(google, microsoft, nvidia);
            context.SaveChanges();
        }
        private static void PupulateDepartments(EmployeeContext context)
        {
            var cSharpBackEndProgramming = new Department()
            {
                Name = "C# Back-End Programming"
            };
            var cSharpFrontEndProgramming = new Department()
            {
                Name = "C# Front-End Programming"
            };
            var pythonProgramming = new Department()
            {
                Name = "Python Programming"
            };
            var management = new Department()
            {
                Name = "Management"
            };
            var accounting = new Department()
            {
                Name = "Accounting"
            };
            var utility = new Department()
            {
                Name = "Utilities"
            };
            
            context.Departments.AddRange(cSharpBackEndProgramming, cSharpFrontEndProgramming, pythonProgramming, management, accounting, utility);
            context.SaveChanges();
        }
        private static void PopulateEmployees(EmployeeContext context)
        {
            var kristijonasDonelaitis = new Employee()
            {
                FirstName = "Kristijonas",
                LastName = "Donelaitis",
                DepartmentId = 1,
                ProjectId = 1
            };
            var jonasMaciulis = new Employee()
            {
                FirstName = "Jonas",
                LastName = "Maciulis",
                DepartmentId = 2,
                ProjectId = 1
            };
            var jonasBiliunas = new Employee()
            {
                FirstName = "Jonas",
                LastName = "Biliunas",
                DepartmentId = 2,
                ProjectId = 2
            };
            var vincasMykolaitisPutinas = new Employee()
            {
                FirstName = "Vincas",
                LastName = "Mykolaitis-Putinas",
                DepartmentId = 3,
                ProjectId = 3
            };
            var salomejaNeris = new Employee()
            {
                FirstName = "Salomeja",
                LastName = "Neris",
                DepartmentId = 4,
                ProjectId = 3
            };
            var marijaPeckauskaite = new Employee()
            {
                FirstName = "Marija",
                LastName = "Peckauskaite",
                DepartmentId = 5,
                ProjectId = 4
            };
            var balysSruoga = new Employee()
            {
                FirstName = "Balys",
                LastName = "Sruoga",
                DepartmentId = 6,
                ProjectId = 2
            };
            var juozasTumasVaizgantas = new Employee()
            {
                FirstName = "Juozas",
                LastName = "Tumas-Vaizgantas",
                DepartmentId = 6,
                ProjectId = 5
            };
            var antanasSkema = new Employee()
            {
                FirstName = "Antanas",
                LastName = "Skema",
                DepartmentId = 5,
                ProjectId = 3
            };
            var ievaSimonaityte = new Employee()
            {
                FirstName = "Ieva",
                LastName = "Simonaityte",
                DepartmentId = 4,
                ProjectId = 4
            };


            context.Employees.AddRange(kristijonasDonelaitis, jonasMaciulis, jonasBiliunas, vincasMykolaitisPutinas, salomejaNeris, marijaPeckauskaite, balysSruoga, juozasTumasVaizgantas, antanasSkema, ievaSimonaityte );
            context.SaveChanges();
        }
        private static void PopulateManagers(EmployeeContext context)
        {
            var olof = new Manager()
            {
                FirstName = "Olof",
                LastName = "Palme",
                Department = context.Departments.FirstOrDefault(d => d.Name == "Management")
            };
            var tage = new Manager()
            {
                FirstName = "Tage",
                LastName = "Erlander",
                Department = context.Departments.FirstOrDefault(d => d.Name == "Management")
            };
            var perAlbin = new Manager()
            {
                FirstName = "Per Albin",
                LastName = "Hansson",
                Department = context.Departments.FirstOrDefault(d => d.Name == "Management")
            };


            context.Managers.AddRange(olof, tage, perAlbin);
            context.SaveChanges();
        }
        private static void PopulateProjects(EmployeeContext context)
        {
            var csChatbot = new Project()
            {
                Name = "AI-Powered Customer Support Chatbot",
                CompanyId = 1
            };
            var cloudDataAnalizer = new Project()
            {
                Name = "Cloud-Based Data Analytics Platform",
                CompanyId = 1
            };
            var blockchainSupply = new Project()
            {
                Name = "Blockchain Supply Chain Management System",
                CompanyId = 2
            };
            var cyberSecurity = new Project()
            {
                Name = "Cybersecurity Threat Detection and Response Platform",
                CompanyId = 2
            };
            var vrSimulation = new Project()
            {
                Name = "Virtual Reality (VR) Training Simulations",
                CompanyId = 3
            };


            context.Projects.AddRange(csChatbot,  cloudDataAnalizer, blockchainSupply, cyberSecurity, vrSimulation);
            context.SaveChanges();
        }
        private static void PopulateDatabase(EmployeeContext context)
        {
            PopulateManagers(context);
            PopulateCompanies(context);
            PupulateDepartments(context);
            PopulateEmployees(context);
            PopulateProjects(context);
        }
    }
}
