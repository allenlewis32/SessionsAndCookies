using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SessionsAndCookies.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            string? sessionValue = HttpContext.Session.GetString("session");
			if (sessionValue == null)
            {
                HttpContext.Session.SetString("session", "sss");
                Console.WriteLine("New session started");
            }
            else
            {
                Console.WriteLine("Session value retrieved: " + sessionValue!);
            }
            string? cookieValue = Request.Cookies["cookie1"];
			if (cookieValue == null)
            {
                Response.Cookies.Append("cookie1", "ccc", new()
                {
                    Secure = true,
                    SameSite = SameSiteMode.None,
                    HttpOnly = true,
                });
                Console.WriteLine("New cookie created");
            }
            else
            {
                Console.WriteLine("Cookie value: retrieved: " + cookieValue!);
            }
        }
    }
}