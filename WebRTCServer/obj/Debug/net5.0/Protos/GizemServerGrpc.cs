// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/gizem_server.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace gizem_server {
  public static partial class StreamGateway
  {
    static readonly string __ServiceName = "gizem.StreamGateway";

    static void __Helper_SerializeMessage(global::Google.Protobuf.IMessage message, grpc::SerializationContext context)
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (message is global::Google.Protobuf.IBufferMessage)
      {
        context.SetPayloadLength(message.CalculateSize());
        global::Google.Protobuf.MessageExtensions.WriteTo(message, context.GetBufferWriter());
        context.Complete();
        return;
      }
      #endif
      context.Complete(global::Google.Protobuf.MessageExtensions.ToByteArray(message));
    }

    static class __Helper_MessageCache<T>
    {
      public static readonly bool IsBufferMessage = global::System.Reflection.IntrospectionExtensions.GetTypeInfo(typeof(global::Google.Protobuf.IBufferMessage)).IsAssignableFrom(typeof(T));
    }

    static T __Helper_DeserializeMessage<T>(grpc::DeserializationContext context, global::Google.Protobuf.MessageParser<T> parser) where T : global::Google.Protobuf.IMessage<T>
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (__Helper_MessageCache<T>.IsBufferMessage)
      {
        return parser.ParseFrom(context.PayloadAsReadOnlySequence());
      }
      #endif
      return parser.ParseFrom(context.PayloadAsNewBuffer());
    }

    static readonly grpc::Marshaller<global::gizem_server.StreamGatewayQ> __Marshaller_gizem_StreamGatewayQ = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::gizem_server.StreamGatewayQ.Parser));
    static readonly grpc::Marshaller<global::gizem_server.StreamGatewayP> __Marshaller_gizem_StreamGatewayP = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::gizem_server.StreamGatewayP.Parser));

    static readonly grpc::Method<global::gizem_server.StreamGatewayQ, global::gizem_server.StreamGatewayP> __Method_Forward = new grpc::Method<global::gizem_server.StreamGatewayQ, global::gizem_server.StreamGatewayP>(
        grpc::MethodType.Unary,
        __ServiceName,
        "Forward",
        __Marshaller_gizem_StreamGatewayQ,
        __Marshaller_gizem_StreamGatewayP);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::gizem_server.GizemServerReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of StreamGateway</summary>
    [grpc::BindServiceMethod(typeof(StreamGateway), "BindService")]
    public abstract partial class StreamGatewayBase
    {
      public virtual global::System.Threading.Tasks.Task<global::gizem_server.StreamGatewayP> Forward(global::gizem_server.StreamGatewayQ request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static grpc::ServerServiceDefinition BindService(StreamGatewayBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_Forward, serviceImpl.Forward).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the  service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static void BindService(grpc::ServiceBinderBase serviceBinder, StreamGatewayBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_Forward, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::gizem_server.StreamGatewayQ, global::gizem_server.StreamGatewayP>(serviceImpl.Forward));
    }

  }
  public static partial class Authentication
  {
    static readonly string __ServiceName = "gizem.Authentication";

    static void __Helper_SerializeMessage(global::Google.Protobuf.IMessage message, grpc::SerializationContext context)
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (message is global::Google.Protobuf.IBufferMessage)
      {
        context.SetPayloadLength(message.CalculateSize());
        global::Google.Protobuf.MessageExtensions.WriteTo(message, context.GetBufferWriter());
        context.Complete();
        return;
      }
      #endif
      context.Complete(global::Google.Protobuf.MessageExtensions.ToByteArray(message));
    }

    static class __Helper_MessageCache<T>
    {
      public static readonly bool IsBufferMessage = global::System.Reflection.IntrospectionExtensions.GetTypeInfo(typeof(global::Google.Protobuf.IBufferMessage)).IsAssignableFrom(typeof(T));
    }

    static T __Helper_DeserializeMessage<T>(grpc::DeserializationContext context, global::Google.Protobuf.MessageParser<T> parser) where T : global::Google.Protobuf.IMessage<T>
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (__Helper_MessageCache<T>.IsBufferMessage)
      {
        return parser.ParseFrom(context.PayloadAsReadOnlySequence());
      }
      #endif
      return parser.ParseFrom(context.PayloadAsNewBuffer());
    }

    static readonly grpc::Marshaller<global::gizem_server.AuthenticationQ> __Marshaller_gizem_AuthenticationQ = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::gizem_server.AuthenticationQ.Parser));
    static readonly grpc::Marshaller<global::gizem_server.AuthenticationP> __Marshaller_gizem_AuthenticationP = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::gizem_server.AuthenticationP.Parser));

    static readonly grpc::Method<global::gizem_server.AuthenticationQ, global::gizem_server.AuthenticationP> __Method_Login = new grpc::Method<global::gizem_server.AuthenticationQ, global::gizem_server.AuthenticationP>(
        grpc::MethodType.Unary,
        __ServiceName,
        "Login",
        __Marshaller_gizem_AuthenticationQ,
        __Marshaller_gizem_AuthenticationP);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::gizem_server.GizemServerReflection.Descriptor.Services[1]; }
    }

    /// <summary>Base class for server-side implementations of Authentication</summary>
    [grpc::BindServiceMethod(typeof(Authentication), "BindService")]
    public abstract partial class AuthenticationBase
    {
      public virtual global::System.Threading.Tasks.Task<global::gizem_server.AuthenticationP> Login(global::gizem_server.AuthenticationQ request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static grpc::ServerServiceDefinition BindService(AuthenticationBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_Login, serviceImpl.Login).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the  service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static void BindService(grpc::ServiceBinderBase serviceBinder, AuthenticationBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_Login, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::gizem_server.AuthenticationQ, global::gizem_server.AuthenticationP>(serviceImpl.Login));
    }

  }
  public static partial class WebRTCSignal
  {
    static readonly string __ServiceName = "gizem.WebRTCSignal";

    static void __Helper_SerializeMessage(global::Google.Protobuf.IMessage message, grpc::SerializationContext context)
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (message is global::Google.Protobuf.IBufferMessage)
      {
        context.SetPayloadLength(message.CalculateSize());
        global::Google.Protobuf.MessageExtensions.WriteTo(message, context.GetBufferWriter());
        context.Complete();
        return;
      }
      #endif
      context.Complete(global::Google.Protobuf.MessageExtensions.ToByteArray(message));
    }

    static class __Helper_MessageCache<T>
    {
      public static readonly bool IsBufferMessage = global::System.Reflection.IntrospectionExtensions.GetTypeInfo(typeof(global::Google.Protobuf.IBufferMessage)).IsAssignableFrom(typeof(T));
    }

    static T __Helper_DeserializeMessage<T>(grpc::DeserializationContext context, global::Google.Protobuf.MessageParser<T> parser) where T : global::Google.Protobuf.IMessage<T>
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (__Helper_MessageCache<T>.IsBufferMessage)
      {
        return parser.ParseFrom(context.PayloadAsReadOnlySequence());
      }
      #endif
      return parser.ParseFrom(context.PayloadAsNewBuffer());
    }

    static readonly grpc::Marshaller<global::gizem_server.SessionInfoUpdateQ> __Marshaller_gizem_SessionInfoUpdateQ = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::gizem_server.SessionInfoUpdateQ.Parser));
    static readonly grpc::Marshaller<global::gizem_server.SessionInfoUpdateP> __Marshaller_gizem_SessionInfoUpdateP = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::gizem_server.SessionInfoUpdateP.Parser));
    static readonly grpc::Marshaller<global::gizem_server.SendMessageQ> __Marshaller_gizem_SendMessageQ = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::gizem_server.SendMessageQ.Parser));
    static readonly grpc::Marshaller<global::gizem_server.SendMessageP> __Marshaller_gizem_SendMessageP = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::gizem_server.SendMessageP.Parser));

    static readonly grpc::Method<global::gizem_server.SessionInfoUpdateQ, global::gizem_server.SessionInfoUpdateP> __Method_SubscribeSessionInfoUpdate = new grpc::Method<global::gizem_server.SessionInfoUpdateQ, global::gizem_server.SessionInfoUpdateP>(
        grpc::MethodType.ServerStreaming,
        __ServiceName,
        "SubscribeSessionInfoUpdate",
        __Marshaller_gizem_SessionInfoUpdateQ,
        __Marshaller_gizem_SessionInfoUpdateP);

    static readonly grpc::Method<global::gizem_server.SendMessageQ, global::gizem_server.SendMessageP> __Method_SendMessage = new grpc::Method<global::gizem_server.SendMessageQ, global::gizem_server.SendMessageP>(
        grpc::MethodType.ServerStreaming,
        __ServiceName,
        "SendMessage",
        __Marshaller_gizem_SendMessageQ,
        __Marshaller_gizem_SendMessageP);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::gizem_server.GizemServerReflection.Descriptor.Services[2]; }
    }

    /// <summary>Base class for server-side implementations of WebRTCSignal</summary>
    [grpc::BindServiceMethod(typeof(WebRTCSignal), "BindService")]
    public abstract partial class WebRTCSignalBase
    {
      public virtual global::System.Threading.Tasks.Task SubscribeSessionInfoUpdate(global::gizem_server.SessionInfoUpdateQ request, grpc::IServerStreamWriter<global::gizem_server.SessionInfoUpdateP> responseStream, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task SendMessage(global::gizem_server.SendMessageQ request, grpc::IServerStreamWriter<global::gizem_server.SendMessageP> responseStream, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static grpc::ServerServiceDefinition BindService(WebRTCSignalBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_SubscribeSessionInfoUpdate, serviceImpl.SubscribeSessionInfoUpdate)
          .AddMethod(__Method_SendMessage, serviceImpl.SendMessage).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the  service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static void BindService(grpc::ServiceBinderBase serviceBinder, WebRTCSignalBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_SubscribeSessionInfoUpdate, serviceImpl == null ? null : new grpc::ServerStreamingServerMethod<global::gizem_server.SessionInfoUpdateQ, global::gizem_server.SessionInfoUpdateP>(serviceImpl.SubscribeSessionInfoUpdate));
      serviceBinder.AddMethod(__Method_SendMessage, serviceImpl == null ? null : new grpc::ServerStreamingServerMethod<global::gizem_server.SendMessageQ, global::gizem_server.SendMessageP>(serviceImpl.SendMessage));
    }

  }
  public static partial class UserList
  {
    static readonly string __ServiceName = "gizem.UserList";

    static void __Helper_SerializeMessage(global::Google.Protobuf.IMessage message, grpc::SerializationContext context)
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (message is global::Google.Protobuf.IBufferMessage)
      {
        context.SetPayloadLength(message.CalculateSize());
        global::Google.Protobuf.MessageExtensions.WriteTo(message, context.GetBufferWriter());
        context.Complete();
        return;
      }
      #endif
      context.Complete(global::Google.Protobuf.MessageExtensions.ToByteArray(message));
    }

    static class __Helper_MessageCache<T>
    {
      public static readonly bool IsBufferMessage = global::System.Reflection.IntrospectionExtensions.GetTypeInfo(typeof(global::Google.Protobuf.IBufferMessage)).IsAssignableFrom(typeof(T));
    }

    static T __Helper_DeserializeMessage<T>(grpc::DeserializationContext context, global::Google.Protobuf.MessageParser<T> parser) where T : global::Google.Protobuf.IMessage<T>
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (__Helper_MessageCache<T>.IsBufferMessage)
      {
        return parser.ParseFrom(context.PayloadAsReadOnlySequence());
      }
      #endif
      return parser.ParseFrom(context.PayloadAsNewBuffer());
    }

    static readonly grpc::Marshaller<global::gizem_server.SubscribeListUpdateQ> __Marshaller_gizem_SubscribeListUpdateQ = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::gizem_server.SubscribeListUpdateQ.Parser));
    static readonly grpc::Marshaller<global::gizem_server.SubscribeListUpdateP> __Marshaller_gizem_SubscribeListUpdateP = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::gizem_server.SubscribeListUpdateP.Parser));

    static readonly grpc::Method<global::gizem_server.SubscribeListUpdateQ, global::gizem_server.SubscribeListUpdateP> __Method_SubscribeListUpdate = new grpc::Method<global::gizem_server.SubscribeListUpdateQ, global::gizem_server.SubscribeListUpdateP>(
        grpc::MethodType.ServerStreaming,
        __ServiceName,
        "SubscribeListUpdate",
        __Marshaller_gizem_SubscribeListUpdateQ,
        __Marshaller_gizem_SubscribeListUpdateP);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::gizem_server.GizemServerReflection.Descriptor.Services[3]; }
    }

    /// <summary>Base class for server-side implementations of UserList</summary>
    [grpc::BindServiceMethod(typeof(UserList), "BindService")]
    public abstract partial class UserListBase
    {
      public virtual global::System.Threading.Tasks.Task SubscribeListUpdate(global::gizem_server.SubscribeListUpdateQ request, grpc::IServerStreamWriter<global::gizem_server.SubscribeListUpdateP> responseStream, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static grpc::ServerServiceDefinition BindService(UserListBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_SubscribeListUpdate, serviceImpl.SubscribeListUpdate).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the  service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static void BindService(grpc::ServiceBinderBase serviceBinder, UserListBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_SubscribeListUpdate, serviceImpl == null ? null : new grpc::ServerStreamingServerMethod<global::gizem_server.SubscribeListUpdateQ, global::gizem_server.SubscribeListUpdateP>(serviceImpl.SubscribeListUpdate));
    }

  }
}
#endregion