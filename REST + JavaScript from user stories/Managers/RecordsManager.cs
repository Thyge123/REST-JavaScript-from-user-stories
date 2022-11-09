using REST___JavaScript_from_user_stories.Models;
using System.Xml.Linq;
using static System.Reflection.Metadata.BlobBuilder;

namespace REST___JavaScript_from_user_stories.Managers
{
    public class RecordsManager : IRecordsManager
    {
        private static int nextId = 1;


        private static readonly List<Record> recordsList = new List<Record>
        {
            new Record {Id = nextId++, Title = "Værsgo", Artist = "Kim Larsen", Publication = new DateTime(1973, 5, 1), Duration = 3600},
            new Record {Id = nextId++, Title = "Nordstrøm", Artist = "Yeet", Publication = new DateTime(2025, 8, 28), Duration = 3}
        };



        public IEnumerable<Record> GetAll(string sortBy = null)
        // Optional parameters
        // https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/named-and-optional-arguments
        {
            List<Record> records = new List<Record>(recordsList);
            // copy constructor
            // Callers should no get a reference to the Data object, but rather get a copy

            //if (title != null)
            //{
            //    records = records.FindAll(book => book.Title.StartsWith(title));
            //}
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
        /// <summary>
        /// DateTime er midlertidig, da ellers skal den sættes manuelt hver gang
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        public Record Add(Record record)
        {
            record.Id = nextId++;
            record.Publication = new DateTime(1999, 1, 1);
            recordsList.Add(record);
            return record;
        }

        public Record? GetById(int Id)
        {
            return recordsList.Find(record => record.Id == Id);
        }

        public Record? Update(int Id, Record updates)
        {
            Record? oldRecord = GetById(Id);
            if (oldRecord == null) return null;
            oldRecord.Title = updates.Title;
            oldRecord.Artist = updates.Artist;
            oldRecord.Duration = updates.Duration;
            oldRecord.Publication = updates.Publication;
            return oldRecord;
        }

        public Record? Delete(int Id)
        {
            Record record = recordsList.Find(record1 => record1.Id == Id);
            if (record == null) return null;
            recordsList.Remove(record);
            return record;
        }
    }
}
