using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageCenter
{
    private static MessageCenter m_Instance;
    public static MessageCenter Instance
    {
        get
        {
            if (m_Instance == null)
            {
                m_Instance = new MessageCenter();
            }
            return m_Instance;
        }
    }

    public Dictionary<int, ManagerBase> managers = new Dictionary<int, ManagerBase>();

    public void SubscribeToMe(int id, ManagerBase manager)
    {
        if (!managers.ContainsKey(id))
        {
            managers.Add(id, manager);
        }
    }

    public void UnSubscribeToMe(int id)
    {
        if (managers.ContainsKey(id))
        {
            managers.Remove(id);
        }
    }

    public void SendMsg(int msgid, ManagerID managerID, MessageArg arg)
    {
        if (managers.ContainsKey((int)managerID))
        {
            
            managers[(int)managerID].handlers[msgid].Invoke(arg);
        }
    }
}
