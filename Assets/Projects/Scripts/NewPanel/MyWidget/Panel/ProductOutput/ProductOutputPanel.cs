using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProductOutputPanel : FirstLevelPanel
{
    public BarGraph graph;
    public float animDuration;
    public ToggleGroup toggleGroup;

    private List<ProductOutput> data = new List<ProductOutput>();
    private List<int> dataID = new List<int>();
    private List<float> dataQuality = new List<float>();
    private List<string> dataName = new List<string>();
    private TimeType timeType;

    public override void Init(ManagerBase manager)
    {
        base.Init(manager);

        timeType = TimeType.Month;
        toggleGroup.GetComponentsInChildren<Toggle>()[(int)timeType].isOn = true;
        graph.animDuration = animDuration;
        graph.SetXAxis();
        graph.OnBarEnter += Graph_OnBarEnter;
        graph.OnBarExit += Graph_OnBarExit;
        graph.OnBarClick += Graph_OnBarClick;
    }

    private void Graph_OnBarClick(BarBase arg0)
    {
        Debug.Log(arg0.titleText.text);
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
        if (dataQuality != null)
            dataQuality.Clear();
        if (dataName != null)
            dataName.Clear();
        if (dataID != null)
            dataID.Clear();

        data = dataIO.GetData_ProductOutputList((int)this.timeType);

        for (int i = 0; i < data.Count; i++)
        {
            var f = typeof(ProductOutput).GetFields();
            for (int j = 0; j < f.Length; j++)
            {
                switch (f[j].Name)
                {
                    case "ID":
                        dataID.Add((int)f[j].GetValue(data[i]));
                        break;
                    case "productName":
                        dataName.Add((string)f[j].GetValue(data[i]));
                        break;
                    case "quality":
                        dataQuality.Add((int)f[j].GetValue(data[i]));
                        break;
                }
            }
        }
    }

    public override void SetData()
    {
        graph.SetBars(dataQuality, dataName);
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
