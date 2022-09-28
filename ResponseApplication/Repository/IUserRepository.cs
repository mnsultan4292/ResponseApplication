using ResponseApplication.Model;

namespace ResponseApplication.Repository
{
    public interface IUserRepository
    {
        Task<List<UserModel>> GetUserDetails(string url);
    }
}
