using REST___JavaScript_from_user_stories.Models;
using static System.Reflection.Metadata.BlobBuilder;

namespace REST___JavaScript_from_user_stories.Managers
{
    public class RecordsManager
    {
        private static int nextId = 1;

        private static readonly List<Record> recordsList = new List<Record>
        {
            new Record {Id = nextId++, Title = "Værsgo", Artist = "Kim Larsen", Publication = new DateTime(1973, 5, 1), Duration = 3600},
            new Record {Id = nextId++, Title = "Nordstrøm", Artist = "Yeet", Publication = new DateTime(2025, 8, 28), Duration = 3}
        };

         public List<Record> GetAll(string sortBy = null)
        // Optional parameters
        // https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/named-and-optional-arguments
        {
            List<Record> records = new List<Record>(recordsList);
            // copy constructor
            // Callers should no get a reference to the Data object, but rather get a copy

            if (sortBy != null)
            {
                switch (sortBy.ToLower())
                {
                    case "id":
                        records = records.OrderBy(record => record.Id).ToList();
                        break;
                    case "title":
                        records = records.OrderBy(record => record.Title).ToList();
                        break;
                          case "artist":
                        records = records.OrderBy(record => record.Artist).ToList();
                        break;
                          case "duration":
                        records = records.OrderBy(record => record.Duration).ToList();
                        break;
                          case "publication":
                        records = records.OrderBy(record => record.Publication.ToString()).ToList();
                        break;
                }
            }
            return records;
         }

         public Record Add(Record record)
         {
            record.Id = nextId++;
            recordsList.Add(record);
            return record;
         }
    }
}
