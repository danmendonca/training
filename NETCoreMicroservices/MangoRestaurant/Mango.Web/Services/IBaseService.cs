namespace Mango.Web.Services
{
    using Mango.Web.Models;

    public interface IBaseService : IDisposable
    {
        Response ResponseModel { get; set; }
        Task<T> SendAsync<T>(ApiRequest apiRequest);
    }
}
