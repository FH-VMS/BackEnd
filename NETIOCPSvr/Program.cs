﻿using System;
using System.Collections.Generic;
using System.Security.AccessControl;
using System.Net;
using System.Linq;
using System.Text;
using System.Diagnostics;
using log4net;
using System.Configuration;
using System.IO;
using System.Net.Sockets;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace SocketAsyncSvr
{    
    public class Program
    {
        public static ILog Logger;
        public static AsyncSocketServer AsyncSocketSvr;
        public static string FileDirectory;
        
        static void Main(string[] args)
        {
            try
            {
               

                DateTime currentTime = DateTime.Now;
                log4net.GlobalContext.Properties["LogDir"] = currentTime.ToString("yyyyMM");
                log4net.GlobalContext.Properties["LogFileName"] = "_SocketAsyncServer" + currentTime.ToString("yyyyMMdd");
                Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                FileDirectory = config.AppSettings.Settings["FileDirectory"].Value;
                if (FileDirectory == "")
                    FileDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Files");
                if (!Directory.Exists(FileDirectory))
                    Directory.CreateDirectory(FileDirectory);
                int port = 0;
                if (!(int.TryParse(config.AppSettings.Settings["Port"].Value, out port)))
                    port = 9999;
                int parallelNum = 0;
                if (!(int.TryParse(config.AppSettings.Settings["ParallelNum"].Value, out parallelNum)))
                    parallelNum = 8000;
                int socketTimeOutMS = 0;
                if (!(int.TryParse(config.AppSettings.Settings["SocketTimeOutMS"].Value, out socketTimeOutMS)))
                    socketTimeOutMS = 5 * 60 * 1000;
               
               AsyncSocketSvr = new AsyncSocketServer(parallelNum);
               AsyncSocketSvr.SocketTimeOutMS = socketTimeOutMS;
               AsyncSocketSvr.Init();
           
               string HostName = Dns.GetHostName(); //得到主机名
               IPHostEntry IpEntry = Dns.GetHostEntry(HostName);
               string ipV4 = string.Empty;
            
             for (int i = 0; i < IpEntry.AddressList.Length; i++)
             {
                 //从IP地址列表中筛选出IPv4类型的IP地址
                 //AddressFamily.InterNetwork表示此IP为IPv4,
                 //AddressFamily.InterNetworkV6表示此地址为IPv6类型
                 if (IpEntry.AddressList[i].AddressFamily == AddressFamily.InterNetwork)
                 {
                     ipV4 = IpEntry.AddressList[i].ToString();
                 }
             }
             IPEndPoint listenPoint = new IPEndPoint(IPAddress.Parse(ipV4), port);
             AsyncSocketSvr.Start(listenPoint);
         
                Console.WriteLine("Press any key to terminate the server process....");
                Console.ReadKey();
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}