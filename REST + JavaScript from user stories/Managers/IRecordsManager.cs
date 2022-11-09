using REST___JavaScript_from_user_stories.Models;

namespace REST___JavaScript_from_user_stories.Managers
{
    public interface IRecordsManager
    {
        Record Add(Record record);
        Record? GetById(int Id);
        Record? Update(int Id, Record updates);
        Record? Delete(int Id);
        IEnumerable<Record> GetAll(string sortBy = null);
    }
}