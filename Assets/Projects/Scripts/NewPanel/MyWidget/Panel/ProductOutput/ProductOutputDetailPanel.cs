using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ProductOutputDetailPanel : SecondLevelPanel
{
    //public List<MyTextNode> textNodes;

    public WMG_Axis_Graph costGraph;
    WMG_Series costS1;
    WMG_Series costS2;

    private ProductTotal productTotal;

    private List<ProductCostTotal> productCostList = new List<ProductCostTotal>();
    private List<string> costNameList = new List<string>();
    private List<int> costYearList = new List<int>();
    private List<string> costMonthList = new List<string>();
    private List<float> costFixedQualityList = new List<float>();
    private List<float> costNonFixedQualityList = new List<float>();

    public override void Control(MessageArg arg)
    {
        base.Control(arg);
        productCostList.Clear();
        costNameList.Clear();
        costYearList.Clear();
        costMonthList.Clear();
        costFixedQualityList.Clear();
        costNonFixedQualityList.Clear();

        ShowOnEffect();

        GetDataFromGetter(DataGetter.Instance.dataIO);
        SetData();
        SetCustomData();
    }

    public override void GetDataFromGetter(IDataIO dataIO)
    {
        GetTotal(dataIO);
        GetCost(dataIO);
    }

    public override void Init(ManagerBase manager)
    {
        base.Init(manager);
        Subscribe((int)MessageUIConst.OpenProductDetailPanel, (arg) =>
        {
            Control(arg);
        });

        costGraph.Init();
        costGraph.yAxis.LabelType = WMG_Axis.labelTypes.ticks;
        costGraph.yAxis.MaxAutoGrow = true;
        costGraph.yAxis.AxisNumTicks = 6;
        costGraph.yAxis.AxisMaxValue = 1;
        costGraph.tooltipDisplaySeriesName = true;
        costGraph.xAxis.AxisNumTicks = 12;

        costS1 = costGraph.addSeries();
        costS1.UseXDistBetweenToSpace = true;
        costS1.seriesName = "固定成本";
        costS2 = costGraph.addSeries();
        costS2.UseXDistBetweenToSpace = true;
        costS2.seriesName = "非固定成本";
        costS1.pointColor = Color.red;
        costS2.pointColor = Color.green;

        IsON = false;
        gameObject.SetActive(IsON);
    }

    public override void OffControl()
    {
        transform.DOScale(Vector3.zero, 0.1f);
        transform.DOLocalMove(closeBtn.localPosition, 0.1f).OnComplete(() =>
        {
            IsON = false;
            gameObject.SetActive(false);
            transform.localScale = Vector3.one;
            transform.localPosition = Vector3.zero;
        });
    }

    public override void SetCustomData()
    {

    }

    public override void SetData()
    {
        costGraph.Init();
        costS1 = costGraph.lineSeries[0].GetComponent<WMG_Series>();

        List<Vector2> list1 = new List<Vector2>();
        for (int i = 0; i < costFixedQualityList.Count; i++)
        {
            list1.Add(new Vector2(i + 1, costFixedQualityList[i]));
        }
        costS1.pointValues.SetList(list1);

        List<Vector2> list2 = new List<Vector2>();
        for (int i = 0; i < costNonFixedQualityList.Count; i++)
        {
            list2.Add(new Vector2(i + 1, costNonFixedQualityList[i]));
        }
        costS2.pointValues.SetList(list2);

        costGraph.xAxis.axisLabels.SetList(costMonthList);
    }

    public override void ShowOnEffect()
    {
        if (IsON)
        {
            return;
        }

        Vector2 vector;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(GetComponent<RectTransform>(), Input.mousePosition, Camera.main, out vector);
        transform.localPosition = vector;
        transform.localScale = Vector3.zero;
        gameObject.SetActive(true);

        transform.DOScale(Vector3.one, 0.3f);
        transform.DOLocalMove(Vector3.zero, 0.3f);

        IsON = true;
    }

    private void GetTotal(IDataIO dataIO)
    {
        productTotal = dataIO.GetData_ProductTotal(this.ID);

        var field = typeof(ProductTotal).GetFields();
        for (int i = 0; i < field.Length; i++)
        {
            if (field[i].Name == "productName")
            {
                string s = field[i].GetValue(productTotal).ToString();
                //textNodes[i].title.text = s + "生产统计分析";
            }
            else
            {
                int b = (int)field[i].GetValue(productTotal);
                //textNodes[i].data.DOText(b.ToString(), 0.6f, true, ScrambleMode.Numerals, "");
            }
        }
    }

    private void GetCost(IDataIO dataIO)
    {
        productCostList = dataIO.GetData_ProductCostTotal(this.ID);

        for (int i = 0; i < productCostList.Count; i++)
        {
            ProductCostTotal cost = productCostList[i];

            var field = typeof(ProductCostTotal).GetFields();
            for (int j = 0; j < field.Length; j++)
            {
                switch (field[j].Name)
                {
                    case "productName":
                        costNameList.Add(field[j].GetValue(cost).ToString());
                        break;
                    case "year":
                        costYearList.Add((int)field[j].GetValue(cost));
                        break;
                    case "month":
                        costMonthList.Add(field[j].GetValue(cost).ToString() + "月");
                        break;
                    case "fixedQuality":
                        costFixedQualityList.Add((float)field[j].GetValue(cost));
                        break;
                    case "nonFixedQuality":
                        costNonFixedQualityList.Add((float)field[j].GetValue(cost));
                        break;
                    default:
                        break;
                }
            }
        }
    }

}
