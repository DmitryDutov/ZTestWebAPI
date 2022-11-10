using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTestWebAPI.Moqs
{
    public class ValuesMoq
    {
        //Создаём нумерованный словарь и заполняем его
        public  Dictionary<int, string> Values = Enumerable .Range(1, 10) 
                                                                  .Select(i => (Id: i, Value: $"Value-{i}")) 
                                                                  .ToDictionary(v => v.Id, v => v.Value);

        public Dictionary<int, string>.KeyCollection Keys => Values.Keys;

        public int Count => Values.Count;

        public bool GetKey(int key)
        {
            return Values.ContainsKey(key);
        }

        public string GetValueById(int id)
        {
            return Values[id];
        }

        public string AddValue(int id, string value)
        {
            Values[id] = value;
            return Values[id];
        }

        public void Remove(int id)
        {
            Values.Remove(id);
        }
    }
}

