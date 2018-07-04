using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testSceneScript : MonoBehaviour
{
    public WMG_Pie_Graph axis_Graph1;

    // Use this for initialization
    void Start()
    {
        Debug.Log(axis_Graph1.legend.legendEntries.Count);
        //axis_Graph1.legend.changeLabelColor(axis_Graph1.legend.legendEntries[2].label, Color.cyan);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log(axis_Graph1.legend.legendEntries.Count);
        }
    }
}
