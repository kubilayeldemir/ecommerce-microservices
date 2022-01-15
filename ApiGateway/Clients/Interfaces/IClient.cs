using System.Threading.Tasks;

namespace Clients.Interfaces
{
    public interface IClient
    {
        public Task<T> GetAsync<T>(string endpoint);
        public Task<T> PostAsync<T>(string endpoint, object body);
        public Task<T> DeleteAsync<T>(string endpoint);
        public void SetBaseAddress(string baseAddress);
    }
}