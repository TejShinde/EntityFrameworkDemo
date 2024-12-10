using EntityFrameworkDemo .Models;
using FilterDemo .Models;
using Microsoft .AspNetCore .Http;
using Microsoft .AspNetCore .Mvc;

namespace EntityFrameworkDemo .Controllers
    {
    public class EmployeeController : Controller
        {
        // GET: EmployeeController
        [UserLog]

        private readonly ApplicationDbContext context;
        EmployeeEF_CRUD db;

        // constructor
        public EmployeeController ( ApplicationDbContext context )
            {
            this .context = context;
            db = new EmployeeEF_CRUD(this .context);
            }

        //ALL EMPLOYEE
        public ActionResult Index ()
            {
            var response = db .GetEmployees();
            return View(response);

            }

        // GET: EmployeeController/Details/5
        public ActionResult Details ( int id )
            {
            var res = db .GetEmployeeById(id);
            return View(res);
            }

        // GET: EmployeeController/Create
        public ActionResult Create ()
            {
            return View();
            }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create ( IFormCollection collection )
        //    {
        //    try
        //        {
        //        return RedirectToAction(nameof(Index));
        //        }
        //    catch
        //        {
        //        return View();
        //    }
        //    }
        public ActionResult Create ( EmployeeEF emp )
            {
            try
                {
                int response = db .AddEmployee(emp);
                if ( response >= 1 )
                    {
                    return RedirectToAction(nameof(Index));
                    }
                else
                    {
                    ViewBag .ErrorMsg = "Something went wrong";
                    return View();
                    }
                }

            catch ( Exception ex )
                {
                ViewBag .ErrorMsg = ex .Message;
                return View();

                }
            }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit ( int id )
            {
            var res = db .GetEmployeeById(id);
            return View(res);
            }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Edit ( int id , IFormCollection collection )
        //    {
        //    try
        //        {
        //        return RedirectToAction(nameof(Index));
        //        }
        //    catch
        //        {
        //        return View();
        //        }
        //    }
        public ActionResult Edit ( EmployeeEF emp )
            {
            try
                {
                int response = db .UpdateEmployee(emp);
                if ( response >= 1 )
                    {
                    return RedirectToAction(nameof(Index));
                    }
                else
                    {
                    ViewBag .ErrorMsg = "Something went wrong";
                    return View();
                    }

                }
            catch ( Exception ex )
                {
                ViewBag .ErrorMsg = ex .Message;
                return View();
                }
            }

        // GET: EmployeeController/Delete/5
        public ActionResult Delete ( int id )
            {
            var res = db .GetEmployeeById(id);
            return View(res);
            }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")] // this inform to CLR that DeleteConfirm is the HttpPost method against Delete
        public ActionResult DeleteConfirm ( int id )
            {
            try
                {
                int response = db .DeleteEmployee(id);
                if ( response >= 1 )
                    {
                    return RedirectToAction(nameof(Index));
                    }
                else
                    {
                    ViewBag .ErrorMsg = "Something went wrong";
                    return View();
                    }
                }
            catch ( Exception ex )
                {
                ViewBag .ErrorMsg = ex .Message;
                return View();
                }
            }
        }
    }
