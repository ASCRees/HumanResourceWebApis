using HumanResourceWebApis.Models;
using PagedList;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Mvc;
using System.Collections;

namespace Employees.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index(int? page, string status, string department)
        {
            var pageNumber = page ?? 1;
            var pageSize = 2;

            IEnumerable<EmployeeViewModel> empList;
            HttpResponseMessage response = GlobalVariables.WebApiclient.GetAsync("Employees").Result;
            empList = response.Content.ReadAsAsync<IEnumerable<EmployeeViewModel>>().Result;

            var statusList = CreateStatusFilterOptions(status);
            var departmentList = CreateDepartmentsFilterOptions(department);

            ViewBag.statusList = statusList;
            ViewBag.departmentsList = departmentList;
            ViewBag.status = status;
            ViewBag.department = department;

            if (!string.IsNullOrWhiteSpace(status))
            {
                var statusItems = statusList.Items.Cast<SelectListItem>().ToList();

                var statusText = statusItems.FirstOrDefault(c => c.Value.Equals(status));

                empList = empList.Where(c => c.Status != null && c.Status.Equals(statusText.Text));
            }

            if (!string.IsNullOrWhiteSpace(department))
            {
                var departmentItems = departmentList.Items.Cast<SelectListItem>().ToList();

                var departmentText = departmentItems.FirstOrDefault(c => c.Value.Equals(department));

                empList = empList.Where(c => c.Department != null && c.Department.Equals(departmentText.Text));
            }

            return View(empList.OrderBy(x => x.Name).ToPagedList(pageNumber, pageSize));
        }

        private SelectList CreateStatusFilterOptions(string status)
        {
            List<SelectListItem> list = new List<SelectListItem>();

            list.Add(new SelectListItem()
            {
                Text = "",
                Value = ""
            });
            list.Add(new SelectListItem()
            {
                Text = "Senior",
                Value = "S"
            });
            list.Add(new SelectListItem()
            {
                Text = "Mid Level",
                Value = "M"
            });
            list.Add(new SelectListItem()
            {
                Text = "Junior",
                Value = "J"
            });
            list.Add(new SelectListItem()
            {
                Text = "Advanced",
                Value = "A"
            });

            return new SelectList(list, "Value", "Text", status);
        }

        private SelectList CreateDepartmentsFilterOptions(string department)
        {
            List<SelectListItem> list = new List<SelectListItem>();

            list.Add(new SelectListItem()
            {
                Text = "",
                Value = ""
            });
            list.Add(new SelectListItem()
            {
                Text = "IT",
                Value = "I"
            });
            list.Add(new SelectListItem()
            {
                Text = "Marketing",
                Value = "M"
            });
            list.Add(new SelectListItem()
            {
                Text = "Administration",
                Value = "A"
            });
            list.Add(new SelectListItem()
            {
                Text = "Sales",
                Value = "S"
            });

            return new SelectList(list, "Value", "Text", department);
        }

        public ActionResult AddOrEdit(int id = 0)
        {
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
            if (emp.EmployeeID.Equals(0))
            {
                HttpResponseMessage newResponse = GlobalVariables.WebApiclient.PostAsJsonAsync("Employees", emp).Result;
                TempData["SuccessMessage"] = "Saved Successfully";
                return RedirectToAction("Index");
            }

            HttpResponseMessage updateResponse = GlobalVariables.WebApiclient.PutAsJsonAsync("Employees/" + emp.EmployeeID, emp).Result;
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