using System;
using ZTestWebAPI.Entities.Base.Interface;

namespace ZTestWebAPI.Models
{
    public class ValueModel : Entity
    {
        public int Id { get; set; }
        public string? Value { get; set; }
    }
}

