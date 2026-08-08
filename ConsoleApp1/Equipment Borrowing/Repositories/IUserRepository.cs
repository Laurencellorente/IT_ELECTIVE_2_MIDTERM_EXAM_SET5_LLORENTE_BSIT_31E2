using Equipment_Borrowing.Models.Domain;

namespace Equipment_Borrowing.Repositories
{
    public interface IUserRepository
    {
        User? GetByUsername(string username);
        void Add(User user);
    }
}