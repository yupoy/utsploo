using System.Web;
using System.Web.Mvc;

namespace UTS_PLOO_151524032_YudisthiraPoyoh
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
