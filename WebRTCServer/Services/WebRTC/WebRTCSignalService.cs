using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using gizem_server;
using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Authorization;
using WebRTCServer.Interfaces;

namespace WebRTCServer
{
    public class WebRTCSignalService : WebRTCSignal.WebRTCSignalBase
    {
        private readonly ILogger<WebRTCSignalService> _logger;
        private readonly StreamContext _streamContext;
        private readonly WebRTCSessionContext _webRtcSessionContext;
        private readonly IServerUtil _serverUtil;

        public WebRTCSignalService(StreamContext streamContext,WebRTCSessionContext webRtcSessionContext,IServerUtil serverUtil, ILogger<WebRTCSignalService> logger)
        {
            _streamContext = streamContext;
            _webRtcSessionContext = webRtcSessionContext;
            _serverUtil = serverUtil;
            _logger = logger;
            _logger.Trace(()=>$"service created");

        }
        
        //[Authorize(policy:"front")]
        public override Task SubscribeSessionInfoUpdate(SessionInfoUpdateQ request, IServerStreamWriter<SessionInfoUpdateP> responseStream, ServerCallContext context)
        {
            _logger.Info(()=>$"connected {context.Peer}");

            var streamId = _serverUtil.generateStreamId(context.GetHttpContext().User); //serverid#authsessionid#streamid serverid is for routing between servers
            
           
           
            var cancellationTokenForStream=_streamContext.RegisterStream(streamId,responseStream);
            context.CancellationToken.Register(()=>{ //herhangi bir network hatasında çalışıyor
                _streamContext.UnregisterStream(streamId);
                
                _logger.Debug(()=>$"Call Context CancellationToken Register() {context.Peer} -> {streamId}");
            });

            //_webRtcSessionContext.RegisterPeer(request.SessionId, streamId);
            cancellationTokenForStream.Register(()=>
            {
                
               // _webRtcSessionContext.UnregisterPeer(request.SessionId,streamId);
               _logger.Debug(()=>$"Unregistered WebRTC Session {context.Peer} {request.SessionId} Stream {streamId}");
            });


             cancellationTokenForStream.WaitHandle.WaitOne();
            _logger.Debug(()=>$"End of Call {context.Peer}");

            return Task.CompletedTask;
        }

        public override async Task SendMessage(SendMessageQ request, IServerStreamWriter<SendMessageP> responseStream, ServerCallContext context)
        {
            _logger.Debug(()=>$"__context.CancellationToken.WaitHandle.Close");
            
            _streamContext.UnregisterStream("s1#0");
            
            await _streamContext.Send("s2#1", new SessionInfoUpdateP() {});
        }
    }
}
