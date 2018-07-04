using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondLevelPanel : PanelBase, IControl
{
    public int ID { get; set; }
    public int ID2 { get; set; }
    public int TimeType { get; set; }
    public bool IsON { get; set; }
    public RectTransform closeBtn;

    public virtual void Control(MessageArg arg)
    {
        this.ID = arg.id;
        this.ID2 = arg.id2;
        this.TimeType = arg.timeType;
    }

    public virtual void OffControl()
    {

    }
}
