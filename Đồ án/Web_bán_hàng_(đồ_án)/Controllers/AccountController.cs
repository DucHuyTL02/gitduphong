using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_bán_hàng__đồ_án_.Models;

namespace Web_bán_hàng__đồ_án_.Controllers
{
    public class AccountController : Controller
    {

        // GET: LoginRegister
        LTWEntities acc = new LTWEntities();
        [HttpGet]
        public ActionResult Register()
        {
            var model = new RegisterViewModel();
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            var existingUser = acc.Users.FirstOrDefault(u => u.Username == model.UserName);
            if (existingUser != null)
            {
                ModelState.AddModelError("Username", "Username đã được sử dụng. Vui lòng chọn tên khác.");
            }
            var existingEmail = acc.Customers.FirstOrDefault(c => c.CustomerEmail == model.Email);
            if (existingEmail != null)
            {
                ModelState.AddModelError("CustomerEmail", "Email đã được sử dụng. Vui lòng chọn email khác.");
            }
            if (ModelState.IsValid)
            {

                try
                {
                    // Tạo đối tượng User từ dữ liệu của model
                    var user = new User
                    {
                        Username = model.UserName,
                        Password = model.Password,
                        UserRole = "Customer"
                    };

                    // Thêm User vào database
                    acc.Users.Add(user);

                    // Tạo đối tượng Customer từ dữ liệu của model
                    var customer = new Customer
                    {
                        CustomerName = model.CustomerName,
                        CustomerPhone = model.CustomerPhone,
                        CustomerEmail = model.Email,
                        CustomerAddress = model.CustomerAddress,
                        Username = model.UserName // Liên kết với User qua khóa ngoại
                    };

                    // Thêm Customer vào database
                    acc.Customers.Add(customer);

                    // Lưu thay đổi
                    acc.SaveChanges();
                    // Redirect sau khi đăng ký thành công
                    return RedirectToAction("trangchu", "Home");
                }
                catch (Exception ex)
                {
                    ViewBag.ErrorMessage = "Có Lỗi";
                    ModelState.AddModelError("", "Error saving data: " + ex.Message);
                }

            }

                return View(model);
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            var user = acc.Users.SingleOrDefault(u => u.Username == username && u.Password == password);
            if (user != null)
            {
                // Xử lý đăng nhập thành công
                Session["User"] = user.Username;
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Sai tên đăng nhập hoặc mật khẩu");
            return View();
        }

    }
}