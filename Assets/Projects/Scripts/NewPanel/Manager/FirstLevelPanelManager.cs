using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstLevelPanelManager : ManagerBase
{
    public override void Init()
    {
        ID = ManagerID.FirstLevelPanel;
        base.Init();
    }

    private void Start()
    {
        Init();
        GetComponentsInChildren(Panels);

        for (int i = 0; i < Panels.Count; i++)
        {
            Panels[i].Init(this);

            Panels[i].GetDataFromGetter(Getter.dataIO);

            Panels[i].SetData();

            Panels[i].SetCustomData();
        }
    }

    //private void Update()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        for (int i = 0; i < Panels.Count; i++)
    //        {
    //            Panels[i].GetDataFromGetter(Getter.dataIO);

    //            Panels[i].SetData();

    //            Panels[i].SetCustomData();
    //        }
    //    }
    //}
}
