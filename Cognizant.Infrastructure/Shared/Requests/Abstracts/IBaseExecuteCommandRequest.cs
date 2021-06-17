using Newtonsoft.Json;
namespace Cognizant.Infrastructure.Shared.Requests.Abstracts
{
    public interface IBaseExecuteCommandRequest
    {

        [JsonProperty("clientId")]
        public string ClientId { get; }
        [JsonProperty("clientSecret")]
        public string ClientSecret { get; }
        [JsonProperty("stdin")]
        public string Stdin { get; set; }
        [JsonProperty("versionIndex")]
        public string VersionIndex { get; set; }
        [JsonProperty("script")]
        public string Script { get; set; }
        [JsonProperty("language")]
        public string Language { get; set; }
        public string ExecuteUrl { get; }
    }
}
