using System;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using gizem_server;
using Microsoft.AspNetCore.Authorization;
using WebRTCServer.Interceptors;
using WebRTCServer.Interfaces;
using System.Linq;
using System.Collections;
using WebRTCServer.Models;

namespace WebRTCServer
{
    public class OnlineListManager
    {
        private readonly IOnlineListRepository _userListRepository;
        private readonly StreamContext _streamContext;
        private readonly ILogger<OnlineListManager> _logger;

        public OnlineListManager(IOnlineListRepository userListRepository,StreamContext streamContext,ILogger<OnlineListManager> logger)
        {
            _userListRepository = userListRepository;
            _streamContext = streamContext;
            _logger = logger;
        }

        public async  Task NotifyUserList()
        {
            var onlineUsers = await _userListRepository.getOnlineUsers();
            foreach (var onlineUser1 in onlineUsers)
            {
                var response = new SubscribeListUpdateP();
                foreach (var onlineUser2 in onlineUsers)
                {
                    if (onlineUser2.StreamId != onlineUser1.StreamId)
                    {
                        var userInfo = new UserInfo();
                        userInfo.Userid = onlineUser2.User.id.ToString();
                        userInfo.Username = onlineUser2.User.Name;
                        response.User.Add(userInfo);
                    }
                }
                await _streamContext.Send(onlineUser1.StreamId,response);
            }
            _logger.Info(()=>$"user list notified");
        }
        public async Task AddToList(int userid,String streamid)
        {
            await _userListRepository.addToOnlineUser(userid,streamid);
            await NotifyUserList();
            
            _logger.Info(()=> $"{userid} removed is online");

        }
        public async Task RemoveFromList(int userid)
        {
            await _userListRepository.removeFromOnlineUser(userid);
            await NotifyUserList();
            _logger.Info(()=>$"{userid} removed is offline");

        }
      
    }
}
