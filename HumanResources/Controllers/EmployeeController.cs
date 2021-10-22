using HumanResources.ModelBuilder;
using HumanResourceWebApis.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Mvc;

namespace Employees.Controllers
{
    public class EmployeeController : Controller
    {
        internal static readonly log4net.ILog Log = log4net.LogManager.GetLogger(typeof(EmployeeController));

        private readonly IEmployeeModelBuilder _employeeModelBuilder;

        public EmployeeController(IEmployeeModelBuilder employeeModelBuilder)
        {
            _employeeModelBuilder = employeeModelBuilder;
        }

        // GET: Employee
        public ActionResult Index(int? page, int? status, int? department, int? itemsperpage = 5, string sortOrder = "N")
        {
            try
            {
                var pageNumber = page ?? 1;
                var pageSize = (int)itemsperpage;

                ViewBag.statusList = _employeeModelBuilder.CreateStatusFilterOptions(status);
                ViewBag.departmentsList = _employeeModelBuilder.CreateDepartmentsFilterOptions(department);
                ViewBag.status = status;
                ViewBag.department = department;
                ViewBag.itemsperpage = itemsperpage;
                ViewBag.sortOrder = sortOrder;

                IEnumerable<VwEmployeeViewModel> employeeList = _employeeModelBuilder.BuildEmployeeList(sortOrder, status, department);

                return View(employeeList.ToPagedList(pageNumber, pageSize));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return Redirect("~/ErrorHandler");
            }
        }

        public ActionResult AddOrEdit(int id = 0)
        {
            try
            {
                ViewBag.statusList = _employeeModelBuilder.CreateStatusFilterOptions(0);
                ViewBag.departmentsList = _employeeModelBuilder.CreateDepartmentsFilterOptions(0);
                if (id.Equals(0))
                {
                    return View(new EmployeeViewModel());
                }

                HttpResponseMessage response = GlobalVariables.WebApiclient.GetAsync("Employees/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<EmployeeViewModel>().Result);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return Redirect("~/ErrorHandler");
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(EmployeeViewModel emp)
        {
            try
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
            catch (Exception ex)
            {
                Log.Error(ex);
                return Redirect("~/ErrorHandler");
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                HttpResponseMessage newResponse = GlobalVariables.WebApiclient.DeleteAsync("Employees/" + id.ToString()).Result;
                TempData["SuccessMessage"] = "Deleted Successfully";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return Redirect("~/ErrorHandler");
            }
        }
    }
}