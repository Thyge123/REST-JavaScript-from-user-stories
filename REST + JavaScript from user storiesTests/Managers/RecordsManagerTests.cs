using Microsoft.VisualStudio.TestTools.UnitTesting;
using REST___JavaScript_from_user_stories.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REST___JavaScript_from_user_stories.Managers.Tests
{
    [TestClass()]
    public class RecordsManagerTests
    {
        private RecordsManager _manager = new RecordsManager();

        [TestMethod()]
        public void GetAllTest()
        {
            int actual = _manager.GetAll().Count;
            int expected = 2;

            Assert.AreEqual(actual, expected);
        }
    }
}