using System;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Security.Claims;
using gizem_server;
using Microsoft.AspNetCore.Authorization;
using WebRTCServer.Interceptors;
using WebRTCServer.Interfaces;
using WebRTCServer.Models;

namespace WebRTCServer
{
    public class UserListService : gizem_server.UserList.UserListBase
    {
        private readonly ILogger<UserListService> _logger;
        private readonly OnlineListManager _onlineListManager;
        private readonly StreamContext _streamContext;
        private readonly IServerUtil _serverUtil;

        public UserListService(OnlineListManager onlineListManager ,StreamContext streamContext,IServerUtil serverUtil, ILogger<UserListService> logger)
        {
            _onlineListManager = onlineListManager;
            _streamContext = streamContext;
            _serverUtil = serverUtil;
            _logger = logger;
            Debug.WriteLine($"WebRTCSignalService {DateTime.Now}");
        }

        [FrontAuth]
        public override async Task SubscribeListUpdate(SubscribeListUpdateQ request, IServerStreamWriter<SubscribeListUpdateP> responseStream, ServerCallContext context)
        {
            var streamId = _serverUtil.generateStreamId(context.GetHttpContext().User);
            var userid = int.Parse(context.GetHttpContext().User.Identity.Name);

            _streamContext.RegisterStream(streamId,responseStream);
            context.CancellationToken.Register(async ()=>{ 
                _streamContext.UnregisterStream(streamId);
                await _onlineListManager.RemoveFromList(userid);
            });

            await _onlineListManager.AddToList(userid, streamId);
            
             _logger.Info(()=> $"{streamId} subscribed");
             
        }

    }
}
