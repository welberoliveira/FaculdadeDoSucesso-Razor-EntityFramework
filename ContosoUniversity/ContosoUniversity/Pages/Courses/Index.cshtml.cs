using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ContosoUniversity.Models;
using System.Configuration;
using ContosoUniversity.Data;

namespace ContosoUniversity.Pages.Courses
{
    public class IndexModel : DepartmentNamePageModel
    {
        private readonly SchoolContext _context;
        private readonly IConfiguration Configuration;

        public IndexModel(SchoolContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }

        public PaginatedList<Course> Courses { get;set; }
        public Course Course { get; set; }
        public List<Department> Departments { get; set; }
        public Department Department { get; set; }
                
        public async Task OnGetAsync(int? pageIndex)
        {
            if (_context.Courses != null)
            {
                IQueryable<Course> couseIQ = from c in _context.Courses
                                             select c;

                var pageSize = Configuration.GetValue("PageSize", 4);
                Courses = await PaginatedList<Course>.CreateAsync
                    (
                        couseIQ.AsNoTracking(), pageIndex ?? 1, pageSize
                    );
            }
        }
        public String CourseDepartmentName(int DepartmentID)
        {
            PopulateDepartmentField(_context, DepartmentID);
            return DepartmentNameField;
        }
    }
}
