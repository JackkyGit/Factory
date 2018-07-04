using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BarBase : MonoBehaviour
{
    public float BarValue { get { return barSlider.value; } set { barSlider.value = value; } }
    public EventTrigger GetEventTrigger { get { return barFill.GetComponent<EventTrigger>(); } }
    public int TriggerCount { get { return GetEventTrigger.triggers.Count; } }

    public event UnityAction<BarBase> OnClickBar;
    public event UnityAction<BarBase> OnPointerEnter;
    public event UnityAction<BarBase> OnPointerExit;

    public Image barBg;
    public Image barFill;
    public Slider barSlider;
    public Text titleText;

    public void SetTriggers()
    {
        UnityAction<BaseEventData> click = new UnityAction<BaseEventData>(MyClick);
        UnityAction<BaseEventData> enter = new UnityAction<BaseEventData>(MyEnter);
        UnityAction<BaseEventData> exit = new UnityAction<BaseEventData>(MyExit);

        EventTrigger.Entry myclick = new EventTrigger.Entry();
        EventTrigger.Entry myenter = new EventTrigger.Entry();
        EventTrigger.Entry myexit = new EventTrigger.Entry();

        myclick.eventID = EventTriggerType.PointerClick;
        myclick.callback.AddListener(click);
        myenter.eventID = EventTriggerType.PointerEnter;
        myenter.callback.AddListener(enter);
        myexit.eventID = EventTriggerType.PointerExit;
        myexit.callback.AddListener(exit);

        GetEventTrigger.triggers.Add(myclick);
        GetEventTrigger.triggers.Add(myenter);
        GetEventTrigger.triggers.Add(myexit);
    }

    public void DelateAllTrigger()
    {
        GetEventTrigger.triggers.Clear();
    }

    private void MyExit(BaseEventData data)
    {
        if (OnPointerExit != null)
        {
            OnPointerExit(this);
        }
    }

    private void MyEnter(BaseEventData data)
    {
        if (OnPointerEnter != null)
        {
            OnPointerEnter(this);
        }
    }

    private void MyClick(BaseEventData data)
    {
        if (OnClickBar != null)
        {
            OnClickBar(this);
        }
    }

    public void ToValue(float endvalue, float duration)
    {
        DOTween.To(() => BarValue, x => BarValue = x, endvalue, duration);
    }

    public void EnterAnim(float duration)
    {
        barFill.transform.DOScale(1.2f, duration).SetEase(Ease.OutElastic);
    }

    public void ExitAnim(float duration)
    {
        barFill.transform.DOScale(1, duration).SetEase(Ease.OutElastic);
    }
}
