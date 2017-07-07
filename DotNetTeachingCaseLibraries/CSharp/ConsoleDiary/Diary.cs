using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDiary
{
    /// <summary>
    /// 日记
    /// </summary>
    [Serializable]
    public class Diary
    {
        /// <summary>
        /// 日期
        /// </summary>
        public DateTime CreateTime
        { get; set; }

        /// <summary>
        /// 星期
        /// </summary>
        public string Week
        { get; set; }
        /// <summary>
        /// 天气
        /// </summary>
        public Weather Weather
        { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string Content
        { get; set; }
    }
}
