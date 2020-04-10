using System;
using System.Threading.Tasks;

namespace WeatherNow.Utilities
{
    public interface IRequestProvider
    {
        Task<TResult?> GetAsync<TResult>(string uri) where TResult : class;
    }
}