using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SimpleCRUD_ENTITY_WITHSQL.Data;
using SimpleCRUD_ENTITY_WITHSQL.Model;

namespace SimpleCRUD_ENTITY_WITHSQL.Pages.Users
{
    public class CreateModel : PageModel
    {
        private readonly SimpleCRUD_ENTITY_WITHSQL.Data.SimpleCRUD_ENTITY_WITHSQLContext _context;

        public CreateModel(SimpleCRUD_ENTITY_WITHSQL.Data.SimpleCRUD_ENTITY_WITHSQLContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public User User { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.User == null || User == null)
            {
                return Page();
            }

            _context.User.Add(User);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
