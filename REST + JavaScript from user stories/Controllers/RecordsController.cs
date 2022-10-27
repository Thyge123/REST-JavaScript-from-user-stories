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
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IEnumerable<Record> Get([FromQuery] string? sort_by)
        {
            return _manager.GetAll(sort_by);
        }

        // GET api/<RecordsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<RecordsController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Record> Post([FromBody] Record value)
        {
            try
            {
                _manager.Add(value);
                string uri = Url.RouteUrl(RouteData.Values) + "/" + value.Id;
                return Created(uri, value);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
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