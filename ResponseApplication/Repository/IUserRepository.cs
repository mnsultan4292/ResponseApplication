using ResponseApplication.Modal;

namespace ResponseApplication.Repository
{
    public interface IUserRepository
    {
        Task<List<UserModal>> GetUserDetails(string url);
    }
}
