using AppService.Api.RequestResponse.Enums;
using AppService.Api.RequestResponse.Requests;
using AppService.Api.RequestResponse.Response;
using AppService.Api.Tables;
using System.Collections;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace AppClient
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var request1 = BuildRequest1();
            var response1 = SendPost(request1);

            var request2 = BuildRequest2();
            var response2 = SendPost(request2);

        }

        static Request BuildRequest1()
        {
            var requestGet = new RequestGet()
            {
                OrderProperty = nameof(Book.Name),
                OrderDirection = OrderDirection.Ascending,
                Filters = new List<RequestFilter>()
                {
                    new RequestFilter() { PropertyName = nameof(Book.Type), Comparer = AppService.Api.RequestResponse.Enums.Comparer.Equal, Value = "2" }
                }
            };

            return new Request()
            {
                EntityName = nameof(Book),
                MethodName = "Get",
                InnerRequestJson = JsonSerializer.Serialize(requestGet)
            };
        }


        static Request BuildRequest2()
        {
            var requestGet = new RequestGet()
            {
                OrderProperty = nameof(Book.PublicationDate),
                OrderDirection = OrderDirection.Ascending,
                Filters = new List<RequestFilter>()
                {
                    new RequestFilter() { PropertyName = nameof(Book.Pages), Comparer = AppService.Api.RequestResponse.Enums.Comparer.Greater, Value = "100" }
                }
            };

            return new Request()
            {
                EntityName = nameof(Book),
                MethodName = "Get",
                InnerRequestJson = JsonSerializer.Serialize(requestGet)
            };
        }



        static Response? SendPost(Request request)
        {
            try
            {

                using (var httpClient = new HttpClient())
                {
                    var jsonContent = System.Net.Http.Json.JsonContent.Create(request);

                    var response = httpClient.PostAsync("http://localhost:5087/service", jsonContent);
                    var responseString = response.Result.Content.ReadAsStringAsync();

                    var responseJson = responseString.Result;
                    return JsonSerializer.Deserialize<Response>(responseJson);

                }

            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
                return null;
            }
        }

    }
}