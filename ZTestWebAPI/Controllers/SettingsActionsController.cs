using Microsoft.AspNetCore.Mvc;

namespace ZTestWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingsActionsController : ControllerBase
    {
        // GET: api/<SettingsActionsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<SettingsActionsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SettingsActionsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {

        }

        // PUT api/<SettingsActionsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }

        // DELETE api/<SettingsActionsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}
