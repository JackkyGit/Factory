using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

/// <summary>
/// 计划统计分析面板
/// </summary>
public class PlanningStatisticsPanel : FirstLevelPanel
{
    public List<DataNode> dataNodes = new List<DataNode>();
    public Text orderText, overText;

    private PlanningStatistics data;
    private List<string> dataList = new List<string>();

    public override void Init(ManagerBase manager)
    {
        base.Init(manager);
    }

    public override void SetData()
    {
        for (int i = 0; i < dataNodes.Count; i++)
        {
            dataNodes[i].text.text = dataList[i];
        }
    }

    public override void GetDataFromGetter(IDataIO dataIO)
    {
        data = dataIO.GetData_PlanningStatistics();

        var fields = typeof(PlanningStatistics).GetFields();

        for (int i = 0; i < fields.Length; i++)
        {
            var b = fields[i].GetValue(data);
            switch (fields[i].Name)
            {
                case "orderCount":
                    dataList.Add("总数" + "\n" + b);
                    orderText.text = b.ToString();
                    break;
                case "overCount":
                    dataList.Add("完成 " + b);
                    overText.text = b.ToString();
                    break;
                case "notStartCount":
                    dataList.Add("未开始 " + b);
                    break;
                case "workingCount":
                    dataList.Add("生产中 " + b);
                    break;
                case "shipCount":
                    dataList.Add("发货 " + b);
                    break;
                case "achievementRate":
                    dataList.Add("完成率 " + b + "%");
                    break;
                case "passRate":
                    dataList.Add("合格率 " + b + "%");
                    break;
                case "timelyRate":
                    dataList.Add("发货及时率 " + b + "%");
                    break;
                default:
                    break;
            }
        }
    }

    public override void SetCustomData()
    {

    }

    /// <summary>
    /// 设置工厂名字
    /// </summary>
    /// <param name="name"></param>
    public void SetNameText(string name)
    {

    }
}
