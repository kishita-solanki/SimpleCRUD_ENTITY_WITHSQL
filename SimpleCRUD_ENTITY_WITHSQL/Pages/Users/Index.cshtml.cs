using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SimpleCRUD_ENTITY_WITHSQL.Data;
using SimpleCRUD_ENTITY_WITHSQL.Model;

namespace SimpleCRUD_ENTITY_WITHSQL.Pages.Users
{
    public class IndexModel : PageModel
    {
        private readonly SimpleCRUD_ENTITY_WITHSQL.Data.SimpleCRUD_ENTITY_WITHSQLContext _context;

        public IndexModel(SimpleCRUD_ENTITY_WITHSQL.Data.SimpleCRUD_ENTITY_WITHSQLContext context)
        {
            _context = context;
        }

        public IList<User> User { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.User != null)
            {
                User = await _context.User.ToListAsync();
            }
        }
    }
}
