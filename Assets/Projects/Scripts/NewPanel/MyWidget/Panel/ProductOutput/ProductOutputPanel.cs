using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class ProductOutputPanel : FirstLevelPanel
{
    public BarGraph graph;

    private List<ProductOutput> data = new List<ProductOutput>();
    private List<int> dataID = new List<int>();
    private List<float> dataQuality = new List<float>();
    private List<string> dataName = new List<string>();
    private TimeType timeType;

    public override void Init(ManagerBase manager)
    {
        base.Init(manager);

        timeType = TimeType.Month;
        graph.SetXAxis();
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

        graph.SetBars(null, dataName);
    }
}
