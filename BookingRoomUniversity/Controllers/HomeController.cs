using System.Diagnostics;
using System.Security.Claims;
using BookingRoomUniversity.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using BookingRoomUniversityService.ManageUserService;
using BookingRoomUniversityRepository.Repositories.Models.Responses;

namespace BookingRoomUniversity.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAuthService _authService;

        public HomeController(IAuthService authService)
        {
            _authService = authService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View("Index");
        }



        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            try
            {
                UserResponse userResponse = await _authService.LoginAsync(email, password);

                if (userResponse != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, userResponse.Email),
                        new Claim(ClaimTypes.Role, userResponse.RoleName)
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var authProperties = new AuthenticationProperties { IsPersistent = true };

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity), authProperties);

                    if (userResponse.RoleName == "Admin" || userResponse.RoleName == "Manager")
                    {
                        return Redirect("https://localhost:5003");
                    }

                    return View("Home");
                }

                return Login();

            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Invalid email or password.";
                return View();
            }
        }




        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
