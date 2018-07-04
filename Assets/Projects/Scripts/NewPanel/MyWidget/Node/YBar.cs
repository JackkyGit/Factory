using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class YBar : MonoBehaviour
{
    public float BarValue { get { return barSlider.value; } set { barSlider.value = value; } }
    public EventTrigger GetEventTrigger { get { return barFill.GetComponent<EventTrigger>(); } }

    public event UnityAction OnClickBar;
    public event UnityAction OnPointerEnter;
    public event UnityAction OnPointerExit;

    public Image barBg;
    public Image barFill;
    public Slider barSlider;

    private void Start()
    {
        SetTriggers();
    }

    private void SetTriggers()
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

    private void MyExit(BaseEventData data)
    {
        if (OnPointerExit != null)
        {
            OnPointerExit();
        }
    }

    private void MyEnter(BaseEventData data)
    {
        if (OnPointerEnter != null)
        {
            OnPointerEnter();
        }
    }

    private void MyClick(BaseEventData data)
    {
        if (OnClickBar != null)
        {
            OnClickBar();
        }
    }
}
