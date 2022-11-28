using Newtonsoft.Json;

namespace MVCWebAppCSP.Models
{
    public class CspReportModel
    {
        [JsonProperty("document-uri")] public string DocumentUri { get; set; }
        [JsonProperty("referer")] public string Referer { get; set; }
        [JsonProperty("effective-directive")] public string EffectiveDirective { get; set; }
        [JsonProperty("violated-directive")] public string ViolatedDirective { get; set; }
        [JsonProperty("original-policy")] public string OriginalPolicy { get; set; }
        [JsonProperty("blocked-uri")] public string BlockedUri { get; set; }
        [JsonProperty("source-file")] public string SourceFİle { get; set; }
        [JsonProperty("line-number")] public string LineNumber { get; set; }
        [JsonProperty("column-number")] public string ColumnNumber { get; set; }
        [JsonProperty("status-code")] public string StatusCode { get; set; }
    }
}