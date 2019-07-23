using System.Web.Mvc;

namespace _07._13_2019_mvc_k30.Areas.Admin
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
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { controller="home",action = "Index", id = UrlParameter.Optional },
                new string[] { "_07._13_2019_mvc_k30.Areas.Admin.Controllers" }
            );
        }
    }
}