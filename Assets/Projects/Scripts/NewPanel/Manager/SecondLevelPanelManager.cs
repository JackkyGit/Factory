using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondLevelPanelManager : ManagerBase
{
    public override void Init()
    {
        ID = ManagerID.SecondLevelPanel;
        base.Init();
    }

    private void Start()
    {
        Init();
        GetComponentsInChildren(Panels);

        for (int i = 0; i < Panels.Count; i++)
        {
            Panels[i].Init(this);
        }
    }
}
