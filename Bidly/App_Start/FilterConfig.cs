using System.Web;
using System.Web.Mvc;

namespace Bidly
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            // this below redirects users to an error page when the action throws an exception

            filters.Add(new HandleErrorAttribute());

            //apply the authorize tag globally so restricting all controller actions to customers who are logged in ONLY

            //filters.Add(new AuthorizeAttribute());
        }
    }
}
