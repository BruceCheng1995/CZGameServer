using ExitGames.Logging;
using ExitGames.Logging.Log4Net;
using log4net.Config;
using Photon.SocketServer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZGameServer
{
    //所有的Server都要继承ApplicationBase，然后实现这三个方法
    public class MyGameServer : ApplicationBase
    {
        public static readonly ILogger log = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// 当有一个客户端链接上以后，就会执行这个方法
        /// </summary>
        /// <param name="initRequest"></param>
        /// <returns></returns>
        /// 
        protected override PeerBase CreatePeer(InitRequest initRequest)
        {
            log.Info("一个客户端链接");
            return new ClientPeer(initRequest);
        }


        /// <summary>
        /// 服务器初始化函数
        /// </summary>
        protected override void Setup()
        {
            log4net.GlobalContext.Properties["Photon:ApplicationLogPath"] = 
                Path.Combine(Path.Combine(this.ApplicationRootPath, "bin_Win64"), "log");
            FileInfo configFlieInfo = new FileInfo(Path.Combine(this.BinaryPath, "log4net.config"
                ));
            if (configFlieInfo.Exists)
            {
                LogManager.SetLoggerFactory(Log4NetLoggerFactory.Instance);//让Photon知道日志输出
                XmlConfigurator.ConfigureAndWatch(configFlieInfo);//读取配置
            }

            log.Info("服务器启动啦");
        }


        /// <summary>
        /// 服务器关闭函数
        /// </summary>
        protected override void TearDown()
        {
            log.Info("服务器关闭啦");
        }
    }
}
