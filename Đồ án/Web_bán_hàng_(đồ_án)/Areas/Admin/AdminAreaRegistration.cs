using System.Web.Mvc;

namespace Web_bán_hàng__đồ_án_.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                  return "Admin"; 
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
              name:  "Admin_default",
             url:   "Admin/{controller}/{action}/{id}",
              defaults:  new { action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "Web_bán_hàng__đồ_án_.Areas.Admin.Controllers" } // Đặt namespace cho Area Admin

            );
        }
    }
}