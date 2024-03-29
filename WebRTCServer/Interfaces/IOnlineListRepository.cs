using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebRTCServer.Interfaces
{
    public interface IOnlineListRepository
    {
        public Task<List<Models.OnlineUser>> getOnlineUsers();
        public Task addToOnlineUser(int userid,string streamid);
        public Task removeFromOnlineUser(int userid);

    }
}