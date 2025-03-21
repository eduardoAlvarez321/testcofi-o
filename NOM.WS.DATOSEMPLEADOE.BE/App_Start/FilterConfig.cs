using System.Web;
using System.Web.Mvc;

namespace NOM.WS.DATOSEMPLEADOE.BE
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
