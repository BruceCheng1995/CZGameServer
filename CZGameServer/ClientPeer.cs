using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Photon.SocketServer;
using PhotonHostRuntimeInterfaces;

namespace CZGameServer
{
    class ClientPeer : Photon.SocketServer.ClientPeer
    {

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="initRequest"></param>
        public ClientPeer(InitRequest initRequest) : base(initRequest)
        {

        }

        /// <summary>
        /// 当每个客户端断开时
        /// </summary>
        /// <param name="reasonCode"></param>
        /// <param name="reasonDetail"></param>
        protected override void OnDisconnect(DisconnectReason reasonCode, string reasonDetail)
        {

        }
        /// <summary>
        /// 客户端发起请求的时候
        /// </summary>
        /// <param name="operationRequest"></param>
        /// <param name="sendParameters"></param>
        protected override void OnOperationRequest(OperationRequest operationRequest, SendParameters sendParameters)
        {
            switch (operationRequest.OperationCode)
            {
                case 1:
                    //解析数据
                    var data = operationRequest.Parameters;
                    object intValue;
                    data.TryGetValue(1, out intValue);
                    object StringValue;
                    data.TryGetValue(2, out StringValue);
                    MyGameServer.log.Info("收到客户端的请求，OpCode：1" + intValue.ToString() + ":" + StringValue.ToString());


                    //返回相应
                    OperationResponse opResponse = new OperationResponse(operationRequest.OperationCode);

                    //构造参数
                    var data2 = new Dictionary<byte, object>();
                    data2.Add(1, 100);
                    data2.Add(2, "这个是参数,服务器发来的");
                    opResponse.SetParameters(data2);
                    //返回code，为发送过来的code，返回的参数，为发送过来的参数
                    SendOperationResponse(opResponse, sendParameters);

                    //推送一个Event
                    EventData ed = new EventData(1);
                    ed.Parameters = data2;
                    SendEvent(ed, new SendParameters());

                    break;
                default:
                    break;
            }
        }
    }
}
