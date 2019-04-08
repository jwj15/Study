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
        // 네트워크

        static void Main()
        {
            // ip주소 표현 방식
            IPAddress ip1 = IPAddress.Parse("192.168.1.13");

            IPAddress ip2 = new IPAddress(new byte[] { 192, 168, 1, 13 });

            IPAddress ip3 = new IPAddress(218212544);
            Console.WriteLine("{0}\n{1}\n{2}", ip1, ip2, ip3.ToString());

            // 유용한 IPAddress 메서드
            IPAddress ip = IPAddress.Parse("216.58.216.174");

            byte[] ipbytes = ip.GetAddressBytes(); // IP를 바이트배열로 

            IPAddress ipv6 = ip.MapToIPv6();  // IPv4를 IPv6로 매핑 
            Console.WriteLine(ipv6);

            // 인터넷 호스트명 정보 얻기
            IPHostEntry hostEntry = Dns.GetHostEntry("www.google.com");

            Console.WriteLine(hostEntry.HostName);
            foreach (IPAddress i1 in hostEntry.AddressList)
            {
                Console.WriteLine(i1);
            }

            Console.WriteLine("--------------------------");
            // 로컬 호스트명 정보 얻기
            string hostname = Dns.GetHostName();
            IPHostEntry localhost = Dns.GetHostEntry(hostname);

            foreach (IPAddress i1 in localhost.AddressList)
            {
                Console.WriteLine(i1);
            }
            Console.WriteLine("--------------------------");

            // IP 에서 호스트명 알아내기
            IPAddress ipaddr = IPAddress.Parse("172.217.161.36");
            IPHostEntry hostEntry2 = Dns.GetHostEntry(ipaddr);
            Console.WriteLine(hostEntry2.HostName);


            IPAddress ip5 = IPAddress.Parse("74.125.28.99");
            IPEndPoint ep = new IPEndPoint(ip5, 80); // 포트

            Console.WriteLine(ep.ToString());

        }


    }
}
