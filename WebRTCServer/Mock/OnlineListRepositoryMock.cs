using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebRTCServer.Interfaces;
using WebRTCServer.Models;

namespace WebRTCServer.Mock
{
    public class OnlineListRepositoryMock:IOnlineListRepository
    {
        private ConcurrentDictionary<int, OnlineUser> _users = new ConcurrentDictionary<int, OnlineUser>();

        public Task<List<OnlineUser>> getOnlineUsers()
        {
            return Task.FromResult(_users.Values.ToList<OnlineUser>());
        }

        public Task addToOnlineUser(int userid, string streamid)
        {
            _users.TryAdd(userid, new OnlineUser()
            {
                StreamId = streamid, 
                User = new User()
                {
                    id = userid,
                    Name = "?????"
                }
            });
            return Task.CompletedTask;
        }

        public  Task removeFromOnlineUser(int userid)
        {
           return Task.FromResult(_users.TryRemove(userid,out OnlineUser old));
        }
    }
}