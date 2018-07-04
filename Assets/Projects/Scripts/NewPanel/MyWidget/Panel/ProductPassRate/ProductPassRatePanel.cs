using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ProductPassRatePanel : FirstLevelPanel
{
    public WMG_Axis_Graph graph;

    List<ProductPassRate> dataList = new List<ProductPassRate>();
    WMG_List<int> dataIdList = new WMG_List<int>();
    WMG_List<string> dataNameList = new WMG_List<string>();
    WMG_List<float> dataPassRateList = new WMG_List<float>();

    public ToggleGroup toggleGroup;

    private List<Toggle> toggles = new List<Toggle>();
    private Dictionary<WMG_Node, int> nodesDic = new Dictionary<WMG_Node, int>();

    public override void GetDataFromGetter(IDataIO dataIO)
    {
        dataList = dataIO.GetData_ProductPassRateList(1);
        for (int i = 0; i < dataList.Count; i++)
        {
            AnalysisData(dataList[i]);
        }
    }

    private void AnalysisData(ProductPassRate product)
    {
        var fields = typeof(ProductPassRate).GetFields();

        for (int i = 0; i < fields.Length; i++)
        {
            switch (fields[i].Name)
            {
                case "ID":
                    int id = (int)fields[i].GetValue(product);
                    dataIdList.Add(id);
                    break;
                case "productName":
                    string n = (string)fields[i].GetValue(product);
                    dataNameList.Add(n);
                    break;
                case "passRate":
                    float q = (float)fields[i].GetValue(product);
                    dataPassRateList.Add(q);
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
    /// 点击计量条的方法，该方法内通过面板控制器打开对应弹出的面板
    /// </summary>
    /// <param name="aSeries">计量条所在的series</param>
    /// <param name="aNode">被点击的计量条</param>
    private void BarGraph_WMG_Click(WMG_Series aSeries, WMG_Node aNode)
    {
        if (nodesDic.ContainsKey(aNode))
        {
            //当字典中包含被点击的计量条时，将计量条所对应的产品id取出
            int t = nodesDic[aNode];
            MessageArg arg = new MessageArg(t);
            //调用面板控制器，传入产品产量明细， 和条目id
            SendMsg((int)MessageUIConst.OpenPassRateDetailPanel, ManagerID.SecondLevelPanel, arg);
        }
    }


    public override void SetData()
    {
        graph.Init();
        graph.groups.SetList(dataNameList);
        WMG_Series s1 = graph.lineSeries[0].GetComponent<WMG_Series>();

        //设置计量条的值，该值为数据列表中 产品质量列表 的值
        List<Vector2> s1datalist = new List<Vector2>();
        for (int i = 0; i < dataPassRateList.Count; i++)
        {
            s1datalist.Add(new Vector2(i + 1, dataPassRateList[i]));
        }
        s1.pointValues.SetList(s1datalist);

        //创建字典，该字典为<节点（即计量条），id>字典，目的是保存每一个计量条所对应的产品id，为了点击计量条时所弹出的窗口传参
        WMG_Node[] nodes = s1.nodeParent.GetComponentsInChildren<WMG_Node>();
        for (int i = 0; i < dataIdList.Count; i++)
        {
            if (!nodesDic.ContainsKey(nodes[i]))
            {
                nodesDic.Add(nodes[i], dataIdList[i]);
            }
        }
    }

    /// <summary>
    /// 年月日变更
    /// </summary>
    /// <param name="t">时间参数，year=0，month=1，day=2</param>
    public void SwichToggle(int t)
    {
        //清空所有列表
        dataIdList.Clear();
        dataList.Clear();
        dataNameList.Clear();
        dataPassRateList.Clear();
        //重新从数据中取值
        dataList = DataGetter.Instance.dataIO.GetData_ProductPassRateList(t);
        for (int i = 0; i < dataList.Count; i++)
        {
            AnalysisData(dataList[i]);
        }
        //重新赋值
        SetData();
    }

    public override void Init(ManagerBase manager)
    {
        base.Init(manager);

        graph.useGroups = true;
        graph.yAxis.LabelType = WMG_Axis.labelTypes.groups;
        graph.tooltipDisplaySeriesName = true;

        graph.WMG_Click += BarGraph_WMG_Click;

        WMG_Series s1;//定义Series

        if (graph.lineSeries.Count == 0)
        {
            s1 = graph.addSeries();//如果该图标下没有series，就添加一个，并绑定为s1
        }
        else
        {
            s1 = graph.lineSeries[0].GetComponent<WMG_Series>();//如果有，把第一个绑定为s1
        }
        s1.dataLabelsNumDecimals = 2;
        s1.seriesName = "产量";//设置名称，该名称为tooltip显示的名称
        s1.dataLabelsFontSize = 14;//设置字号，该字号为条后的计量数字字号
        s1.dataLabelsOffset = new Vector2(2, 5);//设置偏移，该偏移为条后的计量数字位置偏移
        if (s1.usePointColors)
        {
            s1.pointColors.SetList(ColorDatas.Instance.productOutputColors.DataColorList);//如果应用了colors，则使用颜色数据的列表
        }
        else
        {
            s1.pointColor = ColorDatas.Instance.productOutputColors.DataColorList[0];//如果没有应用colors，则使用颜色数据列表的第一个
        }
        s1.dataLabelsEnabled = true;//显示前面的标签
    }

    public override void ShowOnEffect()
    {

    }
}
