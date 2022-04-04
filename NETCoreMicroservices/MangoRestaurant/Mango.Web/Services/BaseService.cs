namespace Mango.Web.Services
{
    using System.Text;
    using System.Threading.Tasks;
    using Mango.Web.Models;
    using Newtonsoft.Json;

    public class BaseService : IBaseService
    {
        public Response ResponseModel { get; set; }

        protected IHttpClientFactory HttpClient { get; set; }

        public BaseService(IHttpClientFactory httpClient)
        {
            this.HttpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            this.ResponseModel = new Response();
        }

        public async Task<T> SendAsync<T>(ApiRequest apiRequest)
        {
            try
            {
                var client = this.HttpClient.CreateClient("MangoAPI");
                var message = new HttpRequestMessage();
                message.Headers.Add("Accept", "application/json");
                message.RequestUri = new Uri(apiRequest.Url);
                client.DefaultRequestHeaders.Clear();
                
                if (apiRequest.Data != null)
                {
                    message.Content = new StringContent(
                        JsonConvert.SerializeObject(apiRequest.Data),
                        Encoding.UTF8,
                        "application/json");
                }

                switch (apiRequest.ApiType)
                {                    
                    case ServiceDependencies.APIType.POST:
                        message.Method = HttpMethod.Post;
                        break;
                    case ServiceDependencies.APIType.PUT:
                        message.Method = HttpMethod.Put;
                        break;
                    case ServiceDependencies.APIType.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;
                    default:
                        message.Method = HttpMethod.Get;
                        break;
                }

                var response = await client.SendAsync(message);
                var apiContent = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(apiContent);
            }
            catch (Exception ex)
            {
                var response = new Response
                {
                    DisplayMessage = "Error",
                    ErrorMessages = new List<string> { ex.Message },
                    Succeeded = false,
                };

                var res = JsonConvert.SerializeObject(response);
                return JsonConvert.DeserializeObject<T>(res);
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
