using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ContosoUniversity.Models;
using System.Globalization;

namespace ContosoUniversity.Pages.Departments
{
    public class IndexModel : PageModel
    {
        private readonly ContosoUniversity.Data.SchoolContext _context;

        public IndexModel(ContosoUniversity.Data.SchoolContext context)
        {
            _context = context;
        }

        public IList<Department> Departments { get;set; } = default!;
        public Department Department { get; set; }

        public async Task OnGetAsync()
        {
            if (_context.Departments != null)
            {
                Departments = await _context.Departments
                .Include(d => d.Administrator).ToListAsync();
            }
        }
    }
}
