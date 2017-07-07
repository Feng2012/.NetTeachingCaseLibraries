using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDiary
{
    /// <summary>
    /// 天气枚举
    /// </summary>
    [Serializable]
    public enum Weather
    {
        晴 = 0,
        多云 = 1,
        阴 = 2,
        小雨 = 4,
        中雨 = 8,
        大雨 = 16,
        暴雨 = 32,
        大风 = 64
    }
}
