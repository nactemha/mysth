using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Grpc.Core;
using Grpc.Net.Client;
using WebRTCServer.Interfaces;

namespace WebRTCServer.Utils
{
    public class ServerUtil:IServerUtil
    {
        private static ConcurrentDictionary<int,GrpcChannel> _channels = new ConcurrentDictionary<int, GrpcChannel>();
        
        private readonly IServerInfoSettings _serverInfoSettings;

        public ServerUtil(IServerInfoSettings serverInfoSettings)
        {
            _serverInfoSettings = serverInfoSettings;
        }

        public string generateStreamId(ClaimsPrincipal user)
        {
            var authsession= user.FindFirstValue("session");
            string streamId =Guid.NewGuid().ToString();
            
            return $"{authsession}${streamId}#{_serverInfoSettings.getServerId()}";
        }

        public Task<GrpcChannel> getGrpcClientChannel(int serverid)
        {
           
            if (_channels.TryGetValue(serverid,out GrpcChannel channel))
            {
                return Task.FromResult(channel);
            }
           
            var serverInfo = _serverInfoSettings.getServerInfo(serverid);
            var handler = new SocketsHttpHandler
            {
                PooledConnectionIdleTimeout = Timeout.InfiniteTimeSpan,
                KeepAlivePingDelay = TimeSpan.FromSeconds(60),
                KeepAlivePingTimeout = TimeSpan.FromSeconds(30),
                EnableMultipleHttp2Connections = true
            };
            channel = GrpcChannel.ForAddress(serverInfo.Url, new GrpcChannelOptions
            {
                HttpHandler = handler,
                Credentials = ChannelCredentials.Insecure
            });
            
            _channels.TryAdd(serverid, channel);
            return Task.FromResult(channel);
            

        }

    }
}