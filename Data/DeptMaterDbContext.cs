using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EMS_Full_Stack_App.Model;

namespace EMS_Full_Stack_App.Data
{
    public class DeptMaterDbContext : DbContext
    {
        public DeptMaterDbContext (DbContextOptions<DeptMaterDbContext> options)
            : base(options)
        {
        }

        public DbSet<EMS_Full_Stack_App.Model.DeptMaster> DeptMaster { get; set; } = default!;

        public DbSet<EMS_Full_Stack_App.Model.EmpProfile>? EmpProfile { get; set; }
    }
}
