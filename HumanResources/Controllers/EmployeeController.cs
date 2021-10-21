using HumanResourceWebApis.Models;
using PagedList;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Mvc;

namespace Employees.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index(string sortOrder, int? page, int? status, int? department, int? itemsperpage = 5)
        {
            var pageNumber = page ?? 1;
            var pageSize = (int)itemsperpage;

            IEnumerable<VwEmployeeViewModel> empList;
            HttpResponseMessage response = GlobalVariables.WebApiclient.GetAsync("Employees").Result;
            empList = response.Content.ReadAsAsync<IEnumerable<VwEmployeeViewModel>>().Result;

            ViewBag.statusList = CreateStatusFilterOptions(status);
            ViewBag.departmentsList = CreateDepartmentsFilterOptions(department);
            ViewBag.status = status;
            ViewBag.department = department;
            ViewBag.itemsperpage = itemsperpage;

            if (status > 0)
            {
                empList = empList.Where(c => c.StatusID.Equals(status));
            }

            if (department > 0)
            {
                empList = empList.Where(c => c.DepartmentID.Equals(department));
            }

            return View(empList.OrderBy(x => x.SurName).ToPagedList(pageNumber, pageSize));
        }

        private SelectList CreateStatusFilterOptions(int? status)
        {
            List<StatusViewModel> statusList = new List<StatusViewModel>(){ new StatusViewModel()
            {
                StatusId = 0,
                StatusName = ""
            } };

            HttpResponseMessage response = GlobalVariables.WebApiclient.GetAsync("Status").Result;
            statusList.AddRange(response.Content.ReadAsAsync<IEnumerable<StatusViewModel>>().Result.ToList());

            return new SelectList(statusList, "StatusId", "StatusName", status);
        }

        private SelectList CreateDepartmentsFilterOptions(int? department)
        {
            List<DepartmentViewModel> departmentList = new List<DepartmentViewModel>() { new DepartmentViewModel()
            {
                DepartmentId = 0,
                DepartmentName = ""
            }};

            HttpResponseMessage response = GlobalVariables.WebApiclient.GetAsync("Departments").Result;
            departmentList.AddRange(response.Content.ReadAsAsync<IEnumerable<DepartmentViewModel>>().Result.ToList());

            return new SelectList(departmentList, "DepartmentId", "DepartmentName", department);
        }

        public ActionResult AddOrEdit(int id = 0)
        {
            ViewBag.statusList = CreateStatusFilterOptions(0);
            ViewBag.departmentsList = CreateDepartmentsFilterOptions(0);
            if (id.Equals(0))
            {
                return View(new EmployeeViewModel());
            }

            HttpResponseMessage response = GlobalVariables.WebApiclient.GetAsync("Employees/" + id.ToString()).Result;
            return View(response.Content.ReadAsAsync<EmployeeViewModel>().Result);
        }

        [HttpPost]
        public ActionResult AddOrEdit(EmployeeViewModel emp)
        {
            if (emp.EmployeeId.Equals(0))
            {
                HttpResponseMessage newResponse = GlobalVariables.WebApiclient.PostAsJsonAsync("Employees", emp).Result;
                TempData["SuccessMessage"] = "Saved Successfully";
                return RedirectToAction("Index");
            }

            HttpResponseMessage updateResponse = GlobalVariables.WebApiclient.PutAsJsonAsync("Employees/" + emp.EmployeeId, emp).Result;
            TempData["SuccessMessage"] = "Updated Successfully";
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage newResponse = GlobalVariables.WebApiclient.DeleteAsync("Employees/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}