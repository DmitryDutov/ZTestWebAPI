using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ZTestWebAPI.Models;
using ZTestWebAPI.Moqs;

namespace ZTestWebDAL.Context
{
    public class ZTestDb: DbContext
    {
        public DbSet<ValueModel> ValuesSet { get; set; } 
        public DbSet<ValuesList> ValuesListSet { get; set; } 
        public ZTestDb(DbContextOptions<ZTestDb> options):base(options)
        {
        }
    }
}

