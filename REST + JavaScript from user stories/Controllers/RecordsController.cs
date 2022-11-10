using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using REST___JavaScript_from_user_stories.DBContext;
using REST___JavaScript_from_user_stories.Managers;
using REST___JavaScript_from_user_stories.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace REST___JavaScript_from_user_stories.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecordsController : ControllerBase
    {
        private IRecordsManager _manager;
        //private RecordsManager _manager = new RecordsManager();

        public RecordsController(RecordContext context)
        {
            //DB
             _manager = new DBRecordsManager(context);

            // Non DB
            //_manager = new RecordsManager();
        }

        [EnableCors("AllowAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet]
        public ActionResult<IEnumerable<Record>> Get([FromQuery] string? sort_by)
        {
            IEnumerable<Record> list = _manager.GetAll(sort_by);
            if (list == null || list.Count() == 0)
            {
                return NoContent();
            }
            else
            {
                return Ok(list);
            }
        }

        //GET api/<RecordsController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Record> GetById(int id)
        {
            Record? foundRecord = _manager.GetById(id);
            if (foundRecord == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(foundRecord);
            }
        }

        //// POST api/<RecordsController>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public ActionResult<Record> Post([FromBody] Record newRecord)
        {
            try
            {
                Record createdRecord = _manager.Add(newRecord);
                return Created("/" + createdRecord.Id, createdRecord);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //// PUT api/<RecordsController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{id}")]
        public ActionResult<Record> Put(int id, [FromBody] Record updates)
        {
            try
            {
                Record updatedRecord = _manager.Update(id, updates);
                if (updatedRecord == null)
                {
                    return NotFound();
                }
                return Ok(updatedRecord);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //// DELETE api/<RecordsController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public ActionResult<Record> Delete(int id)
        {
           Record record = _manager.Delete(id);

            if (id != record.Id)
            {
                return NotFound("No such item, id: " + id);
            }
            return Ok(record);
        }
    }
}