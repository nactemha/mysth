import 'package:echoclient/proto/gizem.pb.dart';
import 'package:flutter/material.dart';
import 'package:echoclient/services.dart';

void main() {
  runApp(MyApp());
}

class MyApp extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Flutter Demo',
      theme: ThemeData(
        primarySwatch: Colors.blue,
        visualDensity: VisualDensity.adaptivePlatformDensity,
      ),
      home: MyHomePage(title: 'Flutter Demo Home Page'),
    );
  }
}

class MyHomePage extends StatefulWidget {
  MyHomePage({Key key, this.title}) : super(key: key);

  final String title;

  @override
  _MyHomePageState createState() => _MyHomePageState();
}

class _MyHomePageState extends State<MyHomePage> {
  void _login() async {
    await ServiceBuilder.Login("ahmet", "1");
  }

  void _test() async {
    try {
      var service1 = await ServiceBuilder.BuildWebRTC1();
      var service2 = await ServiceBuilder.BuildWebRTC2();
      var stream1 = await service1
          .subscribeSessionInfoUpdate(SessionInfoUpdateQ()..sessionId = "s1#0");
      var stream2 = await service2
          .subscribeSessionInfoUpdate(SessionInfoUpdateQ()..sessionId = "s2#1");
      stream1.listen((value) {
        print("stream 1 ->$value");
      });
      stream2.listen((value) {
        print("stream 2 ->$value");
      });
    } catch (ex) {
      print(ex);
    }

    // setState(() {});
  }

  void _test2() async {
    try {
      var service2 = await ServiceBuilder.BuildWebRTC1();
      await service2.sendMessage(SendMessageQ()..message = "ahmettest");
    } catch (ex) {
      print(ex);
    }

    // setState(() {});
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text(widget.title),
      ),
      body: Center(
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          children: <Widget>[
            Container(
                margin: const EdgeInsets.only(left: 20.0, right: 20.0),
                child: Column(children: [
                  OutlineButton(onPressed: _login, child: Text("Login")),
                  OutlineButton(onPressed: _test, child: Text("Test1")),
                  OutlineButton(onPressed: _test2, child: Text("Test2"))
                ])),
          ],
        ),
      ),
    );
  }
}
