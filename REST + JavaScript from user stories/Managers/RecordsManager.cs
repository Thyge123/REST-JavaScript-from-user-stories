using REST___JavaScript_from_user_stories.Models;

namespace REST___JavaScript_from_user_stories.Managers
{
    public class RecordsManager
    {
        private Record records {get; set;}

        private static int nextId = 1;

        private static readonly List<Record> recordsList = new List<Record>
        {
            new Record {Id = nextId++, Title = "Værsgo", Artist = "Kim Larsen", Publication = new DateTime(1973, 5, 1), Duration = 3600},
            new Record {Id = nextId++, Title = "Nordstrøm", Artist = "Yeet", Publication = new DateTime(2025, 8, 28), Duration = 3}
        };

        public List<Record> GetAll()
        {
            return recordsList;
        }

    }
}
