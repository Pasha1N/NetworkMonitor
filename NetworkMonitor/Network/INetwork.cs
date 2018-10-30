using System.Threading.Tasks;

namespace NetworkMonitor.Services
{
    internal interface INetwork
    {
        Task<byte[]> GetDataAsync();
    }
}