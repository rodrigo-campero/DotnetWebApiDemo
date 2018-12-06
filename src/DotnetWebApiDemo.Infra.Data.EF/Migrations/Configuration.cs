using DotnetWebApiDemo.Domain.Entities;
using System;
using System.Collections.Generic;

namespace DotnetWebApiDemo.Infra.Data.EF.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Context.MainContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(Context.MainContext context)
        {
            if (!context.Clients.Any())
            {
                List<string> firstNames = new List<string>
                {
                    "Adam",
                    "Adrian",
                    "Alan",
                    "Alexander",
                    "Andrew",
                    "Anthony",
                    "Austin",
                    "Benjamin",
                    "Blake",
                    "Boris",
                    "Brandon",
                    "Brian",
                    "Cameron",
                    "Carl",
                    "Charles",
                    "Christian",
                    "Christopher",
                    "Colin",
                    "Connor",
                    "Dan",
                    "David",
                    "Dominic",
                    "Dylan",
                    "Edward",
                    "Eric",
                    "Evan",
                    "Frank",
                    "Gavin",
                    "Gordon",
                    "Harry",
                    "Ian",
                    "Isaac",
                    "Jack",
                    "Jacob",
                    "Jake",
                    "James",
                    "Jason",
                    "Joe",
                    "John",
                    "Jonathan",
                    "Joseph",
                    "Joshua",
                    "Julian",
                    "Justin",
                    "Keith",
                    "Kevin",
                    "Leonard",
                    "Liam",
                    "Lucas",
                    "Luke",
                    "Matt",
                    "Max",
                    "Michael",
                    "Nathan",
                    "Neil",
                    "Nicholas",
                    "Oliver",
                    "Owen",
                    "Paul",
                    "Peter",
                    "Phil",
                    "Piers",
                    "Richard",
                    "Robert",
                    "Ryan",
                    "Sam",
                    "Sean",
                    "Sebastian",
                    "Simon",
                    "Stephen",
                    "Steven",
                    "Stewart",
                    "Thomas",
                    "Tim",
                    "Trevor",
                    "Victor",
                    "Warren",
                    "William"
                };

                List<string> lastNames = new List<string>
                {
                    "Abraham",
                    "Allan",
                    "Alsop",
                    "Anderson",
                    "Arnold",
                    "Avery",
                    "Bailey",
                    "Baker",
                    "Ball",
                    "Bell",
                    "Berry",
                    "Black",
                    "Blake",
                    "Bond",
                    "Bower",
                    "Brown",
                    "Buckland",
                    "Burgess",
                    "Butler",
                    "Cameron",
                    "Campbell",
                    "Carr",
                    "Chapman",
                    "Churchill",
                    "Clark",
                    "Clarkson",
                    "Coleman",
                    "Cornish",
                    "Davidson",
                    "Davies",
                    "Dickens",
                    "Dowd",
                    "Duncan",
                    "Dyer",
                    "Edmunds",
                    "Ellison",
                    "Ferguson",
                    "Fisher",
                    "Forsyth",
                    "Fraser",
                    "Gibson",
                    "Gill",
                    "Glover",
                    "Graham",
                    "Grant",
                    "Gray",
                    "Greene",
                    "Hamilton",
                    "Hardacre",
                    "Harris",
                    "Hart",
                    "Hemmings",
                    "Henderson",
                    "Hill",
                    "Hodges",
                    "Howard",
                    "Hudson",
                    "Hughes",
                    "Hunter",
                    "Ince",
                    "Jackson",
                    "James",
                    "Johnston",
                    "Jones",
                    "Kelly",
                    "Kerr",
                    "King",
                    "Knox",
                    "Lambert",
                    "Langdon",
                    "Lawrence",
                    "Lee",
                    "Lewis",
                    "Lyman",
                    "MacDonald",
                    "Mackay",
                    "Mackenzie",
                    "MacLeod",
                    "Manning",
                    "Marshall",
                    "Martin",
                    "Mathis",
                    "May",
                    "McDonald",
                    "McLean",
                    "McGrath",
                    "Metcalfe",
                    "Miller",
                    "Mills",
                    "Mitchell",
                    "Morgan",
                    "Morrison",
                    "Murray",
                    "Nash",
                    "Newman",
                    "Nolan",
                    "North",
                    "Ogden",
                    "Oliver",
                    "Paige",
                    "Parr",
                    "Parsons",
                    "Paterson",
                    "Payne",
                    "Peake",
                    "Peters",
                    "Piper",
                    "Poole",
                    "Powell",
                    "Pullman",
                    "Quinn",
                    "Rampling",
                    "Randall",
                    "Rees",
                    "Reid",
                    "Roberts",
                    "Robertson",
                    "Ross",
                    "Russell",
                    "Rutherford",
                    "Sanderson",
                    "Scott",
                    "Sharp",
                    "Short",
                    "Simpson",
                    "Skinner",
                    "Slater",
                    "Smith",
                    "Springer",
                    "Stewart",
                    "Sutherland",
                    "Taylor",
                    "Terry",
                    "Thomson",
                    "Tucker",
                    "Turner",
                    "Underwood",
                    "Vance",
                    "Vaughan",
                    "Walker",
                    "Wallace",
                    "Walsh",
                    "Watson",
                    "Welch",
                    "White",
                    "Wilkins",
                    "Wilson",
                    "Wright",
                    "Young"
                };

                HashSet<Tuple<int, int>> permutations = new HashSet<Tuple<int, int>>();

                Random random = new Random();

                while (permutations.Count < 5)
                {
                    int a = random.Next(firstNames.Count);
                    int b = random.Next(lastNames.Count);

                    Tuple<int, int> tuple = new Tuple<int, int>(a, b);
                    permutations.Add(tuple);
                }
                HashSet<Client> clients = new HashSet<Client>();
                int index = 0;
                foreach (Tuple<int, int> tuple in permutations)
                {
                    Client client = new Client
                    {
                        FirstName = firstNames[tuple.Item1],
                        LastName = lastNames[tuple.Item2],
                        Email = $"{firstNames[tuple.Item1]}.{lastNames[tuple.Item2]}@gmail.com".ToLower(),
                        Phone = $"({random.Next(10, 99):D}) {random.Next(10000, 99999):#####}-{random.Next(1000, 9999):####}",
                        Gender = (Gender)random.Next(0, 2)
                    };

                    //clients.Add(user);
                    //index++;
                    //if (index % 100 != 0)
                    //{
                    //    continue;
                    //}

                    //context.Clients.AddRange(clients);
                    context.Clients.Add(client);
                    //context.SaveChanges();
                    clients = new HashSet<Client>();
                }
                context.SaveChanges();
            }
        }
    }
}