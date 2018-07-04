using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerBase : MonoBehaviour
{
    public ManagerID ID;
    public DataGetter Getter { get { return DataGetter.Instance; } }
    public List<PanelBase> Panels { get; set; }

    public Dictionary<int, Action<MessageArg>> handlers = new Dictionary<int, Action<MessageArg>>();
    public MessageArg Arg { get; set; }

    private void OnEnable()
    {
        Panels = new List<PanelBase>();
    }

    private void OnDisable()
    {
        Panels.Clear();
    }

    public virtual void Init()
    {
        SubscribeToCenter((int)this.ID, this);
    }

    public virtual void SubscribeToCenter(int id, ManagerBase manager)
    {
        MessageCenter.Instance.SubscribeToMe(id, manager);
    }

    public virtual void SendMsg(int msgid, ManagerID managerID, MessageArg arg)
    {
        MessageCenter.Instance.SendMsg(msgid, managerID, arg);
    }
}
