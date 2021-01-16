using System.Collections.Concurrent;
using System.Threading.Tasks;
using WebRTCServer.Interfaces;
using WebRTCServer.Models;

namespace WebRTCServer.Mock
{
    public class UserRepositoryMock:IUserRepository
    {
        public UserRepositoryMock()
        {
            _users.TryAdd("ahmet", new User() {id = 1, Name = "ahmet"});
            _users.TryAdd("dhewy", new User() {id = 2, Name = "dhewy"});
        }

        private ConcurrentDictionary<string, User> _users = new ConcurrentDictionary<string, User>();
        public Task<User> getUserByName(string name)
        {
            return Task.FromResult(_users[name]);
        }
    }
}