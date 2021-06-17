using Cognizant.DAL.ExternalSoure.ApiClients.Abstracts;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
namespace Cognizant.Infrastructure.Shared.Requests.Commands
{
    public abstract class BaseExecuteCommandRequest : IBaseExecuteCommandRequest
    {

        public string ClientId => _clientId;
        public string ClientSecret => _clientSecret;
        public string ExecuteUrl => _executeUrl;
        public string Stdin { get; set; }
        public string VersionIndex { get; set; } = "0";
        public string Language { get; set; } = "java";
        public string Script { get; set; }

        private string _clientId;
        private string _clientSecret;

        private string _executeUrl;

        public void SetParameters(string clientId, string clientSecret, string executeUrl)
        {
            _clientId = clientId;
            _clientSecret = clientSecret;
            _executeUrl = executeUrl;
        }
    }
}