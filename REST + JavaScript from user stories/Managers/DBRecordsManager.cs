using Microsoft.EntityFrameworkCore;
using REST___JavaScript_from_user_stories.DBContext;
using REST___JavaScript_from_user_stories.Models;

namespace REST___JavaScript_from_user_stories.Managers
{
    public class DBRecordsManager : IRecordsManager
    {
         private static int nextId = 1;

         private RecordContext _recordContext;

        public DBRecordsManager(RecordContext recordContext)
        {
           _recordContext = recordContext;
            
        }

        public Record Add(Record record)
        {
             record.Id = ++nextId;
            _recordContext.Records.Add(record);
            _recordContext.SaveChanges();
            return record;

        }

        public Record? Delete(int Id)
        {
            Record? foundRecord = GetById(Id);

            if (foundRecord != null)
            {
                _recordContext.Records.Remove(foundRecord);
                _recordContext.SaveChanges();
            }
            return foundRecord;
        }

        public IEnumerable<Record> GetAll(string sortBy = null)
        {
            IEnumerable<Record> records = from record in _recordContext.Records
                                    where (sortBy == null)
                                    select record;
            return records;
        }

        public Record? GetById(int Id)
        {
              return _recordContext.Records.FirstOrDefault(record => record.Id == Id);
        }

        public Record? Update(int Id, Record updates)
        {
            Record recordToBeUpdated = GetById(Id);
            recordToBeUpdated.Title = updates.Title;
            recordToBeUpdated.Artist = updates.Artist;
            recordToBeUpdated.Duration = updates.Duration;
            recordToBeUpdated.Publication = updates.Publication;

            _recordContext.SaveChanges();

            return recordToBeUpdated;
        }
    }
}
