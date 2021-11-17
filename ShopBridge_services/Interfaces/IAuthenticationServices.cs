using ShopBridge_dtos;
using System.Threading.Tasks;

namespace ShopBridge_services.Interfaces
{
    public interface IAuthenticationServices
    {
        Task<Response<string>> Login(LoginDto login);
    }
}