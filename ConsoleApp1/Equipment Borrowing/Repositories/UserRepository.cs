using Equipment_Borrowing.Models.Domain;

namespace Equipment_Borrowing.Repositories
{
    public class UserRepository : IUserRepository
    {
        private static readonly List<User> _users = new()
        {
            new User { Id = 1, FirstName = "Admin", LastName = "User", Email = "admin@system.com", Username = "admin", Password = "password123" }
        };

        public User? GetByUsername(string username) =>
            _users.FirstOrDefault(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));

        public void Add(User user)
        {
            user.Id = _users.Any() ? _users.Max(u => u.Id) + 1 : 1;
            _users.Add(user);
        }
    }
}