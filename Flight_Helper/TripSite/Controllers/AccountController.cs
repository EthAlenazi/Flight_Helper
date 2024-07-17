using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TripSite.ViewModel;

public class AccountController : Controller
{
    private readonly AuthService _authService;

    public AccountController(AuthService authService)
    {
        _authService = authService;
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        var token = await _authService.Login(model.Username, model.Password);

        if (token != null)
        {
            // Store the token in a way that can be accessed for subsequent requests (e.g., session, cookie, etc.)
            HttpContext.Session.SetString("JWToken", token);

            return RedirectToAction("Index", "Home");
        }

        ModelState.AddModelError(string.Empty, "Invalid login attempt.");
        return View();
    }
    [HttpGet]
    public IActionResult Login()
    { return View(); }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (ModelState.IsValid)
        {
            var result = await _authService.Register(model);

            if (!string.IsNullOrEmpty(result))
            {
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError(string.Empty, "Registration failed.");
        }

        return View(model);
    }



}
