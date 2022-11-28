using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MVCWebAppCSP
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            AddCspHeader(HttpContext.Current.Response);
        }

        /// <summary>
        /// csp header created with this method
        /// </summary>
        /// <param name="response"></param>
        private void AddCspHeader(HttpResponse response)
        {
            var cspDomains = "";

            //csp report only
            response.AddHeader("Content-Security-Policy-Report-Only", string.Format("default-src data: 'self' 'unsafe-inline' 'unsafe-eval' {0}; style-src 'unsafe-inline' " +
                "{0}; object-src 'none'; report-uri /csp/cspreport", cspDomains));

            //just csp
            response.AddHeader("Content-Security-Policy", string.Format("default-src data: 'self' 'unsafe-inline' 'unsafe-eval' {0}; style-src 'unsafe-inline' " +
                "{0}; object-src 'none'; report-uri /csp/cspreport", cspDomains));
        }
    }
}
