import 'package:echoclient/proto/gizem.pbgrpc.dart';
import 'package:flutter/cupertino.dart';
import 'package:grpc/grpc.dart';

class AuthInterceptors extends ClientInterceptor {
  String _token = "";
  AuthInterceptors(String token) {
    _token = token;
  }
  @override
  ResponseFuture<R> interceptUnary<Q, R>(
      ClientMethod<Q, R> method, Q request, CallOptions options, invoker) {
    var optionsAuth =
        CallOptions(metadata: {"Authorization": "Bearer " + _token});
    optionsAuth.mergedWith(options);
    return super.interceptUnary(method, request, optionsAuth, invoker);
  }

  @override
  ResponseStream<R> interceptStreaming<Q, R>(ClientMethod<Q, R> method,
      Stream<Q> requests, CallOptions options, invoker) {
    var optionsAuth =
        CallOptions(metadata: {"Authorization": "Bearer " + _token});
    optionsAuth.mergedWith(options);
    return super.interceptStreaming(method, requests, optionsAuth, invoker);
  }
}

class ServiceBuilder {
  static ClientChannel _channel1;
  static ClientChannel _channel2;

  static String _token = "";
  static ClientChannel BuildChannel1() {
    if (_channel1 == null) {
      _channel1 = ClientChannel(
        "192.168.1.33",
        port: 5000,
        options: ChannelOptions(
          credentials: ChannelCredentials.insecure(),
        ),
      );
    }
    _channel1.createConnection();
    return _channel1;
  }

  static ClientChannel BuildChannel2() {
    if (_channel2 == null) {
      _channel2 = ClientChannel(
        "192.168.1.33",
        port: 5001,
        options: ChannelOptions(
          credentials: ChannelCredentials.insecure(),
        ),
      );
    }
    _channel2.createConnection();
    return _channel2;
  }

  static Future Login(String username, String password) async {
    try {
      var client = AuthenticationClient(BuildChannel1());
      var result = await client.login(new AuthenticationQ()
        ..username = username
        ..password = password);

      _token = result.token;
    } catch (ex) {
      print(ex);
    }
  }

  static WebRTCSignalClient BuildWebRTC1() {
    var client = WebRTCSignalClient(BuildChannel1(),
        interceptors: [new AuthInterceptors(_token)]);
    return client;
  }

  static WebRTCSignalClient BuildWebRTC2() {
    var client = WebRTCSignalClient(BuildChannel2(),
        interceptors: [new AuthInterceptors(_token)]);
    return client;
  }
}
