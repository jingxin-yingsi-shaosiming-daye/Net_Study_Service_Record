﻿using System;
using System.Net;
using System.Net.Sockets;

namespace EchoService
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //Socket
            Socket lishSocket = new Socket(AddressFamily.InterNetwork
                , SocketType.Stream
                , ProtocolType.Tcp);
            
            
            //Bind
            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
            
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddress,8888);
            
            
            
            lishSocket.Bind(ipEndPoint);
            
            //Listen
            lishSocket.Listen(0);
            
            Console.WriteLine($"[echo服务器]启动成功!!!");
            
            

            while (true)
            {
                //Accept
                Socket acceptSocket = lishSocket.Accept();
                Console.WriteLine($"echo服务器接收到socket连接请求");
                
                //Receive
                Byte[] receiveBytes = new Byte[1024];
                int receiveNum = acceptSocket.Receive(receiveBytes);
                string receiveData = System.Text.Encoding.Default.GetString(receiveBytes);
                
                Console.WriteLine($"服务器接收到数据!!!   => {receiveData}  小宝贝");

                byte[] sendBytes = System.Text.Encoding.Default.GetBytes(System.DateTime.Now.ToString());
               

                acceptSocket.Send(sendBytes);
                


            }
            
        }
    }
}