using System.Web;
using System.Web.Mvc;

namespace Rico.S02.FirstWebApiTest
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
