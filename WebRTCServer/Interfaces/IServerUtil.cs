using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Grpc.Net.Client;

namespace WebRTCServer.Interfaces
{
    public interface IServerUtil
    {
        string generateStreamId(ClaimsPrincipal user);
        Task<GrpcChannel> getGrpcClientChannel(int serverid);
    }
}