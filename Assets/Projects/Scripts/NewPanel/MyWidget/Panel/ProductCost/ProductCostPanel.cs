using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProductCostPanel : FirstLevelPanel
{
    public BarGraph graph;
    public float animDuration;
    public ToggleGroup toggleGroup;

    private List<ProductCost> data = new List<ProductCost>();
    private List<int> dataID = new List<int>();
    private List<float> dataCost = new List<float>();
    private List<string> dataName = new List<string>();
    private TimeType timeType;
    private Dictionary<BarBase, ProductCost> dataDic = new Dictionary<BarBase, ProductCost>();

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
        Debug.Log(dataDic[arg0].ProjectName + " : " + dataDic[arg0].cost);
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
        data = dataIO.GetData_ProductCost((int)this.timeType);
    }

    public override void SetData()
    {

    }
}
