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
    public class DetailsModel : PageModel
    {
        private readonly SimpleCRUD_ENTITY_WITHSQL.Data.SimpleCRUD_ENTITY_WITHSQLContext _context;

        public DetailsModel(SimpleCRUD_ENTITY_WITHSQL.Data.SimpleCRUD_ENTITY_WITHSQLContext context)
        {
            _context = context;
        }

      public User User { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.User == null)
            {
                return NotFound();
            }

            var user = await _context.User.FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            else 
            {
                User = user;
            }
            return Page();
        }
    }
}
