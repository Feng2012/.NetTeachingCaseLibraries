using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    /// <summary>
    /// 消息报文
    /// </summary>
    [Serializable]
    public class MessagePackage : Package
    {
        public override PackageType PackageType
        {
            get => PackageType.Message;       
        }
        /// <summary>
        /// 发送者
        /// </summary>
        public string Sender
        { get; set; }

        /// <summary>
        /// 发送时间
        /// </summary>
        public DateTime SendTime
        { get; set; }

        /// <summary>
        /// 发送内容
        /// </summary>
        public string Content
        { get; set; }

        /// <summary>
        /// 接收好友
        /// </summary>
        public string Accepter
        { get; set; }

        /// <summary>
        /// 重写ToString输出聊天的格式
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var content = $@"-------------------接收到的消息-开始--------------------
{Sender}:{SendTime.ToString("yyyy-MM-dd HH:mm:ss")}
{Content}
--------------------接收到的消息-结束-------------------";
            return content;
        }
    }

    
}
