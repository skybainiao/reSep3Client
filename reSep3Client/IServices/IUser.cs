using reSep3Client.Models;

namespace reSep3Client.IServices
{
    public interface IUser
    {


        Task<bool> RegisterUser(User user);

        Task<User?> LoginUser(User user);


    }
}
