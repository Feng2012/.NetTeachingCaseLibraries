using System;
using System.Collections.Generic;
using System.Text;

namespace SqlServerTools.Data
{
    public enum ComparisonOperator
    {
        Equal = 0,
        NotEqual = 1,
        GreatherThan = 2,
        LessThan = 3,
        GreatherThanOrEqual = 4,
        LessThanOrEqual = 5,
        Like = 6,
        NotLike = 7
        //等于 = 0,
        //不等于 = 1,
        //大于 = 2,
        //小于 = 3,
        //大于等于 = 4,
        //小于等 = 5,
        //包含 = 6,
        //不包含 = 7
    }
}
