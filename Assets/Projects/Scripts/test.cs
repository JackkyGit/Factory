
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public YBar yaxisPrefab;
    public Transform ybarParent;

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            YBar ybar = Instantiate(yaxisPrefab, ybarParent);
            ybar.BarValue = Random.Range(0.5f, 1);
            ybar.OnClickBar += Ybar_OnClickBar;
            ybar.OnPointerEnter += Ybar_OnPointerEnter;
            ybar.OnPointerExit += Ybar_OnPointerExit;
        }
    }

    private void Ybar_OnPointerExit()
    {
        Debug.Log("exit");
    }

    private void Ybar_OnPointerEnter()
    {
        Debug.Log("456");
    }

    private void Ybar_OnClickBar()
    {
        Debug.Log("dianji");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
