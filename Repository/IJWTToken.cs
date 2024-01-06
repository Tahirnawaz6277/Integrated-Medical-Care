using imc_web_api.Models;

namespace imc_web_api.Repository
{
    public interface IJWTToken
    {
        string CreateJWTToken(user user, string role);
    }
}