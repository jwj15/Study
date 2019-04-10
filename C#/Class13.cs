using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Study
{
    class Class13
    {


        static void Main(string[] args)
        {
            // Tcp Server
            // (1) 로컬 포트 7000 을 Listen
            TcpListener listener = new TcpListener(IPAddress.Any, 9999);
            // TcpListener listener = new TcpListener("127.0.0.1", 9999);

            listener.Start();

            byte[] buf = new byte[1024];

            while (true)
            {
                // (2) TcpClient Connection 요청을 받아들여
                //     서버에서 새 TcpClient 객체를 생성하여 리턴
                TcpClient tc1 = listener.AcceptTcpClient();

                // (3) TcpClient 객체에서 NetworkStream을 얻어옴 
                NetworkStream stream1 = tc1.GetStream();

                // (4) 클라이언트가 연결을 끊을 때까지 데이타 수신
                int nbytes1;
                while ((nbytes1 = stream1.Read(buf, 0, buf.Length)) > 0)
                {
                    // (5) 데이타 그대로 송신
                    stream1.Write(buf, 0, nbytes1);
                }

                // (6) 스트림과 TcpClient 객체 
                stream1.Close();
                tc1.Close();

                // (7) 계속 반복
                break;
            }

            // Tcp Client
            IPAddress serveripaddress = IPAddress.Parse("127.0.0.1");
            TcpClient tc = new TcpClient();
            tc.Connect(serveripaddress, 9999);
            //TcpClient tc = new TcpClient("127.0.0.1", 9999);

            string msg = "Hello World";
            byte[] buff = Encoding.ASCII.GetBytes(msg);

            // (2) NetworkStream을 얻어옴 
            NetworkStream stream = tc.GetStream();

            // (3) 스트림에 바이트 데이타 전송
            stream.Write(buff, 0, buff.Length);

            // (4) 스트림으로부터 바이트 데이타 읽기
            byte[] outbuf = new byte[1024];
            int nbytes = stream.Read(outbuf, 0, outbuf.Length);
            string output = Encoding.ASCII.GetString(outbuf, 0, nbytes);
            Console.WriteLine(output);

            // (5) 스트림과 TcpClient 객체 닫기
            stream.Close();
            tc.Close();

            // Socket Server
            // (1) 소켓 객체 생성 (TCP 소켓)
            Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            // (2) 포트에 바인드
            IPEndPoint ep = new IPEndPoint(IPAddress.Any, 9999);
            sock.Bind(ep);

            // (3) 포트 Listening 시작
            sock.Listen(10);

            // (4) 연결을 받아들여 새 소켓 생성 (하나의 연결만 받아들임)
            Socket clientSock = sock.Accept();

            byte[] buff2 = new byte[8192];
            while (!Console.KeyAvailable) // 키 누르면 종료
            {
                // (5) 소켓 수신
                int n = clientSock.Receive(buff2);

                string data = Encoding.UTF8.GetString(buff2, 0, n);
                Console.WriteLine(data);

                // (6) 소켓 송신
                clientSock.Send(buff2, 0, n, SocketFlags.None);  // echo
            }

            // (7) 소켓 닫기
            clientSock.Close();
            sock.Close();

            // Socket Client
            // (1) 소켓 객체 생성 (TCP 소켓)
            Socket sock1 = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            // (2) 서버에 연결
            var ep1 = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9999);
            sock1.Connect(ep1);

            string cmd = string.Empty;
            byte[] receiverBuff = new byte[8192];

            Console.WriteLine("Connected... Enter Q to exit");

            // Q 를 누를 때까지 계속 Echo 실행
            while ((cmd = Console.ReadLine()) != "Q")
            {
                byte[] buff3 = Encoding.UTF8.GetBytes(cmd);

                // (3) 서버에 데이타 전송
                sock1.Send(buff3, SocketFlags.None);

                // (4) 서버에서 데이타 수신
                int n = sock1.Receive(receiverBuff);

                string data = Encoding.UTF8.GetString(receiverBuff, 0, n);
                Console.WriteLine(data);
            }
            // (5) 소켓 닫기
            sock1.Close();

        }
    }
}
