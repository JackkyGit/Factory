using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class DataGetter
{
    private static DataGetter m_instance;
    public static DataGetter Instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = new DataGetter();
            }
            return m_instance;
        }
    }

    public IDataIO dataIO
    {
        get
        {
            return new DemoData();
            //return new RealData();
        }
    }
}
