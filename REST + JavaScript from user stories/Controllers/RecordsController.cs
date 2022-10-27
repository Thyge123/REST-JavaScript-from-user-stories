using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using REST___JavaScript_from_user_stories.Managers;
using REST___JavaScript_from_user_stories.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace REST___JavaScript_from_user_stories.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecordsController : ControllerBase
    {

        private RecordsManager _manager = new RecordsManager();

       
        // GET: api/<RecordsController>
        [HttpGet]
        //[EnableCors("allowAll")]
        public IEnumerable<Record> Get([FromQuery] string ?title, [FromQuery] string ?sort_by)
        {
            return _manager.GetAll(title, sort_by);
        }

        // GET api/<RecordsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<RecordsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<RecordsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RecordsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
