using SuperSocket.WebSocket;
using System;
using System.Collections.Generic;

namespace SuperScoketDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            WebSocketServer server = new WebSocketServer();
            server.NewSessionConnected += Server_NewSessionConnected;

            server.NewMessageReceived += Server_NewMessageReceived;
            server.SessionClosed += Server_SessionClosed;
            try
            {
                server.Setup("127.0.0.1", 40001);//设置端口
                server.Start();//开启监听             
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }

        static void Server_SessionClosed(WebSocketSession session, SuperSocket.SocketBase.CloseReason value)
        {
            Console.WriteLine(session.Origin);
        }

        static void Server_NewMessageReceived(WebSocketSession session, string value)
        {
            Console.WriteLine(value);
            session.Send(value);         
        }

        static void Server_NewSessionConnected(WebSocketSession session)
        {
            Console.WriteLine(session.Origin);
            string path = session.Path;
            string host = session.Host;
            string upgrade = session.Upgrade;
            string uriScheme = session.UriScheme;
            //Dictionary<object,object> 
            Dictionary<object, object> dicList = (Dictionary<object, object>)session.Items;
        }
    }

}
