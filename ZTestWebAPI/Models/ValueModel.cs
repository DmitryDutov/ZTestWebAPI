using System;
using Microsoft.EntityFrameworkCore;
using ZTestWebAPI.Entities.Base.Interface;

namespace ZTestWebAPI.Models
{
    [Index(nameof(Id))]
    public class ValueModel : Entity
    {
        public int Id { get; set; }
        public string? Value { get; set; }
    }
}

