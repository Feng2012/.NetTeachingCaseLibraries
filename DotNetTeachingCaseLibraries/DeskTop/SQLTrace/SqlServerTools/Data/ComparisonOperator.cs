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
        //���� = 0,
        //������ = 1,
        //���� = 2,
        //С�� = 3,
        //���ڵ��� = 4,
        //С�ڵ� = 5,
        //���� = 6,
        //������ = 7
    }
}
