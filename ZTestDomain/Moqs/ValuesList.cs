using ZTestWebAPI.Models;

namespace ZTestWebAPI.Moqs
{
    public class ValuesList
    {
        private List<ValueModel>? _value { get; set; }
        public List<ValueModel>? Values => _value;

        public ValuesList(ValueModel model)
        {
            var list = Enumerable.Range(1, 10)
                                       .Select(i => (Id: i, Value: $"Value-{i}"))
                                       .ToDictionary(v => v.Id, v => v.Value);

            foreach (var item in list)
            {
                model.Id = item.Key;
                model.Value = item.Value;
                _value?.Add(model);
            }

        }
    }
}

