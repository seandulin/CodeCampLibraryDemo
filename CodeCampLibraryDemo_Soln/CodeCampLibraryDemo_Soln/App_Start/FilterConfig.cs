using System.Web;
using System.Web.Mvc;

namespace CodeCampLibraryDemo_Soln
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
