using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ProductPassRatePanel : FirstLevelPanel
{
    public BarGraph graph;
    public float animDuration;
    public ToggleGroup toggleGroup;

    private List<ProductPassRate> data = new List<ProductPassRate>();
    private List<int> dataID = new List<int>();
    private List<float> dataPassRate = new List<float>();
    private List<string> dataName = new List<string>();
    private TimeType timeType;
    private Dictionary<BarBase, ProductPassRate> dataDic = new Dictionary<BarBase, ProductPassRate>();

    public override void Init(ManagerBase manager)
    {
        base.Init(manager);

        timeType = TimeType.Month;
        toggleGroup.GetComponentsInChildren<Toggle>()[(int)timeType].isOn = true;
        graph.animDuration = animDuration;
        graph.OnBarEnter += Graph_OnBarEnter;
        graph.OnBarExit += Graph_OnBarExit;
        graph.OnBarClick += Graph_OnBarClick;
    }

    private void Graph_OnBarClick(BarBase arg0)
    {
        Debug.Log(dataDic[arg0].productName + " : " + dataDic[arg0].passRate);
    }

    private void Graph_OnBarExit(BarBase arg0)
    {
        arg0.ExitAnim(animDuration);
    }

    private void Graph_OnBarEnter(BarBase arg0)
    {
        arg0.EnterAnim(animDuration);
    }

    public override void GetDataFromGetter(IDataIO dataIO)
    {
        if (data != null)
            data.Clear();
        if (dataPassRate != null)
            dataPassRate.Clear();
        if (dataName != null)
            dataName.Clear();
        if (dataID != null)
            dataID.Clear();
        dataDic.Clear();

        data = dataIO.GetData_ProductPassRateList((int)this.timeType);

        for (int i = 0; i < data.Count; i++)
        {
            var f = typeof(ProductPassRate).GetFields();
            for (int j = 0; j < f.Length; j++)
            {
                var b = f[j].GetValue(data[i]);
                switch (f[j].Name)
                {
                    case "ID":
                        dataID.Add((int)b);
                        break;
                    case "productName":
                        dataName.Add(b.ToString());
                        break;
                    case "passRate":
                        dataPassRate.Add((float)b);
                        break;
                }
            }
        }
    }

    public override void SetData()
    {
        graph.SetBars(dataPassRate, dataName);
        dataDic = graph.SetDic<ProductPassRate>(data);
    }

    public override void SetCustomData()
    {

    }

    /// <summary>
    /// 年月日转换
    /// </summary>
    /// <param name="timetype"></param>
    public void OnToggleClick(int timetype)
    {
        this.timeType = (TimeType)timetype;

        GetDataFromGetter(DataGetter.Instance.dataIO);

        SetData();

        SetCustomData();
    }
}
