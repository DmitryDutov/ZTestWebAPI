using Microsoft.AspNetCore.Mvc;
using ZTestWebAPI.Moqs;

namespace ZTestWebAPI.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ILogger<ValuesController> _logger;
        public ValuesMoq Values { get; set; }

        //Получаем сервисы в конструктор и передаём их в поля класса
        public ValuesController(ILogger<ValuesController> logger, ValuesMoq values)
        {
            _logger = logger;
            Values = values;
        }


        //Создадим набор действий в для управления словарём (получение всего набора, получение значения по Id, подсчёт количества, добавить, редактировать, удалить значение по Id)
        [HttpGet] //GET -> http://localhost:5229/api/values
        public IActionResult Get() => Ok(Values.Values);

        [HttpGet("{id}")] //GET -> http://localhost:5229/api/values/5
        public IActionResult GetById(int id)
        {
            if (!Values.GetKey(id))
            {
                return NotFound();
            }

            return Ok(Values.GetValueById(id));
        }

        [HttpGet("count")] //GET -> http://localhost:5229/api/values/count
        //public IActionResult Count() => Ok(Values.Count);
        //public ActionResult<int> Count()=> Values.Count();
        public int Count() => Values.Count;

        [HttpPost] //POST -> http://localhost:5229/api/values
        [HttpPost("add")] //POST -> http://localhost:5229/api/values/add
        public IActionResult Add([FromBody] string Value)
        {
            var id = Values.Count == 0 ? 1 : Values.Keys.Max() + 1;
            Values.AddValue(id, Value);

            return CreatedAtAction(nameof(GetById), new { id });
        }

        [HttpPut("{id}")] //PUT -> http://localhost:5229/api/values/5
        public IActionResult Repalace(int id, [FromBody] string Value)
        {
            if (!Values.GetKey(id))
            {
                return NotFound();
            }

            Values.AddValue(id, Value);

            return Ok();
        }

        [HttpDelete] //DELETE -> http://localhost:5229/api/values/5
        public IActionResult Delete(int id)
        {
            if (!Values.GetKey(id))
            {
                return NotFound();
            }

            Values.Remove(id);

            return Ok();
        }
    }
}

