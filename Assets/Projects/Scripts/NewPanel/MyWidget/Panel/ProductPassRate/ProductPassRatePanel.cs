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

    public override void Init(ManagerBase manager)
    {
        base.Init(manager);

        timeType = TimeType.Month;
        toggleGroup.GetComponentsInChildren<Toggle>()[(int)timeType].isOn = true;
    }

    public override void GetDataFromGetter(IDataIO dataIO)
    {

    }

    public override void SetData()
    {

    }

    public override void SetCustomData()
    {

    }
}
