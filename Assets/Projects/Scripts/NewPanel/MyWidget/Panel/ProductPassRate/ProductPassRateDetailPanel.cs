using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductPassRateDetailPanel : SecondLevelPanel
{
    public WMG_Axis_Graph graph;

    public override void Init(ManagerBase manager)
    {
        base.Init(manager);

        Subscribe((int)MessageUIConst.OpenPassRateDetailPanel, (arg) =>
        {
            Control(arg);
        });

        IsON = false;
        gameObject.SetActive(IsON);

        graph.Init();
        graph.yAxis2.AxisLine.SetActive(false);
    }

    public override void Control(MessageArg arg)
    {
        base.Control(arg);

        GetDataFromGetter(DataGetter.Instance.dataIO);
        SetData();
        SetCustomData();

        ShowOnEffect();
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
