using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using System.Threading.Tasks;

namespace QLNS.Controllers
{
    public class AccountController : Controller
    {
        // Action hiển thị trang đăng nhập
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // Action xử lý việc đăng nhập
        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            // Thực hiện xác thực người dùng
            if (IsValidUser(username, password))
            {
                // Tạo danh sách Claims cho người dùng
                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, username),
                    // Các claim khác của người dùng (nếu cần)
                };

                // Tạo thông tin đăng nhập
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                // Tạo thông tin xác thực
                var authProperties = new AuthenticationProperties
                {
                    // Cấu hình các thuộc tính xác thực (nếu cần)
                };

                // Đăng nhập người dùng
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

                // Chuyển hướng đến trang sau khi đăng nhập thành công
                return RedirectToAction("Index", "Home");
            }

            // Xác thực không thành công, hiển thị thông báo lỗi
            ModelState.AddModelError("", "Đăng nhập không hợp lệ");
            return View();
        }

        // Action đăng xuất
        public async Task<IActionResult> Logout()
        {
            // Thực hiện đăng xuất
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            // Chuyển hướng đến trang sau khi đăng xuất
            return RedirectToAction("Index", "Home");
        }

        // Phương thức xác thực người dùng (đơn giản chỉ để mô phỏng)
        private bool IsValidUser(string username, string password)
        {
            // Thực hiện kiểm tra xác thực của người dùng (ví dụ: so sánh username và password với cơ sở dữ liệu người dùng)

            // Trong ví dụ này, tôi đơn giản chỉ kiểm tra một tài khoản người dùng cố định
            if (username == "admin" && password == "1")
            {
                return true;
            }

            return false;
        }
    }
}
