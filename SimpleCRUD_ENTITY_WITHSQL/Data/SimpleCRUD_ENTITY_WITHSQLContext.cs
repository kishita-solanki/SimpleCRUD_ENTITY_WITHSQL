using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimpleCRUD_ENTITY_WITHSQL.Model;

namespace SimpleCRUD_ENTITY_WITHSQL.Data
{
    public class SimpleCRUD_ENTITY_WITHSQLContext : DbContext
    {
        public SimpleCRUD_ENTITY_WITHSQLContext (DbContextOptions<SimpleCRUD_ENTITY_WITHSQLContext> options)
            : base(options)
        {
        }

        public DbSet<SimpleCRUD_ENTITY_WITHSQL.Model.User> User { get; set; } = default!;
    }
}
