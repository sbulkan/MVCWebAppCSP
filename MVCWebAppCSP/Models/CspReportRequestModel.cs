
using Newtonsoft.Json;

namespace MVCWebAppCSP.Models
{
    public class CspReportRequestModel
    {
        [JsonProperty("csp-report")] public CspReportModel CspReport { get; set; }
    }
}