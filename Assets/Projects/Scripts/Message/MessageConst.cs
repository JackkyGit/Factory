using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct MessageArg
{
    public int id;
    public int id2;
    public int timeType;

    public MessageArg(int id1 = -1, int id2 = -1, int time = -1)
    {
        this.id = id1;
        this.id2 = id2;
        this.timeType = time;
    }
}

public enum ManagerID
{
    FirstLevelPanel = 1000,
    SecondLevelPanel = 2000,
    ThirdLevelPanel = 3000,
}

public enum MessageUIConst
{
    OpenProductDetailPanel = 1,
    OpenPassRateDetailPanel = 2,
}
