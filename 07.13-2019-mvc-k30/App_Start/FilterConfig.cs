using System.Web;
using System.Web.Mvc;

namespace _07._13_2019_mvc_k30
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
