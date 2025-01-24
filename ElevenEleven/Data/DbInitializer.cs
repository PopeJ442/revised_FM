using ElevenEleven.Enums;
using ElevenEleven.Models;

namespace ElevenEleven.Data
{
    public static class DbInitializer
    {
        public static void SeedData(ApplicationDbContext context) 
        {
            if (!context.Players.Any())
            {
                var firstNames = new List<string>
                {
                    "Emmanuel", "Samuel", "Isaac", "Daniel", "Michael",
                    "Nana", "Joseph", "Richard", "Eric", "Francis",
                    "John", "George", "David", "Mohammed", "Stephen",
                    "Prince", "Charles", "Kofi", "Frank", "Benjamin",
                    "Ebenezer", "Kwame", "James", "Ernest", "Peter",
                    "Patrick", "Paul", "William", "Edward", "Felix",
                    "Ibrahim", "Seth", "Anthony", "Abdul", "Robert",
                    "Philip", "Bernard", "Yaw", "Kwabena", "Albert",
                    "Alex", "Kwaku", "Henry", "Frederick", "Solomon",
                    "Thomas", "Evans", "Bright", "Abdulai", "Joshua",
                    "Alfred", "Kwasi", "Victor", "Maxwell", "Mark",
                    "Enoch", "Kwadwo", "Nii", "Bismark", "Abraham",
                    "Gideon", "Jonathan", "Justice", "Gabriel", "Fred",
                    "Nicholas", "Martin", "Dennis", "Christian", "Lawrence",
                    "Alhassan", "Godwin", "Alexander"
                };

                var middleNames = new List<string>
                {
                    "Konadu", "Bediako", "", "", "Debrah", "Teye", "", "Takyi",
                    "Twum", "", "", "Peprah", "Mahama", "Biney", "Blankson",
                    "Martey", "", "Aggrey", "Ohene", "", "Ackah", "Asiamah",
                    "", "", "Marfo", "Narh", "Hagan", "Baiden", "", "Poku",
                    "Awuku", "Otchere", "Okine", "", "Aggrey", "", "", "Annor",
                    "", "Ankomah", "Hayford", "", "Fosu", "", "Tamakloe", "Anane"
                };

                var lastNames = new List<string>
                {
                    "Danquah", "Yakubu", "Kwarteng", "Larbi", "Musah",
                    "Andoh", "Nana", "Cudjoe", "Aryee", "Amankwah",
                    "Sarfo", "Addai", "Tawiah", "Afful", "Ankrah",
                    "Agyekum", "Kyei", "Ibrahim", "Bonsu", "Iddrisu",
                    "Kwakye", "Afriyie", "Kumah", "Anim", "Salifu",
                    "Seidu", "Nkansah", "Ampofo", "Koranteng", "Arhin",
                    "Tagoe", "Amissah", "Manu", "Forson", "Awuah",
                    "Boamah", "Nortey", "Addae", "Gyimah", "Boadu",
                    "Agyapong", "Sowah", "Kusi", "Issah", "Solomon",
                    "Boadi", "Kumi", "Akoto", "Essel", "Botchway",
                    "Dodoo", "Tettey", "Twumasi", "Doe", "Duah"
                };

                // Random number generator
                Random random = new Random();

                // Create 100 players
                for (int i = 0; i < 100; i++)
                {
                    // Randomly pick names
                    string firstName = firstNames[random.Next(firstNames.Count)];
                    string middleName = middleNames[random.Next(middleNames.Count)];
                    string lastName = lastNames[random.Next(lastNames.Count)];

                    // Randomly generate other details
                    var player = new Player
                    {
                        FirstName = firstName,
                        MiddleName = middleName,
                        LastName = lastName,
                        DateOfBirth = new DateOnly(random.Next(1985, 2005), random.Next(1, 13), random.Next(1, 29)),
                        Gender = (Gender)random.Next(0, 2), // Assuming 0 = Male, 1 = Female
                        Nationality = Country.Ghana, // Change this based on your enum
                        PhoneNumber = $"0{random.Next(200000000, 299999999)}",
                        EmailAddress = $"{firstName.ToLower()}.{lastName.ToLower()}@example.com",
                        ResidentialAddress = $"House No {random.Next(1, 100)}, Accra",
                        Height = Math.Round(random.NextDouble() * (2.1 - 1.6) + 1.6, 2), // Height between 1.6m and 2.1m
                        Weight = random.Next(60, 100), // Weight between 60kg and 100kg
                        PreferredFoot = (PreferredFoot)random.Next(0, 3) // 0 = Left, 1 = Right, 2 = Both
                    };

                    // Add to the context
                    context.Players.Add(player);
                }

                // Save all players to the database
                context.SaveChanges();
            }


        }
    }
}
