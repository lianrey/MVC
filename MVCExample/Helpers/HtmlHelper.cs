using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCExample.Helpers
{
    public static class HtmlHelpers
    {
        public static MvcHtmlString submitButton(this HtmlHelper helper, string value)
        {
            string button = String.Format("<input type='submit' value='{0}'></input>",value);            
            return new MvcHtmlString(button);
        }
    }
}