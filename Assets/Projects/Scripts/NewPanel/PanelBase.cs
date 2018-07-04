using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelBase : MonoBehaviour, IPanel
{
    public ManagerBase Manager { get; set; }

    public virtual void GetDataFromGetter(IDataIO dataIO)
    {

    }

    public virtual void Init(ManagerBase manager)
    {
        this.Manager = manager;
    }

    public virtual void SendMsg(int msgid, ManagerID managerID, MessageArg arg)
    {
        Manager.SendMsg(msgid, managerID, arg);
    }

    public virtual void SetCustomData()
    {

    }

    public virtual void SetData()
    {

    }

    public virtual void ShowOnEffect()
    {
        
    }

    public virtual void Subscribe(int id, Action<MessageArg> handle)
    {
        if (!Manager.handlers.ContainsKey(id))
        {
            Manager.handlers.Add(id, new Action<MessageArg>(arg => { }));
        }
        Manager.handlers[id] += handle;
    }
}
