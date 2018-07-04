using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

public class BarGraph : MonoBehaviour
{
    public Transform barParent;
    public Transform signParent;
    public float animDuration;
    public int signCount;

    public List<BarBase> bars = new List<BarBase>();
    public List<Sign> signs = new List<Sign>();

    public BarBase barPrefab;
    public Sign signPrefab;

    public event UnityAction<BarBase> OnBarClick;
    public event UnityAction<BarBase> OnBarEnter;
    public event UnityAction<BarBase> OnBarExit;

    private void SetBarEvent()
    {
        DelateAllEvent();
        for (int i = 0; i < bars.Count; i++)
        {
            bars[i].SetTriggers();
            bars[i].OnClickBar += OnBarClick;
            bars[i].OnPointerEnter += OnBarEnter;
            bars[i].OnPointerExit += OnBarExit;
        }
    }

    public void DelateAllEvent()
    {
        for (int i = 0; i < bars.Count; i++)
        {
            if (bars[i].TriggerCount > 0)
            {
                bars[i].DelateAllTrigger();
                bars[i].OnClickBar -= OnBarClick;
                bars[i].OnPointerEnter -= OnBarEnter;
                bars[i].OnPointerExit -= OnBarExit;
            }
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
                bars[i].ToValue(0, animDuration);
            }
            return;
        }

        for (int i = 0; i < bars.Count; i++)
        {
            bars[i].ToValue(values[i], animDuration);
        }
    }

    private void DeleteList<T>(List<T> list) where T : MonoBehaviour
    {
        if (list == null)
            return;

        for (int i = 0; i < list.Count; i++)
        {
            DestroyImmediate(list[i].gameObject);
        }
        list.Clear();
    }

    public void SetBars(List<float> values = null, List<string> titlelist = null)
    {
        List<float> vs = null;
        if (values != null)
        {
            float max = Mathf.Max(values.ToArray());
            int p = 0;
            while (max / 10 > 1)
            {
                p++;
                max = max / 10;
            }
            int f = (int)max + 1;
            float m = f * Mathf.Pow(10, p);
            vs = new List<float>();
            for (int i = 0; i < values.Count; i++)
            {
                vs.Add(values[i] / m);
            }
            SetXAxis(m);

            if (values.Count > 0 && values.Count != bars.Count)
            {
                DeleteList(bars);
                for (int i = 0; i < values.Count; i++)
                {
                    Instantiate(barPrefab, barParent);
                }
                GetBars();
            }
        }
        else if ((titlelist != null && titlelist.Count > 0 && titlelist.Count != bars.Count))
        {
            DeleteList(bars);
            for (int i = 0; i < titlelist.Count; i++)
            {
                Instantiate(barPrefab, barParent);
            }
            GetBars();
        }

        SetBarsValue(vs);
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
        }
        float g = max / (signCount - 1);
        for (int i = 0; i < signs.Count; i++)
        {
            signs[i].signText.text = (g * i).ToString();
        }
    }
}
