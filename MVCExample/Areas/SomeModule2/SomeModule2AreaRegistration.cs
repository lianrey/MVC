using System.Web.Mvc;

namespace MVCExample.Areas.SomeModule2
{
    public class SomeModule2AreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "SomeModule2";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "SomeModule2_default",
                "SomeModule2/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
