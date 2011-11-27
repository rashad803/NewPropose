using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewPropose.DataAccess.IRepository;

namespace NewPropose.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public ActionResult Index()
        {
            var model = _employeeRepository.GetAll();
            return View(model);
        }

    }
}
