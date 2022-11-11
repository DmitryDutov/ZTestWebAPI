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

        //    public int Max
        //    {
        //        get
        //        {
        //            int? obj = _value?.Find(x => x.Id == Max).Id;

        //            return obj == null ? 0 : obj.Value;
        //        }
        //    }

        //    public int Count => Values.Count;

        //    public bool GetKey(int key)
        //    {
        //        var info = _value.Any(x => x.Id == key);

        //        return info;
        //    }

        //    public string? GetValueById(int id)
        //    {
        //        return Values?.Find(x => x.Id == id).Value;
        //    }

        //    public ValueModel AddValue(int id, string value)
        //    {
        //        var model = new ValueModel
        //        {
        //            Id = id,
        //            Value = value
        //        };

        //        return model;
        //    }

        //    public void Remove(int id)
        //    {
        //        Values.Remove(Values?.Find(x => x?.Id == id));
        //    }
    }
}

