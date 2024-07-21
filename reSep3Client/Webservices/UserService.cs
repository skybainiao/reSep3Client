using reSep3Client.IServices;
using reSep3Client.Models;
using System.Net.Http.Json;

namespace reSep3Client.Webservices
{
    public class UserService : IUser
    {
        private readonly HttpClient httpClient;

        public UserService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<bool> RegisterUser(User user)
        {
            var response = await httpClient.PostAsJsonAsync("users", user);
            return response.IsSuccessStatusCode;
        }

        public async Task<User?> LoginUser(User user)
        {
            var response = await httpClient.PostAsJsonAsync("users/login", user);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<User>();
            }
            return null;
        }
    }
}
