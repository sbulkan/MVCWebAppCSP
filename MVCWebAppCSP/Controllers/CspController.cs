using MVCWebAppCSP.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;

namespace MVCWebAppCSP.Controllers
{
    public class CspController : Controller
    {
        [HttpPost]
        public void CspReport()
        {
            AddCspReportLog(Request.InputStream);
        }

        private void AddCspReportLog(Stream inputStream)
        {
            try
            {
                var cspModelFromRequest = DeserializeReportObject(inputStream);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private object DeserializeReportObject(Stream inputStream)
        {
            try
            {
                inputStream.Seek(0, SeekOrigin.Begin);
                using (var streamReader = new StreamReader(inputStream))
                {
                    var cspJson = streamReader.ReadToEnd();

                    if (cspJson == string.Empty)
                        return null;

                    var cspReportModel = System.Text.Json.JsonSerializer.Deserialize<CspReportRequestModel>(cspJson);

                    //You Can Log model here like

                    Dictionary<string, object> keyValuePairs = new Dictionary<string, object>()
                    {
                        {"BlockedUri", cspReportModel.CspReport.BlockedUri },
                        {"ViolatedDirective", cspReportModel.CspReport.ViolatedDirective },
                        {"DocumentUri", cspReportModel.CspReport.DocumentUri },
                        {"StatusCode", cspReportModel.CspReport.StatusCode },
                        {"Referer", cspReportModel.CspReport.Referer },
                        {"ClientIp", GetClientIp() }
                    };

                    return cspReportModel;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private string GetClientIp()
        {
            return HttpContext.Request.ServerVariables["HTTP_CLIENT_IP"] ?? HttpContext.Request.UserHostAddress ?? string.Empty;
        }
    }
}