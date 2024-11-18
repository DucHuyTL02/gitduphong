using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_bán_hàng__đồ_án_.Models;

namespace Web_bán_hàng__đồ_án_.Controllers
{
    public class ProductController : Controller
    {
        LTWEntities csdl = new LTWEntities();   
        // GET: Product
        public ActionResult Details(int? id)
        {
            var product = csdl.Products.FirstOrDefault(i => i.CategoryID == id);
            if (product == null)
            {
                return HttpNotFound();
            }

            return View(product);
        }

        public ActionResult Xacnhan()
        {
            return View();
        }

        public ActionResult Thanhtoan()
        {
            var cartItems = new List<Product>
            {
                new Product
                {
                    ProductID = 1,
                    ProductName = "Sách - Vì Con Gái Tôi Có Thể Đánh Bại Cả Ma Vương (Tập 6)",
                    ProductImage= "/images/book1.jpg",
                    ProductPrice = 435000,
                    StockQuantityPro = 1,
                  
                },
                new Product
                {
                    ProductID = 2,
                    ProductName = "Bàn phím không dây DYM 303 công thái học",
                    ProductImage = "/images/keyboard1.jpg",
                    ProductPrice = 252000,
                    StockQuantityPro = 1,
                },
                new Product
                {
                    ProductID = 3,
                    ProductName = "Livestreams Bộ bàn phím chuột không dây gaming 2.4Ghz",
                    ProductImage = "/images/keyboard2.jpg",
                    ProductPrice = 206000,
                    StockQuantityPro = 1,
                }
            };

            return View(cartItems);
        }
    
        public ActionResult Giohang()
        {
            return View();
        }
   [HttpPost]
        public ActionResult UpdateQuantity(int id, int quantity)
        {
            return View();
        }

        [HttpPost]
        public ActionResult RemoveItem(int id)
        {
            return View();
        }
    }
}