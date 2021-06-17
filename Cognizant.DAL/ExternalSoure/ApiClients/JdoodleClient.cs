using Cognizant.BLL.Entities;
using Cognizant.BLL.Results;
using Cognizant.DAL.ExternalSoure.ApiClients.Abstracts;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Cognizant.DAL.ExternalSoure.ApiClients
{
    public class JdoodleClient : IJdoodleClient
    {
        private HttpClient httpClient;
        public JdoodleClient()
        {
            httpClient = new HttpClient();
            httpClient.Timeout = new TimeSpan(0, 0, 0, 5);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<ExecuteResult<ResponseEntity>> Compile(IBaseExecuteCommandRequest baseExecuteCommandRequest)
        {
            try
            {
                var executeResult = await httpClient.PostAsync(baseExecuteCommandRequest.ExecuteUrl, new StringContent(JsonConvert.SerializeObject(baseExecuteCommandRequest)));
                if (executeResult.IsSuccessStatusCode)
                {
                    var content = await executeResult.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<ResponseEntity>(content);
                    return ExecuteResult<ResponseEntity>.Success(result);
                }
                return ExecuteResult<ResponseEntity>.Fail("Compile Request Failed");
            }
            catch (Exception ex)
            {
                return ExecuteResult<ResponseEntity>.Fail(ex.Message);
            }
        }
    }
}
