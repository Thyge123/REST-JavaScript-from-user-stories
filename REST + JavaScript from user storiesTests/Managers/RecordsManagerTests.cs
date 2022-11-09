using Microsoft.VisualStudio.TestTools.UnitTesting;
using REST___JavaScript_from_user_stories.Models;

namespace REST___JavaScript_from_user_stories.Managers.Tests
{
    [TestClass()]
    public class RecordsManagerTests
    {
        private RecordsManager _manager = new RecordsManager();

        [TestMethod()]
        public void GetAllTest()
        {
            int actual = _manager.GetAll().Count();
            int expected = 2;

            Assert.AreEqual(actual, expected);
        }

         [TestMethod()]
        public void GetByIdTest()
        {
            Record actual = _manager.GetById(1);
            Record expected = new Record {Id = 1, Title = "Værsgo", Artist = "Kim Larsen", Publication = new DateTime(1973, 5, 1), Duration = 3600};
            Assert.AreEqual(actual, expected);
        }


        [TestMethod()]
        public void AddRecordTest()
        {
            Record record = new Record(3, "Hello", "Bo", 10, new DateTime(1, 1, 1));
            _manager.Add(record);
            int actual = _manager.GetAll().Count();
            int expected = 3;
            Assert.AreEqual(actual, expected);
        }

        [TestMethod()]
        public void DeleteRecordTest()
        {
            _manager.Delete(3);
            int actual = _manager.GetAll().Count();
            int expected = 2;
            Assert.AreEqual(actual, expected);
        }

        [TestMethod()]
        public void UpdateRecordTest()
        {
          
        }


    }
}