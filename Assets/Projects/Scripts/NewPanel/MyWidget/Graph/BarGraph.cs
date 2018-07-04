using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

public class BarGraph : MonoBehaviour
{
    public Transform barParent;
    public Transform signParent;
    public int signCount;

    public List<BarBase> bars = new List<BarBase>();
    public List<Sign> signs = new List<Sign>();

    public BarBase barPrefab;
    public Sign signPrefab;

    public event UnityAction OnBarClick;
    public event UnityAction OnBarEnter;
    public event UnityAction OnBarExit;

    private void SetBarEvent()
    {
        for (int i = 0; i < bars.Count; i++)
        {
            bars[i].OnClickBar += OnBarClick;
            bars[i].OnPointerEnter += OnBarEnter;
            bars[i].OnPointerExit += OnBarExit;
        }
    }

    public void GetBars()
    {
        bars.Clear();
        barParent.GetComponentsInChildren<BarBase>(bars);
    }

    private void SetBarsTitle(List<string> titlelist)
    {
        if (titlelist == null)
            return;

        for (int i = 0; i < titlelist.Count; i++)
        {
            bars[i].titleText.text = titlelist[i];
        }
    }

    private void SetBarsValue(List<float> values)
    {
        if (values == null)
        {
            for (int i = 0; i < bars.Count; i++)
            {
                bars[i].ToValue(0, 0.1f);
            }
            return;
        }

        for (int i = 0; i < bars.Count; i++)
        {
            bars[i].ToValue(values[i], 0.1f);
        }
    }

    private void DeleteList<T>(List<T> list) where T : MonoBehaviour
    {
        if (list == null)
            return;

        for (int i = 0; i < list.Count; i++)
        {
            Destroy(list[i].gameObject);
        }
        list.Clear();
    }

    public void SetBars(List<float> values = null, List<string> titlelist = null)
    {
        if (values != null && values.Count > 0 && values.Count != bars.Count)
        {
            float max = Mathf.Max(values.ToArray());
            int p = 0;
            while (max / 10 > 1)
            {
                p++;
                max = max / 10;
                Debug.Log(max);
            }
            int f = (int)max + 1;
            float m = f * Mathf.Pow(10, p);
            SetXAxis(m);

            DeleteList(bars);
            for (int i = 0; i < values.Count; i++)
            {
                Instantiate(barPrefab, barParent);
            }
            GetBars();
        }
        if ((titlelist != null && titlelist.Count > 0 && titlelist.Count != bars.Count))
        {
            DeleteList(bars);
            for (int i = 0; i < titlelist.Count; i++)
            {
                Instantiate(barPrefab, barParent);
            }
            GetBars();
        }

        SetBarsValue(values);
        SetBarsTitle(titlelist);
        SetBarEvent();
    }

    public void SetXAxis(float max = 0)
    {
        if (signCount > 1 && signCount != signs.Count)
        {
            DeleteList(signs);
            for (int i = 0; i < signCount; i++)
            {
                signs.Add(Instantiate(signPrefab, signParent));
            }
            float g = max / (signCount - 1);
            for (int i = 0; i < signs.Count; i++)
            {
                signs[i].signText.text = (g * i).ToString();
            }
        }
    }
}
