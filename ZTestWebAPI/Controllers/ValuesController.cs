using Microsoft.AspNetCore.Mvc;
using ZTestWebAPI.Models;
using ZTestWebAPI.Moqs;

namespace ZTestWebAPI.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ILogger<ValuesController> _logger;
        public ICollection<ValueModel>? Values { get; set; }

        //Получаем сервисы в конструктор и передаём их в поля класса
        public ValuesController(ILogger<ValuesController> logger, ValuesList values)
        {
            _logger = logger;
            Values = values?.Values;
        }


        //Создадим набор действий в для управления словарём (получение всего набора, получение значения по Id, подсчёт количества, добавить, редактировать, удалить значение по Id)
        [HttpGet] //GET -> "http://localhost:5229/api/values"
        public IActionResult Get() => Ok(Values);

        [HttpGet("{id}")] //GET -> "http://localhost:5229/api/values/5"
        public IActionResult GetById(int id)
        {
            if (!Values.Any(x=>x.Id == id))
            {
                return NotFound();
            }

            return Ok(Values?.FirstOrDefault(x => x.Id == id));
        }

        [HttpGet("count")] //GET -> "http://localhost:5229/api/values/count"
        //public IActionResult Count() => Ok(Values.Count);
        //public ActionResult<int> Count()=> Values.Count();
        public int Count() => Values.Count;

        [HttpPost] //POST -> "http://localhost:5229/api/values"
        [HttpPost("add")] //POST -> "http://localhost:5229/api/values/add"
        public IActionResult Add([FromBody] string Value)
        {
            var id = Values.Count == 0 ? 1 : Values?.Select(x => x).Max().Id + 1;

            var item = new ValueModel
            {
                Id = (int)id, 
                Value = Value
            };
            Values?.Add(item);

            return Ok($"Объект Id:{item.Id}, Value:{item.Value} успушно добавлен");
        }

        [HttpPut("{id}")] //PUT -> "http://localhost:5229/api/values/5"
        public IActionResult Repalace(int id, [FromBody] string Value)
        {
            if (!Values.Any(x=>x.Id == id))
            {
                return NotFound();
            }

            var item = new ValueModel
            {
                Id = (int)id, 
                Value = Value
            };

            Values.Remove(Values.FirstOrDefault(x => x.Id == id));
            Values?.Add(item);

            return Ok($"Объект с Id = {id} был изменен");
        }

        [HttpDelete] //DELETE -> "http://localhost:5229/api/values/5"
        public IActionResult Delete(int id)
        {
            if (!Values.Any(x=>x.Id == id))
            {
                return NotFound();
            }

            var item = Values.FirstOrDefault(x => x.Id == id);
            Values.Remove(item);

            return Ok($"Объект Id:{item.Id}, Value:{item.Value} удален");
        }
    }
}

