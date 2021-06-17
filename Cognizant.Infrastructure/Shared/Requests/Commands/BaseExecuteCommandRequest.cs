using Cognizant.DAL.ExternalSoure.ApiClients.Abstracts;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
namespace Cognizant.Infrastructure.Shared.Requests.Commands
{
    public abstract class BaseExecuteCommandRequest : IBaseExecuteCommandRequest
    {

        private readonly IConfiguration _config;

        public string ClientId => _config.GetSection("JdoodleApi:clientId").Value;
        public string ClientSecret => _config.GetSection("JdoodleApi:clientSecret").Value;
        public string ExecuteUrl => _config.GetSection("JdoodleApi:executeUrl").Value;
        public string Stdin { get; set; }
        public string VersionIndex { get; set; } = "0";
        public string Language { get; set; } = "0";
        public string Script { get; set; }
        public BaseExecuteCommandRequest(IConfiguration configuration)
        {
            _config = configuration;
        }

    }
}
