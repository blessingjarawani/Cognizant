using Cognizant.DAL.ExternalSoure.ApiClients;
using Cognizant.DAL.ExternalSoure.ApiClients.Abstracts;
using Cognizant.Infrastructure.Shared.Requests.Commands;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Cognizant.TESTS
{
    public class Tests
    {
        private IJdoodleClient _jdoodleClient;
        IBaseExecuteCommandRequest _executeCommandRequest;
        [SetUp]

        public void Setup()
        {
            _jdoodleClient = new JdoodleClient();
            _executeCommandRequest = new CompileCommand();
            _executeCommandRequest.SetParameters(clientId: "8fda6bc1191f7f442aef06970b64d237",
                                                 clientSecret: "5293cd08bd29bccc4a131f8ef9ec57baafe2c4e43dcca96d642efe988481c320",
                                                 executeUrl: "https://api.jdoodle.com/v1/execute");

        }

        [Test]
        public async Task ShouldReturnSucessOnCsharp()
        {
            _executeCommandRequest.Language = "csharp";
            _executeCommandRequest.VersionIndex = "0";
            _executeCommandRequest.Script = @"using System;
                                            class GFG
                                              {    static int sum(int[] arr, int n)
                                              { int sum = 0; 

          for (int i = 0; i < n; i++)
                    sum += arr[i];

                return sum;
            }

            // Driver method
            public static void Main()
            {

                int[] arr = { 12, 3, 4, 15 };
                int n = arr.Length;
              Console.Write(sum(arr, n));
            }

        }";
            var result = await _jdoodleClient.Compile(_executeCommandRequest);
            Assert.IsTrue(result.IsSuccess);
            Assert.IsTrue(!string.IsNullOrWhiteSpace(result.Result.Output));
         
        }
    }
}