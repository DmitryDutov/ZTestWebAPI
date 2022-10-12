using Microsoft.AspNetCore.Mvc;

namespace ZTestWebAPI.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ILogger<ValuesController> _logger;

        //Получаем сервисы в конструктор и передаём их в поля класса
        public ValuesController(ILogger<ValuesController> logger)
        {
            _logger = logger;
        }

        //Создаём нумерованный словарь и заполняем его
        private static readonly Dictionary<int, string> Values = Enumerable
            .Range(1, 10)
            .Select(i => (Id: i, Value: $"Value-{i}"))
            .ToDictionary(v => v.Id, v => v.Value);

        //Создадим набор действий в для управления словарём (получение всего набора, получение значения по Id, редактировать, удалить значение по Id)
        [HttpGet] //GET -> http://localhost:5000/api/values
        public IActionResult Get() => Ok(Values.Values);

        [HttpGet]//GET -> http://localhost:5000/api/values/5
        public IActionResult Get(int Id)
        {
            if (!Values.ContainsKey(Id))
            {
                return NotFound();
            }

            return Ok(Values[Id]);
        }
    }
}

