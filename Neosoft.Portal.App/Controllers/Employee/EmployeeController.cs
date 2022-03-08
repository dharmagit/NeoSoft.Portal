using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NeoSoft.Portal.Model;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Neosoft.Portal.App.Controllers
{
    public class EmployeeController : Controller
    {

        public EmployeeController()
        {
            //_context = context;
        }

        // GET: /<controller>/
        //public IActionResult Index()
        //{
        //    return View();
        //}

        // GET: Employee
        public async Task<IActionResult> Index()
        {
            return View();
        }

        // GET: Employee/Create
        public IActionResult AddorEdit(int id = 0)
        {
            if (id == 0)
                return View(new EmployeeMaster());
            else
                return View();
        }

        // POST: Employee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddorEdit([Bind("EmployeeId,FirstName,LastName,Department,EmpCode,Position,Email,OfficeLocation")] EmployeeMaster employee)
        {
            if (ModelState.IsValid)
            {
                //if (employee.EmployeeId == 0)
                //    _context.Add(employee);
                //else
                //    _context.Update(employee);
                //await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employee/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            //var employee = await _context.Employees.FindAsync(id);
            //_context.Employees.Remove(employee);
            //await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
