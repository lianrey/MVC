using System.Web.Mvc;

namespace MVCExample.Areas.SomeModule1
{
    public class SomeModule1AreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "SomeModule1";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "SomeModule1_default",
                "SomeModule1/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
