using EventManagerWeb.Entity;
using EventManagerWeb.Entity.ViewModels;
using System.Threading.Tasks;

namespace EventManagerWeb.API.Helpers
{
    public interface IUserService
    {
        Task<AuthenticateResponse> Authenticate(AuthenticateRequest authenticateRequest);
    }
}
