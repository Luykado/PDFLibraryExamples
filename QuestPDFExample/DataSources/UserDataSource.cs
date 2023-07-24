using QuestPDFExample.Models;
using QuestPDF.Helpers;
using QuestPDFExample.Enums;

namespace QuestPDFExample.DataSources
{
    public static class UserDataSource
    {
        private static Random Random = new Random();

        public static IEnumerable<User> GetUsers(int count)
        {
            var users = Enumerable.Range(1, count).Select(_ => GenerateRandomUser());

            return users;
        }

        private static DateTime GetRandomDate(DateTime startDate, DateTime endDate)
        {
            TimeSpan timeSpan = endDate - startDate;
            TimeSpan randomSpan = new(0, Random.Next(0, (int)timeSpan.TotalMinutes), 0);
            return startDate + randomSpan;
        }

        private static T GetRandomEnumValue<T>()
        {
            Array values = Enum.GetValues(typeof(T));
            return (T)values.GetValue(Random.Next(values.Length));
        }

        private static Note GenerateRandomNote()
        {
            DateTime startDate = new(2014, 1, 1);

            return new Note
            {
                Content = Placeholders.Label(),
                Description = Placeholders.Label(),
                Date = GetRandomDate(startDate, DateTime.Now),
            };
        }

        private static Address GenerateRandomAddress()
        {
            return new Address
            {
                Street = Placeholders.Label(),
                City = Placeholders.Label(),
                State = Placeholders.Label(),
            };
        }

        private static Passport GenerateRandomPassport()
        {
            DateTime startDate = new(2014, 1, 1);
            DateTime endDate = DateTime.Now;
            return new Passport
            {
                Country = Placeholders.Label(),
                ExpirationDate = GetRandomDate(startDate, endDate),
                Issuer = Placeholders.Name(),
                Series = Placeholders.Label(),
                Number = Placeholders.PhoneNumber(),
            };
        }

        private static User GenerateRandomUser()
        {
            DateTime startDate = new(1970, 1, 1);
            DateTime endDate = new(2000, 1, 1);

            return new User
            {
                FullName = Placeholders.Name(),
                Age = Random.Next(1, 80),
                BirthDate = GetRandomDate(startDate, endDate),
                Email = Placeholders.Email(),
                Gender = GetRandomEnumValue<Gender>(),
                Phone = Placeholders.PhoneNumber(),
                Passport = GenerateRandomPassport(),
                Address = GenerateRandomAddress(),
                Notes = Enumerable.Range(1, 5).Select(_ => GenerateRandomNote()),
            };
        }
    }
}
