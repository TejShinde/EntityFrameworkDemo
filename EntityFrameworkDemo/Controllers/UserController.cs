using Microsoft .AspNetCore .Mvc;
using EntityFrameworkDemo .Models;

namespace EntityFrameworkDemo .Controllers
    {
    public class UserController : Controller
        {
        private readonly ApplicationDbContext context;
       // private readonly UserCrud loginService;
        UserCrud dal;
        public UserController ( ApplicationDbContext context )
            {
            this .context = context;
            dal = new UserCrud(this .context); //tightly coupled
            }

        // GET: Register
        public IActionResult Register ()
            {
            return View();
            }

        // POST: Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register ( UserLogin user )
            {
            if ( ModelState .IsValid )
                {
                var result = dal .RegisterUser(user);
                if ( result > 0 )
                    {
                    return RedirectToAction("Index" , "Login");
                    }
                else
                    {
                    ViewBag .ErrorMessage = "Registration failed. Please try again.";
                    }
                }
            return View(user);
            }

        // GET: Login
        public IActionResult Index ()
            {
            return View();
            }

        // POST: Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index ( UserLogin login )
            {
            try
                {
                if ( ModelState .IsValid )
                    {
                    var user = dal .ValidateUser(login);
                    if ( user != null )
                        {
                        // Set session or authentication logic here (if required)
                        return RedirectToAction("Dashboard");
                        }
                    else
                        {
                        ViewBag .ErrorMsg = "Invalid username or password.";
                        return View();
                        }
                    }
                return View(login);
                }
            catch ( Exception ex )
                {
                ViewBag .ErrorMsg = ex .Message;
                return View();
                }
            }

        public IActionResult Dashboard ()
            {
            return View(); // Redirect to a secured dashboard page
            }
        }
    }
