using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct PlanningStatistics
{
    public int orderCount;
    public int overCount;
    public int notStartCount;
    public int workingCount;
    public int shipCount;
    public int achievementRate;
    public int passRate;
    public int timelyRate;

    public PlanningStatistics SetData(int orderC, int overC, int notC, int workingC, int shipC, int achivementR, int passR, int timelyR)
    {
        this.orderCount = orderC;
        this.overCount = overC;
        this.notStartCount = notC;
        this.workingCount = workingC;
        this.shipCount = shipC;
        this.achievementRate = achivementR;
        this.passRate = passR;
        this.timelyRate = timelyR;
        return this;
    }
}

public struct ProductOutput
{
    public int ID; //产品ID
    public string productName;//产品名称
    public int quality; //产品数量

    public ProductOutput SetData(int id, string name, int quality)
    {
        this.ID = id;
        this.productName = name;
        this.quality = quality;
        return this;
    }
}

public struct ProductTotal
{
    public string productName; //产品名称
    public int yearQuality;   //产品年生产总数
    public int monthQuality; //产品月生产总数
    public int weekQuality; //产品周生产总数
    public int dayQuality; //产品日生产总数

    public ProductTotal SetData(string name, int yearQ, int monthQ, int weekQ, int dayQ)
    {
        this.productName = name;
        this.yearQuality = yearQ;
        this.monthQuality = monthQ;
        this.weekQuality = weekQ;
        this.dayQuality = dayQ;
        return this;
    }
}

public struct ProductCostTotal
{
    public string productName;          // 产品名称
    public int year;                               //年
    public int month;                           //月
    public float fixedQuality;               //固定费用
    public float nonFixedQuality;        //非固定费用

    public ProductCostTotal SetData(string name, int year, int month, float fixedQ, float nonFixedQ)
    {
        this.productName = name;
        this.year = year;
        this.month = month;
        this.fixedQuality = fixedQ;
        this.nonFixedQuality = nonFixedQ;
        return this;
    }
}

public struct ProductPassRate
{
    public int ID;
    public string productName;                                      //产品名称
    public float passRate;                                              //合格率 （保留2位小数）

    public ProductPassRate SetData(int id, string name, float rate)
    {
        this.ID = id;
        this.productName = name;
        this.passRate = rate;
        return this;
    }
}
