using reSep3Client.IServices;
using reSep3Client.Models;
using System.Net.Http.Json;

namespace reSep3Client.Webservices
{
    public class UserService : IUser
    {

        public async Task<bool> RegisterUser(User user)
        {
            using HttpClient httpClient = new();
            var response = await httpClient.PostAsJsonAsync("http://localhost:8080/users", user);
            return response.IsSuccessStatusCode;
        }

        public async Task<User?> LoginUser(User user)
        {
            using HttpClient httpClient = new();
            var response = await httpClient.PostAsJsonAsync("http://localhost:8080/login", user);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<User>();
            }
            else
            {
                return null;
            }
        }

         
    }
}
